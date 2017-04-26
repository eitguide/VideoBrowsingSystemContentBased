using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Model
{
    public class RegionOfFrame
    {
        public int X;
        public int Y;

        public RegionOfFrame(int xIndex, int yIndex) { this.X = xIndex; this.Y = yIndex; }

        public RegionOfFrame() { }
    }
}
