namespace Energetic_Simple_Asset.Page
{
    partial class FrmAssetValidation
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
            this.btnEditRowAndSave = new System.Windows.Forms.Button();
            this.BtnCheckFromDb = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnScanTags = new System.Windows.Forms.Button();
            this.cboRoom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvAssetInRoom = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblAssetCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTempAsset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAssetInRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnEditRowAndSave);
            this.splitContainer1.Panel2.Controls.Add(this.BtnCheckFromDb);
            this.splitContainer1.Panel2.Controls.Add(this.btnClear);
            this.splitContainer1.Panel2.Controls.Add(this.btnStop);
            this.splitContainer1.Panel2.Controls.Add(this.btnScanTags);
            this.splitContainer1.Panel2.Click += new System.EventHandler(this.splitContainer1_Panel2_Click);
            this.splitContainer1.Size = new System.Drawing.Size(828, 331);
            this.splitContainer1.SplitterDistance = 643;
            this.splitContainer1.TabIndex = 3;
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
            this.DgvTempAsset.ShowEditingIcon = false;
            this.DgvTempAsset.Size = new System.Drawing.Size(643, 331);
            this.DgvTempAsset.TabIndex = 0;
            this.DgvTempAsset.SelectionChanged += new System.EventHandler(this.DgvTempAsset_SelectionChanged_1);
            // 
            // btnEditRowAndSave
            // 
            this.btnEditRowAndSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditRowAndSave.Enabled = false;
            this.btnEditRowAndSave.Location = new System.Drawing.Point(3, 223);
            this.btnEditRowAndSave.Name = "btnEditRowAndSave";
            this.btnEditRowAndSave.Size = new System.Drawing.Size(175, 41);
            this.btnEditRowAndSave.TabIndex = 7;
            this.btnEditRowAndSave.Text = "EDIT ROW AND SAVE";
            this.btnEditRowAndSave.UseVisualStyleBackColor = true;
            this.btnEditRowAndSave.Click += new System.EventHandler(this.btnEditRowAndSave_Click);
            // 
            // BtnCheckFromDb
            // 
            this.BtnCheckFromDb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCheckFromDb.Enabled = false;
            this.BtnCheckFromDb.Location = new System.Drawing.Point(3, 176);
            this.BtnCheckFromDb.Name = "BtnCheckFromDb";
            this.BtnCheckFromDb.Size = new System.Drawing.Size(175, 41);
            this.BtnCheckFromDb.TabIndex = 6;
            this.BtnCheckFromDb.Text = "CHECK FROM DATABASE";
            this.BtnCheckFromDb.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(3, 97);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(175, 41);
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
            this.btnStop.Size = new System.Drawing.Size(175, 41);
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
            this.btnScanTags.Size = new System.Drawing.Size(175, 41);
            this.btnScanTags.TabIndex = 0;
            this.btnScanTags.Text = "SCAN TAGS";
            this.btnScanTags.UseVisualStyleBackColor = true;
            // 
            // cboRoom
            // 
            this.cboRoom.FormattingEnabled = true;
            this.cboRoom.Location = new System.Drawing.Point(107, 13);
            this.cboRoom.Name = "cboRoom";
            this.cboRoom.Size = new System.Drawing.Size(130, 21);
            this.cboRoom.TabIndex = 4;
            this.cboRoom.SelectedIndexChanged += new System.EventHandler(this.cboRoom_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Room Code:";
            // 
            // DgvAssetInRoom
            // 
            this.DgvAssetInRoom.AllowUserToAddRows = false;
            this.DgvAssetInRoom.AllowUserToDeleteRows = false;
            this.DgvAssetInRoom.AllowUserToResizeRows = false;
            this.DgvAssetInRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvAssetInRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvAssetInRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAssetInRoom.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgvAssetInRoom.Location = new System.Drawing.Point(12, 40);
            this.DgvAssetInRoom.Name = "DgvAssetInRoom";
            this.DgvAssetInRoom.ReadOnly = true;
            this.DgvAssetInRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvAssetInRoom.ShowEditingIcon = false;
            this.DgvAssetInRoom.Size = new System.Drawing.Size(804, 89);
            this.DgvAssetInRoom.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblAssetCount);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.DgvAssetInRoom);
            this.splitContainer2.Panel1.Controls.Add(this.cboRoom);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(828, 467);
            this.splitContainer2.SplitterDistance = 132;
            this.splitContainer2.TabIndex = 7;
            // 
            // lblAssetCount
            // 
            this.lblAssetCount.AutoSize = true;
            this.lblAssetCount.ForeColor = System.Drawing.Color.Blue;
            this.lblAssetCount.Location = new System.Drawing.Point(243, 16);
            this.lblAssetCount.Name = "lblAssetCount";
            this.lblAssetCount.Size = new System.Drawing.Size(0, 13);
            this.lblAssetCount.TabIndex = 7;
            // 
            // FrmAssetValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 467);
            this.Controls.Add(this.splitContainer2);
            this.Name = "FrmAssetValidation";
            this.Text = "Assets Validation";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTempAsset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAssetInRoom)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DgvTempAsset;
        private System.Windows.Forms.Button BtnCheckFromDb;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnScanTags;
        private System.Windows.Forms.ComboBox cboRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvAssetInRoom;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lblAssetCount;
        private System.Windows.Forms.Button btnEditRowAndSave;
    }
}