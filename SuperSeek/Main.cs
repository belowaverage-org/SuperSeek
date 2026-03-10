using System.ComponentModel;
using System.Text.RegularExpressions;

namespace SuperSeek
{
    public partial class Main : Form
    {
        private Dictionary<string, List<string>> ExtensionsAndFiles = new();
        private List<string> SelectedFiles = new();
        private List<(string, int)> Matches = new();
        private uint Scanned = 0;
        private string CurrentFolder = "C:\\";
        private Dictionary<Component, string> LabelCache = new();
        private CancellationTokenSource CTS = new();
        private System.Windows.Forms.Timer LabelTimer = new();
        private bool _Running = false;
        private bool Running {
            get
            {
                return _Running;
            }
            set 
            {
                _Running = value;
                if (_Running)
                {
                    Cursor = Cursors.WaitCursor;
                    btnSearchOrCancel.Text = "Cancel";
                }
                else
                {
                    Cursor = Cursors.Default;
                    btnSearchOrCancel.Text = "Search";
                    SetLabel(tsslStatus, "Idle.");
                }
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive, true, true);
            }
        }
        private EnumerationOptions EnumerationOptions = new()
        {
            RecurseSubdirectories = false,
            IgnoreInaccessible = true
        };

        public Main()
        {
            InitializeComponent();
            LabelTimer.Interval = 100;
            LabelTimer.Tick += LabelTimer_Tick;
            LabelTimer.Enabled = true;
        }

        private async void LabelTimer_Tick(object? sender, EventArgs e)
        {
            SetLabel(tsslResults, Matches.Count.ToString());
            SetLabel(tsslScanned, Scanned.ToString());
            if (Running)
            {
                tspbMain.Maximum = SelectedFiles.Count;
                tspbMain.Value = (int)Scanned;
            }
        }

        private void Initialize(object sender, EventArgs e)
        {
            LabelTimer.Start();
            miToggleExtensions.Checked = !scMain.Panel1Collapsed;
            Task.Run(() =>
            {
                Invoke(miOpenFolder.PerformClick);
            });
        }

        private void SetLabel(Component Label, params string[] Strings)
        {
            var textProperty = Label.GetType().GetProperties().First((pi) => { return pi.Name == "Text"; });
            if (textProperty == null) return;
            if (!LabelCache.ContainsKey(Label))
            {
                LabelCache.Add(Label, (string)textProperty.GetValue(Label)!);
            }
            var originalText = LabelCache[Label];
            uint i = 0;
            foreach(var item in Strings)
            {
                textProperty.SetValue(Label, originalText.Replace($"{{{i}}}", item));
            }
        }

        private async void OpenFolder(object sender, EventArgs e)
        {
            SetLabel(tsslStatus, "Waiting for folder dialog...");
            fbMain.ShowDialog();
            if (!Directory.Exists(fbMain.SelectedPath))
            {
                Running = false;
                return;
            }
            CurrentFolder = fbMain.SelectedPath;
            SetLabel(tsslCurrentFolder, CurrentFolder);
            SetLabel(tsslStatus, "Clearing...");
            Running = true;
            ExtensionsAndFiles.Clear();
            lvExtensions.Items.Clear();
            SemaphoreSlim ss = new(1);
            SetLabel(tsslStatus, "Gathering files...");
            await DiscoverFilesAsync(new DirectoryInfo(CurrentFolder), async (file) =>
            {
                try
                {
                    var ext = file.Extension.ToLower();
                    await ss.WaitAsync(CTS.Token);
                    var added = ExtensionsAndFiles.TryAdd(ext, new List<string>());
                    ExtensionsAndFiles[ext].Add(file.FullName);
                }
                catch
                {
                    //Cancelled
                }
                ss.Release();
            });
            SetLabel(tsslStatus, "Rendering extension list...");
            lvExtensions.BeginUpdate();
            foreach (var item in ExtensionsAndFiles)
            {
                lvExtensions.Items.Add(new ListViewItem([item.Key, item.Value.Count.ToString()]));
            }
            lvExtensions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvExtensions.EndUpdate();
            Running = false;
        }

        private void Exit(object sender, EventArgs e)
        {
            Close();
        }

        private void ToggleExtensionList(object sender, EventArgs e)
        {
            scMain.Panel1Collapsed = !scMain.Panel1Collapsed;
            miToggleExtensions.Checked = !scMain.Panel1Collapsed;
        }

        private async Task DiscoverFilesAsync(DirectoryInfo DirectoryInfo, Func<FileInfo, Task>? Action = null)
        {
            if (CTS.IsCancellationRequested) return;
            await Task.Run(async () =>
            {
                List<Task> Tasks = new();
                var dirs = DirectoryInfo.GetDirectories("*", EnumerationOptions);
                foreach (DirectoryInfo dir in dirs)
                {
                    if (CTS.IsCancellationRequested) break;
                    Tasks.Add(DiscoverFilesAsync(dir, Action));
                }
                var files = DirectoryInfo.GetFiles("*", EnumerationOptions);
                foreach (FileInfo file in files)
                {
                    if (CTS.IsCancellationRequested) break;
                    if (Action != null) Tasks.Add(Action(file));
                }
                await Task.WhenAll(Tasks);
            });
        }

        private void lvExtensions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (Running) return;
            SelectedFiles.Clear();
            foreach (ListViewItem lvi in lvExtensions.CheckedItems)
            {
                SelectedFiles.AddRange(ExtensionsAndFiles[lvi.Text]);
            }
            SetLabel(tsslSelectedFiles, SelectedFiles.Count.ToString());
        }

        private void FilterExtensions(object sender, EventArgs e)
        {
            lvExtensions.SelectedItems.Clear();
            var item = lvExtensions.FindItemWithText('.' + tbExtensionSearch.Text);
            item?.Selected = true;
            item?.EnsureVisible();
        }

        private void tbExtensionSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                var item = lvExtensions.FindItemWithText('.' + tbExtensionSearch.Text);
                item?.Checked = !item.Checked;
            }
        }

        private async void Cancel()
        {
            SetLabel(tsslStatus, "Cancelling...");
            await CTS.CancelAsync();
            CTS = new();
        }

        private async void SearchOrCancel(object sender, EventArgs e)
        {
            if (Running)
            {
                Cancel();
            }
            else
            {
                Running = true;
                lvResults.BeginUpdate();
                lvResults.Items.Clear();
                Regex regex = new(tbMainSearch.Text, RegexOptions.IgnoreCase);
                await ScanFilesAsync(SelectedFiles, regex);
                foreach (var match in Matches)
                {
                    lvResults.Items.Add(new ListViewItem([match.Item1, match.Item2.ToString()]));
                }
                lvResults.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvResults.EndUpdate();
                
                Running = false;
            }
        }

        private async Task ScanFilesAsync(List<string> Files, Regex Regex)
        {
            Scanned = 0;
            Matches.Clear();
            List<Task> Tasks = new();
            foreach (var file in Files)
            {
                if (CTS.IsCancellationRequested) break;
                Tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        if (CTS.IsCancellationRequested) return;
                        var content = await File.ReadAllTextAsync(file, CTS.Token);
                        if (CTS.IsCancellationRequested) return;
                        var rmatches = Regex.Count(content);
                        if (rmatches > 0) Matches.Add((file, rmatches));
                        Scanned++;
                    }
                    catch
                    {
                        //Handle file errors...
                    }
                }));
            }
            await Task.WhenAll(Tasks);
        }
    }
}