using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoBrowsingSystemContentBased.Widget
{
    public class CustomPictureBox: PictureBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
    }
  
}
