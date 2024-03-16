using Impinj.OctaneSdk;
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
    public partial class FrmAssetRegistration : Form
    {
        string logText;
        delegate void DelegateVoid();
        List<ImpinjReader> readers = new List<ImpinjReader>();
        int opIdUser, opIdTid;
        FrmMain _frmMain;
        string userData, tidData, epcData, preEpcData;
        double Rssi;
        int ant;
        string dispText;
        DataTable tempAsset;
        bool IsConnected = false;

        public FrmAssetRegistration(FrmMain e)
        {
            InitializeComponent();

            _frmMain = e;

            this.Load += FrmAssetRegistration_Load;
            this.FormClosed += FrmAssetRegistration_FormClosed;
        }

        private void FrmAssetRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisconnectReaders();
        }

        private void FrmAssetRegistration_Load(object sender, EventArgs e)
        {
            ConnectReaders();
        }

        private void btnScanTags_Click(object sender, EventArgs e)
        {
            StartReaders();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopReaders();
        }

        private void splitContainer1_Panel2_Click(object sender, EventArgs e)
        {
            if (!IsConnected) ConnectReaders();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTempAsset();
        }

        private void DgvTempAsset_Click(object sender, EventArgs e)
        {
            if (!IsConnected) ConnectReaders();
        }

        private void DgvTempAsset_SelectionChanged(object sender, EventArgs e)
        {
            EnableGridButtons();
        }

        private void DgvTempAsset_DoubleClick(object sender, EventArgs e)
        {
            // Edit
            ShowDialog_EditRowAndSave();
        }

        private void btnEditRowAndSave_Click(object sender, EventArgs e)
        {
            // Edit
            StopReaders();
            ShowDialog_EditRowAndSave();
        }

        private void BtnRemoveRow_Click(object sender, EventArgs e)
        {
            StopReaders();
            RemoveRows();
        }

        private void BtnCheckFromDb_Click(object sender, EventArgs e)
        {
            StopReaders();
            CheckFromDB();
        }

        void CheckFromDB()
        {
            try
            {
                foreach (DataGridViewRow row in DgvTempAsset.Rows)
                {
                    // Check from web api
                    string tid = row.Cells["Asset TID"].Value.ToString();
                    string RoomCode = "", Fid = "", AssetLabel = "", AssetType = "", AssetDescription = "";
                    try
                    {
                        using (AssetWebApi.AssetServiceClient cl = new AssetWebApi.AssetServiceClient())
                        {
                            AssetWebApi.ResultModelType res = cl.SearchByTid(tid);
                            if (res.Flag)
                            {
                                RoomCode = res.ROOM_CODE;
                                Fid = res.ASSET_FID;
                                AssetLabel = res.ASSET_LABEL;
                                AssetType = res.ASSET_TYPE;
                                AssetDescription = res.ASSET_DESCRIPTION;

                                row.Cells["Room Code"].Value = RoomCode;
                                row.Cells["Asset FID"].Value = Fid;
                                row.Cells["Asset Type"].Value = AssetType;
                                row.Cells["Asset Label"].Value = AssetLabel;
                                row.Cells["Asset Description"].Value = AssetDescription;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format(">>> An exception has occurred. {0}", ex.Message));

                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format(">>> An exception has occurred. {0}", ex.Message));

            }
        }

        private void UpdateListbox(ImpinjReader sender, TagOpReport report)
        {
            // Loop through all the completed tag operations
            foreach (TagOpResult result in report)
            {
                preEpcData = epcData;
                dispText = "";
                userData = tidData = epcData = "";
                int ant = 0;

                // Was this completed operation a tag read operation?
                if (result is TagReadOpResult)
                {
                    // Cast it to the correct type.
                    TagReadOpResult readResult = result as TagReadOpResult;

                    // Save the EPC
                    epcData = readResult.Tag.Epc.ToHexString();
                    Rssi = readResult.Tag.PeakRssiInDbm;

                    // Are these the results for User memory or TID?
                    if (readResult.OpId == opIdUser)
                        userData = readResult.Data.ToHexString();
                    else if (readResult.OpId == opIdTid)
                        tidData = readResult.Data.ToHexString();

                    ant = readResult.Tag.AntennaPortNumber;
                }

                if (tidData.Equals("")) continue;

                // Text
                dispText = string.Format("Reader {0}/{1}: | EPC : {2} | TID : {3} | User : {4}, {5}", sender.Name, sender.Address, epcData, tidData, userData, ant);
                // log
                System.Diagnostics.Trace.WriteLine(string.Format(">>> {0} : {1}", DateTime.Now.ToString("hh:mm:ss fff"), dispText));

                // Check from web api
                string RoomCode = "", Fid = "", AssetLabel = "", AssetType = "", AssetDescription = "";
                //try
                //{
                //    using (AssetWebApi.AssetServiceClient cl = new AssetWebApi.AssetServiceClient())
                //    {
                //        AssetWebApi.ResultModelType res = cl.SearchByTid(tidData);
                //        if (res.Flag)
                //        {
                //            RoomCode = res.ROOM_CODE;
                //            Fid = res.ASSET_FID;
                //            AssetLabel = res.ASSET_LABEL;
                //            AssetType = res.ASSET_TYPE;
                //            AssetDescription = res.ASSET_DESCRIPTION;
                //        }
                //    }
                //}
                //catch { }

                // display by add to datatable
                try
                {
                    if (tempAsset == null) tempAsset = new DataTable();
                    if (tempAsset.Columns.Count <= 0)
                    {
                        tempAsset.Columns.AddRange(new DataColumn[9]
                        {
                            new DataColumn("No."),
                            new DataColumn("Asset TID"),
                            new DataColumn("RSSI"),
                            new DataColumn("Room Code"),
                            new DataColumn("Asset EPC"),
                            new DataColumn("Asset FID"),
                            new DataColumn("Asset Type"),
                            new DataColumn("Asset Label"),
                            new DataColumn("Asset Description"),
                        });
                        tempAsset.PrimaryKey = new DataColumn[] { tempAsset.Columns["Asset TID"] };
                    }
                    tempAsset.Rows.Add(tempAsset.Rows.Count + 1, tidData, Rssi, RoomCode, epcData, Fid, AssetLabel, AssetType, AssetDescription);
                    DgvTempAsset.DataSource = tempAsset;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format(">>> An Octane SDK exception has occurred. {0}", ex.Message));
                    //System.Threading.Thread.Sleep(1000);
                }

            }

        }

        private void OnTagOpComplete(ImpinjReader sender, TagOpReport report)
        {
            if (DgvTempAsset.InvokeRequired)
            {
                DgvTempAsset.BeginInvoke(new DelegateVoid(() =>
                {
                    UpdateListbox(sender, report);
                }));
            }
            else
            {
                UpdateListbox(sender, report);
            }
        }

        void ShowDialog_EditRowAndSave()
        {
            try
            {
                FrmEditRowAndSaveAsset dlg = new FrmEditRowAndSaveAsset(DgvTempAsset.SelectedRows[0]);
                dlg.ShowDialog(_frmMain);
            }
            catch { }

        }

        void ClearTempAsset()
        {
            Action action = () =>
            {
                tempAsset.Rows.Clear();
                DgvTempAsset.DataSource = tempAsset;
                if (btnScanTags.Enabled) btnScanTags.Focus();
                if (btnStop.Enabled) btnStop.Focus();
            };
            if (DgvTempAsset.InvokeRequired) DgvTempAsset.BeginInvoke(new DelegateVoid(() => { action(); }));
            else action();
        }

        void EnableGridButtons()
        {
            Action action = () =>
            {
                if (0 < tempAsset.Rows.Count) BtnCheckFromDb.Enabled = btnClear.Enabled = true;
                else BtnCheckFromDb.Enabled = btnClear.Enabled = false;
                if (0 < DgvTempAsset.SelectedRows.Count) btnEditRowAndSave.Enabled = BtnRemoveRow.Enabled = true;
                else btnEditRowAndSave.Enabled = BtnRemoveRow.Enabled = false;
            };
            if (BtnRemoveRow.InvokeRequired) BtnRemoveRow.BeginInvoke(new DelegateVoid(() => { action(); }));
            else action();
        }

        void RemoveRows()
        {
            Action action = () =>
            {
                try
                {
                    foreach (DataGridViewRow row in DgvTempAsset.SelectedRows)
                    {
                        DgvTempAsset.Rows.Remove(row);
                    }
                }
                catch { }
            };
            if (DgvTempAsset.InvokeRequired) DgvTempAsset.BeginInvoke(new DelegateVoid(() => { action(); }));
            else action();
        }

        public void ConnectReaders()
        {
            try
            {
                btnScanTags.Enabled = btnStop.Enabled = btnClear.Enabled = btnEditRowAndSave.Enabled = BtnRemoveRow.Enabled = false;

                readers.Clear();
                //Gpi.Clear();

                // Add new gate
                string key = "Reader #1";
                readers.Add(new ImpinjReader(AppAttributes.Reader1_IpAddress, key));
                //CreateNewGpiOf(key);

                // Loop through the List of readers to configure and start them.
                foreach (ImpinjReader reader in readers)
                {
                    // Connect to the reader.
                    // Change the ReaderHostname constant in SolutionConstants.cs 
                    // to the IP address or hostname of your reader.
                    reader.Connect();

                    // Get the default settings
                    // We'll use these as a starting point
                    // and then modify the settings we're 
                    // interested in.
                    Settings settings = reader.QueryDefaultSettings();

                    // Tell the reader to include the antenna number
                    // and TID (using FastID) in all tag reports. 
                    // FastID is available on Impinj Monza 4 and later chips.
                    settings.Report.IncludeAntennaPortNumber = true;//
                    settings.Report.IncludeFastId = true;
                    settings.Report.IncludePeakRssi = true;

                    // Set the transmit power (in dBm).
                    settings.Antennas.GetAntenna(1).TxPowerInDbm = AppAttributes.TxPowerInDbm;
                    //settings.Antennas.GetAntenna(2).TxPowerInDbm = 15;
                    //settings.Antennas.GetAntenna(3).TxPowerInDbm = 15;
                    //settings.Antennas.GetAntenna(4).TxPowerInDbm = 15;

                    // Send a tag report for every tag read.
                    settings.Report.Mode = ReportMode.Individual;//

                    //// Start reading tags when GPI #1 goes high.
                    //settings.Gpis.GetGpi(1).IsEnabled = true;//
                    //settings.Gpis.GetGpi(1).DebounceInMs = 50;//
                    //settings.AutoStart.Mode = AutoStartMode.GpiTrigger;//
                    //settings.AutoStart.GpiPortNumber = 1;//
                    //settings.AutoStart.GpiLevel = true;//

                    //// Stop reading tags when GPI #1 goes low.
                    //settings.AutoStop.Mode = AutoStopMode.GpiTrigger;//
                    //settings.AutoStop.GpiPortNumber = 1;//
                    //settings.AutoStop.GpiLevel = false;//

                    // GPO 1 will go high when tags when tags are read.
                    //settings.Gpos.GetGpo(2).Mode = GpoMode.LLRPConnectionStatus;

                    // GPO 2 will go high when a client application connects to the reader.
                    //settings.Gpos.GetGpo(3).Mode = GpoMode.ReaderInventoryStatus;

                    //// GPO 3 will pulse high for the specified period of time.
                    //settings.Gpos.GetGpo(4).Mode = GpoMode.Pulsed;
                    //settings.Gpos.GetGpo(4).GpoPulseDurationMsec = 1000;

                    //// GPO 4 will behave as a regular GPO.
                    //settings.Gpos.GetGpo(1).Mode = GpoMode.Normal;

                    // Create a tag read operation for User memory.
                    TagReadOp readUser = new TagReadOp();
                    // Read from user memory
                    readUser.MemoryBank = MemoryBank.User;
                    // Read two (16-bit) words
                    readUser.WordCount = 2;
                    // Starting at word 0
                    readUser.WordPointer = 0;

                    // Create a tag read operation for TID memory.
                    TagReadOp readTid = new TagReadOp();
                    // Read from TID memory
                    readTid.MemoryBank = MemoryBank.Tid;
                    // Read two (16-bit) words
                    readTid.WordCount = 6;
                    // Starting at word 0
                    readTid.WordPointer = 0;

                    // Add these operations to the reader as Optimized Read ops.
                    // Optimized Read ops apply to all tags, unlike 
                    // Tag Operation Sequences, which can be applied to specific tags.
                    // Speedway Revolution supports up to two Optimized Read operations.
                    settings.Report.OptimizedReadOps.Add(readUser);
                    settings.Report.OptimizedReadOps.Add(readTid);

                    // Store the operation IDs for later.
                    opIdUser = readUser.Id;
                    opIdTid = readTid.Id;

                    // Apply the newly modified settings.
                    reader.ApplySettings(settings);

                    // Assign the TagsReported event handler.
                    // This specifies which method to call
                    // when tags reports are available.
                    reader.TagOpComplete += OnTagOpComplete;

                }

                // BUTTONS
                btnScanTags.Enabled = true;
                btnStop.Enabled = false;

                _frmMain.PostStatus("Configured readers successful.");
                IsConnected = true;

            }
            catch (OctaneSdkException ex)
            {
                // An Octane SDK exception occurred. Handle it here.
                System.Diagnostics.Trace.WriteLine(string.Format(">>> An Octane SDK exception has occurred. {0}", ex.Message));
                btnScanTags.Enabled = btnStop.Enabled = btnClear.Enabled = btnEditRowAndSave.Enabled = BtnRemoveRow.Enabled = false;
                _frmMain.PostStatus("Readers configuration failed. An Octane SDK exception occurred.");
                MessageBox.Show(string.Format("An Octane SDK exception has occurred. {0}", ex.Message), "Reader Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // A general exception occurred. Handle it here.
                System.Diagnostics.Trace.WriteLine(">>> An exception has occurred. {0}", ex.Message);
                _frmMain.PostStatus("Readers configuration failed. A general exception occurred.");
                MessageBox.Show(string.Format("An Octane SDK exception has occurred. {0}", ex.Message), "Reader Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void DisconnectReaders()
        {
            try
            {
                foreach (ImpinjReader reader in readers)
                {
                    if (reader.QueryStatus().IsSingulating)
                        reader.Stop();
                    reader.Disconnect();
                    reader.TagOpComplete -= OnTagOpComplete;
                }
                IsConnected = false;
            }
            catch (OctaneSdkException ex)
            {
                // An Octane SDK exception occurred. Handle it here.
                System.Diagnostics.Trace.WriteLine(string.Format(">>> An Octane SDK exception has occurred. {0}", ex.Message));
                btnScanTags.Enabled = btnStop.Enabled = btnClear.Enabled = btnEditRowAndSave.Enabled = BtnRemoveRow.Enabled = false;
                _frmMain.PostStatus("Readers configuration failed. An Octane SDK exception occurred.");
                MessageBox.Show(string.Format("An Octane SDK exception has occurred. {0}", ex.Message), "Reader Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // A general exception occurred. Handle it here.
                System.Diagnostics.Trace.WriteLine(">>> An exception has occurred. {0}", ex.Message);
                _frmMain.PostStatus("Readers configuration failed. A general exception occurred.");
                MessageBox.Show(string.Format("An Octane SDK exception has occurred. {0}", ex.Message), "Reader Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void StartReaders()
        {
            try
            {
                btnScanTags.Enabled = btnStop.Enabled = false;

                if (!IsConnected) ConnectReaders();

                foreach (ImpinjReader reader in readers)
                {
                    reader.Connect();
                    if (!reader.QueryStatus().IsSingulating)
                        reader.Start();
                }

                btnStop.Enabled = true;
                btnStop.Focus();
            }
            catch (OctaneSdkException ex)
            {
                // An Octane SDK exception occurred. Handle it here.
                System.Diagnostics.Trace.WriteLine(string.Format(">>> An Octane SDK exception has occurred. {0}", ex.Message));
                btnScanTags.Enabled = btnStop.Enabled = btnClear.Enabled = btnEditRowAndSave.Enabled = BtnRemoveRow.Enabled = false;
                _frmMain.PostStatus("Readers configuration failed. An Octane SDK exception occurred.");
                MessageBox.Show(string.Format("An Octane SDK exception has occurred. {0}", ex.Message), "Reader Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // A general exception occurred. Handle it here.
                System.Diagnostics.Trace.WriteLine(">>> An exception has occurred. {0}", ex.Message);
                _frmMain.PostStatus("Readers configuration failed. A general exception occurred.");
                MessageBox.Show(string.Format("An Octane SDK exception has occurred. {0}", ex.Message), "Reader Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void StopReaders()
        {
            try
            {
                btnScanTags.Enabled = btnStop.Enabled = false;

                try
                {
                    foreach (ImpinjReader reader in readers)
                    {
                        if (reader.QueryStatus().IsSingulating)
                            reader.Stop();
                    }
                }
                catch { }

                DisconnectReaders();
                IsConnected = false;

                btnScanTags.Enabled = true;
                btnScanTags.Focus();
            }
            catch (OctaneSdkException ex)
            {
                // An Octane SDK exception occurred. Handle it here.
                System.Diagnostics.Trace.WriteLine(string.Format(">>> An Octane SDK exception has occurred. {0}", ex.Message));
                btnScanTags.Enabled = btnStop.Enabled = btnClear.Enabled = btnEditRowAndSave.Enabled = BtnRemoveRow.Enabled = false;
                _frmMain.PostStatus("Readers configuration failed. An Octane SDK exception occurred.");
                MessageBox.Show(string.Format("An Octane SDK exception has occurred. {0}", ex.Message), "Reader Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // A general exception occurred. Handle it here.
                System.Diagnostics.Trace.WriteLine(">>> An exception has occurred. {0}", ex.Message);
                _frmMain.PostStatus("Readers configuration failed. A general exception occurred.");
                MessageBox.Show(string.Format("An Octane SDK exception has occurred. {0}", ex.Message), "Reader Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
