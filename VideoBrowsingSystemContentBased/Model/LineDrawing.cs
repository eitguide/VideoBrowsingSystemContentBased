using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Model
{
    public class LineDrawing : IShape
    {
        public List<Point> listPoint { get; set; }
        public Color color { get; set; }
        public float size { get; set; }

        public LineDrawing(Color _color, float _size)
        {
            color = _color;
            size = _size;
            listPoint = new List<Point>();
        }
    }
}
