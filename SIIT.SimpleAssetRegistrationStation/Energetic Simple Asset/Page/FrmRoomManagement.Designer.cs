namespace Energetic_Simple_Asset.Page
{
    partial class FrmRoomManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DgvTempAsset = new System.Windows.Forms.DataGridView();
            this.BtnCheckFromDb = new System.Windows.Forms.Button();
            this.btnEditRowAndSave = new System.Windows.Forms.Button();
            this.BtnRemoveRow = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnScanTags = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTempAsset)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DgvTempAsset);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.BtnCheckFromDb);
            this.splitContainer1.Panel2.Controls.Add(this.btnEditRowAndSave);
            this.splitContainer1.Panel2.Controls.Add(this.BtnRemoveRow);
            this.splitContainer1.Panel2.Controls.Add(this.btnClear);
            this.splitContainer1.Panel2.Controls.Add(this.btnStop);
            this.splitContainer1.Panel2.Controls.Add(this.btnScanTags);
            this.splitContainer1.Panel2.Click += new System.EventHandler(this.splitContainer1_Panel2_Click);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 622;
            this.splitContainer1.TabIndex = 2;
            // 
            // DgvTempAsset
            // 
            this.DgvTempAsset.AllowUserToAddRows = false;
            this.DgvTempAsset.AllowUserToDeleteRows = false;
            this.DgvTempAsset.AllowUserToResizeRows = false;
            this.DgvTempAsset.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvTempAsset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTempAsset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvTempAsset.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgvTempAsset.Location = new System.Drawing.Point(0, 0);
            this.DgvTempAsset.Name = "DgvTempAsset";
            this.DgvTempAsset.ReadOnly = true;
            this.DgvTempAsset.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTempAsset.ShowEditingIcon = false;
            this.DgvTempAsset.Size = new System.Drawing.Size(622, 450);
            this.DgvTempAsset.TabIndex = 0;
            // 
            // BtnCheckFromDb
            // 
            this.BtnCheckFromDb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCheckFromDb.Enabled = false;
            this.BtnCheckFromDb.Location = new System.Drawing.Point(3, 176);
            this.BtnCheckFromDb.Name = "BtnCheckFromDb";
            this.BtnCheckFromDb.Size = new System.Drawing.Size(168, 41);
            this.BtnCheckFromDb.TabIndex = 6;
            this.BtnCheckFromDb.Text = "CHECK FROM DATABASE";
            this.BtnCheckFromDb.UseVisualStyleBackColor = true;
            // 
            // btnEditRowAndSave
            // 
            this.btnEditRowAndSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditRowAndSave.Enabled = false;
            this.btnEditRowAndSave.Location = new System.Drawing.Point(4, 260);
            this.btnEditRowAndSave.Name = "btnEditRowAndSave";
            this.btnEditRowAndSave.Size = new System.Drawing.Size(168, 41);
            this.btnEditRowAndSave.TabIndex = 5;
            this.btnEditRowAndSave.Text = "EDIT ROW AND SAVE";
            this.btnEditRowAndSave.UseVisualStyleBackColor = true;
            // 
            // BtnRemoveRow
            // 
            this.BtnRemoveRow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemoveRow.Enabled = false;
            this.BtnRemoveRow.Location = new System.Drawing.Point(3, 307);
            this.BtnRemoveRow.Name = "BtnRemoveRow";
            this.BtnRemoveRow.Size = new System.Drawing.Size(168, 41);
            this.BtnRemoveRow.TabIndex = 4;
            this.BtnRemoveRow.Text = "REMOVE ROW";
            this.BtnRemoveRow.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(3, 97);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(168, 41);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(3, 50);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(168, 41);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnScanTags
            // 
            this.btnScanTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScanTags.Enabled = false;
            this.btnScanTags.Location = new System.Drawing.Point(3, 3);
            this.btnScanTags.Name = "btnScanTags";
            this.btnScanTags.Size = new System.Drawing.Size(168, 41);
            this.btnScanTags.TabIndex = 0;
            this.btnScanTags.Text = "SCAN TAGS";
            this.btnScanTags.UseVisualStyleBackColor = true;
            // 
            // FrmRoomManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmRoomManagement";
            this.Text = "Room Management";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTempAsset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DgvTempAsset;
        private System.Windows.Forms.Button BtnCheckFromDb;
        private System.Windows.Forms.Button btnEditRowAndSave;
        private System.Windows.Forms.Button BtnRemoveRow;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnScanTags;
    }
}