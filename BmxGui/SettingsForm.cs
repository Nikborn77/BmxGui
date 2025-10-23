using System;
using System.IO;
using System.Windows.Forms;

namespace BmxGui
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnBrowse = new Button();
            this.txtBmxPath = new TextBox();
            this.label1 = new Label();
            this.btnOk = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            this.label1.Text = "Path to bmx binaries (folder containing raw2bmx.exe etc.):";
            this.label1.AutoSize = true;
            this.label1.Top = 15;
            this.label1.Left = 12;

            this.txtBmxPath.Top = 40;
            this.txtBmxPath.Left = 12;
            this.txtBmxPath.Width = 420;
            this.txtBmxPath.Text = Properties.Settings.Default.BmxPath ?? "";

            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.Left = 440;
            this.btnBrowse.Top = 38;
            this.btnBrowse.Click += BtnBrowse_Click;

            this.btnOk.Text = "OK";
            this.btnOk.Left = 300;
            this.btnOk.Top = 80;
            this.btnOk.Click += BtnOk_Click;

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Left = 380;
            this.btnCancel.Top = 80;
            this.btnCancel.Click += (s,e) => this.DialogResult = DialogResult.Cancel;

            this.ClientSize = new System.Drawing.Size(540, 120);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBmxPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Text = "Settings";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            this.ResumeLayout(false);
        }

        private void BtnBrowse_Click(object? sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtBmxPath.Text = fbd.SelectedPath;
            }
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            if (!Directory.Exists(txtBmxPath.Text))
            {
                MessageBox.Show("Path does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Properties.Settings.Default.BmxPath = txtBmxPath.Text;
            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
        }

        private Button btnBrowse;
        private TextBox txtBmxPath;
        private Label label1;
        private Button btnOk;
        private Button btnCancel;
    }
}
