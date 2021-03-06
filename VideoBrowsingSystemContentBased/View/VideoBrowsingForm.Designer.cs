﻿namespace VideoBrowsingSystemContentBased
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
            this.tblpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.grbxListFrame = new System.Windows.Forms.GroupBox();
            this.grbxFrameShot = new System.Windows.Forms.GroupBox();
            this.pnFrameShot = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbxVideoPlayer = new System.Windows.Forms.GroupBox();
            this.axWMP = new AxWMPLib.AxWindowsMediaPlayer();
            this.grbxSearchBySketch = new System.Windows.Forms.GroupBox();
            this.btnSearchByImage = new System.Windows.Forms.Button();
            this.grbxSearchByText = new System.Windows.Forms.GroupBox();
            this.rbtnContent = new System.Windows.Forms.RadioButton();
            this.rbtnORC = new System.Windows.Forms.RadioButton();
            this.btnSearchByText = new System.Windows.Forms.Button();
            this.txtTextQuery = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lazypicscrListFrame = new VideoBrowsingSystemContentBased.Widget.LazyPictureScrolling();
            this.putColorAndSketchV2 = new VideoBrowsingSystemContentBased.Widget.PutColorAndSketchV2();
            this.tblpLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.grbxListFrame.SuspendLayout();
            this.grbxFrameShot.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grbxVideoPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWMP)).BeginInit();
            this.grbxSearchBySketch.SuspendLayout();
            this.grbxSearchByText.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblpLeft
            // 
            this.tblpLeft.ColumnCount = 1;
            this.tblpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblpLeft.Controls.Add(this.statusBar1, 0, 2);
            this.tblpLeft.Controls.Add(this.grbxListFrame, 0, 0);
            this.tblpLeft.Controls.Add(this.grbxFrameShot, 0, 1);
            this.tblpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpLeft.Location = new System.Drawing.Point(0, 0);
            this.tblpLeft.Margin = new System.Windows.Forms.Padding(4);
            this.tblpLeft.Name = "tblpLeft";
            this.tblpLeft.RowCount = 3;
            this.tblpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tblpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tblpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblpLeft.Size = new System.Drawing.Size(919, 697);
            this.tblpLeft.TabIndex = 0;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 677);
            this.statusBar1.Margin = new System.Windows.Forms.Padding(0);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(919, 20);
            this.statusBar1.TabIndex = 0;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 10;
            // 
            // grbxListFrame
            // 
            this.grbxListFrame.Controls.Add(this.lazypicscrListFrame);
            this.grbxListFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbxListFrame.Location = new System.Drawing.Point(3, 2);
            this.grbxListFrame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxListFrame.Name = "grbxListFrame";
            this.grbxListFrame.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxListFrame.Size = new System.Drawing.Size(913, 533);
            this.grbxListFrame.TabIndex = 2;
            this.grbxListFrame.TabStop = false;
            this.grbxListFrame.Text = "Frames";
            // 
            // grbxFrameShot
            // 
            this.grbxFrameShot.Controls.Add(this.pnFrameShot);
            this.grbxFrameShot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbxFrameShot.Location = new System.Drawing.Point(3, 539);
            this.grbxFrameShot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxFrameShot.Name = "grbxFrameShot";
            this.grbxFrameShot.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxFrameShot.Size = new System.Drawing.Size(913, 130);
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
            this.pnFrameShot.Size = new System.Drawing.Size(907, 111);
            this.pnFrameShot.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.grbxVideoPlayer);
            this.panel1.Controls.Add(this.grbxSearchBySketch);
            this.panel1.Controls.Add(this.grbxSearchByText);
            this.panel1.Location = new System.Drawing.Point(938, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 713);
            this.panel1.TabIndex = 1;
            // 
            // grbxVideoPlayer
            // 
            this.grbxVideoPlayer.Controls.Add(this.axWMP);
            this.grbxVideoPlayer.Location = new System.Drawing.Point(4, 506);
            this.grbxVideoPlayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxVideoPlayer.Name = "grbxVideoPlayer";
            this.grbxVideoPlayer.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxVideoPlayer.Size = new System.Drawing.Size(387, 260);
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
            this.axWMP.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.axWMP_PreviewKeyDown);
            // 
            // grbxSearchBySketch
            // 
            this.grbxSearchBySketch.Controls.Add(this.btnSearchByImage);
            this.grbxSearchBySketch.Controls.Add(this.putColorAndSketchV2);
            this.grbxSearchBySketch.Location = new System.Drawing.Point(0, 98);
            this.grbxSearchBySketch.Margin = new System.Windows.Forms.Padding(4);
            this.grbxSearchBySketch.Name = "grbxSearchBySketch";
            this.grbxSearchBySketch.Padding = new System.Windows.Forms.Padding(4);
            this.grbxSearchBySketch.Size = new System.Drawing.Size(411, 401);
            this.grbxSearchBySketch.TabIndex = 4;
            this.grbxSearchBySketch.TabStop = false;
            this.grbxSearchBySketch.Text = "Search By Sketch";
            // 
            // btnSearchByImage
            // 
            this.btnSearchByImage.Image = global::VideoBrowsingSystemContentBased.Properties.Resources.search_20x20;
            this.btnSearchByImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchByImage.Location = new System.Drawing.Point(11, 359);
            this.btnSearchByImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchByImage.Name = "btnSearchByImage";
            this.btnSearchByImage.Size = new System.Drawing.Size(108, 34);
            this.btnSearchByImage.TabIndex = 2;
            this.btnSearchByImage.Text = "    Search";
            this.btnSearchByImage.UseVisualStyleBackColor = true;
            this.btnSearchByImage.Click += new System.EventHandler(this.btnSearchByImage_Click);
            // 
            // grbxSearchByText
            // 
            this.grbxSearchByText.Controls.Add(this.rbtnContent);
            this.grbxSearchByText.Controls.Add(this.rbtnORC);
            this.grbxSearchByText.Controls.Add(this.btnSearchByText);
            this.grbxSearchByText.Controls.Add(this.txtTextQuery);
            this.grbxSearchByText.Location = new System.Drawing.Point(0, 0);
            this.grbxSearchByText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxSearchByText.Name = "grbxSearchByText";
            this.grbxSearchByText.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxSearchByText.Size = new System.Drawing.Size(395, 97);
            this.grbxSearchByText.TabIndex = 3;
            this.grbxSearchByText.TabStop = false;
            this.grbxSearchByText.Text = "Search By Text";
            // 
            // rbtnContent
            // 
            this.rbtnContent.AutoSize = true;
            this.rbtnContent.Location = new System.Drawing.Point(251, 63);
            this.rbtnContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnContent.Name = "rbtnContent";
            this.rbtnContent.Size = new System.Drawing.Size(138, 21);
            this.rbtnContent.TabIndex = 3;
            this.rbtnContent.TabStop = true;
            this.rbtnContent.Text = "Image Captioning";
            this.rbtnContent.UseVisualStyleBackColor = true;
            this.rbtnContent.Click += new System.EventHandler(this.rbtnContent_Click);
            // 
            // rbtnORC
            // 
            this.rbtnORC.AutoSize = true;
            this.rbtnORC.Location = new System.Drawing.Point(133, 63);
            this.rbtnORC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnORC.Name = "rbtnORC";
            this.rbtnORC.Size = new System.Drawing.Size(112, 21);
            this.rbtnORC.TabIndex = 2;
            this.rbtnORC.TabStop = true;
            this.rbtnORC.Text = "Text Spotting";
            this.rbtnORC.UseVisualStyleBackColor = true;
            this.rbtnORC.Click += new System.EventHandler(this.rbtnORC_Click);
            // 
            // btnSearchByText
            // 
            this.btnSearchByText.Image = global::VideoBrowsingSystemContentBased.Properties.Resources.search_20x20;
            this.btnSearchByText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchByText.Location = new System.Drawing.Point(7, 57);
            this.btnSearchByText.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchByText.Name = "btnSearchByText";
            this.btnSearchByText.Size = new System.Drawing.Size(108, 34);
            this.btnSearchByText.TabIndex = 1;
            this.btnSearchByText.Text = "    Search";
            this.btnSearchByText.UseVisualStyleBackColor = true;
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.tblpLeft);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(919, 697);
            this.panel2.TabIndex = 1;
            // 
            // lazypicscrListFrame
            // 
            this.lazypicscrListFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lazypicscrListFrame.Location = new System.Drawing.Point(3, 17);
            this.lazypicscrListFrame.Margin = new System.Windows.Forms.Padding(5);
            this.lazypicscrListFrame.Name = "lazypicscrListFrame";
            this.lazypicscrListFrame.Size = new System.Drawing.Size(907, 514);
            this.lazypicscrListFrame.TabIndex = 0;
            // 
            // putColorAndSketchV2
            // 
            this.putColorAndSketchV2.Location = new System.Drawing.Point(7, 23);
            this.putColorAndSketchV2.Margin = new System.Windows.Forms.Padding(5);
            this.putColorAndSketchV2.Name = "putColorAndSketchV2";
            this.putColorAndSketchV2.Size = new System.Drawing.Size(917, 932);
            this.putColorAndSketchV2.TabIndex = 3;
            // 
            // VideoBrowsingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VideoBrowsingForm";
            this.Text = "Video Browsing System Content Based";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VideoBrowsingForm_KeyDown);
            this.tblpLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.grbxListFrame.ResumeLayout(false);
            this.grbxFrameShot.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grbxVideoPlayer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWMP)).EndInit();
            this.grbxSearchBySketch.ResumeLayout(false);
            this.grbxSearchByText.ResumeLayout(false);
            this.grbxSearchByText.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblpLeft;
        private System.Windows.Forms.Panel pnFrameShot;
        private System.Windows.Forms.Panel panel1;
        private AxWMPLib.AxWindowsMediaPlayer axWMP;
        private System.Windows.Forms.Button btnSearchByText;
        private System.Windows.Forms.TextBox txtTextQuery;
        private System.Windows.Forms.GroupBox grbxListFrame;
        private System.Windows.Forms.GroupBox grbxFrameShot;
        private System.Windows.Forms.GroupBox grbxSearchByText;
        private System.Windows.Forms.GroupBox grbxSearchBySketch;
        private System.Windows.Forms.RadioButton rbtnContent;
        private System.Windows.Forms.RadioButton rbtnORC;
        private System.Windows.Forms.GroupBox grbxVideoPlayer;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.Button btnSearchByImage;
        private Widget.PutColorAndSketchV2 putColorAndSketchV2;
        private Widget.LazyPictureScrolling lazypicscrListFrame;
        private System.Windows.Forms.Panel panel2;

    }
}

