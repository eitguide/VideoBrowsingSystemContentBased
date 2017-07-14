namespace VideoBrowsingSystemContentBased.View
{
    partial class IndexProcessing
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
            this.btnTextSpotIndexing = new System.Windows.Forms.Button();
            this.btnTextCaptionIndexing = new System.Windows.Forms.Button();
            this.fdjhfjkd = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnParseXML = new System.Windows.Forms.Button();
            this.btnParseJson = new System.Windows.Forms.Button();
            this.pbTest = new System.Windows.Forms.ProgressBar();
            this.btnDoWork = new System.Windows.Forms.Button();
            this.btnSearchTextSpot = new System.Windows.Forms.Button();
            this.btnSearchCap = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTextSpotIndexing
            // 
            this.btnTextSpotIndexing.Location = new System.Drawing.Point(12, 99);
            this.btnTextSpotIndexing.Name = "btnTextSpotIndexing";
            this.btnTextSpotIndexing.Size = new System.Drawing.Size(110, 23);
            this.btnTextSpotIndexing.TabIndex = 0;
            this.btnTextSpotIndexing.Text = "TextSpot Indexing";
            this.btnTextSpotIndexing.UseVisualStyleBackColor = true;
            // 
            // btnTextCaptionIndexing
            // 
            this.btnTextCaptionIndexing.Location = new System.Drawing.Point(145, 99);
            this.btnTextCaptionIndexing.Name = "btnTextCaptionIndexing";
            this.btnTextCaptionIndexing.Size = new System.Drawing.Size(133, 23);
            this.btnTextCaptionIndexing.TabIndex = 1;
            this.btnTextCaptionIndexing.Text = "TextCaptionIndexig";
            this.btnTextCaptionIndexing.UseVisualStyleBackColor = true;
            // 
            // fdjhfjkd
            // 
            this.fdjhfjkd.Location = new System.Drawing.Point(29, 178);
            this.fdjhfjkd.Name = "fdjhfjkd";
            this.fdjhfjkd.Size = new System.Drawing.Size(40, 23);
            this.fdjhfjkd.TabIndex = 2;
            this.fdjhfjkd.Text = "Status";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(75, 178);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(203, 23);
            this.lblStatus.TabIndex = 3;
            // 
            // btnParseXML
            // 
            this.btnParseXML.Location = new System.Drawing.Point(12, 45);
            this.btnParseXML.Name = "btnParseXML";
            this.btnParseXML.Size = new System.Drawing.Size(110, 23);
            this.btnParseXML.TabIndex = 4;
            this.btnParseXML.Text = "ParseXML";
            this.btnParseXML.UseVisualStyleBackColor = true;
            // 
            // btnParseJson
            // 
            this.btnParseJson.Location = new System.Drawing.Point(145, 45);
            this.btnParseJson.Name = "btnParseJson";
            this.btnParseJson.Size = new System.Drawing.Size(133, 23);
            this.btnParseJson.TabIndex = 5;
            this.btnParseJson.Text = "Parse Json DenseCap";
            this.btnParseJson.UseVisualStyleBackColor = true;
            // 
            // pbTest
            // 
            this.pbTest.Location = new System.Drawing.Point(12, 143);
            this.pbTest.Name = "pbTest";
            this.pbTest.Size = new System.Drawing.Size(266, 23);
            this.pbTest.TabIndex = 6;
            // 
            // btnDoWork
            // 
            this.btnDoWork.Location = new System.Drawing.Point(284, 143);
            this.btnDoWork.Name = "btnDoWork";
            this.btnDoWork.Size = new System.Drawing.Size(65, 23);
            this.btnDoWork.TabIndex = 7;
            this.btnDoWork.Text = "DoWork";
            this.btnDoWork.UseVisualStyleBackColor = true;
            this.btnDoWork.Click += new System.EventHandler(this.btnDoWork_Click);
            // 
            // btnSearchTextSpot
            // 
            this.btnSearchTextSpot.Location = new System.Drawing.Point(325, 45);
            this.btnSearchTextSpot.Name = "btnSearchTextSpot";
            this.btnSearchTextSpot.Size = new System.Drawing.Size(75, 23);
            this.btnSearchTextSpot.TabIndex = 8;
            this.btnSearchTextSpot.Text = "Search TS";
            this.btnSearchTextSpot.UseVisualStyleBackColor = true;
            this.btnSearchTextSpot.Click += new System.EventHandler(this.btnSearchTextSpot_Click);
            // 
            // btnSearchCap
            // 
            this.btnSearchCap.Location = new System.Drawing.Point(325, 98);
            this.btnSearchCap.Name = "btnSearchCap";
            this.btnSearchCap.Size = new System.Drawing.Size(75, 23);
            this.btnSearchCap.TabIndex = 9;
            this.btnSearchCap.Text = "Search Cap";
            this.btnSearchCap.UseVisualStyleBackColor = true;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(38, 12);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(362, 20);
            this.txtQuery.TabIndex = 10;
            // 
            // IndexProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 210);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnSearchCap);
            this.Controls.Add(this.btnSearchTextSpot);
            this.Controls.Add(this.btnDoWork);
            this.Controls.Add(this.pbTest);
            this.Controls.Add(this.btnParseJson);
            this.Controls.Add(this.btnParseXML);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.fdjhfjkd);
            this.Controls.Add(this.btnTextCaptionIndexing);
            this.Controls.Add(this.btnTextSpotIndexing);
            this.Name = "IndexProcessing";
            this.Text = "IndexProcessing";
            this.Load += new System.EventHandler(this.IndexProcessing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTextSpotIndexing;
        private System.Windows.Forms.Button btnTextCaptionIndexing;
        private System.Windows.Forms.Label fdjhfjkd;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnParseXML;
        private System.Windows.Forms.Button btnParseJson;
        private System.Windows.Forms.ProgressBar pbTest;
        private System.Windows.Forms.Button btnDoWork;
        private System.Windows.Forms.Button btnSearchTextSpot;
        private System.Windows.Forms.Button btnSearchCap;
        private System.Windows.Forms.TextBox txtQuery;
    }
}