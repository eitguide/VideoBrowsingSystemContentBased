using ColorMine.ColorSpaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBrowsingSystemContentBased.Controller;
using VideoBrowsingSystemContentBased.Controller.ImageIndexing;
using VideoBrowsingSystemContentBased.Model;
using VideoBrowsingSystemContentBased.Utils;

namespace VideoBrowsingSystemContentBased.View
{
    public partial class ImageIndexing : Form
    {
        enum DELTA_E
        {
            NONE,
            CIE76,
            CMCIC,
            CIE94,
            CIE2000,
        }
        enum DRAWING
        {
            NONE,
            LIST_VW_COLORS_RGB_SORTED,
            LIST_VW_COLORS_LAB_SORTED,
            LIST_VW_COLORS,
        }
        private List<VisualWordCell_RGB> VisualWord;
        private DRAWING currentDrawing = DRAWING.NONE;
        private DELTA_E currentDeltaE = DELTA_E.NONE;
        private delegate double CalDistanceDlgt(ColorSpace color1, ColorSpace color2);
        private CalDistanceDlgt calDistanceHander;

        public ImageIndexing()
        {
            InitializeComponent();
            Load += ImageIndexing_Load;

            pnListColor.Paint += pnListColor_Paint;
            btnCIE76_Lab.Click += btnCIE76_Lab_Click;
            btnCMCIC_lab.Click += btnCMCIC_lab_Click;
            btnCIE94_Lab.Click += btnCIE94_Lab_Click;
            btnCIE2000_Lab.Click += btnCIE2000_Lab_Click;
            
            txtR.Text = "20";
            txtG.Text = "50";
            txtB.Text = "15";
        }

        void btnCIE2000_Lab_Click(object sender, EventArgs e)
        {
            currentDrawing = DRAWING.LIST_VW_COLORS_LAB_SORTED;
            currentDeltaE = DELTA_E.CIE2000;
            pnListColor.Refresh();
        }

        void btnCIE94_Lab_Click(object sender, EventArgs e)
        {
            currentDrawing = DRAWING.LIST_VW_COLORS_LAB_SORTED;
            currentDeltaE = DELTA_E.CIE94;
            pnListColor.Refresh();
        }

        void btnCMCIC_lab_Click(object sender, EventArgs e)
        {
            currentDrawing = DRAWING.LIST_VW_COLORS_LAB_SORTED;
            currentDeltaE = DELTA_E.CMCIC;
            pnListColor.Refresh();
        }

        void btnCIE76_Lab_Click(object sender, EventArgs e)
        {
            currentDrawing = DRAWING.LIST_VW_COLORS_LAB_SORTED;
            currentDeltaE = DELTA_E.CIE76;
            pnListColor.Refresh();
        }

