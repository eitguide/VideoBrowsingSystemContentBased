using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Model
{
    public class VisualWordCell_RGB
    {
        public int XIndex { get; set; }
        public int YIndex { get; set; }
        public Color Color { get; set; }

        public VisualWordCell_RGB()
        {

        }

        public VisualWordCell_RGB(int xIndex, int yIndex, Color color)
        {
            this.XIndex = xIndex;
            this.YIndex = yIndex;
            this.Color = color;
        }
    }
}
