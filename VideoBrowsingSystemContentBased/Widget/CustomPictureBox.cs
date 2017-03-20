using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBrowsingSystemContentBased.Utils;

namespace VideoBrowsingSystemContentBased.Widget
{
    public class CustomPictureBox: PictureBox
    {
       
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, ColorHelper.ConvertToARGB("#16a085"), ButtonBorderStyle.Solid);
		}
    }
  
}
