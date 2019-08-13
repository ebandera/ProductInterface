namespace ProductInterface
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsAndConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMappings = new System.Windows.Forms.ComboBox();
            this.cboOutput = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelInput = new System.Windows.Forms.Button();
            this.btnDelOutput = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtFileName
            // 
            this.txtFileName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtFileName.Location = new System.Drawing.Point(21, 119);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(239, 20);
            this.txtFileName.TabIndex = 11;
            this.txtFileName.Text = "Choose Data File";
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.BackColor = System.Drawing.Color.DarkBlue;
            this.btnLoadFile.ForeColor = System.Drawing.Color.White;
            this.btnLoadFile.Location = new System.Drawing.Point(266, 116);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(101, 23);
            this.btnLoadFile.TabIndex = 12;
            this.btnLoadFile.Text = "Browse";
            this.btnLoadFile.UseVisualStyleBackColor = false;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkBlue;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(21, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Produce Output";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkBlue;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsAndConfigToolStripMenuItem,
            this.productManualToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(379, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsAndConfigToolStripMenuItem
            // 
            this.settingsAndConfigToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsAndConfigToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsAndConfigToolStripMenuItem.Name = "settingsAndConfigToolStripMenuItem";
            this.settingsAndConfigToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.settingsAndConfigToolStripMenuItem.Text = "Settings and Config";
            this.settingsAndConfigToolStripMenuItem.Click += new System.EventHandler(this.settingsAndConfigToolStripMenuItem_Click);
            // 
            // productManualToolStripMenuItem
            // 
            this.productManualToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productManualToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.productManualToolStripMenuItem.Name = "productManualToolStripMenuItem";
            this.productManualToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.productManualToolStripMenuItem.Text = "Product Manual";
            this.productManualToolStripMenuItem.Click += new System.EventHandler(this.productManualToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(21, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Input Type";
            // 
            // cboMappings
            // 
            this.cboMappings.FormattingEnabled = true;
            this.cboMappings.Location = new System.Drawing.Point(21, 49);
            this.cboMappings.Name = "cboMappings";
            this.cboMappings.Size = new System.Drawing.Size(239, 21);
            this.cboMappings.TabIndex = 29;
            // 
            // cboOutput
            // 
            this.cboOutput.FormattingEnabled = true;
            this.cboOutput.Location = new System.Drawing.Point(21, 84);
            this.cboOutput.Name = "cboOutput";
            this.cboOutput.Size = new System.Drawing.Size(239, 21);
            this.cboOutput.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(21, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Output Type";
            // 
            // btnDelInput
            // 
            this.btnDelInput.BackColor = System.Drawing.Color.DarkBlue;
            this.btnDelInput.ForeColor = System.Drawing.Color.White;
            this.btnDelInput.Location = new System.Drawing.Point(266, 47);
            this.btnDelInput.Name = "btnDelInput";
            this.btnDelInput.Size = new System.Drawing.Size(101, 23);
            this.btnDelInput.TabIndex = 33;
            this.btnDelInput.Text = "Delete Input";
            this.btnDelInput.UseVisualStyleBackColor = false;
            this.btnDelInput.Click += new System.EventHandler(this.btnDelInput_Click);
            // 
            // btnDelOutput
            // 
            this.btnDelOutput.BackColor = System.Drawing.Color.DarkBlue;
            this.btnDelOutput.ForeColor = System.Drawing.Color.White;
            this.btnDelOutput.Location = new System.Drawing.Point(266, 82);
            this.btnDelOutput.Name = "btnDelOutput";
            this.btnDelOutput.Size = new System.Drawing.Size(101, 23);
            this.btnDelOutput.TabIndex = 34;
            this.btnDelOutput.Text = "Delete Output";
            this.btnDelOutput.UseVisualStyleBackColor = false;
            this.btnDelOutput.Click += new System.EventHandler(this.btnDelOutput_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(21, 184);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(346, 23);
            this.progressBar1.TabIndex = 35;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(379, 213);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnDelOutput);
            this.Controls.Add(this.btnDelInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboOutput);
            this.Controls.Add(this.cboMappings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CEDNet Label Print Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMappings;
        private System.Windows.Forms.ComboBox cboOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelInput;
        private System.Windows.Forms.Button btnDelOutput;
        private System.Windows.Forms.ToolStripMenuItem settingsAndConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productManualToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

