namespace VideoBrowsingSystemContentBased.Widget
{
    partial class ColorPickerUC
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
            this.SuspendLayout();
            // 
            // ColorPickerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VideoBrowsingSystemContentBased.Properties.Resources.color_picker;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Name = "ColorPickerUC";
            this.Size = new System.Drawing.Size(625, 336);
            this.SizeChanged += new System.EventHandler(this.ColorPickerUC_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ColorPickerUC_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorPickerUC_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColorPickerUC_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ColorPickerUC_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
