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
    public partial class ViewPCTImage : Form
    {
        //string filePath = @"C:\Users\puyed\Downloads\nghia (4).txt";
        //string IMG_DIR = @"D:\SoureThesis\Data\pct_output\TRECVID2016_35423\TRECVID2016_35423.shot35423_1.RKF_5.Frame_346.txt";
        string PCT_DIR = @"D:\SoureThesis\Data\pct_output";
        string IMG_DIR = @"G:\net\dl380g7a\export\ddn11a2\ledduy\trecvid-avs\keyframe-5\tv2016\test.iacc.3";

        private Image _bitmap;
        List<Color> listVisualWords;
        string currentImgFilePath = null;
        string currentPctFilePath = null;
        ConfigPCT.ColorSpace currentColorSpaceForFormula = ConfigPCT.ColorSpace.Lab;
        ConfigPCT.FormulaLab currentDistanceFormulaLab = ConfigPCT.FormulaLab.Lab_CIE2000;
        ConfigPCT.FormulaRGB currentDistanceFormulaRGB = ConfigPCT.FormulaRGB.RGB_Euclid;

        private string[] allFilePathsPCT = null;

        public ViewPCTImage()
        {
            InitializeComponent();

            listVisualWords = ColorHelper.GenerateColorVisualWord_Rgb();
            allFilePathsPCT = FileManager.GetInstance().GetAllFilePathsRecursive(PCT_DIR);

            ShowRandomImagePCT();
            rbtnCIE2000.Checked = true;
            txtFileNameNoExtension.Text = "Enter filename without extension, then hit Enter!";

            panel1.Paint += panel1_Paint;
            panel2.Paint += panel2_Paint;
            rbtnRgbEuclid.CheckedChanged += radioButton_CheckedChanged;
            rbtnCIE76.CheckedChanged += radioButton_CheckedChanged;
            rbtnCMCIC.CheckedChanged += radioButton_CheckedChanged;
            rbtnCIE94.CheckedChanged += radioButton_CheckedChanged;
            rbtnCIE2000.CheckedChanged += radioButton_CheckedChanged;
            txtFileNameNoExtension.KeyDown += txtFileNameNoExtension_KeyDown;
        }

        void txtFileNameNoExtension_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string textInput = txtFileNameNoExtension.Text.Trim();
                if (!string.IsNullOrEmpty(textInput))
                {
                    try
                    {
                        ShowSpecificImagePCT(textInput);
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("File not found!");
                    }
                }
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRgbEuclid.Checked)
            {
                currentColorSpaceForFormula = ConfigPCT.ColorSpace.RGB;
                currentDistanceFormulaRGB = ConfigPCT.FormulaRGB.RGB_Euclid;
            }
            else if (rbtnCIE76.Checked)
            {
                currentColorSpaceForFormula = ConfigPCT.ColorSpace.Lab;
                currentDistanceFormulaLab = ConfigPCT.FormulaLab.Lab_CIE76;
            }
            else if (rbtnCMCIC.Checked)
            {
                currentColorSpaceForFormula = ConfigPCT.ColorSpace.Lab;
                currentDistanceFormulaLab = ConfigPCT.FormulaLab.Lab_CMCIC;
            }
            else if (rbtnCIE94.Checked)
            {
                currentColorSpaceForFormula = ConfigPCT.ColorSpace.Lab;
                currentDistanceFormulaLab = ConfigPCT.FormulaLab.Lab_CIE94;
            }
            else if (rbtnCIE2000.Checked)
            {
                currentColorSpaceForFormula = ConfigPCT.ColorSpace.Lab;
                currentDistanceFormulaLab = ConfigPCT.FormulaLab.Lab_CIE2000;
            }

            panel1.Refresh();
        }

        private void ShowSpecificImagePCT(string fileNameNoExtension)
        {
            // input: filename
            // output: get value for currentImgFilePath & currentPctFilePath
            currentPctFilePath = string.Format("{0}\\{1}\\{2}.txt", PCT_DIR, fileNameNoExtension.Split('.')[0], fileNameNoExtension);
            currentImgFilePath = string.Format("{0}\\{1}\\{2}.jpg", IMG_DIR, fileNameNoExtension.Split('.')[0], fileNameNoExtension);

            if (!File.Exists(currentPctFilePath))
            {
                throw new System.IO.FileNotFoundException();
            }

            panel1.Refresh();
        }

        private void ShowRandomImagePCT()
        {
            // input: no
            // output: get value for currentImgFilePath & currentPctFilePath
            
            // get the random index
            int randomIndex = RandomHelper.RandomAB(0, allFilePathsPCT.Length - 1);

            // get filePath with the random index below
            currentPctFilePath = allFilePathsPCT[randomIndex];
            string fileNameNoExtension = Path.GetFileNameWithoutExtension(currentPctFilePath);
            currentImgFilePath = string.Format("{0}\\{1}\\{2}.jpg", IMG_DIR, fileNameNoExtension.Split('.')[0], fileNameNoExtension);
            
            panel1.Refresh();
        }

        void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int x = 0, y = 2, radius = 15;
            foreach (Color color in listVisualWords)
            {
                DrawDot(g, new Dot_RGB(new Point(x + radius, y + radius), radius, color));
                x += radius * 2 + 2;
            }
        }

        void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Doc PCT Data
            PCTFeature_RGB data = PCTReadingFeature.ReadingFeatureFromFile_RGB(currentPctFilePath);
            _bitmap = ImageHelper.GetBitmapFromFile(currentImgFilePath);


            // Load data
            panel1.Width = data.Width * 2 + 30;
            panel1.Height = data.Height * 2 + 15;
            panel2.Location = new Point(5, panel1.Location.Y + panel1.Height + 25);
            Graphics g = e.Graphics;

            g.DrawImage(_bitmap, new Point(0, 0));
            g.DrawImage(_bitmap, new Point(15 + data.Width, 15 + data.Height));
            g.DrawImage(_bitmap, new Point(0, 15 + data.Height));


            foreach (Dot_RGB dot in data.ListColorPoint)
            {
                // draw pct dots
                DrawDotWithBorder(g, new Dot_RGB(new Point(dot.location.X, dot.location.Y + data.Height + 15), dot.radius, dot.color));

                // draw visual dots
                Color c = listVisualWords[DistanceHelper.ColorKNN(dot.color, listVisualWords, currentColorSpaceForFormula, currentDistanceFormulaRGB, currentDistanceFormulaLab)];
                if (dot.radius >= 10)
                    DrawDotWithBorder(g, new Dot_RGB(new Point(dot.location.X + data.Width + 15, dot.location.Y + data.Height + 15), dot.radius, c));

            }

           
        }

        private void DrawDot(Graphics g, Dot_RGB dot)
        {
            SolidBrush brush = new SolidBrush(dot.color);
            g.FillEllipse(brush, dot.location.X - dot.radius, dot.location.Y - dot.radius, dot.radius * 2, dot.radius * 2);
        }

        private void DrawDotWithBorder(Graphics g, Dot_RGB dot)
        {
            SolidBrush brush = new SolidBrush(dot.color);
            g.FillEllipse(brush, dot.location.X - dot.radius, dot.location.Y - dot.radius, dot.radius * 2, dot.radius * 2);
            Pen pen = new Pen(ColorHelper.GetBlackOrWhiteColorContrast(dot.color));
            g.DrawEllipse(pen, dot.location.X - dot.radius, dot.location.Y - dot.radius, dot.radius * 2, dot.radius * 2);
        }

        private void btnOpenRandomImage_Click(object sender, EventArgs e)
        {
            ShowRandomImagePCT();
        }

    }
}
