namespace Energetic_Simple_Asset.Page
{
    partial class FrmEditRowAndSaveRoom
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
            this.BtnSaveAndContinue = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSaveAndClose = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEpc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRoomCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnSaveAndContinue
            // 
            this.BtnSaveAndContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveAndContinue.Location = new System.Drawing.Point(12, 144);
            this.BtnSaveAndContinue.Name = "BtnSaveAndContinue";
            this.BtnSaveAndContinue.Size = new System.Drawing.Size(123, 46);
            this.BtnSaveAndContinue.TabIndex = 23;
            this.BtnSaveAndContinue.Text = "Save to DB and continue edit";
            this.BtnSaveAndContinue.UseVisualStyleBackColor = true;
            this.BtnSaveAndContinue.Click += new System.EventHandler(this.BtnSaveAndContinue_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(270, 144);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(123, 46);
            this.BtnCancel.TabIndex = 24;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSaveAndClose
            // 
            this.BtnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveAndClose.Location = new System.Drawing.Point(141, 144);
            this.BtnSaveAndClose.Name = "BtnSaveAndClose";
            this.BtnSaveAndClose.Size = new System.Drawing.Size(123, 46);
            this.BtnSaveAndClose.TabIndex = 21;
            this.BtnSaveAndClose.Text = "Save to DB and close";
            this.BtnSaveAndClose.UseVisualStyleBackColor = true;
            this.BtnSaveAndClose.Click += new System.EventHandler(this.BtnSaveAndClose_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(129, 95);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(243, 20);
            this.txtDesc.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Room Description:";
            // 
            // txtTID
            // 
            this.txtTID.Location = new System.Drawing.Point(129, 43);
            this.txtTID.Name = "txtTID";
            this.txtTID.ReadOnly = true;
            this.txtTID.Size = new System.Drawing.Size(243, 20);
            this.txtTID.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Room Code:";
            // 
            // txtEpc
            // 
            this.txtEpc.Location = new System.Drawing.Point(129, 69);
            this.txtEpc.Name = "txtEpc";
            this.txtEpc.ReadOnly = true;
            this.txtEpc.Size = new System.Drawing.Size(243, 20);
            this.txtEpc.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Room EPC:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Room TID:";
            // 
            // txtRoomCode
            // 
            this.txtRoomCode.Location = new System.Drawing.Point(130, 17);
            this.txtRoomCode.Name = "txtRoomCode";
            this.txtRoomCode.Size = new System.Drawing.Size(243, 20);
            this.txtRoomCode.TabIndex = 27;
            // 
            // FrmEditRowAndSaveRoom
            // 
            this.AcceptButton = this.BtnSaveAndClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(404, 206);
            this.Controls.Add(this.txtRoomCode);
            this.Controls.Add(this.BtnSaveAndContinue);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSaveAndClose);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEpc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "FrmEditRowAndSaveRoom";
            this.Text = "Edit Room";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSaveAndContinue;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSaveAndClose;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEpc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRoomCode;
    }
}