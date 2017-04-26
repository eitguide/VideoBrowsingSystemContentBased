namespace VideoBrowsingSystemContentBased.View
{
    partial class ViewPCTImage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOpenRandomImage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnCIE2000 = new System.Windows.Forms.RadioButton();
            this.rbtnCIE94 = new System.Windows.Forms.RadioButton();
            this.rbtnCMCIC = new System.Windows.Forms.RadioButton();
            this.rbtnCIE76 = new System.Windows.Forms.RadioButton();
            this.rbtnRgbEuclid = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFileNameNoExtension = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(12, 633);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(980, 60);
            this.panel2.TabIndex = 1;
            // 
            // btnOpenRandomImage
            // 
            this.btnOpenRandomImage.Location = new System.Drawing.Point(123, 51);
            this.btnOpenRandomImage.Name = "btnOpenRandomImage";
            this.btnOpenRandomImage.Size = new System.Drawing.Size(75, 68);
            this.btnOpenRandomImage.TabIndex = 2;
            this.btnOpenRandomImage.Text = "Open Random Image";
            this.btnOpenRandomImage.UseVisualStyleBackColor = true;
            this.btnOpenRandomImage.Click += new System.EventHandler(this.btnOpenRandomImage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnCIE2000);
            this.groupBox1.Controls.Add(this.rbtnCIE94);
            this.groupBox1.Controls.Add(this.rbtnCMCIC);
            this.groupBox1.Controls.Add(this.rbtnCIE76);
            this.groupBox1.Controls.Add(this.rbtnRgbEuclid);
            this.groupBox1.Controls.Add(this.btnOpenRandomImage);
            this.groupBox1.Location = new System.Drawing.Point(762, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 158);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // rbtnCIE2000
            // 
            this.rbtnCIE2000.AutoSize = true;
            this.rbtnCIE2000.Location = new System.Drawing.Point(7, 129);
            this.rbtnCIE2000.Name = "rbtnCIE2000";
            this.rbtnCIE2000.Size = new System.Drawing.Size(82, 21);
            this.rbtnCIE2000.TabIndex = 7;
            this.rbtnCIE2000.TabStop = true;
            this.rbtnCIE2000.Text = "CIE2000";
            this.rbtnCIE2000.UseVisualStyleBackColor = true;
            // 
            // rbtnCIE94
            // 
            this.rbtnCIE94.AutoSize = true;
            this.rbtnCIE94.Location = new System.Drawing.Point(7, 102);
            this.rbtnCIE94.Name = "rbtnCIE94";
            this.rbtnCIE94.Size = new System.Drawing.Size(66, 21);
            this.rbtnCIE94.TabIndex = 6;
            this.rbtnCIE94.TabStop = true;
            this.rbtnCIE94.Text = "CIE94";
            this.rbtnCIE94.UseVisualStyleBackColor = true;
            // 
            // rbtnCMCIC
            // 
            this.rbtnCMCIC.AutoSize = true;
            this.rbtnCMCIC.Location = new System.Drawing.Point(7, 75);
            this.rbtnCMCIC.Name = "rbtnCMCIC";
            this.rbtnCMCIC.Size = new System.Drawing.Size(76, 21);
            this.rbtnCMCIC.TabIndex = 5;
            this.rbtnCMCIC.TabStop = true;
            this.rbtnCMCIC.Text = "CMC I:c";
            this.rbtnCMCIC.UseVisualStyleBackColor = true;
            // 
            // rbtnCIE76
            // 
            this.rbtnCIE76.AutoSize = true;
            this.rbtnCIE76.Location = new System.Drawing.Point(7, 48);
            this.rbtnCIE76.Name = "rbtnCIE76";
            this.rbtnCIE76.Size = new System.Drawing.Size(66, 21);
            this.rbtnCIE76.TabIndex = 4;
            this.rbtnCIE76.TabStop = true;
            this.rbtnCIE76.Text = "CIE76";
            this.rbtnCIE76.UseVisualStyleBackColor = true;
            // 
            // rbtnRgbEuclid
            // 
            this.rbtnRgbEuclid.AutoSize = true;
            this.rbtnRgbEuclid.Location = new System.Drawing.Point(7, 21);
            this.rbtnRgbEuclid.Name = "rbtnRgbEuclid";
            this.rbtnRgbEuclid.Size = new System.Drawing.Size(97, 21);
            this.rbtnRgbEuclid.TabIndex = 3;
            this.rbtnRgbEuclid.TabStop = true;
            this.rbtnRgbEuclid.Text = "Rgb Euclid";
            this.rbtnRgbEuclid.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFileNameNoExtension);
            this.groupBox2.Location = new System.Drawing.Point(620, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 52);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // txtFileNameNoExtension
            // 
            this.txtFileNameNoExtension.Location = new System.Drawing.Point(7, 22);
            this.txtFileNameNoExtension.Name = "txtFileNameNoExtension";
            this.txtFileNameNoExtension.Size = new System.Drawing.Size(329, 22);
            this.txtFileNameNoExtension.TabIndex = 0;
            // 
            // ViewPCTImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 724);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ViewPCTImage";
            this.Text = "ViewPCTImage";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOpenRandomImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnCIE2000;
        private System.Windows.Forms.RadioButton rbtnCIE94;
        private System.Windows.Forms.RadioButton rbtnCMCIC;
        private System.Windows.Forms.RadioButton rbtnCIE76;
        private System.Windows.Forms.RadioButton rbtnRgbEuclid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFileNameNoExtension;
    }
}