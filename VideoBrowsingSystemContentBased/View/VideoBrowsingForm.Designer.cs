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
            this.grbxVideoPlayer = new System.Windows.Forms.GroupBox();
            this.axWMP = new AxWMPLib.AxWindowsMediaPlayer();
            this.grbxSearchBySketch = new System.Windows.Forms.GroupBox();
            this.putColorAndSketch1 = new VideoBrowsingSystemContentBased.Widget.PutColorAndSketch();
            this.grbxSearchByText = new System.Windows.Forms.GroupBox();
            this.rbtnContent = new System.Windows.Forms.RadioButton();
            this.rbtnORC = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtTextQuery = new System.Windows.Forms.TextBox();
            this.tblpRoot.SuspendLayout();
            this.tblpLeft.SuspendLayout();
            this.grbxListFrame.SuspendLayout();
            this.grbxFrameShot.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grbxVideoPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWMP)).BeginInit();
            this.grbxSearchBySketch.SuspendLayout();
            this.grbxSearchByText.SuspendLayout();
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
            this.tblpRoot.Size = new System.Drawing.Size(1348, 721);
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
            this.tblpLeft.Size = new System.Drawing.Size(935, 713);
            this.tblpLeft.TabIndex = 0;
            // 
            // grbxListFrame
            // 
            this.grbxListFrame.Controls.Add(this.pnListFrame);
            this.grbxListFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbxListFrame.Location = new System.Drawing.Point(3, 2);
            this.grbxListFrame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxListFrame.Name = "grbxListFrame";
            this.grbxListFrame.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxListFrame.Size = new System.Drawing.Size(929, 566);
            this.grbxListFrame.TabIndex = 2;
            this.grbxListFrame.TabStop = false;
            this.grbxListFrame.Text = "Frames";
            // 
            // pnListFrame
            // 
            this.pnListFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnListFrame.Location = new System.Drawing.Point(3, 17);
            this.pnListFrame.Margin = new System.Windows.Forms.Padding(4);
            this.pnListFrame.Name = "pnListFrame";
            this.pnListFrame.Size = new System.Drawing.Size(923, 547);
            this.pnListFrame.TabIndex = 0;
            // 
            // grbxFrameShot
            // 
            this.grbxFrameShot.Controls.Add(this.pnFrameShot);
            this.grbxFrameShot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbxFrameShot.Location = new System.Drawing.Point(3, 572);
            this.grbxFrameShot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxFrameShot.Name = "grbxFrameShot";
            this.grbxFrameShot.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxFrameShot.Size = new System.Drawing.Size(929, 139);
            this.grbxFrameShot.TabIndex = 3;
            this.grbxFrameShot.TabStop = false;
            this.grbxFrameShot.Text = "Shot\'s frames";
            // 
            // pnFrameShot
            // 
            this.pnFrameShot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnFrameShot.Location = new System.Drawing.Point(3, 17);
            this.pnFrameShot.Margin = new System.Windows.Forms.Padding(4);
            this.pnFrameShot.Name = "pnFrameShot";
            this.pnFrameShot.Size = new System.Drawing.Size(923, 120);
            this.pnFrameShot.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbxVideoPlayer);
            this.panel1.Controls.Add(this.grbxSearchBySketch);
            this.panel1.Controls.Add(this.grbxSearchByText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(947, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 713);
            this.panel1.TabIndex = 1;
            // 
            // grbxVideoPlayer
            // 
            this.grbxVideoPlayer.Controls.Add(this.axWMP);
            this.grbxVideoPlayer.Location = new System.Drawing.Point(4, 506);
            this.grbxVideoPlayer.Name = "grbxVideoPlayer";
            this.grbxVideoPlayer.Size = new System.Drawing.Size(386, 260);
            this.grbxVideoPlayer.TabIndex = 5;
            this.grbxVideoPlayer.TabStop = false;
            this.grbxVideoPlayer.Text = "Video Player";
            // 
            // axWMP
            // 
            this.axWMP.Enabled = true;
            this.axWMP.Location = new System.Drawing.Point(6, 24);
            this.axWMP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axWMP.Name = "axWMP";
            this.axWMP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWMP.OcxState")));
            this.axWMP.Size = new System.Drawing.Size(300, 217);
            this.axWMP.TabIndex = 2;
            // 
            // grbxSearchBySketch
            // 
            this.grbxSearchBySketch.Controls.Add(this.putColorAndSketch1);
            this.grbxSearchBySketch.Location = new System.Drawing.Point(0, 98);
            this.grbxSearchBySketch.Margin = new System.Windows.Forms.Padding(4);
            this.grbxSearchBySketch.Name = "grbxSearchBySketch";
            this.grbxSearchBySketch.Padding = new System.Windows.Forms.Padding(4);
            this.grbxSearchBySketch.Size = new System.Drawing.Size(411, 401);
            this.grbxSearchBySketch.TabIndex = 4;
            this.grbxSearchBySketch.TabStop = false;
            this.grbxSearchBySketch.Text = "Search By Sketch";
            // 
            // putColorAndSketch1
            // 
            this.putColorAndSketch1.Location = new System.Drawing.Point(4, 19);
            this.putColorAndSketch1.Margin = new System.Windows.Forms.Padding(0);
            this.putColorAndSketch1.Name = "putColorAndSketch1";
            this.putColorAndSketch1.Size = new System.Drawing.Size(1108, 914);
            this.putColorAndSketch1.TabIndex = 0;
            // 
            // grbxSearchByText
            // 
            this.grbxSearchByText.Controls.Add(this.rbtnContent);
            this.grbxSearchByText.Controls.Add(this.rbtnORC);
            this.grbxSearchByText.Controls.Add(this.btnSearch);
            this.grbxSearchByText.Controls.Add(this.txtTextQuery);
            this.grbxSearchByText.Location = new System.Drawing.Point(0, 0);
            this.grbxSearchByText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxSearchByText.Name = "grbxSearchByText";
            this.grbxSearchByText.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxSearchByText.Size = new System.Drawing.Size(394, 97);
            this.grbxSearchByText.TabIndex = 3;
            this.grbxSearchByText.TabStop = false;
            this.grbxSearchByText.Text = "Search By Text";
            // 
            // rbtnContent
            // 
            this.rbtnContent.AutoSize = true;
            this.rbtnContent.Location = new System.Drawing.Point(309, 63);
            this.rbtnContent.Name = "rbtnContent";
            this.rbtnContent.Size = new System.Drawing.Size(78, 21);
            this.rbtnContent.TabIndex = 3;
            this.rbtnContent.TabStop = true;
            this.rbtnContent.Text = "Content";
            this.rbtnContent.UseVisualStyleBackColor = true;
            // 
            // rbtnORC
            // 
            this.rbtnORC.AutoSize = true;
            this.rbtnORC.Location = new System.Drawing.Point(236, 63);
            this.rbtnORC.Name = "rbtnORC";
            this.rbtnORC.Size = new System.Drawing.Size(59, 21);
            this.rbtnORC.TabIndex = 2;
            this.rbtnORC.TabStop = true;
            this.rbtnORC.Text = "ORC";
            this.rbtnORC.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::VideoBrowsingSystemContentBased.Properties.Resources.search_20x20;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(7, 56);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 34);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "    Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtTextQuery
            // 
            this.txtTextQuery.Location = new System.Drawing.Point(7, 22);
            this.txtTextQuery.Margin = new System.Windows.Forms.Padding(4);
            this.txtTextQuery.Name = "txtTextQuery";
            this.txtTextQuery.Size = new System.Drawing.Size(380, 22);
            this.txtTextQuery.TabIndex = 0;
            this.txtTextQuery.Text = "practice";
            // 
            // VideoBrowsingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.tblpRoot);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VideoBrowsingForm";
            this.Text = "Video Browsing System Content Based";
            this.tblpRoot.ResumeLayout(false);
            this.tblpLeft.ResumeLayout(false);
            this.grbxListFrame.ResumeLayout(false);
            this.grbxFrameShot.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grbxVideoPlayer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWMP)).EndInit();
            this.grbxSearchBySketch.ResumeLayout(false);
            this.grbxSearchByText.ResumeLayout(false);
            this.grbxSearchByText.PerformLayout();
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
        private System.Windows.Forms.GroupBox grbxSearchByText;
        private System.Windows.Forms.GroupBox grbxSearchBySketch;
        private Widget.PutColorAndSketch putColorAndSketch1;
        private System.Windows.Forms.RadioButton rbtnContent;
        private System.Windows.Forms.RadioButton rbtnORC;
        private System.Windows.Forms.GroupBox grbxVideoPlayer;

    }
}

