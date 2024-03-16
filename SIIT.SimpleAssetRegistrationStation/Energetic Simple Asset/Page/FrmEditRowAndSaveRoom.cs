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
    public partial class FrmEditRowAndSaveRoom : Form
    {
        public string RoomCode { get { return txtRoomCode.Text; } set { txtRoomCode.Text = value; } }
        public string TID { get { return txtTID.Text; } set { txtTID.Text = value; } }
        public string EPC { get { return txtEpc.Text; } set { txtEpc.Text = value; } }
        public string RoomDescription { get { return txtDesc.Text; } set { txtDesc.Text = value; } }
        private DataGridViewRow _row;

        public FrmEditRowAndSaveRoom(DataGridViewRow e)
        {
            InitializeComponent();
            _row = e;
            RoomCode = e.Cells["Room Code"].Value.ToString();
            TID = e.Cells["Room TID"].Value.ToString();
            EPC = e.Cells["Room EPC"].Value.ToString();
            RoomDescription = e.Cells["Room Description"].Value.ToString();
        }

        private void BtnSaveAndContinue_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BtnSaveAndClose_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Save()
        {
            using (AssetWebApi.AssetServiceClient cl = new AssetWebApi.AssetServiceClient())
            {
                AssetWebApi.ResultModelType res = cl.RoomSave(EPC, TID, RoomCode, RoomDescription);
                MessageBox.Show(res.Message);
            }
            _row.Cells["Room Code"].Value = RoomCode;
            _row.Cells["Room Description"].Value = RoomDescription;
        }

    }
}
