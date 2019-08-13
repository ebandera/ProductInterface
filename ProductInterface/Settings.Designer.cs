namespace ProductInterface
{
    partial class Settings
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
            this.lblOffsetX = new System.Windows.Forms.Label();
            this.lblOffsetY = new System.Windows.Forms.Label();
            this.lblMapping = new System.Windows.Forms.Label();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.numOffsetX = new System.Windows.Forms.NumericUpDown();
            this.numOffsetY = new System.Windows.Forms.NumericUpDown();
            this.chkAddlDataRetrieve = new System.Windows.Forms.CheckBox();
            this.chkAddlDataRequire = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblPCNum = new System.Windows.Forms.Label();
            this.lblAcctNum = new System.Windows.Forms.Label();
            this.txtAcctNum = new System.Windows.Forms.TextBox();
            this.txtPCNum = new System.Windows.Forms.TextBox();
            this.lblValPC = new System.Windows.Forms.Label();
            this.lblValAcct = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.productManualContainsAdditionalInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preloadedInputsOutputsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblLogo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOffsetX
            // 
            this.lblOffsetX.AutoSize = true;
            this.lblOffsetX.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblOffsetX.Location = new System.Drawing.Point(22, 196);
            this.lblOffsetX.Name = "lblOffsetX";
            this.lblOffsetX.Size = new System.Drawing.Size(197, 13);
            this.lblOffsetX.TabIndex = 0;
            this.lblOffsetX.Text = "Left-Right Alignment (higher moves right)";
            // 
            // lblOffsetY
            // 
            this.lblOffsetY.AutoSize = true;
            this.lblOffsetY.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblOffsetY.Location = new System.Drawing.Point(22, 230);
            this.lblOffsetY.Name = "lblOffsetY";
            this.lblOffsetY.Size = new System.Drawing.Size(202, 13);
            this.lblOffsetY.TabIndex = 1;
            this.lblOffsetY.Text = "Up-Down Alignment (higher moves down)";
            // 
            // lblMapping
            // 
            this.lblMapping.AutoSize = true;
            this.lblMapping.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMapping.Location = new System.Drawing.Point(22, 264);
            this.lblMapping.Name = "lblMapping";
            this.lblMapping.Size = new System.Drawing.Size(195, 13);
            this.lblMapping.TabIndex = 2;
            this.lblMapping.Text = "Load In Mapping Template for Input File";
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.BackColor = System.Drawing.Color.DarkBlue;
            this.btnBrowseInput.ForeColor = System.Drawing.Color.White;
            this.btnBrowseInput.Location = new System.Drawing.Point(250, 259);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(121, 23);
            this.btnBrowseInput.TabIndex = 3;
            this.btnBrowseInput.Text = "Browse";
            this.btnBrowseInput.UseVisualStyleBackColor = false;
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblOutput.Location = new System.Drawing.Point(22, 298);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(137, 13);
            this.lblOutput.TabIndex = 4;
            this.lblOutput.Text = "Load in New Output Format";
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.BackColor = System.Drawing.Color.DarkBlue;
            this.btnBrowseOutput.ForeColor = System.Drawing.Color.White;
            this.btnBrowseOutput.Location = new System.Drawing.Point(250, 293);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(121, 23);
            this.btnBrowseOutput.TabIndex = 5;
            this.btnBrowseOutput.Text = "Browse";
            this.btnBrowseOutput.UseVisualStyleBackColor = false;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // numOffsetX
            // 
            this.numOffsetX.ForeColor = System.Drawing.Color.DarkBlue;
            this.numOffsetX.Location = new System.Drawing.Point(250, 194);
            this.numOffsetX.Name = "numOffsetX";
            this.numOffsetX.Size = new System.Drawing.Size(119, 20);
            this.numOffsetX.TabIndex = 6;
            // 
            // numOffsetY
            // 
            this.numOffsetY.ForeColor = System.Drawing.Color.DarkBlue;
            this.numOffsetY.Location = new System.Drawing.Point(250, 228);
            this.numOffsetY.Name = "numOffsetY";
            this.numOffsetY.Size = new System.Drawing.Size(119, 20);
            this.numOffsetY.TabIndex = 7;
            // 
            // chkAddlDataRetrieve
            // 
            this.chkAddlDataRetrieve.AutoSize = true;
            this.chkAddlDataRetrieve.Checked = true;
            this.chkAddlDataRetrieve.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddlDataRetrieve.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkAddlDataRetrieve.Location = new System.Drawing.Point(25, 349);
            this.chkAddlDataRetrieve.Name = "chkAddlDataRetrieve";
            this.chkAddlDataRetrieve.Size = new System.Drawing.Size(259, 17);
            this.chkAddlDataRetrieve.TabIndex = 8;
            this.chkAddlDataRetrieve.Text = "Retrieve All Additional Data From Product Record";
            this.chkAddlDataRetrieve.UseVisualStyleBackColor = true;
            this.chkAddlDataRetrieve.CheckedChanged += new System.EventHandler(this.chkAddlDataRetrieve_CheckedChanged);
            // 
            // chkAddlDataRequire
            // 
            this.chkAddlDataRequire.AutoSize = true;
            this.chkAddlDataRequire.Enabled = false;
            this.chkAddlDataRequire.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkAddlDataRequire.Location = new System.Drawing.Point(46, 373);
            this.chkAddlDataRequire.Name = "chkAddlDataRequire";
            this.chkAddlDataRequire.Size = new System.Drawing.Size(276, 17);
            this.chkAddlDataRequire.TabIndex = 9;
            this.chkAddlDataRequire.Text = "Only Include Products With Additional Data in Output";
            this.chkAddlDataRequire.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkBlue;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(25, 399);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(343, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblPCNum
            // 
            this.lblPCNum.AutoSize = true;
            this.lblPCNum.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblPCNum.Location = new System.Drawing.Point(22, 128);
            this.lblPCNum.Name = "lblPCNum";
            this.lblPCNum.Size = new System.Drawing.Size(61, 13);
            this.lblPCNum.TabIndex = 12;
            this.lblPCNum.Text = "PC Number";
            // 
            // lblAcctNum
            // 
            this.lblAcctNum.AutoSize = true;
            this.lblAcctNum.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblAcctNum.Location = new System.Drawing.Point(22, 162);
            this.lblAcctNum.Name = "lblAcctNum";
            this.lblAcctNum.Size = new System.Drawing.Size(124, 13);
            this.lblAcctNum.TabIndex = 13;
            this.lblAcctNum.Text = "Default Account Number";
            // 
            // txtAcctNum
            // 
            this.txtAcctNum.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtAcctNum.Location = new System.Drawing.Point(250, 159);
            this.txtAcctNum.Name = "txtAcctNum";
            this.txtAcctNum.Size = new System.Drawing.Size(119, 20);
            this.txtAcctNum.TabIndex = 14;
            this.txtAcctNum.Enter += new System.EventHandler(this.txtAcctNum_Enter);
            // 
            // txtPCNum
            // 
            this.txtPCNum.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtPCNum.Location = new System.Drawing.Point(250, 125);
            this.txtPCNum.Name = "txtPCNum";
            this.txtPCNum.Size = new System.Drawing.Size(119, 20);
            this.txtPCNum.TabIndex = 15;
            this.txtPCNum.Enter += new System.EventHandler(this.txtPCNum_Enter);
            // 
            // lblValPC
            // 
            this.lblValPC.AutoSize = true;
            this.lblValPC.ForeColor = System.Drawing.Color.Red;
            this.lblValPC.Location = new System.Drawing.Point(246, 113);
            this.lblValPC.Name = "lblValPC";
            this.lblValPC.Size = new System.Drawing.Size(125, 13);
            this.lblValPC.TabIndex = 16;
            this.lblValPC.Text = "* Must be 4 digit Numeric";
            this.lblValPC.Visible = false;
            // 
            // lblValAcct
            // 
            this.lblValAcct.AutoSize = true;
            this.lblValAcct.ForeColor = System.Drawing.Color.Red;
            this.lblValAcct.Location = new System.Drawing.Point(247, 148);
            this.lblValAcct.Name = "lblValAcct";
            this.lblValAcct.Size = new System.Drawing.Size(122, 13);
            this.lblValAcct.TabIndex = 17;
            this.lblValAcct.Text = "*Must be 5 digit Numeric";
            this.lblValAcct.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preloadedInputsOutputsToolStripMenuItem,
            this.productManualContainsAdditionalInformationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(380, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // productManualContainsAdditionalInformationToolStripMenuItem
            // 
            this.productManualContainsAdditionalInformationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productManualContainsAdditionalInformationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.productManualContainsAdditionalInformationToolStripMenuItem.Name = "productManualContainsAdditionalInformationToolStripMenuItem";
            this.productManualContainsAdditionalInformationToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.productManualContainsAdditionalInformationToolStripMenuItem.Text = "Product Manual";
            this.productManualContainsAdditionalInformationToolStripMenuItem.Click += new System.EventHandler(this.productManualContainsAdditionalInformationToolStripMenuItem_Click);
            // 
            // preloadedInputsOutputsToolStripMenuItem
            // 
            this.preloadedInputsOutputsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preloadedInputsOutputsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.preloadedInputsOutputsToolStripMenuItem.Name = "preloadedInputsOutputsToolStripMenuItem";
            this.preloadedInputsOutputsToolStripMenuItem.Size = new System.Drawing.Size(163, 20);
            this.preloadedInputsOutputsToolStripMenuItem.Text = "Preloaded Inputs/Outputs";
            this.preloadedInputsOutputsToolStripMenuItem.Click += new System.EventHandler(this.preloadedInputsOutputsToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(243, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 65);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Location = new System.Drawing.Point(13, 36);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(177, 13);
            this.lblLogo.TabIndex = 20;
            this.lblLogo.Text = "Location Logo (click logo to update)";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 436);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblValAcct);
            this.Controls.Add(this.lblValPC);
            this.Controls.Add(this.txtPCNum);
            this.Controls.Add(this.txtAcctNum);
            this.Controls.Add(this.lblAcctNum);
            this.Controls.Add(this.lblPCNum);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chkAddlDataRequire);
            this.Controls.Add(this.chkAddlDataRetrieve);
            this.Controls.Add(this.numOffsetY);
            this.Controls.Add(this.numOffsetX);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnBrowseInput);
            this.Controls.Add(this.lblMapping);
            this.Controls.Add(this.lblOffsetY);
            this.Controls.Add(this.lblOffsetX);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Settings";
            this.Text = "Settings and Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveSettings);
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOffsetX;
        private System.Windows.Forms.Label lblOffsetY;
        private System.Windows.Forms.Label lblMapping;
        private System.Windows.Forms.Button btnBrowseInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.NumericUpDown numOffsetX;
        private System.Windows.Forms.NumericUpDown numOffsetY;
        private System.Windows.Forms.CheckBox chkAddlDataRetrieve;
        private System.Windows.Forms.CheckBox chkAddlDataRequire;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblPCNum;
        private System.Windows.Forms.Label lblAcctNum;
        private System.Windows.Forms.TextBox txtAcctNum;
        private System.Windows.Forms.TextBox txtPCNum;
        private System.Windows.Forms.Label lblValPC;
        private System.Windows.Forms.Label lblValAcct;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem productManualContainsAdditionalInformationToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.ToolStripMenuItem preloadedInputsOutputsToolStripMenuItem;
    }
}