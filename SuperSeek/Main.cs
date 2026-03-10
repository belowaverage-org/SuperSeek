using System.Text.RegularExpressions;

namespace SuperSeek
{
    public partial class Main : Form
    {
        private Dictionary<string, List<string>> ExtensionsAndFiles = new();
        private List<string> SelectedFiles = new();
        private string CurrentFolder = "C:\\";
        private EnumerationOptions EnumerationOptions = new()
        {
            RecurseSubdirectories = false,
            IgnoreInaccessible = true
        };

        public Main()
        {
            InitializeComponent();
        }

        private async void OpenFolder(object sender, EventArgs e)
        {
            tsslStatus.Text = "Status: Waiting for user...";
            fbMain.ShowDialog();
            if (!Directory.Exists(fbMain.SelectedPath))
            {
                tsslStatus.Text = "Status: Idle";
                return;
            }
            CurrentFolder = fbMain.SelectedPath;
            tsslCurrentFolder.Text = "Current Folder: " + CurrentFolder;
            tsslStatus.Text = "Status: Clearing...";
            Enabled = false;
            ExtensionsAndFiles.Clear();
            lvExtensions.Items.Clear();
            SemaphoreSlim ss = new(1);
            tsslStatus.Text = "Status: Gathering files...";
            await LoopFilesAsync(new DirectoryInfo(CurrentFolder), async (file) =>
            {
                var ext = file.Extension.ToLower();
                await ss.WaitAsync();
                var added = ExtensionsAndFiles.TryAdd(ext, new List<string>());
                ExtensionsAndFiles[ext].Add(file.FullName);
                ss.Release();
            });
            tsslStatus.Text = "Status: Rendering extension list...";
            lvExtensions.BeginUpdate();
            foreach (var item in ExtensionsAndFiles)
            {
                ListViewItem lvi = new([item.Key, item.Value.Count.ToString()]);
                lvExtensions.Items.Add(lvi);
            }
            lvExtensions.EndUpdate();
            tsslStatus.Text = "Status: GC Collect...";
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive, true, true);
            tsslStatus.Text = "Status: Idle";
            Enabled = true;
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

        private void Initialize(object sender, EventArgs e)
        {
            miToggleExtensions.Checked = !scMain.Panel1Collapsed;
            tsslCurrentFolder.Text = "Current Folder: " + CurrentFolder;
            Task.Run(() =>
            {
                Invoke(miOpenFolder.PerformClick);
            });
        }

        private async Task LoopFilesAsync(DirectoryInfo DirectoryInfo, Func<FileInfo, Task>? Action = null)
        {
            await Task.Run(async () =>
            {
                List<Task> Tasks = new();
                var dirs = DirectoryInfo.GetDirectories("*", EnumerationOptions);
                foreach (DirectoryInfo dir in dirs)
                {
                    Tasks.Add(LoopFilesAsync(dir, Action));
                }
                var files = DirectoryInfo.GetFiles("*", EnumerationOptions);
                foreach (FileInfo file in files)
                {
                    if (Action != null) Tasks.Add(Action(file));
                }
                await Task.WhenAll(Tasks);
            });
        }

        private void lvExtensions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!Enabled) return;
            SelectedFiles.Clear();
            foreach (ListViewItem lvi in lvExtensions.CheckedItems)
            {
                SelectedFiles.AddRange(ExtensionsAndFiles[lvi.Text]);
            }
            tsslSelectedFiles.Text = "Selected Files: " + SelectedFiles.Count;
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

        private async void Search(object sender, EventArgs e)
        {
            Enabled = false;
            lvResults.BeginUpdate();
            lvResults.Items.Clear();
            Regex regex = new(tbMainSearch.Text, RegexOptions.IgnoreCase);
            var matches = await SearchFilesAsync(SelectedFiles, regex);
            foreach (var match in matches)
            {
                foreach (Match rmatch in match.Value)
                {
                    lvResults.Items.Add(new ListViewItem([match.Key, rmatch.Value]));
                }
            }
            lvResults.EndUpdate();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive, true, true);
            Enabled = true;
        }

        private async Task<Dictionary<string, MatchCollection>> SearchFilesAsync(List<string> Files, Regex Regex)
        {
            List<Task> Tasks = new();
            SemaphoreSlim ss = new(1);
            Dictionary<string, MatchCollection> Matches = new();
            foreach (var file in Files)
            {
                Tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        var content = await File.ReadAllTextAsync(file);
                        var rmatches = Regex.Matches(content);
                        if (rmatches != null && rmatches.Count != 0) Matches.Add(file, rmatches);
                    }
                    catch
                    {
                        //Handle file errors...
                    }
                }));
            }
            await Task.WhenAll(Tasks);
            return Matches;
        }
    }
}
