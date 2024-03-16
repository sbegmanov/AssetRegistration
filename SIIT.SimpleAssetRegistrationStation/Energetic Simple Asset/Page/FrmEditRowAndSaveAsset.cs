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
    public partial class FrmEditRowAndSaveAsset : Form
    {
        public string RoomCode { get { return cboRoomCode.Text; } set { cboRoomCode.Text = value; } }
        public string TID { get { return txtTID.Text; } set { txtTID.Text = value; } }
        public string EPC { get; set; }
        public string FID { get { return txtFID.Text; } set { txtFID.Text = value; } }
        public string AssetLabel { get { return txtLabel.Text; } set { txtLabel.Text = value; } }
        public string AssetType { get { return cboType.Text; } set { cboType.Text = value; } }
        public string AssetDescription { get { return txtDesc.Text; } set { txtDesc.Text = value; } }
        private DataGridViewRow _row;

        public FrmEditRowAndSaveAsset(DataGridViewRow e)
        {
            InitializeComponent();
            _row = e;
            RoomCode = e.Cells["Room Code"].Value.ToString();
            TID= e.Cells["Asset TID"].Value.ToString();
            EPC= e.Cells["Asset EPC"].Value.ToString();
            FID= e.Cells["Asset FID"].Value.ToString();
            AssetType= e.Cells["Asset Type"].Value.ToString();
            AssetLabel= e.Cells["Asset Label"].Value.ToString();
            AssetDescription= e.Cells["Asset Description"].Value.ToString();

            using (AssetWebApi.AssetServiceClient cl = new AssetWebApi.AssetServiceClient())
            {
                AssetWebApi.ResultModelType res = cl.RoomAssetSelectAll();
                if (res.Flag)
                {
                    foreach(DataRow row in res.DataSetResult.Tables[0].Rows)
                    {
                        cboRoomCode.Items.Add(row["ROOM_CODE"].ToString());
                    }
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                
        private void BtnSaveAndClose_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void BtnSaveAndContinue_Click(object sender, EventArgs e)
        {
            Save();
        }

        void Save()
        {
            using (AssetWebApi.AssetServiceClient cl = new AssetWebApi.AssetServiceClient())
            {
                AssetWebApi.ResultModelType res = cl.Save(RoomCode, EPC, TID, FID, AssetLabel, AssetType, AssetDescription);
                MessageBox.Show(res.Message);
            }
            _row.Cells["Room Code"].Value = RoomCode;
            _row.Cells["Asset Type"].Value = AssetType;
            _row.Cells["Asset Label"].Value = AssetLabel;
            _row.Cells["Asset Description"].Value = AssetDescription;
        }

    }
}