        void pnListColor_Paint(object sender, PaintEventArgs e)
        {
            if (currentDrawing == DRAWING.NONE)
            {
            }
            else if (currentDrawing == DRAWING.LIST_VW_COLORS)
            {
                #region
                pnListColor.AutoScroll = true;
                pnListColor.CreateGraphics().SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Graphics g = e.Graphics;
                int x = 0, y = 0;
                int widthEachColor = 30;

                List<Color> colorVisualWord = ColorHelper.GenerateColorVisualWord_Rgb();
                for (int i = 0; i < colorVisualWord.Count; i++)
                {
                    DrawDot(g, new Dot_RGB(new Point(x + widthEachColor / 2, y + widthEachColor / 2), widthEachColor / 2, colorVisualWord[i]));
                    x += widthEachColor + 10;

                    // go to new row 
                    if (x + widthEachColor + 10 > pnListColor.Width - widthEachColor / 2)
                    {
                        x = 0;
                        y += widthEachColor + 20;
                    }
                } 
                #endregion
            }
            else if (currentDrawing == DRAWING.LIST_VW_COLORS_RGB_SORTED)
            {
                #region
                // Input: rgb color
                // Output: draw input color, draw visualize color in distance order des, distance below the color

                Color inputColor = Color.FromArgb(int.Parse(txtR.Text.Trim()), int.Parse(txtG.Text.Trim()), int.Parse(txtB.Text.Trim()));
                List<Color> listVWColorRgb = ColorHelper.GenerateColorVisualWord_Rgb();

                List<double> listDistance = new List<double>();
                foreach (Color colorVWRgb in listVWColorRgb)
                {
                    listDistance.Add(DistanceHelper.CalDistance_RGBEuclid(Color.FromArgb((int)inputColor.R, (int)inputColor.G, (int)inputColor.B), colorVWRgb));
                }
                List<int> listIndexSortAsc = SortingHelper.SortAsc(listDistance);



                DrawDot(pnVisualizse.CreateGraphics(), new Dot_RGB(new Point(50, 50), 20, Color.FromArgb(int.Parse(txtR.Text.Trim()), int.Parse(txtG.Text.Trim()), int.Parse(txtB.Text.Trim()))));

                int x = 0, y = 0;
                int widthEachColor = 30;
                List<Color> colorVisualWord = ColorHelper.GenerateColorVisualWord_Rgb();
                foreach (int index in listIndexSortAsc)
                {
                    //Console.WriteLine(listDistance[index]);

                    Graphics g = e.Graphics;
                    //g.Clear(Color.Green);
                    DrawDot(g, new Dot_RGB(new Point(x + widthEachColor / 2, y + widthEachColor / 2), widthEachColor / 2, colorVisualWord[index]));
                    g.DrawString(Math.Round(listDistance[index], 1).ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), x, y + widthEachColor);
                    x += widthEachColor + 10;

                    // go to new row 
                    if (x + widthEachColor + 10 > pnListColor.Width - widthEachColor / 2)
                    {
                        x = 0;
                        y += widthEachColor + 20;
                    }
                }
                #endregion
            }
            else if (currentDrawing == DRAWING.LIST_VW_COLORS_LAB_SORTED)
            {
                #region
                // Input: rgb color
                // Output: draw input color, draw visualize color in distance order des, distance below the color

                Lab inputColor = ColorHelper.RgbToLab(new Rgb { R = double.Parse(txtR.Text.Trim()), G = double.Parse(txtG.Text.Trim()), B = double.Parse(txtB.Text.Trim()) });
                List<Lab> listVWColorLab = ColorHelper.GenerateColorVisualWord_Lab();
                
                List<double> listDistance = new List<double>();
                if (currentDeltaE == DELTA_E.CIE76) calDistanceHander = DistanceHelper.CalDistance_CIE76;
                else if (currentDeltaE == DELTA_E.CMCIC) calDistanceHander = DistanceHelper.CalDistance_CMCIC;
                else if (currentDeltaE == DELTA_E.CIE94) calDistanceHander = DistanceHelper.CalDistance_CIE94;
                else if (currentDeltaE == DELTA_E.CIE2000) calDistanceHander = DistanceHelper.CalDistance_CIE2000;
                foreach (Lab colorVWLab in listVWColorLab)
                {
                    listDistance.Add(calDistanceHander(inputColor, colorVWLab));
                }
                List<int> listIndexSortAsc = SortingHelper.SortAsc(listDistance);



                DrawDot(pnVisualizse.CreateGraphics(), new Dot_RGB(new Point(50, 50), 20, Color.FromArgb(int.Parse(txtR.Text.Trim()), int.Parse(txtG.Text.Trim()), int.Parse(txtB.Text.Trim()))));

                int x = 0, y = 0;
                int widthEachColor = 30;
                List<Color> colorVisualWord = ColorHelper.GenerateColorVisualWord_Rgb();
                foreach (int index in listIndexSortAsc)
                {
                    //Console.WriteLine(listDistance[index]);

                    Graphics g = e.Graphics;
                    //g.Clear(Color.Green);
                    DrawDot(g, new Dot_RGB(new Point(x + widthEachColor / 2, y + widthEachColor / 2), widthEachColor / 2, colorVisualWord[index]));
                    g.DrawString(Math.Round(listDistance[index], 1).ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), x, y + widthEachColor);
                    x += widthEachColor + 10;

                    // go to new row 
                    if (x + widthEachColor + 10 > pnListColor.Width - widthEachColor / 2)
                    {
                        x = 0;
                        y += widthEachColor + 20;
                    }
                } 
                #endregion
            }
        }

        void ImageIndexing_Load(object sender, EventArgs e)
        {
  
            this.VisualWord = VisualWordHelper.CreateListVWKeys_Rgb();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void DrawDot(Graphics g, Dot_RGB dot)
        {
            SolidBrush brush = new SolidBrush(dot.color);
            g.FillEllipse(brush, dot.location.X - dot.radius, dot.location.Y - dot.radius, dot.radius * 2, dot.radius * 2);
        }

        private void btnVisualize_Click(object sender, EventArgs e)
        {
            //int R = int.Parse(txtR.Text.Trim());
            //int G = int.Parse(txtG.Text.Trim());
            //int B = int.Parse(txtB.Text.Trim());

            //Color c = Color.FromArgb(255, R, G, B);

            //List<Color> colorVisualWord = ColorHelper.GenerateColorVisualWord();

            //DrawDot(pnVisualizse.CreateGraphics(), new Dot(new Point(50, 50), 20, c));
            //int index = DistanceHelper.ColorKNN(c, colorVisualWord);

            //Color result = VisualWord[index].Color;
            //Console.WriteLine("Index: " + index + ", " + "Color: " + result.ToString());



            //Color resultColor = colorVisualWord[index];
            //DrawDot(pnVisualizse.CreateGraphics(), new Dot(new Point(100, 50), 20, resultColor));

            currentDrawing = DRAWING.LIST_VW_COLORS_RGB_SORTED;
            pnListColor.Refresh();

        }

        private void btnVisualizeListColor_Click(object sender, EventArgs e)
        {
            currentDrawing = DRAWING.LIST_VW_COLORS;
            pnListColor.Refresh();
        }

        private void btnPCTIndexing_Click(object sender, EventArgs e)
        {
            if (ConfigPCT.COLOR_SPACE_USING == ConfigPCT.ColorSpace.RGB)
                PCTIndexing.RunIndexing_RGB(ConfigCommon.PCT_INDEX_STORAGE);
            else if (ConfigPCT.COLOR_SPACE_USING == ConfigPCT.ColorSpace.Lab)
                PCTIndexing.RunIndexing_Lab(ConfigCommon.PCT_INDEX_STORAGE);

            //PCTIndexing.RunIndexing_LabColor(Config.PCT_INDEX_STORAGE);

            //Dictionary<String, List<String>> dic = PCTIndexing.LoadImageIndexStrorage(Config.PCT_INDEX_STORAGE);
            
           
         
        }
        
    }
}
