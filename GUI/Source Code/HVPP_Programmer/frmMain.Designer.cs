namespace HVPP_Programmer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gpb_Chip = new System.Windows.Forms.GroupBox();
            this.cbx_Port = new System.Windows.Forms.ComboBox();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.btn_Signature = new System.Windows.Forms.Button();
            this.tbx_Signature = new System.Windows.Forms.TextBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.lbl_Signature = new System.Windows.Forms.Label();
            this.cbx_Chip = new System.Windows.Forms.ComboBox();
            this.lbl_Chip = new System.Windows.Forms.Label();
            this.gpb_Function = new System.Windows.Forms.GroupBox();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.btn_Calibration = new System.Windows.Forms.Button();
            this.tbx_Calibration = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Lock = new System.Windows.Forms.Button();
            this.btn_Erase = new System.Windows.Forms.Button();
            this.gpb_Fuse = new System.Windows.Forms.GroupBox();
            this.btn_WriteExtendedFuse = new System.Windows.Forms.Button();
            this.btn_WriteHighFuse = new System.Windows.Forms.Button();
            this.btn_WriteLowFuse = new System.Windows.Forms.Button();
            this.btn_ReadFuses = new System.Windows.Forms.Button();
            this.tbx_Lock = new System.Windows.Forms.TextBox();
            this.lbl_Lock = new System.Windows.Forms.Label();
            this.tbx_EFuse = new System.Windows.Forms.TextBox();
            this.tbx_HFuse = new System.Windows.Forms.TextBox();
            this.tbx_LFuse = new System.Windows.Forms.TextBox();
            this.lbl_EFuse = new System.Windows.Forms.Label();
            this.lbl_HFuse = new System.Windows.Forms.Label();
            this.lbl_LFuse = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.gpb_Chip.SuspendLayout();
            this.gpb_Function.SuspendLayout();
            this.gpb_Fuse.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpb_Chip
            // 
            this.gpb_Chip.Controls.Add(this.cbx_Port);
            this.gpb_Chip.Controls.Add(this.lbl_Port);
            this.gpb_Chip.Controls.Add(this.btn_Signature);
            this.gpb_Chip.Controls.Add(this.tbx_Signature);
            this.gpb_Chip.Controls.Add(this.btn_Connect);
            this.gpb_Chip.Controls.Add(this.lbl_Signature);
            this.gpb_Chip.Controls.Add(this.cbx_Chip);
            this.gpb_Chip.Controls.Add(this.lbl_Chip);
            this.gpb_Chip.Location = new System.Drawing.Point(12, 12);
            this.gpb_Chip.Name = "gpb_Chip";
            this.gpb_Chip.Size = new System.Drawing.Size(689, 59);
            this.gpb_Chip.TabIndex = 0;
            this.gpb_Chip.TabStop = false;
            this.gpb_Chip.Text = "ATMEL Chip";
            // 
            // cbx_Port
            // 
            this.cbx_Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Port.FormattingEnabled = true;
            this.cbx_Port.Items.AddRange(new object[] {
            "ATMEGA8(A)(L)",
            "ATMEGA48",
            "ATMEGA168(P)(PA)",
            "ATMEGA328(P)"});
            this.cbx_Port.Location = new System.Drawing.Point(248, 19);
            this.cbx_Port.Name = "cbx_Port";
            this.cbx_Port.Size = new System.Drawing.Size(71, 21);
            this.cbx_Port.TabIndex = 7;
            // 
            // lbl_Port
            // 
            this.lbl_Port.AutoSize = true;
            this.lbl_Port.Location = new System.Drawing.Point(213, 24);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(29, 13);
            this.lbl_Port.TabIndex = 6;
            this.lbl_Port.Text = "Port:";
            // 
            // btn_Signature
            // 
            this.btn_Signature.Location = new System.Drawing.Point(572, 20);
            this.btn_Signature.Name = "btn_Signature";
            this.btn_Signature.Size = new System.Drawing.Size(93, 23);
            this.btn_Signature.TabIndex = 5;
            this.btn_Signature.Text = "Read Signature";
            this.btn_Signature.UseVisualStyleBackColor = true;
            this.btn_Signature.Click += new System.EventHandler(this.btn_Signature_Click);
            // 
            // tbx_Signature
            // 
            this.tbx_Signature.Location = new System.Drawing.Point(484, 20);
            this.tbx_Signature.Name = "tbx_Signature";
            this.tbx_Signature.Size = new System.Drawing.Size(78, 20);
            this.tbx_Signature.TabIndex = 4;
            this.tbx_Signature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(333, 18);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(60, 23);
            this.btn_Connect.TabIndex = 3;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // lbl_Signature
            // 
            this.lbl_Signature.AutoSize = true;
            this.lbl_Signature.Location = new System.Drawing.Point(399, 24);
            this.lbl_Signature.Name = "lbl_Signature";
            this.lbl_Signature.Size = new System.Drawing.Size(79, 13);
            this.lbl_Signature.TabIndex = 2;
            this.lbl_Signature.Text = "Chip Signature:";
            // 
            // cbx_Chip
            // 
            this.cbx_Chip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Chip.FormattingEnabled = true;
            this.cbx_Chip.Items.AddRange(new object[] {
            "ATMEGA8(A)(L)",
            "ATMEGA48",
            "ATMEGA168(P)(PA)",
            "ATMEGA328(P)"});
            this.cbx_Chip.Location = new System.Drawing.Point(86, 19);
            this.cbx_Chip.Name = "cbx_Chip";
            this.cbx_Chip.Size = new System.Drawing.Size(121, 21);
            this.cbx_Chip.TabIndex = 1;
            // 
            // lbl_Chip
            // 
            this.lbl_Chip.AutoSize = true;
            this.lbl_Chip.Location = new System.Drawing.Point(15, 24);
            this.lbl_Chip.Name = "lbl_Chip";
            this.lbl_Chip.Size = new System.Drawing.Size(65, 13);
            this.lbl_Chip.TabIndex = 0;
            this.lbl_Chip.Text = "Target Chip:";
            // 
            // gpb_Function
            // 
            this.gpb_Function.Controls.Add(this.btn_Calibration);
            this.gpb_Function.Controls.Add(this.tbx_Calibration);
            this.gpb_Function.Controls.Add(this.label1);
            this.gpb_Function.Controls.Add(this.btn_Lock);
            this.gpb_Function.Controls.Add(this.btn_Erase);
            this.gpb_Function.Location = new System.Drawing.Point(12, 86);
            this.gpb_Function.Name = "gpb_Function";
            this.gpb_Function.Size = new System.Drawing.Size(689, 60);
            this.gpb_Function.TabIndex = 1;
            this.gpb_Function.TabStop = false;
            this.gpb_Function.Text = "Chip Functions";
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Location = new System.Drawing.Point(501, 285);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(75, 23);
            this.btn_Disconnect.TabIndex = 7;
            this.btn_Disconnect.Text = "Disconnect";
            this.btn_Disconnect.UseVisualStyleBackColor = true;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // btn_Calibration
            // 
            this.btn_Calibration.Location = new System.Drawing.Point(175, 19);
            this.btn_Calibration.Name = "btn_Calibration";
            this.btn_Calibration.Size = new System.Drawing.Size(131, 23);
            this.btn_Calibration.TabIndex = 6;
            this.btn_Calibration.Text = "Read Calibration Byte";
            this.btn_Calibration.UseVisualStyleBackColor = true;
            this.btn_Calibration.Click += new System.EventHandler(this.btn_Calibration_Click);
            // 
            // tbx_Calibration
            // 
            this.tbx_Calibration.Location = new System.Drawing.Point(104, 21);
            this.tbx_Calibration.Name = "tbx_Calibration";
            this.tbx_Calibration.Size = new System.Drawing.Size(55, 20);
            this.tbx_Calibration.TabIndex = 5;
            this.tbx_Calibration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Calibration Byte:";
            // 
            // btn_Lock
            // 
            this.btn_Lock.Location = new System.Drawing.Point(551, 18);
            this.btn_Lock.Name = "btn_Lock";
            this.btn_Lock.Size = new System.Drawing.Size(114, 23);
            this.btn_Lock.TabIndex = 1;
            this.btn_Lock.Text = "Write Lock Byte";
            this.btn_Lock.UseVisualStyleBackColor = true;
            this.btn_Lock.Click += new System.EventHandler(this.btn_Lock_Click);
            // 
            // btn_Erase
            // 
            this.btn_Erase.Location = new System.Drawing.Point(433, 18);
            this.btn_Erase.Name = "btn_Erase";
            this.btn_Erase.Size = new System.Drawing.Size(96, 23);
            this.btn_Erase.TabIndex = 0;
            this.btn_Erase.Text = "Erase Chip";
            this.btn_Erase.UseVisualStyleBackColor = true;
            this.btn_Erase.Click += new System.EventHandler(this.btn_Erase_Click);
            // 
            // gpb_Fuse
            // 
            this.gpb_Fuse.Controls.Add(this.btn_WriteExtendedFuse);
            this.gpb_Fuse.Controls.Add(this.btn_WriteHighFuse);
            this.gpb_Fuse.Controls.Add(this.btn_WriteLowFuse);
            this.gpb_Fuse.Controls.Add(this.btn_ReadFuses);
            this.gpb_Fuse.Controls.Add(this.tbx_Lock);
            this.gpb_Fuse.Controls.Add(this.lbl_Lock);
            this.gpb_Fuse.Controls.Add(this.tbx_EFuse);
            this.gpb_Fuse.Controls.Add(this.tbx_HFuse);
            this.gpb_Fuse.Controls.Add(this.tbx_LFuse);
            this.gpb_Fuse.Controls.Add(this.lbl_EFuse);
            this.gpb_Fuse.Controls.Add(this.lbl_HFuse);
            this.gpb_Fuse.Controls.Add(this.lbl_LFuse);
            this.gpb_Fuse.Location = new System.Drawing.Point(12, 164);
            this.gpb_Fuse.Name = "gpb_Fuse";
            this.gpb_Fuse.Size = new System.Drawing.Size(689, 102);
            this.gpb_Fuse.TabIndex = 2;
            this.gpb_Fuse.TabStop = false;
            this.gpb_Fuse.Text = "Fuse Settings";
            // 
            // btn_WriteExtendedFuse
            // 
            this.btn_WriteExtendedFuse.Location = new System.Drawing.Point(286, 59);
            this.btn_WriteExtendedFuse.Name = "btn_WriteExtendedFuse";
            this.btn_WriteExtendedFuse.Size = new System.Drawing.Size(139, 23);
            this.btn_WriteExtendedFuse.TabIndex = 14;
            this.btn_WriteExtendedFuse.Text = "Write Extended Fuse";
            this.btn_WriteExtendedFuse.UseVisualStyleBackColor = true;
            this.btn_WriteExtendedFuse.Click += new System.EventHandler(this.btn_WriteExtendedFuse_Click);
            // 
            // btn_WriteHighFuse
            // 
            this.btn_WriteHighFuse.Location = new System.Drawing.Point(154, 59);
            this.btn_WriteHighFuse.Name = "btn_WriteHighFuse";
            this.btn_WriteHighFuse.Size = new System.Drawing.Size(114, 23);
            this.btn_WriteHighFuse.TabIndex = 13;
            this.btn_WriteHighFuse.Text = "Write High Fuse";
            this.btn_WriteHighFuse.UseVisualStyleBackColor = true;
            this.btn_WriteHighFuse.Click += new System.EventHandler(this.btn_WriteHighFuse_Click);
            // 
            // btn_WriteLowFuse
            // 
            this.btn_WriteLowFuse.Location = new System.Drawing.Point(18, 59);
            this.btn_WriteLowFuse.Name = "btn_WriteLowFuse";
            this.btn_WriteLowFuse.Size = new System.Drawing.Size(114, 23);
            this.btn_WriteLowFuse.TabIndex = 12;
            this.btn_WriteLowFuse.Text = "Write Low Fuse";
            this.btn_WriteLowFuse.UseVisualStyleBackColor = true;
            this.btn_WriteLowFuse.Click += new System.EventHandler(this.btn_WriteLowFuse_Click);
            // 
            // btn_ReadFuses
            // 
            this.btn_ReadFuses.Location = new System.Drawing.Point(590, 21);
            this.btn_ReadFuses.Name = "btn_ReadFuses";
            this.btn_ReadFuses.Size = new System.Drawing.Size(75, 23);
            this.btn_ReadFuses.TabIndex = 11;
            this.btn_ReadFuses.Text = "Read Fuses";
            this.btn_ReadFuses.UseVisualStyleBackColor = true;
            this.btn_ReadFuses.Click += new System.EventHandler(this.btn_ReadFuses_Click);
            // 
            // tbx_Lock
            // 
            this.tbx_Lock.Location = new System.Drawing.Point(509, 23);
            this.tbx_Lock.Name = "tbx_Lock";
            this.tbx_Lock.Size = new System.Drawing.Size(55, 20);
            this.tbx_Lock.TabIndex = 10;
            this.tbx_Lock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_Lock
            // 
            this.lbl_Lock.AutoSize = true;
            this.lbl_Lock.Location = new System.Drawing.Point(445, 26);
            this.lbl_Lock.Name = "lbl_Lock";
            this.lbl_Lock.Size = new System.Drawing.Size(58, 13);
            this.lbl_Lock.TabIndex = 9;
            this.lbl_Lock.Text = "Lock Byte:";
            // 
            // tbx_EFuse
            // 
            this.tbx_EFuse.Location = new System.Drawing.Point(370, 23);
            this.tbx_EFuse.Name = "tbx_EFuse";
            this.tbx_EFuse.Size = new System.Drawing.Size(55, 20);
            this.tbx_EFuse.TabIndex = 8;
            this.tbx_EFuse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbx_HFuse
            // 
            this.tbx_HFuse.Location = new System.Drawing.Point(213, 23);
            this.tbx_HFuse.Name = "tbx_HFuse";
            this.tbx_HFuse.Size = new System.Drawing.Size(55, 20);
            this.tbx_HFuse.TabIndex = 7;
            this.tbx_HFuse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbx_LFuse
            // 
            this.tbx_LFuse.Location = new System.Drawing.Point(77, 23);
            this.tbx_LFuse.Name = "tbx_LFuse";
            this.tbx_LFuse.Size = new System.Drawing.Size(55, 20);
            this.tbx_LFuse.TabIndex = 6;
            this.tbx_LFuse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_EFuse
            // 
            this.lbl_EFuse.AutoSize = true;
            this.lbl_EFuse.Location = new System.Drawing.Point(283, 26);
            this.lbl_EFuse.Name = "lbl_EFuse";
            this.lbl_EFuse.Size = new System.Drawing.Size(81, 13);
            this.lbl_EFuse.TabIndex = 5;
            this.lbl_EFuse.Text = "Extended Fuse:";
            // 
            // lbl_HFuse
            // 
            this.lbl_HFuse.AutoSize = true;
            this.lbl_HFuse.Location = new System.Drawing.Point(149, 26);
            this.lbl_HFuse.Name = "lbl_HFuse";
            this.lbl_HFuse.Size = new System.Drawing.Size(58, 13);
            this.lbl_HFuse.TabIndex = 4;
            this.lbl_HFuse.Text = "High Fuse:";
            // 
            // lbl_LFuse
            // 
            this.lbl_LFuse.AutoSize = true;
            this.lbl_LFuse.Location = new System.Drawing.Point(15, 26);
            this.lbl_LFuse.Name = "lbl_LFuse";
            this.lbl_LFuse.Size = new System.Drawing.Size(56, 13);
            this.lbl_LFuse.TabIndex = 3;
            this.lbl_LFuse.Text = "Low Fuse:";
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(602, 285);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 23);
            this.btn_Exit.TabIndex = 8;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 323);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Disconnect);
            this.Controls.Add(this.gpb_Fuse);
            this.Controls.Add(this.gpb_Function);
            this.Controls.Add(this.gpb_Chip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "AVR Micor Processer HVPP Configurator GUI v0.9 (Developped by Shichang Zhuo)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gpb_Chip.ResumeLayout(false);
            this.gpb_Chip.PerformLayout();
            this.gpb_Function.ResumeLayout(false);
            this.gpb_Function.PerformLayout();
            this.gpb_Fuse.ResumeLayout(false);
            this.gpb_Fuse.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpb_Chip;
        private System.Windows.Forms.ComboBox cbx_Chip;
        private System.Windows.Forms.Label lbl_Chip;
        private System.Windows.Forms.TextBox tbx_Signature;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Label lbl_Signature;
        private System.Windows.Forms.Button btn_Signature;
        private System.Windows.Forms.GroupBox gpb_Function;
        private System.Windows.Forms.Button btn_Lock;
        private System.Windows.Forms.Button btn_Erase;
        private System.Windows.Forms.Button btn_Calibration;
        private System.Windows.Forms.TextBox tbx_Calibration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpb_Fuse;
        private System.Windows.Forms.Label lbl_LFuse;
        private System.Windows.Forms.Label lbl_EFuse;
        private System.Windows.Forms.Label lbl_HFuse;
        private System.Windows.Forms.Button btn_WriteExtendedFuse;
        private System.Windows.Forms.Button btn_WriteHighFuse;
        private System.Windows.Forms.Button btn_WriteLowFuse;
        private System.Windows.Forms.Button btn_ReadFuses;
        private System.Windows.Forms.TextBox tbx_Lock;
        private System.Windows.Forms.Label lbl_Lock;
        private System.Windows.Forms.TextBox tbx_EFuse;
        private System.Windows.Forms.TextBox tbx_HFuse;
        private System.Windows.Forms.TextBox tbx_LFuse;
        private System.Windows.Forms.ComboBox cbx_Port;
        private System.Windows.Forms.Label lbl_Port;
        private System.Windows.Forms.Button btn_Disconnect;
        private System.Windows.Forms.Button btn_Exit;
    }
}

