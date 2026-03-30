using SuperSeek.Properties;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Principal;
using System.Text.RegularExpressions;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace SuperSeek
{
    public partial class Main : Form
    {
        private readonly Settings Settings = new();
        private readonly Dictionary<string, List<string>> ExtensionsAndFiles = [];
        private readonly SemaphoreSlim ExtensionsAndFilesSemaphore = new(1);
        private readonly List<string> SelectedFiles = [];
        private readonly List<(string, int)> Results = [];
        private readonly SemaphoreSlim ResultsSemaphore = new(1);
        private readonly Dictionary<Component, string> LabelCache = [];
        private readonly bool IsElevated = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        private uint Scanned = 0;
        private string CurrentFolder = "C:\\";
        private CancellationTokenSource CTS = new();
        private uint CpuUsage = 0;
        private bool _Running = false;
        private long LastTick = Environment.TickCount64;
        private TimeSpan LastCpuTime;
        private int MinWaitMS = 0;
        private int MaxWaitMS = 0;
        private bool IsClosing = false;
        private static long MemoryUsedB => Environment.WorkingSet;
        private static int MemoryUsedMB => (int)(MemoryUsedB / 1024 / 1024);
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

                }
                else
                {
                    Cursor = Cursors.Default;
                    btnSearchOrCancel.Text = "Search";
                    SetLabel(tsslStatus, "Idle.");
                }
                msMain.Enabled =
                tsbRefreshExts.Enabled =
                tsbOpenFolder.Enabled =
                tsbSearchPath.Enabled =
                tsbSearchContent.Enabled =
                lvResults.Enabled =
                tbMainSearch.Enabled =
                scMain.Panel1.Enabled =
                !_Running;
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive, true, true);
            }
        }
        private readonly EnumerationOptions EnumerationOptions = new()
        {
            RecurseSubdirectories = false,
            IgnoreInaccessible = true
        };

        public Main()
        {
            InitializeComponent();
            new Thread(TimerThread).Start();
        }

        private static bool GetSetSortColumn(ListView ListView, int Column)
        {
            var col = ListView.Columns[Column];
            foreach (ColumnHeader icol in ListView.Columns)
            {
                if (icol.Index == Column) continue;
                icol.Text = icol.Text.Replace("▼ ", string.Empty);
                icol.Text = icol.Text.Replace("▲ ", string.Empty);
            }
            if (col.Text.StartsWith("▼ "))
            {
                col.Text = col.Text.Replace('▼', '▲');
                return true;
            }
            if (col.Text.StartsWith("▲ "))
            {
                col.Text = col.Text.Replace('▲', '▼');
                return false;
            }
            col.Text = $"▼ {col.Text}";
            return false;
        }

        private void TimerThread()
        {
            int counter = 0;
            while (!IsClosing)
            {
                new Thread(Timer100MSTick).Start();
                if (counter++ >= 10)
                {
                    new Thread(Timer1000MSTick).Start();
                    counter = 0;
                }
                Thread.Sleep(100);
            }
        }

        private void Timer100MSTick()
        {
            UpdateForm();
            if (Running) CalculateWaits();
        }

        private void UpdateForm()
        {
            try
            {
                Invoke(() =>
                {
                    SetLabel(tsslResults, Results.Count.ToString());
                    SetLabel(tsslScanned, Scanned.ToString());
                    SetLabel(tsslSelectedFiles, SelectedFiles.Count.ToString());
                    SetLabel(tslCpuUsage, CpuUsage.ToString());
                    SetLabel(tslMemory, MemoryUsedMB.ToString());
                    if (CpuUsage < 10)
                    {
                        tslCpuUsage.Image = Resources.speed_16dp_8C1AF6_FILL0_wght400_GRAD0_opsz20;
                    }
                    if (CpuUsage >= 10 && CpuUsage < 50)
                    {
                        tslCpuUsage.Image = Resources.speed_16dp_F19E39_FILL0_wght400_GRAD0_opsz20;
                    }
                    if (CpuUsage >= 50)
                    {
                        tslCpuUsage.Image = Resources.speed_16dp_EA3323_FILL0_wght400_GRAD0_opsz20;
                    }
                    if (CpuUsage < 10)
                    {
                        tslCpuUsage.Image = Resources.speed_16dp_8C1AF6_FILL0_wght400_GRAD0_opsz20;
                    }
                    if (CpuUsage >= 10 && CpuUsage < 50)
                    {
                        tslCpuUsage.Image = Resources.speed_16dp_F19E39_FILL0_wght400_GRAD0_opsz20;
                    }
                    if (CpuUsage >= 50)
                    {
                        tslCpuUsage.Image = Resources.speed_16dp_EA3323_FILL0_wght400_GRAD0_opsz20;
                    }
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
                });
            }
            catch
            {
                //Form disposed.
            }
        }

        private void Timer1000MSTick()
        {
            CalculateCPUUsage();
            if (Running) GC.Collect(GC.MaxGeneration, GCCollectionMode.Default, false, false);
        }

        private void CalculateCPUUsage()
        {
            var tickCount = Environment.TickCount64;
            var cpuTotalTime = Environment.CpuUsage.TotalTime;
            var elapstedTicks = tickCount - LastTick;
            if (elapstedTicks == 0) elapstedTicks = 1;
            var cpuUsage = (cpuTotalTime.Subtract(LastCpuTime).Ticks / elapstedTicks) / Environment.ProcessorCount / 100;
            LastCpuTime = cpuTotalTime;
            LastTick = tickCount;
            CpuUsage = (uint)cpuUsage;
        }

        private void CalculateWaits()
        {
            var aggression = (float)Settings.ScanAggression / 100;
            var remainingFiles = SelectedFiles.Count - Scanned;
            MinWaitMS = (int)((remainingFiles / 100) * aggression);
            MaxWaitMS = (int)((remainingFiles) * aggression);
        }

        private void Initialize(object sender, EventArgs e)
        {
            miToggleExtensions.Checked = !scMain.Panel1Collapsed;
            Settings.ShowDialog();
            OpenFolder(null!, null!);
            TopMost = true;
            TopMost = false;
        }

        private void SetLabel(Component Label, params string[] Strings)
        {
            var textProperty = Label.GetType().GetProperties().First((pi) => { return pi.Name == "Text"; });
            if (textProperty == null) return;
            if (!LabelCache.TryGetValue(Label, out string? newText))
            {
                newText = (string)textProperty.GetValue(Label)!;
                LabelCache.Add(Label, newText);
            }
            uint i = 0;
            foreach (var item in Strings)
            {
                newText = newText.Replace($"{{{i}}}", item);
            }
            if (newText != (string)textProperty.GetValue(Label)!)
            {
                textProperty.SetValue(Label, newText);
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
            SetLabel(tsslStatus, "Gathering files...");
            await DiscoverFilesAsync(new DirectoryInfo(CurrentFolder), async (file) =>
            {
                try
                {
                    var ext = file.Extension.ToLower();
                    await ExtensionsAndFilesSemaphore.WaitAsync(CTS.Token);
                    var added = ExtensionsAndFiles.TryAdd(ext, []);
                    ExtensionsAndFiles[ext].Add(file.FullName);
                }
                catch
                {
                    //Cancelled
                }
                ExtensionsAndFilesSemaphore.Release();
            });
            SetLabel(tsslStatus, "Rendering extension list...");
            Refresh();
            lvExtensions.BeginUpdate();
            List<ListViewItem> items = [];
            foreach (var item in ExtensionsAndFiles)
            {
                items.Add(new([item.Key, item.Value.Count.ToString()]));
            }
            lvExtensions.Items.AddRange([.. items]);
            lvExtensions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvExtensions.EndUpdate();
            Running = false;
        }

        private async void MiExit_Click(object sender, EventArgs e)
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
                List<Task> Tasks = [];
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

        private void LvExtensions_ItemChecked(object sender, ItemCheckedEventArgs e)
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

        private void TbExtensionSearch_KeyDown(object sender, KeyEventArgs e)
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
            if (Close) SetLabel(tsslStatus, "Closing...");
            if (!Close) SetLabel(tsslStatus, "Cancelling...");
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
                SetLabel(tsslStatus, "Clearing...");
                ClearResults();
                Regex regex = new(tbMainSearch.Text, RegexOptions.IgnoreCase);
                SetLabel(tsslStatus, "Scanning files...");
                CalculateWaits();
                await ScanFilesAsync(SelectedFiles, regex);
                List<ListViewItem> items = [];
                foreach (var match in Results)
                {
                    items.Add(new([match.Item1, match.Item2.ToString()]));
                }
                SetLabel(tsslStatus, "Rendering results...");
                Refresh();
                lvResults.Items.AddRange([.. items]);
                lvResults.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvResults.EndUpdate();
                Running = false;
            }
        }

        private async Task ScanFilesAsync(List<string> Files, Regex Regex)
        {
            List<Task> Tasks = [];
            foreach (var file in Files)
            {
                if (CTS.IsCancellationRequested) break;
                Tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        if (CTS.IsCancellationRequested) return;
                        if (Regex.ToString() == string.Empty)
                        {
                            await ResultsSemaphore.WaitAsync(CTS.Token);
                            Results.Add((file, 0));
                            Scanned++;
                            ResultsSemaphore.Release();
                            return;
                        }
                        if (CTS.IsCancellationRequested) return;
                        var size = new FileInfo(file).Length;
                        if (CTS.IsCancellationRequested) return;
                        if (size > Settings.MaxFileSize || size > Settings.MemoryCeiling) return;
                        if (tsbSearchContent.Checked && Settings.ScanAggression > 0)
                        {
                            do
                            {
                                await Task.Delay(Random.Shared.Next(MinWaitMS, MaxWaitMS), CTS.Token);
                            }
                            while (MemoryUsedB >= Settings.MemoryCeiling - size);
                        }
                        if (CTS.IsCancellationRequested) return;
                        var rmatches = 0;
                        if (tsbSearchContent.Checked)
                        {
                            var content = await File.ReadAllTextAsync(file, CTS.Token);
                            if (CTS.IsCancellationRequested) return;
                            rmatches += Regex.Count(content);
                            if (CTS.IsCancellationRequested) return;
                        }
                        if (tsbSearchPath.Checked) rmatches += Regex.Count(file);
                        if (CTS.IsCancellationRequested) return;
                        await ResultsSemaphore.WaitAsync(CTS.Token);
                        if (rmatches > 0) Results.Add((file, rmatches));
                        Scanned++;
                        ResultsSemaphore.Release();
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
            else
            {
                IsClosing = true;
            }
        }

        private void TbMainSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchOrCancel.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void OpenSelectedFiles(object? sender = null, EventArgs? e = null)
        {
            if (lvResults.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvResults.SelectedItems)
                {
                    OpenFile(item.Text, sender == tsbOpenWith, sender == tsbReveal);
                }
            }
        }

        private void OpenFile(string File, bool OpenWith = false, bool Reveal = false)
        {
            if (Reveal)
            {
                ProcessStartInfo info = new()
                {
                    UseShellExecute = true,
                    FileName = "explorer.exe",
                    Arguments = $"/select,\"{File}\""
                };
                Process.Start(info);
                return;
            }
            if (OpenWith)
            {
                var verb = string.Empty;
                if (IsElevated) verb = "runas";
                ProcessStartInfo info = new()
                {
                    UseShellExecute = true,
                    FileName = "OpenWith.exe",
                    Arguments = $"\"{File}\"",
                    Verb = verb
                };
                Process.Start(info);
                return;
            }
            PInvoke.ShellExecute(HWND.Null, null, File, null, null, SHOW_WINDOW_CMD.SW_NORMAL);
        }

        private void LvResults_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tsbOpenWith.Enabled =
            tsbReveal.Enabled =
            lvResults.SelectedItems.Count > 0;
        }

        private void LvResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                OpenSelectedFiles();
            }
        }

        private void SortColumn(object sender, ColumnClickEventArgs e)
        {
            var lv = (ListView)sender;
            var direction = GetSetSortColumn(lv, e.Column);
            lv.ListViewItemSorter = new ColumnComparer(e.Column, direction);
            lv.Sort();
        }

        private class ColumnComparer(int Column, bool Reverse = false) : IComparer
        {
            private readonly int Column = Column;
            private readonly bool Reverse = Reverse;

            public int Compare(object? x, object? y)
            {
                int result;
                var lviX = (ListViewItem?)x;
                var lviY = (ListViewItem?)y;
                var textX = lviX?.SubItems[Column].Text;
                var textY = lviY?.SubItems[Column].Text;
                if (int.TryParse(textX, out var intX) && int.TryParse(textY, out var intY))
                {
                    result = intY - intX;
                }
                else
                {
                    result = string.Compare(textX, textY);
                }
                if (Reverse)
                {
                    return result * -1;
                }
                else
                {
                    return result;
                }
            }
        }

        private async void MiSettings_ClickAsync(object sender, EventArgs e)
        {
            await Settings.ShowDialogAsync(this);
        }
    }
}