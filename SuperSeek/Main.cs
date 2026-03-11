using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace SuperSeek
{
    public partial class Main : Form
    {
        private Dictionary<string, List<string>> ExtensionsAndFiles = new();
        private List<string> SelectedFiles = new();
        private List<(string, int)> Results = new();
        private uint Scanned = 0;
        private string CurrentFolder = "C:\\";
        private Dictionary<Component, string> LabelCache = new();
        private CancellationTokenSource CTS = new();
        private System.Windows.Forms.Timer LabelTimer = new();
        private bool _Running = false;
        private bool Running
        {
            get
            {
                return _Running;
            }
            set
            {
                _Running = value;
                if (_Running)
                {
                    Cursor = Cursors.AppStarting;
                    btnSearchOrCancel.Text = "Cancel";
                    SetLabel(tsslStatus, "Working...");
                    msMain.Enabled =
                    tsMain.Enabled =
                    lvResults.Enabled =
                    tbMainSearch.Enabled =
                    scMain.Panel1.Enabled =
                    false;
                }
                else
                {
                    Cursor = Cursors.Default;
                    btnSearchOrCancel.Text = "Search";
                    SetLabel(tsslStatus, "Idle.");
                    msMain.Enabled =
                    tsMain.Enabled =
                    lvResults.Enabled =
                    tbMainSearch.Enabled =
                    scMain.Panel1.Enabled =
                    true;
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
            SetLabel(tsslResults, Results.Count.ToString());
            SetLabel(tsslScanned, Scanned.ToString());
            SetLabel(tsslSelectedFiles, SelectedFiles.Count.ToString());
            if (Running)
            {
                if (Scanned > 0)
                {
                    tspbMain.Style = ProgressBarStyle.Continuous;
                    tspbMain.Maximum = SelectedFiles.Count;
                    tspbMain.Value = (int)Scanned;
                }
                else
                {
                    tspbMain.Style = ProgressBarStyle.Marquee;
                }
            }
            else
            {
                tspbMain.Style = ProgressBarStyle.Continuous;
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
            foreach (var item in Strings)
            {
                textProperty.SetValue(Label, originalText.Replace($"{{{i}}}", item));
            }
        }

        private void ClearExtensions()
        {
            lvExtensions.Items.Clear();
            SelectedFiles.Clear();
            ExtensionsAndFiles.Clear();
            ClearResults();
        }

        private void ClearResults()
        {
            lvResults.Items.Clear();
            Results.Clear();
            Scanned = 0;
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
            RefreshFolder();
        }

        private async void RefreshFolder(object? sender = null, EventArgs? e = null)
        {
            Running = true;
            SetLabel(tsslStatus, "Clearing...");
            ClearExtensions();
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
                ListViewItem lvi = new([item.Key, item.Value.Count.ToString()]);
                //lvi.Checked = tsbAllExtensions.Checked;
                lvExtensions.Items.Add(lvi);
            }
            lvExtensions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvExtensions.EndUpdate();
            Running = false;
        }

        private async void miExit_Click(object sender, EventArgs e)
        {
            await Cancel(true);
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

        private async Task Cancel(bool Close = false)
        {
            SetLabel(tsslStatus, "Cancelling...");
            await CTS.CancelAsync();
            if (Close)
            {
                Running = false;
                this.Close();
                return;
            }
            CTS = new();
        }

        private async void SearchOrCancel(object sender, EventArgs e)
        {
            if (Running)
            {
                await Cancel();
            }
            else
            {
                Running = true;
                lvResults.BeginUpdate();
                ClearResults();
                Regex regex = new(tbMainSearch.Text, RegexOptions.IgnoreCase);
                await ScanFilesAsync(SelectedFiles, regex);
                foreach (var match in Results)
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
            List<Task> Tasks = new();
            foreach (var file in Files)
            {
                if (CTS.IsCancellationRequested) break;
                Tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        if (CTS.IsCancellationRequested) return;
                        if (Regex.ToString() == String.Empty)
                        {
                            Results.Add((file, 0));
                            return;
                        }
                        if (CTS.IsCancellationRequested) return;
                        var content = await File.ReadAllTextAsync(file, CTS.Token);
                        if (CTS.IsCancellationRequested) return;
                        var rmatches = Regex.Count(file);
                        rmatches += Regex.Count(content);
                        if (rmatches > 0) Results.Add((file, rmatches));
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

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Running)
            {
                e.Cancel = true;
                _ = Cancel(true);
            }
        }

        private void tbMainSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchOrCancel.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void lvResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvResults.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvResults.SelectedItems)
                {
                    OpenFile(item.Text);
                }
            }
        }

        private void OpenFile(string File)
        {
            ProcessStartInfo info = new()
            {
                UseShellExecute = true,
                FileName = "explorer.exe",
                Arguments = File
            };
            Process.Start(info);
        }

        private void tsbAllExts_CheckedChanged(object sender, EventArgs e)
        {
            /*
            lvExtensions.BeginUpdate();
            foreach (ListViewItem item in lvExtensions.Items)
            {
                item.Checked = tsbAllExtensions.Checked;
            }
            lvExtensions.EndUpdate();
            */
        }
    }
}