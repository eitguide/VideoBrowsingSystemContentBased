using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBrowsingSystemContentBased.Model;
using VideoBrowsingSystemContentBased.Utils;

namespace VideoBrowsingSystemContentBased.View
{
    public partial class ImageIndexing : Form
    {
        private List<Color> VisualWord;
        public ImageIndexing()
        {
            InitializeComponent();
            Load += ImageIndexing_Load;
        }

        void ImageIndexing_Load(object sender, EventArgs e)
        {
            this.VisualWord = ColorHelper.GenerateColorVisualWord();
            Console.WriteLine("Size: " + this.VisualWord.Count);
            
            int SMALL_DISTANCE = 64;
            List<Color> listRemove = new List<Color>();
            foreach (Color c1 in this.VisualWord)
            {
                int i =0 ;
                foreach (Color c2 in this.VisualWord)
                {
                    if (c1.R == c2.R && c1.G == c2.G && c1.B == c2.B)
                        break;

                    double distance = DistanceHelper.CalDistance(c1, c2);
                    Console.WriteLine("DISTANCE: " + distance);
                    if (distance <= SMALL_DISTANCE)
                    {
                        if (!listRemove.Contains(c2))
                        {
                            listRemove.Add(c2);
                        }
                    }
                }
            }
            foreach (Color c in listRemove)
            {
                this.VisualWord.Remove(c);
            }
            Console.WriteLine("Size: " + this.VisualWord.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.VisualWord = ColorHelper.GenerateColorVisualWord();
            Console.WriteLine("Generate Finished");
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

            DrawDot(pnVisualizse.CreateGraphics(), new Dot(new Point(50, 50), 20, c));
            int index = DistanceHelper.ColorKNN(c, this.VisualWord);

            Color result = VisualWord[index];
            Console.WriteLine("Index: " + index + ", " + "Color: " + result.ToString());

            Color resultColor = VisualWord[index];
            DrawDot(pnVisualizse.CreateGraphics(), new Dot(new Point(100, 50), 20, resultColor));
          

        }

        private void btnVisualizeListColor_Click(object sender, EventArgs e)
        {
            pnListColor.AutoScroll = true;
            pnListColor.CreateGraphics().SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int x = 0, y = 0;
            int widthEachColor = 30;
            for (int i = 0; i < this.VisualWord.Count; i++)
            {
                DrawDot(pnListColor.CreateGraphics(), new Dot(new Point(x + widthEachColor / 2, y + widthEachColor / 2), widthEachColor / 2, this.VisualWord[i]));
                x += widthEachColor;

                // go to new row 
                if (x + widthEachColor > pnListColor.Width - widthEachColor / 2)
                {
                    x = 0;
                    y += widthEachColor;
                }
            }
        }
    }
}
