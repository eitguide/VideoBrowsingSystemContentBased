using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Model
{
    public class PCTFeature_Lab
    {
        public String FrameName { get; set; }
        public int NumberColorPoint { get; set; }
        public int  Width { get; set; }
        public int Height { get; set; }
        public List<Dot_Lab> ListColorPoint { get; set; }

        public PCTFeature_Lab()
        {
            this.ListColorPoint = new List<Dot_Lab>();
        }
    }
}
