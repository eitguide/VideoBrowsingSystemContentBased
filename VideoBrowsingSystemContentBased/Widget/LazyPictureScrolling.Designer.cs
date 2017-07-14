namespace VideoBrowsingSystemContentBased.Widget
{
    partial class LazyPictureScrolling
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowlpnlPicsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowlpnlPicsContainer
            // 
            this.flowlpnlPicsContainer.Location = new System.Drawing.Point(25, 28);
            this.flowlpnlPicsContainer.Name = "flowlpnlPicsContainer";
            this.flowlpnlPicsContainer.Size = new System.Drawing.Size(200, 100);
            this.flowlpnlPicsContainer.TabIndex = 0;
            // 
            // LazyPictureScrolling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowlpnlPicsContainer);
            this.Name = "LazyPictureScrolling";
            this.Size = new System.Drawing.Size(326, 209);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowlpnlPicsContainer;
    }
}
