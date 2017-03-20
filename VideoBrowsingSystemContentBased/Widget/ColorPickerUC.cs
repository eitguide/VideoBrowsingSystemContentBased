using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace VideoBrowsingSystemContentBased.Widget
{
    public partial class ColorPickerUC : UserControl
    {
       Point selection;
        private bool mouseDown;
        Bitmap bitmap;
        Color color; 

        public ColorPickerUC()
        {
            InitializeComponent();
            DoubleBuffered = true;
            bitmap = this.BackgroundImage as Bitmap;
            bitmap = new Bitmap(bitmap, this.Width, this.Height);
           
        }

        public Color GetColor()
        {
            return color;
        }

        private void ColorPickerUC_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 1F))
            {
                pen.DashStyle = DashStyle.Dash;
                System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(selection.X - 5, selection.Y - 5, 10, 10);
                e.Graphics.DrawRectangle(pen, rectangle);
            }
        }

        private void ColorPickerUC_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Location: " + e.Location.ToString());
            int x = (e.X >= 0) ? e.X : 0;
            x = (x < this.Width) ? x : this.Width - 1;
            int y = (e.Y >= 0) ? e.Y : 0;
            y = (y < this.Height) ? y : this.Height - 1;


            selection = PointToClient(MousePosition);
            GetColorAtPixel(x, y);

            Console.WriteLine(RGBConverter(color));
            mouseDown = true;
            Invalidate();
            Refresh();
        }

        private void ColorPickerUC_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown)
            {
                return;
            }

            Console.WriteLine("Location: " + e.Location.ToString());
            int x = (e.X >= 0) ? e.X : 0;
            x = (x < this.Width) ? x : this.Width - 1;
            int y = (e.Y >= 0) ? e.Y : 0;
            y = (y < this.Height) ? y : this.Height - 1;

            selection = PointToClient(MousePosition);

            GetColorAtPixel(x, y);
            Console.WriteLine(RGBConverter(color));
            Invalidate();
            Refresh();
        }

        private void ColorPickerUC_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Location: " + e.Location.ToString());
            mouseDown = false;
            int x = (e.X >= 0) ? e.X : 0;
            x = (x < this.Width) ? x : this.Width - 1;
            int y = (e.Y >= 0) ? e.Y : 0;
            y = (y < this.Height) ? y : this.Height - 1;


            selection = PointToClient(MousePosition);
            GetColorAtPixel(x, y);
            Console.WriteLine(RGBConverter(color));
            Invalidate();
            Refresh();
        }

        private void ColorPickerUC_SizeChanged(object sender, EventArgs e)
        {
            UpdateBitmap();
        }

        private static String RGBConverter(System.Drawing.Color c)
        {
            return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        }

        public void UpdateBitmap()
        {
            if (this.Width == 0) return;
            if (this.Height == 0) return;
            bitmap = this.BackgroundImage as Bitmap;
            bitmap = new Bitmap(bitmap, this.Width, this.Height);
        }

        public void GetColorAtPixel(int x, int y)
        {
            //if (Variables.IsGetColorByAverage == false)
            //{
            //    color = bitmap.GetPixel(x, y);
            //}
            //else
            //{
            //    int R_Sum = 0;
            //    int G_Sum = 0;
            //    int B_Sum = 0;

            //    Color temp;
            //    for (int i = x - 4; i <= x + 4; i++)
            //    {
            //        if (i < 0 || i > this.Width) continue;
            //        for (int j = y - 4; j <= y + 4; j++)
            //        {
            //            if (j < 0 || j > this.Height) continue;

            //            temp = bitmap.GetPixel(x, y);
            //            R_Sum += temp.R;
            //            G_Sum += temp.G;
            //            B_Sum += temp.B;

            //        }
            //    }

            //    color = Color.FromArgb(Convert.ToInt32(R_Sum / 81), Convert.ToInt32(G_Sum / 81), Convert.ToInt32(B_Sum / 81));
            //}
            color = bitmap.GetPixel(x, y);
        }
    }
}
