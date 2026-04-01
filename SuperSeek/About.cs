using System.Reflection;

namespace SuperSeek
{
    public partial class About : Form
    {
        private readonly Assembly CurrentAssembly = Assembly.GetExecutingAssembly();
        public About()
        {
            InitializeComponent();
            lblProduct.Text = CurrentAssembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
            Text = $"{lblProduct.Text}: About";
            lblDescription.Text =
            $"{CurrentAssembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description}\r" +
            $"{CurrentAssembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright}\r" +
            $"Version: {CurrentAssembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version}";
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
