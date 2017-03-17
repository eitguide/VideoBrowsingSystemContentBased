namespace VideoBrowsingSystemContentBased
{
    partial class VideoBrowsingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoBrowsingForm));
            this.tblpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.tblpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.pnListFrame = new System.Windows.Forms.Panel();
            this.pnFrameShot = new System.Windows.Forms.Panel();
            this.txtTextQuery = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.axWMP = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblpRoot.SuspendLayout();
            this.tblpLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWMP)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblpRoot
            // 
            this.tblpRoot.ColumnCount = 2;
            this.tblpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblpRoot.Controls.Add(this.tblpLeft, 0, 0);
            this.tblpRoot.Controls.Add(this.panel1, 1, 0);
            this.tblpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpRoot.Location = new System.Drawing.Point(0, 0);
            this.tblpRoot.Name = "tblpRoot";
            this.tblpRoot.RowCount = 1;
            this.tblpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblpRoot.Size = new System.Drawing.Size(784, 561);
            this.tblpRoot.TabIndex = 0;
            // 
            // tblpLeft
            // 
            this.tblpLeft.ColumnCount = 1;
            this.tblpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblpLeft.Controls.Add(this.pnListFrame, 0, 0);
            this.tblpLeft.Controls.Add(this.pnFrameShot, 0, 1);
            this.tblpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpLeft.Location = new System.Drawing.Point(3, 3);
            this.tblpLeft.Name = "tblpLeft";
            this.tblpLeft.RowCount = 2;
            this.tblpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tblpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblpLeft.Size = new System.Drawing.Size(542, 555);
            this.tblpLeft.TabIndex = 0;
            // 
            // pnListFrame
            // 
            this.pnListFrame.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnListFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnListFrame.Location = new System.Drawing.Point(3, 3);
            this.pnListFrame.Name = "pnListFrame";
            this.pnListFrame.Size = new System.Drawing.Size(536, 438);
            this.pnListFrame.TabIndex = 0;
            // 
            // pnFrameShot
            // 
            this.pnFrameShot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pnFrameShot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnFrameShot.Location = new System.Drawing.Point(3, 447);
            this.pnFrameShot.Name = "pnFrameShot";
            this.pnFrameShot.Size = new System.Drawing.Size(536, 105);
            this.pnFrameShot.TabIndex = 1;
            // 
            // txtTextQuery
            // 
            this.txtTextQuery.Location = new System.Drawing.Point(14, 29);
            this.txtTextQuery.Name = "txtTextQuery";
            this.txtTextQuery.Size = new System.Drawing.Size(207, 20);
            this.txtTextQuery.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(146, 55);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // axWMP
            // 
            this.axWMP.Enabled = true;
            this.axWMP.Location = new System.Drawing.Point(3, 366);
            this.axWMP.Margin = new System.Windows.Forms.Padding(2);
            this.axWMP.Name = "axWMP";
            this.axWMP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWMP.OcxState")));
            this.axWMP.Size = new System.Drawing.Size(300, 308);
            this.axWMP.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.axWMP);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtTextQuery);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(551, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 555);
            this.panel1.TabIndex = 1;
            // 
            // VideoBrowsingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tblpRoot);
            this.Name = "VideoBrowsingForm";
            this.Text = "Video Browsing System Content Based";
            this.tblpRoot.ResumeLayout(false);
            this.tblpLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWMP)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblpRoot;
        private System.Windows.Forms.TableLayoutPanel tblpLeft;
        private System.Windows.Forms.Panel pnListFrame;
        private System.Windows.Forms.Panel pnFrameShot;
        private System.Windows.Forms.Panel panel1;
        private AxWMPLib.AxWindowsMediaPlayer axWMP;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtTextQuery;

    }
}

