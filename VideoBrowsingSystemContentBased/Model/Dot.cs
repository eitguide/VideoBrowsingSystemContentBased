using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Model
{
    public class Dot : IShape
    {
        public Point location { get; set; }
        public float radius { get; set; }
        public Color color { get; set; }

        public Dot(Point _location, float _radius, Color _color)
        {
            location = _location;
            radius = _radius;
            color = _color;
        }
    }
}
