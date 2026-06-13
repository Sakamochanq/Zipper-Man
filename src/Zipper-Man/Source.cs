using System.Windows.Forms;
using Zipper_Man.utils;
using System;

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

            SelectCodeBox.SelectedIndex = 1;
        }

        string title = "Zipper Man";

        private void SelectZipButton_Click(object sender, EventArgs e)
        {
            using(var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    SelectZipBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    SelectExFolderBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void ExtractButton_Click(object sender, System.EventArgs e)
        {
            zip zip = new zip();

            string zipFolder = SelectZipBox.Text;
            string extractFolder = SelectExFolderBox.Text;

            Application.DoEvents();

            try
            {
                // 進捗バーの初期化と更新
                zip.Extract(zipFolder, extractFolder, SelectCodeBox.Text, (current, total) =>
                {
                    progressBar1.Maximum = total;
                    progressBar1.Value = current;

                    // UIの更新
                    Application.DoEvents();
                });

                MessageBox.Show("Extract Successfully!", title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            SelectExFolderBox.Text = null;
            SelectZipBox.Text = null;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ZIPの入ったフォルダを選択
        private void SelectButton1_Click(object sender, EventArgs e)
        {
            SelectZipButton_Click(sender, e);
        }

        // 解凍先のフォルダを選択
        private void SelectButton2_Click(object sender, EventArgs e)
        {
            SelectFolderButton_Click(sender, e);
        }

        private void AuthorButton_Click(object sender, EventArgs e)
        {
        }
    }
}
