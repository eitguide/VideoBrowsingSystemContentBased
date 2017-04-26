using ColorMine.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Model
{
    public class Dot_Lab
    {
        public Point location { get; set; }
        public float radius { get; set; }
        public Lab color { get; set; }

        public Dot_Lab(Point _location, float _radius, Lab _color)
        {
            location = _location;
            radius = _radius;
            color = _color;
        }
    }
}
