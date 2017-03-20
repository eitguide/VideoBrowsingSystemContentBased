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
            this.grbxListFrame = new System.Windows.Forms.GroupBox();
            this.pnListFrame = new System.Windows.Forms.Panel();
            this.grbxFrameShot = new System.Windows.Forms.GroupBox();
            this.pnFrameShot = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbxSearchByText = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtTextQuery = new System.Windows.Forms.TextBox();
            this.axWMP = new AxWMPLib.AxWindowsMediaPlayer();
            this.colorDottingUC1 = new VideoBrowsingSystemContentBased.Widget.ColorDottingUC();
            this.tblpRoot.SuspendLayout();
            this.tblpLeft.SuspendLayout();
            this.grbxListFrame.SuspendLayout();
            this.grbxFrameShot.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbxSearchByText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWMP)).BeginInit();
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
            this.tblpRoot.Margin = new System.Windows.Forms.Padding(4);
            this.tblpRoot.Name = "tblpRoot";
            this.tblpRoot.RowCount = 1;
            this.tblpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblpRoot.Size = new System.Drawing.Size(1045, 690);
            this.tblpRoot.TabIndex = 0;
            // 
            // tblpLeft
            // 
            this.tblpLeft.ColumnCount = 1;
            this.tblpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblpLeft.Controls.Add(this.grbxListFrame, 0, 0);
            this.tblpLeft.Controls.Add(this.grbxFrameShot, 0, 1);
            this.tblpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpLeft.Location = new System.Drawing.Point(4, 4);
            this.tblpLeft.Margin = new System.Windows.Forms.Padding(4);
            this.tblpLeft.Name = "tblpLeft";
            this.tblpLeft.RowCount = 2;
            this.tblpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tblpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblpLeft.Size = new System.Drawing.Size(723, 682);
            this.tblpLeft.TabIndex = 0;
            // 
            // grbxListFrame
            // 
            this.grbxListFrame.Controls.Add(this.pnListFrame);
            this.grbxListFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbxListFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbxListFrame.Location = new System.Drawing.Point(3, 3);
            this.grbxListFrame.Name = "grbxListFrame";
            this.grbxListFrame.Size = new System.Drawing.Size(717, 539);
            this.grbxListFrame.TabIndex = 2;
            this.grbxListFrame.TabStop = false;
            this.grbxListFrame.Text = "Frames";
            // 
            // pnListFrame
            // 
            this.pnListFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnListFrame.Location = new System.Drawing.Point(3, 22);
            this.pnListFrame.Margin = new System.Windows.Forms.Padding(4);
            this.pnListFrame.Name = "pnListFrame";
            this.pnListFrame.Size = new System.Drawing.Size(711, 514);
            this.pnListFrame.TabIndex = 0;
            // 
            // grbxFrameShot
            // 
            this.grbxFrameShot.Controls.Add(this.pnFrameShot);
            this.grbxFrameShot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbxFrameShot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbxFrameShot.Location = new System.Drawing.Point(3, 548);
            this.grbxFrameShot.Name = "grbxFrameShot";
            this.grbxFrameShot.Size = new System.Drawing.Size(717, 131);
            this.grbxFrameShot.TabIndex = 3;
            this.grbxFrameShot.TabStop = false;
            this.grbxFrameShot.Text = "Shot\'s frames";
            // 
            // pnFrameShot
            // 
            this.pnFrameShot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnFrameShot.Location = new System.Drawing.Point(3, 22);
            this.pnFrameShot.Margin = new System.Windows.Forms.Padding(4);
            this.pnFrameShot.Name = "pnFrameShot";
            this.pnFrameShot.Size = new System.Drawing.Size(711, 106);
            this.pnFrameShot.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.grbxSearchByText);
            this.panel1.Controls.Add(this.axWMP);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(735, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 682);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.colorDottingUC1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 318);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By Dotting Color";
            // 
            // grbxSearchByText
            // 
            this.grbxSearchByText.Controls.Add(this.btnSearch);
            this.grbxSearchByText.Controls.Add(this.txtTextQuery);
            this.grbxSearchByText.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbxSearchByText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbxSearchByText.Location = new System.Drawing.Point(0, 0);
            this.grbxSearchByText.Name = "grbxSearchByText";
            this.grbxSearchByText.Size = new System.Drawing.Size(306, 98);
            this.grbxSearchByText.TabIndex = 3;
            this.grbxSearchByText.TabStop = false;
            this.grbxSearchByText.Text = "Search By Text";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(7, 56);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtTextQuery
            // 
            this.txtTextQuery.Location = new System.Drawing.Point(7, 22);
            this.txtTextQuery.Margin = new System.Windows.Forms.Padding(4);
            this.txtTextQuery.Name = "txtTextQuery";
            this.txtTextQuery.Size = new System.Drawing.Size(275, 26);
            this.txtTextQuery.TabIndex = 0;
            this.txtTextQuery.Text = "practice";
            // 
            // axWMP
            // 
            this.axWMP.Enabled = true;
            this.axWMP.Location = new System.Drawing.Point(3, 458);
            this.axWMP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axWMP.Name = "axWMP";
            this.axWMP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWMP.OcxState")));
            this.axWMP.Size = new System.Drawing.Size(300, 217);
            this.axWMP.TabIndex = 2;
            // 
            // colorDottingUC1
            // 
            this.colorDottingUC1.Location = new System.Drawing.Point(3, 22);
            this.colorDottingUC1.Name = "colorDottingUC1";
            this.colorDottingUC1.Size = new System.Drawing.Size(293, 293);
            this.colorDottingUC1.TabIndex = 0;
            // 
            // VideoBrowsingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 690);
            this.Controls.Add(this.tblpRoot);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VideoBrowsingForm";
            this.Text = "Video Browsing System Content Based";
            this.tblpRoot.ResumeLayout(false);
            this.tblpLeft.ResumeLayout(false);
            this.grbxListFrame.ResumeLayout(false);
            this.grbxFrameShot.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grbxSearchByText.ResumeLayout(false);
            this.grbxSearchByText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWMP)).EndInit();
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
        private System.Windows.Forms.GroupBox grbxListFrame;
        private System.Windows.Forms.GroupBox grbxFrameShot;
        private System.Windows.Forms.GroupBox groupBox1;
        private Widget.ColorDottingUC colorDottingUC1;
        private System.Windows.Forms.GroupBox grbxSearchByText;

    }
}

