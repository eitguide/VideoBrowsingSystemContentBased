using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBrowsingSystemContentBased.Model;

namespace VideoBrowsingSystemContentBased.Widget
{
    public partial class PutColorAndSketch : UserControl
    {

        private bool selectedDotColors = false;
        private bool selectedSketch = false;

        private Color BACK_COLOR_SELECTED = Color.LightGray;
        private Color BACK_COLOR_NOT_SELECTED = Color.Transparent;

        private int BRUSH_SIZE_DOT_COLOR = 25;
        private int BRUSH_SIZE_SKETCH = 5;
        private Color colorSelected = Color.Black;
        private Bitmap bitmapSampleColor = null;
        private List<IShape> listShapes = null;
        private bool isDrawing = false;
        private int [] brushSizes = {5,10,15,20,25};
        private Point selectedPixel = Point.Empty;

        public PutColorAndSketch()
        {
            InitializeComponent();

            CheckOptionDotColors();
            listShapes = new List<IShape>();

            // init events not available in [Design]
            pnlBrushSize.MouseWheel += pnlBrushSize_MouseWheel;
        }

        public Bitmap getBitmapListLineDrawingDrawed()
        {
            Bitmap bitmapListLineDrawingDrawed = new Bitmap(picbxPaperDrawing.Width, picbxPaperDrawing.Height);
            Graphics g = Graphics.FromImage(bitmapListLineDrawingDrawed);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            LineDrawing lineDrawing;
            foreach(IShape shape in listShapes)
            {
                if (shape is LineDrawing)
                {
                    lineDrawing = shape as LineDrawing;
                    DrawLineDrawing(g, lineDrawing);
                }
            }

            return bitmapListLineDrawingDrawed;
        }

        public void FixLayout(int width)
        {
            picbxColorPicker.Width = width;
            float ratioImgColorPicker = (float)picbxColorPicker.Image.Width / (float)picbxColorPicker.Image.Height;
            picbxColorPicker.Height = (int)((float)width / ratioImgColorPicker);
            picbxColorPicker.Location = new Point(0, 0);
            picbxColorPicker.SizeMode = PictureBoxSizeMode.StretchImage;
            
            bitmapSampleColor = new Bitmap(picbxColorPicker.Image, picbxColorPicker.Width, picbxColorPicker.Height);
            //logSizePicker();
            
            picbxPaperDrawing.Location = new Point(pnlToolBox.Width, picbxColorPicker.Height);
            picbxPaperDrawing.Width = width - pnlToolBox.Width;
            picbxPaperDrawing.Height = (int)((float)picbxPaperDrawing.Width * 9f / 16f);
            picbxPaperDrawing.SizeMode = PictureBoxSizeMode.CenterImage;

            pnlToolBox.Location = new Point(0, picbxColorPicker.Height);
            pnlToolBox.Width = width - picbxPaperDrawing.Width;
            pnlToolBox.Height = picbxPaperDrawing.Height;

            pnlBrushSize.Location = new Point(0, 0);
            btnDotColors.Location = new Point(0, pnlBrushSize.Height);
            btnSketch.Location = new Point(0, pnlBrushSize.Height + btnDotColors.Height);
            btnUndo.Location = new Point(0, pnlToolBox.Height - btnClear.Height - btnUndo.Height);
            btnClear.Location = new Point(0, pnlToolBox.Height - btnClear.Height);
                
            this.Height = picbxColorPicker.Height + picbxPaperDrawing.Height;
        }

        private void CheckOptionDotColors()
        {
            btnDotColors.BackColor = BACK_COLOR_SELECTED;
            btnSketch.BackColor = BACK_COLOR_NOT_SELECTED;
            selectedDotColors = true;
            selectedSketch = false;
            pnlBrushSize.Refresh();
        }

        private void CheckOptionSketch()
        {
            btnSketch.BackColor = BACK_COLOR_SELECTED;
            btnDotColors.BackColor = BACK_COLOR_NOT_SELECTED;
            btnDotColors.FlatAppearance.BorderSize = 0;
            selectedSketch = true;
            selectedDotColors = false;
            pnlBrushSize.Refresh();
        }

        private void DrawDot(Graphics g, Dot dot)
        {
            SolidBrush brush = new SolidBrush(dot.color);
            g.FillEllipse(brush, dot.location.X, dot.location.Y, dot.radius * 2, dot.radius * 2);
        }
        private void DrawLineDrawing(Graphics g, LineDrawing lineDrawing)
        {
            Pen pen = new Pen(lineDrawing.color, lineDrawing.size);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            if (lineDrawing.listPoint.Count == 1)
            {
                SolidBrush brush = new SolidBrush(lineDrawing.color);
                Point location = lineDrawing.listPoint[0];
                g.FillEllipse(brush, location.X - (float)lineDrawing.size / 2f, location.Y - (float)lineDrawing.size / 2f, lineDrawing.size, lineDrawing.size);
                return;
            }
            for (int i = 0; i < lineDrawing.listPoint.Count - 1; i++)
            {
                g.DrawLine(pen, lineDrawing.listPoint[i], lineDrawing.listPoint[i + 1]);
            }
        }

