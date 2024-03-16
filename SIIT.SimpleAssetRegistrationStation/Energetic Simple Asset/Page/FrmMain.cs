using Energetic_Simple_Asset.AssetWebApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Energetic_Simple_Asset.Page
{
    public partial class FrmMain : Form
    {
        delegate void DelegateVoid();

        public void PostStatus(string text)
        {
            if (statusStrip1.InvokeRequired)
            {
                statusStrip1.BeginInvoke(new DelegateVoid(() =>
                {
                    lblMainStatus.Text = text;
                }));
            }
            else
            {
                lblMainStatus.Text = text;
            }
        }

        public FrmMain()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            this.Load += FrmMain_Load;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            AppAttributes.Load();
            PostStatus("Ready.");
        }

        void TestWebApi()
        {
            try
            {
                using (AssetServiceClient client = new AssetServiceClient())
                {
                    string ret = client.MorningCheck();
                    MessageBox.Show(string.Format("Test connection successful.\n\r{0}", ret));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\n\r{1}", ex.Message, ex.StackTrace));
            }
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            Page.AboutBoxMain aboutBoxMain = new AboutBoxMain();
            aboutBoxMain.ShowDialog();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuFileTestConnection_Click(object sender, EventArgs e)
        {
            TestWebApi();
        }

        private void mnuTools_AssetRegistration_Click(object sender, EventArgs e)
        {
            ShowAssetRegistration();
        }

        void ShowAssetRegistration()
        {
            PostStatus("Asset Registration...");
            this.Cursor = Cursors.WaitCursor;
            FrmAssetRegistration frm = new FrmAssetRegistration(this);
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }

        private void mnuTools_Reader1Settings_Click(object sender, EventArgs e)
        {
            PostStatus("Reader Settings...");
            this.Cursor = Cursors.WaitCursor;
            var frm = new FrmReaderSetting();
            this.Cursor = Cursors.Default;
            frm.ShowDialog(this);
            PostStatus("Ready.");
        }

        private void mnuTools_RoomManagement_Click(object sender, EventArgs e)
        {
            PostStatus("Room Management...");
            this.Cursor = Cursors.WaitCursor;
            var frm = new FrmRoomManagement(this);
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }

        private void mnuTools_AssetValidation_Click(object sender, EventArgs e)
        {
            PostStatus("Asset Validation...");
            this.Cursor = Cursors.WaitCursor;
            var frm = new FrmAssetValidation(this);
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
