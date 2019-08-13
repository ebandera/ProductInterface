namespace ProductInterface
{
    partial class frmPreloadedTypes
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkInputCEDHotSheet = new System.Windows.Forms.CheckBox();
            this.chkInputCED001 = new System.Windows.Forms.CheckBox();
            this.chkInputCEDXls = new System.Windows.Forms.CheckBox();
            this.chkInputMfrCat = new System.Windows.Forms.CheckBox();
            this.chkInputVMIImage = new System.Windows.Forms.CheckBox();
            this.chkInputVMI = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkOutput5162Image = new System.Windows.Forms.CheckBox();
            this.chkOutputDymo1x3 = new System.Windows.Forms.CheckBox();
            this.chkOutput1x2Spool = new System.Windows.Forms.CheckBox();
            this.chkOutput1x3Spool = new System.Windows.Forms.CheckBox();
            this.chkOutput2x3MinSpool = new System.Windows.Forms.CheckBox();
            this.chkOutput2x3Spool = new System.Windows.Forms.CheckBox();
            this.chkOutput1x2Sheet = new System.Windows.Forms.CheckBox();
            this.chkOutput1x3Sheet = new System.Windows.Forms.CheckBox();
            this.chkOutput2x3MinSheet = new System.Windows.Forms.CheckBox();
            this.chkOutput2x3Sheet = new System.Windows.Forms.CheckBox();
            this.chkOutput5162 = new System.Windows.Forms.CheckBox();
            this.chkOutput5160 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkInputCEDHotSheet);
            this.groupBox1.Controls.Add(this.chkInputCED001);
            this.groupBox1.Controls.Add(this.chkInputCEDXls);
            this.groupBox1.Controls.Add(this.chkInputMfrCat);
            this.groupBox1.Controls.Add(this.chkInputVMIImage);
            this.groupBox1.Controls.Add(this.chkInputVMI);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(13, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preloaded Input Types";
            // 
            // chkInputCEDHotSheet
            // 
            this.chkInputCEDHotSheet.AutoSize = true;
            this.chkInputCEDHotSheet.Location = new System.Drawing.Point(7, 140);
            this.chkInputCEDHotSheet.Name = "chkInputCEDHotSheet";
            this.chkInputCEDHotSheet.Size = new System.Drawing.Size(99, 17);
            this.chkInputCEDHotSheet.TabIndex = 5;
            this.chkInputCEDHotSheet.Text = "CED Hot Sheet";
            this.chkInputCEDHotSheet.UseVisualStyleBackColor = true;
            this.chkInputCEDHotSheet.Click += new System.EventHandler(this.chkInput_Click);
            // 
            // chkInputCED001
            // 
            this.chkInputCED001.AutoSize = true;
            this.chkInputCED001.Location = new System.Drawing.Point(7, 116);
            this.chkInputCED001.Name = "chkInputCED001";
            this.chkInputCED001.Size = new System.Drawing.Size(155, 17);
            this.chkInputCED001.TabIndex = 4;
            this.chkInputCED001.Text = "CED Generic 001 Price File";
            this.chkInputCED001.UseVisualStyleBackColor = true;
            this.chkInputCED001.Click += new System.EventHandler(this.chkInput_Click);
            // 
            // chkInputCEDXls
            // 
            this.chkInputCEDXls.AutoSize = true;
            this.chkInputCEDXls.Location = new System.Drawing.Point(7, 92);
            this.chkInputCEDXls.Name = "chkInputCEDXls";
            this.chkInputCEDXls.Size = new System.Drawing.Size(157, 17);
            this.chkInputCEDXls.TabIndex = 3;
            this.chkInputCEDXls.Text = "CED Generic XLS Price File";
            this.chkInputCEDXls.UseVisualStyleBackColor = true;
            this.chkInputCEDXls.Click += new System.EventHandler(this.chkInput_Click);
            // 
            // chkInputMfrCat
            // 
            this.chkInputMfrCat.AutoSize = true;
            this.chkInputMfrCat.Location = new System.Drawing.Point(7, 68);
            this.chkInputMfrCat.Name = "chkInputMfrCat";
            this.chkInputMfrCat.Size = new System.Drawing.Size(84, 17);
            this.chkInputMfrCat.TabIndex = 2;
            this.chkInputMfrCat.Text = "Mfr Cat Only";
            this.chkInputMfrCat.UseVisualStyleBackColor = true;
            this.chkInputMfrCat.Click += new System.EventHandler(this.chkInput_Click);
            // 
            // chkInputVMIImage
            // 
            this.chkInputVMIImage.AutoSize = true;
            this.chkInputVMIImage.Location = new System.Drawing.Point(7, 44);
            this.chkInputVMIImage.Name = "chkInputVMIImage";
            this.chkInputVMIImage.Size = new System.Drawing.Size(145, 17);
            this.chkInputVMIImage.TabIndex = 1;
            this.chkInputVMIImage.Text = "VMI With Image Override";
            this.chkInputVMIImage.UseVisualStyleBackColor = true;
            this.chkInputVMIImage.Click += new System.EventHandler(this.chkInput_Click);
            // 
            // chkInputVMI
            // 
            this.chkInputVMI.AutoSize = true;
            this.chkInputVMI.Checked = true;
            this.chkInputVMI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInputVMI.Location = new System.Drawing.Point(7, 20);
            this.chkInputVMI.Name = "chkInputVMI";
            this.chkInputVMI.Size = new System.Drawing.Size(45, 17);
            this.chkInputVMI.TabIndex = 0;
            this.chkInputVMI.Text = "VMI";
            this.chkInputVMI.UseVisualStyleBackColor = true;
            this.chkInputVMI.Click += new System.EventHandler(this.chkInput_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkOutput5162Image);
            this.groupBox2.Controls.Add(this.chkOutputDymo1x3);
            this.groupBox2.Controls.Add(this.chkOutput1x2Spool);
            this.groupBox2.Controls.Add(this.chkOutput1x3Spool);
            this.groupBox2.Controls.Add(this.chkOutput2x3MinSpool);
            this.groupBox2.Controls.Add(this.chkOutput2x3Spool);
            this.groupBox2.Controls.Add(this.chkOutput1x2Sheet);
            this.groupBox2.Controls.Add(this.chkOutput1x3Sheet);
            this.groupBox2.Controls.Add(this.chkOutput2x3MinSheet);
            this.groupBox2.Controls.Add(this.chkOutput2x3Sheet);
            this.groupBox2.Controls.Add(this.chkOutput5162);
            this.groupBox2.Controls.Add(this.chkOutput5160);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox2.Location = new System.Drawing.Point(13, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 317);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preloaded Output Labels";
            // 
            // chkOutput5162Image
            // 
            this.chkOutput5162Image.AutoSize = true;
            this.chkOutput5162Image.Location = new System.Drawing.Point(7, 284);
            this.chkOutput5162Image.Name = "chkOutput5162Image";
            this.chkOutput5162Image.Size = new System.Drawing.Size(176, 17);
            this.chkOutput5162Image.TabIndex = 11;
            this.chkOutput5162Image.Text = "Avery 5162 Sheets (with Image)";
            this.chkOutput5162Image.UseVisualStyleBackColor = true;
            this.chkOutput5162Image.Click += new System.EventHandler(this.chkOutput_Click);
            // 
            // chkOutputDymo1x3
            // 
            this.chkOutputDymo1x3.AutoSize = true;
            this.chkOutputDymo1x3.Location = new System.Drawing.Point(7, 260);
            this.chkOutputDymo1x3.Name = "chkOutputDymo1x3";
            this.chkOutputDymo1x3.Size = new System.Drawing.Size(136, 17);
            this.chkOutputDymo1x3.TabIndex = 10;
            this.chkOutputDymo1x3.Text = "Dymo 1x3 Spool Printer";
            this.chkOutputDymo1x3.UseVisualStyleBackColor = true;
            this.chkOutputDymo1x3.Click += new System.EventHandler(this.chkOutput_Click);
            // 
            // chkOutput1x2Spool
            // 
            this.chkOutput1x2Spool.AutoSize = true;
            this.chkOutput1x2Spool.Location = new System.Drawing.Point(7, 236);
            this.chkOutput1x2Spool.Name = "chkOutput1x2Spool";
            this.chkOutput1x2Spool.Size = new System.Drawing.Size(145, 17);
            this.chkOutput1x2Spool.TabIndex = 9;
            this.chkOutput1x2Spool.Text = "Panduit 1x2 Spool Printer";
            this.chkOutput1x2Spool.UseVisualStyleBackColor = true;
            this.chkOutput1x2Spool.Click += new System.EventHandler(this.chkOutput_Click);
            // 
            // chkOutput1x3Spool
            // 
            this.chkOutput1x3Spool.AutoSize = true;
            this.chkOutput1x3Spool.Location = new System.Drawing.Point(7, 212);
            this.chkOutput1x3Spool.Name = "chkOutput1x3Spool";
            this.chkOutput1x3Spool.Size = new System.Drawing.Size(145, 17);
            this.chkOutput1x3Spool.TabIndex = 8;
            this.chkOutput1x3Spool.Text = "Panduit 1x3 Spool Printer";
            this.chkOutput1x3Spool.UseVisualStyleBackColor = true;
            this.chkOutput1x3Spool.Click += new System.EventHandler(this.chkOutput_Click);
            // 
            // chkOutput2x3MinSpool
            // 
            this.chkOutput2x3MinSpool.AutoSize = true;
            this.chkOutput2x3MinSpool.Location = new System.Drawing.Point(7, 188);
            this.chkOutput2x3MinSpool.Name = "chkOutput2x3MinSpool";
            this.chkOutput2x3MinSpool.Size = new System.Drawing.Size(189, 17);
            this.chkOutput2x3MinSpool.TabIndex = 7;
            this.chkOutput2x3MinSpool.Text = "Panduit 2x3 (Minimal) Spool Printer";
            this.chkOutput2x3MinSpool.UseVisualStyleBackColor = true;
            this.chkOutput2x3MinSpool.Click += new System.EventHandler(this.chkOutput_Click);
            // 
            // chkOutput2x3Spool
            // 
            this.chkOutput2x3Spool.AutoSize = true;
            this.chkOutput2x3Spool.Location = new System.Drawing.Point(7, 164);
            this.chkOutput2x3Spool.Name = "chkOutput2x3Spool";
            this.chkOutput2x3Spool.Size = new System.Drawing.Size(145, 17);
            this.chkOutput2x3Spool.TabIndex = 6;
            this.chkOutput2x3Spool.Text = "Panduit 2x3 Spool Printer";
            this.chkOutput2x3Spool.UseVisualStyleBackColor = true;
            this.chkOutput2x3Spool.Click += new System.EventHandler(this.chkOutput_Click);
            // 
            // chkOutput1x2Sheet
            // 
            this.chkOutput1x2Sheet.AutoSize = true;
            this.chkOutput1x2Sheet.Location = new System.Drawing.Point(7, 140);
            this.chkOutput1x2Sheet.Name = "chkOutput1x2Sheet";
            this.chkOutput1x2Sheet.Size = new System.Drawing.Size(113, 17);
            this.chkOutput1x2Sheet.TabIndex = 5;
            this.chkOutput1x2Sheet.Text = "Panduit 1x2 Sheet";
            this.chkOutput1x2Sheet.UseVisualStyleBackColor = true;
            this.chkOutput1x2Sheet.Click += new System.EventHandler(this.chkOutput_Click);
            // 
            // chkOutput1x3Sheet
            // 
            this.chkOutput1x3Sheet.AutoSize = true;
            this.chkOutput1x3Sheet.Location = new System.Drawing.Point(7, 116);
            this.chkOutput1x3Sheet.Name = "chkOutput1x3Sheet";
            this.chkOutput1x3Sheet.Size = new System.Drawing.Size(118, 17);
            this.chkOutput1x3Sheet.TabIndex = 4;
            this.chkOutput1x3Sheet.Text = "Panduit 1x3 Sheets";
            this.chkOutput1x3Sheet.UseVisualStyleBackColor = true;
            this.chkOutput1x3Sheet.Click += new System.EventHandler(this.chkOutput_Click);
            // 
            // chkOutput2x3MinSheet
            // 
            this.chkOutput2x3MinSheet.AutoSize = true;
            this.chkOutput2x3MinSheet.Location = new System.Drawing.Point(7, 92);
            this.chkOutput2x3MinSheet.Name = "chkOutput2x3MinSheet";
            this.chkOutput2x3MinSheet.Size = new System.Drawing.Size(162, 17);
            this.chkOutput2x3MinSheet.TabIndex = 3;
            this.chkOutput2x3MinSheet.Text = "Panduit 2x3 Sheets (Minimal)";
            this.chkOutput2x3MinSheet.UseVisualStyleBackColor = true;
            this.chkOutput2x3MinSheet.Click += new System.EventHandler(this.chkOutput_Click);
            // 
            // chkOutput2x3Sheet
            // 
            this.chkOutput2x3Sheet.AutoSize = true;
            this.chkOutput2x3Sheet.Location = new System.Drawing.Point(7, 68);
            this.chkOutput2x3Sheet.Name = "chkOutput2x3Sheet";
            this.chkOutput2x3Sheet.Size = new System.Drawing.Size(118, 17);
            this.chkOutput2x3Sheet.TabIndex = 2;
            this.chkOutput2x3Sheet.Text = "Panduit 2x3 Sheets";
            this.chkOutput2x3Sheet.UseVisualStyleBackColor = true;
            this.chkOutput2x3Sheet.Click += new System.EventHandler(this.chkOutput_Click);
            // 
            // chkOutput5162
            // 
            this.chkOutput5162.AutoSize = true;
            this.chkOutput5162.Checked = true;
            this.chkOutput5162.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutput5162.Location = new System.Drawing.Point(7, 44);
            this.chkOutput5162.Name = "chkOutput5162";
            this.chkOutput5162.Size = new System.Drawing.Size(116, 17);
            this.chkOutput5162.TabIndex = 1;
            this.chkOutput5162.Text = "Avery 5162 Sheets";
            this.chkOutput5162.UseVisualStyleBackColor = true;
            this.chkOutput5162.Click += new System.EventHandler(this.chkOutput_Click);
            // 
            // chkOutput5160
            // 
            this.chkOutput5160.AutoSize = true;
            this.chkOutput5160.Checked = true;
            this.chkOutput5160.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutput5160.Location = new System.Drawing.Point(7, 20);
            this.chkOutput5160.Name = "chkOutput5160";
            this.chkOutput5160.Size = new System.Drawing.Size(116, 17);
            this.chkOutput5160.TabIndex = 0;
            this.chkOutput5160.Text = "Avery 5160 Sheets";
            this.chkOutput5160.UseVisualStyleBackColor = true;
            this.chkOutput5160.Click += new System.EventHandler(this.chkOutput_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Best Practice - Only enable what you need";
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.DarkBlue;
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(244, 483);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(151, 36);
            this.btnDone.TabIndex = 3;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // frmPreloadedTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(407, 539);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPreloadedTypes";
            this.Text = "Preloaded Input Types / Preloaded Output Labels";
            this.Load += new System.EventHandler(this.frmPreloadedTypes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkInputCEDHotSheet;
        private System.Windows.Forms.CheckBox chkInputCED001;
        private System.Windows.Forms.CheckBox chkInputCEDXls;
        private System.Windows.Forms.CheckBox chkInputMfrCat;
        private System.Windows.Forms.CheckBox chkInputVMIImage;
        private System.Windows.Forms.CheckBox chkInputVMI;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkOutput5162Image;
        private System.Windows.Forms.CheckBox chkOutputDymo1x3;
        private System.Windows.Forms.CheckBox chkOutput1x2Spool;
        private System.Windows.Forms.CheckBox chkOutput1x3Spool;
        private System.Windows.Forms.CheckBox chkOutput2x3MinSpool;
        private System.Windows.Forms.CheckBox chkOutput2x3Spool;
        private System.Windows.Forms.CheckBox chkOutput1x2Sheet;
        private System.Windows.Forms.CheckBox chkOutput1x3Sheet;
        private System.Windows.Forms.CheckBox chkOutput2x3MinSheet;
        private System.Windows.Forms.CheckBox chkOutput2x3Sheet;
        private System.Windows.Forms.CheckBox chkOutput5162;
        private System.Windows.Forms.CheckBox chkOutput5160;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDone;
    }
}