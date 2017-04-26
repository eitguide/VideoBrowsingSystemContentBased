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
using VideoBrowsingSystemContentBased.Utils;

namespace VideoBrowsingSystemContentBased.Widget
{
    public partial class PutColorAndSketchV2 : UserControl
    {
        private bool selectedDotColors = false;
        private bool selectedSketch = false;

        private Color BACK_COLOR_SELECTED = Color.LightGray;
        private Color BACK_COLOR_NOT_SELECTED = Color.Transparent;

        private Color colorSelected = Color.Black;
        private Bitmap bitmapSampleColor = null;
        private List<IShape> listShapes = null;
        private bool isDrawing = false;
        private int [] BRUSH_SIZES = {5,10,15,20,25,30,35,40,45,50};
        private int curBrushSizeDotColorIndex = 6;
        private int curBrushSizeDotColor;
        private int curBrushSizeSketchIndex = 0;
        private int curBrushSizeSketch;
        private Point selectedPixel = Point.Empty;
        private List<Color> listColorVisualWords;

        public PutColorAndSketchV2()
        {
            InitializeComponent();
            curBrushSizeDotColor = BRUSH_SIZES[curBrushSizeDotColorIndex];
            curBrushSizeSketch = BRUSH_SIZES[curBrushSizeSketchIndex];

            CheckOptionDotColors();
            listShapes = new List<IShape>();
            listColorVisualWords = ColorHelper.GenerateColorVisualWord_Rgb();

            // init events not available in [Design]
            pnlBrushSize.MouseWheel += pnlBrushSize_MouseWheel;
        }

        public Bitmap GetBitmapListLineDrawingDrawed()
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

        public List<Dot_RGB> GetListDotsDrawed_RGB()
        {
            List<Dot_RGB> listDotsDrawed = new List<Dot_RGB>();
            foreach(IShape shape in listShapes)
            {
                if (shape is Dot_RGB)
                {
                    listDotsDrawed.Add(shape as Dot_RGB);
                }
            }
            return listDotsDrawed;
        }

        public List<Dot_Lab> GetListDotsDrawed_Lab()
        {
            List<Dot_Lab> listDotsDrawed = new List<Dot_Lab>();
            foreach (IShape shape in listShapes)
            {
                if (shape is Dot_RGB)
                {
                    Dot_Lab dotLab = (shape as Dot_RGB).ToDotLab();
                    listDotsDrawed.Add(dotLab);
                }
            }
            return listDotsDrawed;
        }

        public Size GetPaperDrawingWidthHeight()
        {
            // always width:height = 16:9
            return picbxPaperDrawing.Size;
        }

        public void SetColorForBrush(Color c)
        {
            colorSelected = c;
            pnlBrushSize.Refresh();
        }

