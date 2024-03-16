using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energetic_Simple_Asset.Page
{
    public static class AppAttributes
    {
        public static string Reader1_IpAddress = "192.168.1.31";
        public static double TxPowerInDbm = 15;

        public static void Save()
        {
            Properties.Settings.Default.Reader1IpAddress = Reader1_IpAddress;
            Properties.Settings.Default.Reader1Ant1TxPower = TxPowerInDbm;
            Properties.Settings.Default.Save();
        }

        public static void Load()
        {
            Reader1_IpAddress = Properties.Settings.Default.Reader1IpAddress;
            TxPowerInDbm = Properties.Settings.Default.Reader1Ant1TxPower;
        }
    }
}
