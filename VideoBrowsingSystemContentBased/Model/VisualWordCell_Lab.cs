using ColorMine.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Model
{
    public class VisualWordCell_Lab
    {
        public int XIndex { get; set; }
        public int YIndex { get; set; }
        public Lab Color { get; set; }

        public VisualWordCell_Lab()
        {

        }

        public VisualWordCell_Lab(int xIndex, int yIndex, Lab color)
        {
            this.XIndex = xIndex;
            this.YIndex = yIndex;
            this.Color = color;
        }
    }
}
