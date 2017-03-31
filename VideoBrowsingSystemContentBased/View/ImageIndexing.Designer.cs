namespace VideoBrowsingSystemContentBased.View
{
    partial class ImageIndexing
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtR = new System.Windows.Forms.TextBox();
            this.txtG = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.adfa = new System.Windows.Forms.Label();
            this.rpVisualize = new System.Windows.Forms.GroupBox();
            this.pnVisualizse = new System.Windows.Forms.Panel();
            this.btnVisualize = new System.Windows.Forms.Button();
            this.pnListColor = new System.Windows.Forms.Panel();
            this.btnVisualizeListColor = new System.Windows.Forms.Button();
            this.rpVisualize.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "GenerateVisualWord";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtR
            // 
            this.txtR.Location = new System.Drawing.Point(46, 77);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(41, 20);
            this.txtR.TabIndex = 1;
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(134, 77);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(41, 20);
            this.txtG.TabIndex = 2;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(231, 77);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(41, 20);
            this.txtB.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "R";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "G";
            // 
            // adfa
            // 
            this.adfa.AutoSize = true;
            this.adfa.Location = new System.Drawing.Point(195, 80);
            this.adfa.Name = "adfa";
            this.adfa.Size = new System.Drawing.Size(14, 13);
            this.adfa.TabIndex = 6;
            this.adfa.Text = "B";
            // 
            // rpVisualize
            // 
            this.rpVisualize.Controls.Add(this.pnVisualizse);
            this.rpVisualize.Location = new System.Drawing.Point(15, 121);
            this.rpVisualize.Name = "rpVisualize";
            this.rpVisualize.Size = new System.Drawing.Size(257, 128);
            this.rpVisualize.TabIndex = 7;
            this.rpVisualize.TabStop = false;
            this.rpVisualize.Text = "Visualize";
            // 
            // pnVisualizse
            // 
            this.pnVisualizse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnVisualizse.Location = new System.Drawing.Point(3, 16);
            this.pnVisualizse.Name = "pnVisualizse";
            this.pnVisualizse.Size = new System.Drawing.Size(251, 109);
            this.pnVisualizse.TabIndex = 0;
            // 
            // btnVisualize
            // 
            this.btnVisualize.Location = new System.Drawing.Point(176, 12);
            this.btnVisualize.Name = "btnVisualize";
            this.btnVisualize.Size = new System.Drawing.Size(75, 23);
            this.btnVisualize.TabIndex = 8;
            this.btnVisualize.Text = "Visualize";
            this.btnVisualize.UseVisualStyleBackColor = true;
            this.btnVisualize.Click += new System.EventHandler(this.btnVisualize_Click);
            // 
            // pnListColor
            // 
            this.pnListColor.Location = new System.Drawing.Point(18, 315);
            this.pnListColor.Name = "pnListColor";
            this.pnListColor.Size = new System.Drawing.Size(536, 252);
            this.pnListColor.TabIndex = 9;
            // 
            // btnVisualizeListColor
            // 
            this.btnVisualizeListColor.Location = new System.Drawing.Point(388, 11);
            this.btnVisualizeListColor.Name = "btnVisualizeListColor";
            this.btnVisualizeListColor.Size = new System.Drawing.Size(112, 23);
            this.btnVisualizeListColor.TabIndex = 10;
            this.btnVisualizeListColor.Text = "Visualize List Color";
            this.btnVisualizeListColor.UseVisualStyleBackColor = true;
            this.btnVisualizeListColor.Click += new System.EventHandler(this.btnVisualizeListColor_Click);
            // 
            // ImageIndexing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 579);
            this.Controls.Add(this.btnVisualizeListColor);
            this.Controls.Add(this.pnListColor);
            this.Controls.Add(this.btnVisualize);
            this.Controls.Add(this.rpVisualize);
            this.Controls.Add(this.adfa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtG);
            this.Controls.Add(this.txtR);
            this.Controls.Add(this.button1);
            this.Name = "ImageIndexing";
            this.Text = "ImageIndexing";
            this.rpVisualize.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label adfa;
        private System.Windows.Forms.GroupBox rpVisualize;
        private System.Windows.Forms.Panel pnVisualizse;
        private System.Windows.Forms.Button btnVisualize;
        private System.Windows.Forms.Panel pnListColor;
        private System.Windows.Forms.Button btnVisualizeListColor;
    }
}