        public void FixLayout(int width)
        {
            pnlColorPicker.Width = width;
            pnlColorPicker.Location = new Point(0, 0);
            pnlColorPicker.Refresh();

            bitmapSampleColor = new Bitmap(pnlColorPicker.Width, pnlColorPicker.Height);
            pnlColorPicker.DrawToBitmap(bitmapSampleColor, new Rectangle(0, 0, pnlColorPicker.Width, pnlColorPicker.Height));

            picbxPaperDrawing.Location = new Point(pnlToolBox.Width, pnlColorPicker.Height);
            picbxPaperDrawing.Width = width - pnlToolBox.Width;
            picbxPaperDrawing.Height = (int)((float)picbxPaperDrawing.Width * 9f / 16f);
            picbxPaperDrawing.SizeMode = PictureBoxSizeMode.CenterImage;

            pnlToolBox.Location = new Point(0, pnlColorPicker.Height);
            pnlToolBox.Width = width - picbxPaperDrawing.Width;
            pnlToolBox.Height = picbxPaperDrawing.Height;

            pnlBrushSize.Location = new Point(0, 0);
            btnDotColors.Location = new Point(0, pnlBrushSize.Height);
            btnSketch.Location = new Point(0, pnlBrushSize.Height + btnDotColors.Height);
            btnUndo.Location = new Point(0, pnlToolBox.Height - btnClear.Height - btnUndo.Height);
            btnClear.Location = new Point(0, pnlToolBox.Height - btnClear.Height);

            this.Height = pnlColorPicker.Height + picbxPaperDrawing.Height;
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

        private void DrawDot(Graphics g, Dot_RGB dot)
        {
            SolidBrush brush = new SolidBrush(dot.color);
            g.FillEllipse(brush, dot.location.X - dot.radius, dot.location.Y - dot.radius, dot.radius * 2, dot.radius * 2);
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
        private void picbxPaperDrawing_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectedDotColors)
            {
                if (colorSelected != Color.Empty)
                {
                    listShapes.Add(new Dot_RGB(new Point(e.X , e.Y), (float)curBrushSizeDotColor / 2f, colorSelected));
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
                    listShapes.Add(new LineDrawing(colorSelected, (float)curBrushSizeSketch));
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
            Dot_RGB dot;
            LineDrawing lineDrawing;

            foreach (IShape shape in listShapes)
            {
                if (shape is Dot_RGB)
                {
                    dot = shape as Dot_RGB;
                    DrawDot(e.Graphics, dot);
                }
                else if (shape is LineDrawing)
                {
                    lineDrawing = shape as LineDrawing;
                    DrawLineDrawing(e.Graphics, lineDrawing);
                }
            }
        }
        // Panel
        private void pnlBrushSize_Paint(object sender, PaintEventArgs e)
        {
            int brushSize;
            if (selectedDotColors) brushSize = curBrushSizeDotColor;
            else if (selectedSketch) brushSize = curBrushSizeSketch;
            else throw new Exception("BRUSH_SIZE NOT FOUND!");

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //SolidBrush brush = new SolidBrush(colorSelected);
            //int constBrushSize = 30;
            //e.Graphics.FillEllipse(brush, (float)(pnlBrushSize.Width - constBrushSize) / 2f,
            //                              (float)(pnlBrushSize.Height - constBrushSize) / 2f,
            //                              constBrushSize, constBrushSize);
            pnlBrushSize.BackColor = colorSelected;

            SolidBrush brush = new SolidBrush(ColorHelper.GetBlackOrWhiteColorContrast(colorSelected));
            string textToDrawn = brushSize.ToString();
            Font fontToDrawn = new Font("Consolas", 10);
            SizeF textSize = e.Graphics.MeasureString(textToDrawn, fontToDrawn);
            Point locationToDrawn = new Point((pnlBrushSize.Width - (int)textSize.Width) / 2,
                                                (pnlBrushSize.Height - (int)textSize.Height) / 2);
            e.Graphics.DrawString(textToDrawn, fontToDrawn, brush, locationToDrawn);
        }
        private void pnlBrushSize_MouseWheel(object sender, MouseEventArgs e)
        {
            if (selectedDotColors)
            {
                if (e.Delta > 0)
                {
                    if (curBrushSizeDotColorIndex < BRUSH_SIZES.Length - 1)
                        curBrushSizeDotColor = BRUSH_SIZES[++curBrushSizeDotColorIndex];
                }
                else
                {
                    if (curBrushSizeDotColorIndex > 0)
                        curBrushSizeDotColor = BRUSH_SIZES[--curBrushSizeDotColorIndex];
                }
                pnlBrushSize.Refresh();
            }
            else if (selectedSketch)
            {
                if (e.Delta > 0)
                {
                    if (curBrushSizeSketchIndex < BRUSH_SIZES.Length - 1)
                        curBrushSizeSketch = BRUSH_SIZES[++curBrushSizeSketchIndex];
                }
                else
                {
                    if (curBrushSizeSketchIndex > 0)
                        curBrushSizeSketch = BRUSH_SIZES[--curBrushSizeSketchIndex];
                }
                pnlBrushSize.Refresh();
            }
            else
                throw new Exception("BRUSH_SIZE NOT FOUND!");
        }
        private void pnlColorPicker_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int x = 0, y = 0, countRow = 1;
            int widthEachColor = 30;
            for (int i = 0; i < listColorVisualWords.Count; i++)
            {
                DrawDot(g, new Dot_RGB(new Point(x + widthEachColor / 2, y + widthEachColor / 2), widthEachColor / 2, listColorVisualWords[i]));
                x += widthEachColor;

                // go to new row 
                if (x + widthEachColor > pnlColorPicker.Width - widthEachColor / 2)
                {
                    countRow++;
                    x = 0;
                    y += widthEachColor;
                }
            }
            pnlColorPicker.Height = countRow * widthEachColor + 5;
        }
        private void pnlColorPicker_MouseClick(object sender, MouseEventArgs e)
        {
            Color colorSelectedTemp = bitmapSampleColor.GetPixel(e.X, e.Y);
            if (!listColorVisualWords.Contains(colorSelectedTemp))
                return;

            colorSelected = colorSelectedTemp;
            selectedPixel = e.Location;
            //picbxColorPicker.Refresh();
            pnlBrushSize.Refresh();
        }
        #endregion


    }
}
