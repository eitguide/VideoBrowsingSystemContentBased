using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace VideoBrowsingSystemContentBased.Widget
{
    public class ImageView : Control
    {
        public Image Image
        {
            get
            {
                return this.Image;
            }
            set
            {
                this.Image = value;
                Invalidate();
            }
        }
        

        protected override void OnPaint(PaintEventArgs e)
        {
           
            Console.WriteLine("OnPaint");
            base.OnPaint(e);
            if (this.Image != null)
            {
                e.Graphics.DrawImage(this.Image, 0, 0, this.Image.Width, this.Image.Height);
            }
        }
    }
}
