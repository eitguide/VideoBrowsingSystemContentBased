namespace VideoBrowsingSystemContentBased.Widget
{
    partial class ColorDottingUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorDottingUC));
            this.label = new System.Windows.Forms.Label();
            this.panelColorSelected = new System.Windows.Forms.Panel();
            this.colorPicker = new VideoBrowsingSystemContentBased.Widget.ColorPickerUC();
            this.gbDraw = new System.Windows.Forms.GroupBox();
            this.drawUI = new VideoBrowsingSystemContentBased.Widget.PaperDottingUC();
            this.gbDraw.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(3, 350);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(102, 17);
            this.label.TabIndex = 1;
            this.label.Text = "Color selected:";
            // 
            // panelColorSelected
            // 
            this.panelColorSelected.Location = new System.Drawing.Point(110, 346);
            this.panelColorSelected.Name = "panelColorSelected";
            this.panelColorSelected.Size = new System.Drawing.Size(49, 25);
            this.panelColorSelected.TabIndex = 2;
            // 
            // colorPicker
            // 
            this.colorPicker.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("colorPicker.BackgroundImage")));
            this.colorPicker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.colorPicker.Location = new System.Drawing.Point(0, 0);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(625, 336);
            this.colorPicker.TabIndex = 0;
            this.colorPicker.MouseCaptureChanged += new System.EventHandler(this.colorPickerUC1_MouseCaptureChanged);
            // 
            // gbDraw
            // 
            this.gbDraw.Controls.Add(this.drawUI);
            this.gbDraw.Location = new System.Drawing.Point(4, 383);
            this.gbDraw.Name = "gbDraw";
            this.gbDraw.Size = new System.Drawing.Size(621, 205);
            this.gbDraw.TabIndex = 3;
            this.gbDraw.TabStop = false;
            // 
            // drawUI
            // 
            this.drawUI.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("drawUI.BackgroundImage")));
            this.drawUI.Location = new System.Drawing.Point(7, 22);
            this.drawUI.Name = "drawUI";
            this.drawUI.Size = new System.Drawing.Size(608, 177);
            this.drawUI.TabIndex = 0;
            // 
            // ColorDottingUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDraw);
            this.Controls.Add(this.panelColorSelected);
            this.Controls.Add(this.label);
            this.Controls.Add(this.colorPicker);
            this.Name = "ColorDottingUC";
            this.Size = new System.Drawing.Size(638, 602);
            this.SizeChanged += new System.EventHandler(this.ColorDottingUC_SizeChanged);
            this.gbDraw.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColorPickerUC colorPicker;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panelColorSelected;
        private System.Windows.Forms.GroupBox gbDraw;
        private PaperDottingUC drawUI;
    }
}
