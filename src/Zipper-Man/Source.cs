using System.Windows.Forms;

namespace Zipper_Man
{
    public partial class Source : Form
    {
        public Source()
        {
            InitializeComponent();

            SelectCodeBox.Items.Add("UTF-8");
            SelectCodeBox.Items.Add("Shift-JIS");
            SelectCodeBox.Items.Add("EUC-JP");

            SelectCodeBox.SelectedIndex = 0;

        }

        private void ExtractButton_Click(object sender, System.EventArgs e)
        {
        }
    }
}
