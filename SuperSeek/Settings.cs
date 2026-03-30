namespace SuperSeek
{
    public partial class Settings : Form
    {
        private long _MemoryCeiling = 4294967296; //4GB
        private long _MaxFileSize = 1073741824; //1GB
        private int _ScanAggression = 100;
        public long MemoryCeiling => _MemoryCeiling;
        public long MaxFileSize => _MaxFileSize;
        public long ScanAggression => _ScanAggression;

        public Settings()
        {
            InitializeComponent();
        }

        private static int ToMB(long B)
        {
            return (int)(B / 1024 / 1024);
        }

        private static long ToB(string MB)
        {
            return (long.Parse(MB.Replace("MB", "")) * 1024 * 1024);
        }

        public new void ShowDialog()
        {
            UpdateControls();
            base.ShowDialog();
        }

        public new async Task ShowDialogAsync(IWin32Window Owner)
        {
            UpdateControls();
            await base.ShowDialogAsync(Owner);
        }

        private void UpdateControls()
        {
            tbAggression.Value = (_ScanAggression - 200) * -1;
            mtbMaxFileSize.Text = ToMB(_MaxFileSize).ToString();
            mtbMemCeiling.Text = ToMB(_MemoryCeiling).ToString();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            _ScanAggression = (tbAggression.Value - 200) * -1;
            _MaxFileSize = ToB(mtbMaxFileSize.Text);
            _MemoryCeiling = ToB(mtbMemCeiling.Text);
            Close();
        }
    }
}