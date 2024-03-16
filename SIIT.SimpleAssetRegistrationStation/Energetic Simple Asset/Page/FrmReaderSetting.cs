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
    public partial class FrmReaderSetting : Form
    {
        public FrmReaderSetting()
        {
            InitializeComponent();

            AppAttributes.Load();
            txtIpAddress.Text = AppAttributes.Reader1_IpAddress;
            numTxPower.Value = (decimal)AppAttributes.TxPowerInDbm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AppAttributes.Reader1_IpAddress = txtIpAddress.Text;
            AppAttributes.TxPowerInDbm = (double)numTxPower.Value;
            AppAttributes.Save();
            this.Close();
        }
    }
}
