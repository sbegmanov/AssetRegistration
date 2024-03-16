namespace Energetic_Simple_Asset.Page
{
    partial class FrmEditRowAndSaveAsset
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFID = new System.Windows.Forms.TextBox();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.cboRoomCode = new System.Windows.Forms.ComboBox();
            this.BtnSaveAndClose = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSaveAndContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset TID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Asset FID:";
            // 
            // txtFID
            // 
            this.txtFID.Location = new System.Drawing.Point(128, 73);
            this.txtFID.Name = "txtFID";
            this.txtFID.Size = new System.Drawing.Size(243, 20);
            this.txtFID.TabIndex = 2;
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(128, 99);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(243, 20);
            this.txtLabel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Asset Label:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Room Code:";
            // 
            // txtTID
            // 
            this.txtTID.Location = new System.Drawing.Point(128, 47);
            this.txtTID.Name = "txtTID";
            this.txtTID.ReadOnly = true;
            this.txtTID.Size = new System.Drawing.Size(243, 20);
            this.txtTID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Asset Type:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(128, 152);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(243, 20);
            this.txtDesc.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Asset Description:";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Chair",
            "Desktop table",
            "CPU",
            "Keyboard",
            "Monitor",
            "Mouse",
            "Table",
            "Office Item"});
            this.cboType.Location = new System.Drawing.Point(128, 125);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(243, 21);
            this.cboType.TabIndex = 4;
            // 
            // cboRoomCode
            // 
            this.cboRoomCode.FormattingEnabled = true;
            this.cboRoomCode.Location = new System.Drawing.Point(128, 20);
            this.cboRoomCode.Name = "cboRoomCode";
            this.cboRoomCode.Size = new System.Drawing.Size(243, 21);
            this.cboRoomCode.TabIndex = 0;
            // 
            // BtnSaveAndClose
            // 
            this.BtnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveAndClose.Location = new System.Drawing.Point(140, 200);
            this.BtnSaveAndClose.Name = "BtnSaveAndClose";
            this.BtnSaveAndClose.Size = new System.Drawing.Size(123, 46);
            this.BtnSaveAndClose.TabIndex = 6;
            this.BtnSaveAndClose.Text = "Save to DB and close";
            this.BtnSaveAndClose.UseVisualStyleBackColor = true;
            this.BtnSaveAndClose.Click += new System.EventHandler(this.BtnSaveAndClose_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(269, 200);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(123, 46);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSaveAndContinue
            // 
            this.BtnSaveAndContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveAndContinue.Location = new System.Drawing.Point(11, 200);
            this.BtnSaveAndContinue.Name = "BtnSaveAndContinue";
            this.BtnSaveAndContinue.Size = new System.Drawing.Size(123, 46);
            this.BtnSaveAndContinue.TabIndex = 7;
            this.BtnSaveAndContinue.Text = "Save to DB and continue edit";
            this.BtnSaveAndContinue.UseVisualStyleBackColor = true;
            this.BtnSaveAndContinue.Click += new System.EventHandler(this.BtnSaveAndContinue_Click);
            // 
            // FrmEditRowAndSaveAsset
            // 
            this.AcceptButton = this.BtnSaveAndClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(404, 258);
            this.Controls.Add(this.BtnSaveAndContinue);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSaveAndClose);
            this.Controls.Add(this.cboRoomCode);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditRowAndSaveAsset";
            this.Text = "Edit Asset";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFID;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.ComboBox cboRoomCode;
        private System.Windows.Forms.Button BtnSaveAndClose;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSaveAndContinue;
    }
}