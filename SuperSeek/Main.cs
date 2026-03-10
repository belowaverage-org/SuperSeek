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

        private async void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Status: Waiting for user...";
            folderBrowserDialog1.ShowDialog();
            CurrentFolder = folderBrowserDialog1.SelectedPath;
            toolStripStatusLabel1.Text = "Current Folder: " + CurrentFolder;
            toolStripStatusLabel2.Text = "Status: Clearing...";
            Enabled = false;
            ExtensionsAndFiles.Clear();
            listView2.Items.Clear();
            SemaphoreSlim ss = new(1);
            toolStripStatusLabel2.Text = "Status: Gathering files...";
            await LoopFilesAsync(new DirectoryInfo(CurrentFolder), async (file) =>
            {
                var ext = file.Extension.ToLower();
                await ss.WaitAsync();
                var added = ExtensionsAndFiles.TryAdd(ext, new List<string>());
                ExtensionsAndFiles[ext].Add(file.FullName);
                ss.Release();
            });
            toolStripStatusLabel2.Text = "Status: Rendering extension list...";
            listView2.BeginUpdate();
            foreach (var item in ExtensionsAndFiles)
            {
                ListViewItem lvi = new([item.Key, item.Value.Count.ToString()]);
                listView2.Items.Add(lvi);
            }
            listView2.EndUpdate();
            toolStripStatusLabel2.Text = "Status: Idle";
            Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fileExtensionFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
            fileExtensionFilterToolStripMenuItem.Checked = !splitContainer1.Panel1Collapsed;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            fileExtensionFilterToolStripMenuItem.Checked = !splitContainer1.Panel1Collapsed;
            toolStripStatusLabel1.Text = "Current Folder: " + CurrentFolder;
            Task.Run(() =>
            {
                Invoke(openFolderToolStripMenuItem.PerformClick);
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

        private void listView2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!Enabled) return;
            SelectedFiles.Clear();
            foreach (ListViewItem lvi in listView2.CheckedItems)
            {
                SelectedFiles.AddRange(ExtensionsAndFiles[lvi.Text]);
            }
            toolStripStatusLabel3.Text = "Selected Files: " + SelectedFiles.Count;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView2.SelectedItems.Clear();
            var item = listView2.FindItemWithText('.' + textBox1.Text);
            item?.Selected = true;
            item?.EnsureVisible();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                var item = listView2.FindItemWithText('.' + textBox1.Text);
                item?.Checked = !item.Checked;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Enabled = false;
            listView1.BeginUpdate();
            listView1.Items.Clear();
            Regex regex = new(textBox2.Text, RegexOptions.IgnoreCase);
            var matches = await SearchFilesAsync(SelectedFiles, regex);
            foreach (var match in matches)
            {
                foreach (Match rmatch in match.Value)
                {
                    listView1.Items.Add(new ListViewItem([match.Key, rmatch.Value]));
                }
            }
            listView1.EndUpdate();
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
