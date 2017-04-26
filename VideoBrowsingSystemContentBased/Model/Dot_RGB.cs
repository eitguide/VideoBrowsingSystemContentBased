using ColorMine.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Model
{
    public class Dot_RGB : IShape
    {
        public Point location { get; set; }
        public float radius { get; set; }
        public Color color { get; set; }

        public Dot_RGB(Point _location, float _radius, Color _color)
        {
            location = _location;
            radius = _radius;
            color = _color;
        }

        public Dot_Lab ToDotLab()
        {
            Lab labColor = (new Rgb { R = this.color.R, G = this.color.G, B = this.color.B }).To<Lab>();
            return new Dot_Lab(this.location, this.radius, labColor);
        }
    }
}
