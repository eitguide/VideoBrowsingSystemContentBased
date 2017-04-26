namespace VideoBrowsingSystemContentBased.Widget
{
    partial class PutColorAndSketchV2
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
            this.pnlToolBox = new System.Windows.Forms.Panel();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlBrushSize = new System.Windows.Forms.Panel();
            this.btnDotColors = new System.Windows.Forms.Button();
            this.btnSketch = new System.Windows.Forms.Button();
            this.picbxPaperDrawing = new System.Windows.Forms.PictureBox();
            this.pnlColorPicker = new System.Windows.Forms.Panel();
            this.pnlToolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbxPaperDrawing)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlToolBox
            // 
            this.pnlToolBox.Controls.Add(this.btnUndo);
            this.pnlToolBox.Controls.Add(this.btnClear);
            this.pnlToolBox.Controls.Add(this.pnlBrushSize);
            this.pnlToolBox.Controls.Add(this.btnDotColors);
            this.pnlToolBox.Controls.Add(this.btnSketch);
            this.pnlToolBox.Location = new System.Drawing.Point(17, 414);
            this.pnlToolBox.Margin = new System.Windows.Forms.Padding(4);
            this.pnlToolBox.Name = "pnlToolBox";
            this.pnlToolBox.Size = new System.Drawing.Size(33, 396);
            this.pnlToolBox.TabIndex = 1;
            // 
            // btnUndo
            // 
            this.btnUndo.BackgroundImage = global::VideoBrowsingSystemContentBased.Properties.Resources.undo;
            this.btnUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUndo.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Location = new System.Drawing.Point(0, 152);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(4);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(33, 31);
            this.btnUndo.TabIndex = 4;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = global::VideoBrowsingSystemContentBased.Properties.Resources.clear;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(0, 113);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(33, 31);
            this.btnClear.TabIndex = 3;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlBrushSize
            // 
            this.pnlBrushSize.Location = new System.Drawing.Point(0, 74);
            this.pnlBrushSize.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBrushSize.Name = "pnlBrushSize";
            this.pnlBrushSize.Size = new System.Drawing.Size(33, 33);
            this.pnlBrushSize.TabIndex = 2;
            this.pnlBrushSize.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBrushSize_Paint);
            // 
            // btnDotColors
            // 
            this.btnDotColors.BackgroundImage = global::VideoBrowsingSystemContentBased.Properties.Resources.dots_color;
            this.btnDotColors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDotColors.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnDotColors.FlatAppearance.BorderSize = 0;
            this.btnDotColors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDotColors.Location = new System.Drawing.Point(0, 221);
            this.btnDotColors.Margin = new System.Windows.Forms.Padding(4);
            this.btnDotColors.Name = "btnDotColors";
            this.btnDotColors.Size = new System.Drawing.Size(33, 31);
            this.btnDotColors.TabIndex = 1;
            this.btnDotColors.UseVisualStyleBackColor = true;
            this.btnDotColors.Click += new System.EventHandler(this.btnDotColors_Click);
            // 
            // btnSketch
            // 
            this.btnSketch.BackgroundImage = global::VideoBrowsingSystemContentBased.Properties.Resources.Actions_draw_freehand_icon;
            this.btnSketch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSketch.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnSketch.FlatAppearance.BorderSize = 0;
            this.btnSketch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSketch.Location = new System.Drawing.Point(0, 252);
            this.btnSketch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSketch.Name = "btnSketch";
            this.btnSketch.Size = new System.Drawing.Size(33, 31);
            this.btnSketch.TabIndex = 0;
            this.btnSketch.UseVisualStyleBackColor = true;
            this.btnSketch.Click += new System.EventHandler(this.btnSketch_Click);
            // 
            // picbxPaperDrawing
            // 
            this.picbxPaperDrawing.Image = global::VideoBrowsingSystemContentBased.Properties.Resources.transparent_background;
            this.picbxPaperDrawing.Location = new System.Drawing.Point(82, 376);
            this.picbxPaperDrawing.Margin = new System.Windows.Forms.Padding(4);
            this.picbxPaperDrawing.Name = "picbxPaperDrawing";
            this.picbxPaperDrawing.Size = new System.Drawing.Size(917, 465);
            this.picbxPaperDrawing.TabIndex = 0;
            this.picbxPaperDrawing.TabStop = false;
            this.picbxPaperDrawing.Paint += new System.Windows.Forms.PaintEventHandler(this.picbxPaperDrawing_Paint);
            this.picbxPaperDrawing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picbxPaperDrawing_MouseClick);
            this.picbxPaperDrawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbxPaperDrawing_MouseDown);
            this.picbxPaperDrawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbxPaperDrawing_MouseMove);
            this.picbxPaperDrawing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbxPaperDrawing_MouseUp);
            // 
            // pnlColorPicker
            // 
            this.pnlColorPicker.Location = new System.Drawing.Point(68, 46);
            this.pnlColorPicker.Name = "pnlColorPicker";
            this.pnlColorPicker.Size = new System.Drawing.Size(200, 100);
            this.pnlColorPicker.TabIndex = 2;
            this.pnlColorPicker.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlColorPicker_Paint);
            this.pnlColorPicker.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlColorPicker_MouseClick);
            // 
            // PutColorAndSketchV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlColorPicker);
            this.Controls.Add(this.pnlToolBox);
            this.Controls.Add(this.picbxPaperDrawing);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PutColorAndSketchV2";
            this.Size = new System.Drawing.Size(917, 932);
            this.pnlToolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbxPaperDrawing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlToolBox;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlBrushSize;
        private System.Windows.Forms.Button btnDotColors;
        private System.Windows.Forms.Button btnSketch;
        private System.Windows.Forms.PictureBox picbxPaperDrawing;
        private System.Windows.Forms.Panel pnlColorPicker;

    }
}