        #region Events
        // Buttons
        private void btnDotColors_Click(object sender, EventArgs e)
        {
            CheckOptionDotColors();
        }
        private void btnSketch_Click(object sender, EventArgs e)
        {
            CheckOptionSketch();
        }
        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (listShapes != null && listShapes.Count > 0)
            {
                listShapes.RemoveAt(listShapes.Count - 1);
                picbxPaperDrawing.Refresh();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (listShapes != null && listShapes.Count > 0)
            {
                listShapes.Clear();
                picbxPaperDrawing.Refresh();
            }
        }
        // PictureBox
        private void picbxColorPicker_MouseClick(object sender, MouseEventArgs e)
        {
            colorSelected = bitmapSampleColor.GetPixel(e.X, e.Y);
            selectedPixel = e.Location;
            picbxColorPicker.Refresh();
            pnlBrushSize.Refresh();
        }
        private void picbxPaperDrawing_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectedDotColors)
            {
                if (colorSelected != Color.Empty)
                {
                    listShapes.Add(new Dot(new Point(e.X - BRUSH_SIZE_DOT_COLOR / 2, e.Y - BRUSH_SIZE_DOT_COLOR / 2), (float)BRUSH_SIZE_DOT_COLOR / 2f, colorSelected));
                    picbxPaperDrawing.Refresh();
                }
            }
        }
        private void picbxPaperDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedSketch)
            {
                isDrawing = true;
                if (colorSelected != Color.Empty)
                {
                    listShapes.Add(new LineDrawing(colorSelected, (float)BRUSH_SIZE_SKETCH));
                    (listShapes[listShapes.Count - 1] as LineDrawing).listPoint.Add(e.Location);
                    picbxPaperDrawing.Refresh();
                }
            }
        }
        private void picbxPaperDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedSketch)
            {
                if (isDrawing)
                {
                    if (colorSelected != Color.Empty)
                    {
                        (listShapes[listShapes.Count - 1] as LineDrawing).listPoint.Add(e.Location);
                        picbxPaperDrawing.Refresh();
                    }
                }
            }
        }
        private void picbxPaperDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedSketch)
            {
                if (isDrawing)
                {
                    isDrawing = false;
                }
            }
        }
        private void picbxPaperDrawing_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Dot dot;
            LineDrawing lineDrawing;

            foreach (IShape shape in listShapes)
            {
                if (shape is Dot)
                {
                    dot = shape as Dot;
                    DrawDot(e.Graphics, dot);
                }
                else if (shape is LineDrawing)
                {
                    lineDrawing = shape as LineDrawing;
                    DrawLineDrawing(e.Graphics, lineDrawing);
                }
            }
        }
        private void picbxColorPicker_Paint(object sender, PaintEventArgs e)
        {
            if (selectedPixel != Point.Empty)
            {
                Pen pen = new Pen(Color.Black);
                pen.DashPattern = new float[]{1,1};
                int width = 10;
                e.Graphics.DrawRectangle(pen, selectedPixel.X - width / 2, selectedPixel.Y - width / 2, width, width);
            }
        }
        // Panel
        private void pnlBrushSize_Paint(object sender, PaintEventArgs e)
        {
            int brushSize;
            if (selectedDotColors) brushSize = BRUSH_SIZE_DOT_COLOR;
            else if (selectedSketch) brushSize = BRUSH_SIZE_SKETCH;
            else throw new Exception("BRUSH_SIZE NOT FOUND!");

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SolidBrush brush = new SolidBrush(colorSelected);
            e.Graphics.FillEllipse(brush, (float)(pnlBrushSize.Width - brushSize) / 2f,
                                          (float)(pnlBrushSize.Height - brushSize) / 2f,
                                          brushSize, brushSize);
        }
        void pnlBrushSize_MouseWheel(object sender, MouseEventArgs e)
        {
            // BRUSH_SIZE = 5,10,15,20,25
            if (selectedDotColors)
            {
                if (e.Delta > 0)
                {
                    if (BRUSH_SIZE_DOT_COLOR < 25)
                    {
                        BRUSH_SIZE_DOT_COLOR += 5;
                        pnlBrushSize.Refresh();
                    }
                }
                else
                {
                    if (BRUSH_SIZE_DOT_COLOR > 5)
                    {
                        BRUSH_SIZE_DOT_COLOR -= 5;
                        pnlBrushSize.Refresh();
                    }
                }
            }
            else if (selectedSketch)
            {
                if (e.Delta > 0)
                {
                    if (BRUSH_SIZE_SKETCH < 25)
                    {
                        BRUSH_SIZE_SKETCH += 5;
                        pnlBrushSize.Refresh();
                    }
                }
                else
                {
                    if (BRUSH_SIZE_SKETCH > 5)
                    {
                        BRUSH_SIZE_SKETCH -= 5;
                        pnlBrushSize.Refresh();
                    }
                }
            }
            else
                throw new Exception("BRUSH_SIZE NOT FOUND!");
        }
        #endregion
    }
}