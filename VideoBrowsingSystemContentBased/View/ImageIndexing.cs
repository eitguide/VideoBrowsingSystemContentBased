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
        private List<VisualWordCell> VisualWord;
        public ImageIndexing()
        {
            InitializeComponent();
            Load += ImageIndexing_Load;
        }

        void ImageIndexing_Load(object sender, EventArgs e)
        {
  
            this.VisualWord = VisualWordHelper.CreateVisualWordCell();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void DrawDot(Graphics g, Dot dot)
        {
            SolidBrush brush = new SolidBrush(dot.color);
            g.FillEllipse(brush, dot.location.X - dot.radius, dot.location.Y - dot.radius, dot.radius * 2, dot.radius * 2);
        }

        private void btnVisualize_Click(object sender, EventArgs e)
        {
            int R = int.Parse(txtR.Text.Trim());
            int G = int.Parse(txtG.Text.Trim());
            int B = int.Parse(txtB.Text.Trim());

            Color c = Color.FromArgb(255, R, G, B);

            List<Color> colorVisualWord = ColorHelper.GenerateColorVisualWord();

            DrawDot(pnVisualizse.CreateGraphics(), new Dot(new Point(50, 50), 20, c));
            int index = DistanceHelper.ColorKNN(c, colorVisualWord);

            Color result = VisualWord[index].Color;
            Console.WriteLine("Index: " + index + ", " + "Color: " + result.ToString());



            Color resultColor = colorVisualWord[index];
            DrawDot(pnVisualizse.CreateGraphics(), new Dot(new Point(100, 50), 20, resultColor));
          

        }

        private void btnVisualizeListColor_Click(object sender, EventArgs e)
        {
            pnListColor.AutoScroll = true;
            pnListColor.CreateGraphics().SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Graphics g = pnListColor.CreateGraphics();
            int x = 0, y = 0;
            int widthEachColor = 30;

            List<Color> colorVisualWord = ColorHelper.GenerateColorVisualWord();
            for (int i = 0; i < colorVisualWord.Count; i++)
            {
                DrawDot(g, new Dot(new Point(x + widthEachColor / 2, y + widthEachColor / 2), widthEachColor / 2, colorVisualWord[i]));
                x += widthEachColor;

                // go to new row 
                if (x + widthEachColor > pnListColor.Width - widthEachColor / 2)
                {
                    x = 0;
                    y += widthEachColor;
                }
            }
        }

        private void btnPCTIndexing_Click(object sender, EventArgs e)
        {
            
            PCTIndexing.RunIndexing(Config.PCT_INDEX_STORAGE);

            Dictionary<String, List<String>> dic = PCTIndexing.LoadImageIndexStrorage(Config.PCT_INDEX_STORAGE);
            
           
         
        }

        
    }
}
