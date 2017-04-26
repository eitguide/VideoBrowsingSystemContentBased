using ColorMine.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBrowsingSystemContentBased.Utils;

namespace VideoBrowsingSystemContentBased.Model
{
    public class PCTFeature_RGB
    {
        public String FrameName { get; set; }
        public int NumberColorPoint { get; set; }
        public int  Width { get; set; }
        public int Height { get; set; }
        public List<Dot_RGB> ListColorPoint { get; set; }

        public PCTFeature_RGB()
        {
            this.ListColorPoint = new List<Dot_RGB>();
        }


        public PCTFeature_Lab ToPCTFeature_Lab()
        {
            PCTFeature_Lab pctFeature_Lab = new PCTFeature_Lab();
            pctFeature_Lab.FrameName = this.FrameName;
            pctFeature_Lab.NumberColorPoint = this.NumberColorPoint;
            pctFeature_Lab.Width = this.Width;
            pctFeature_Lab.Height = this.Height;
            foreach (Dot_RGB dotRGB in this.ListColorPoint)
            {
                Dot_Lab newDotLab = new Dot_Lab(dotRGB.location, dotRGB.radius, 
                    ColorHelper.RgbToLab(new Rgb { R = dotRGB.color.R, G = dotRGB.color.G, B = dotRGB.color.B }));

                pctFeature_Lab.ListColorPoint.Add(newDotLab);
            }

            return pctFeature_Lab;
        }
    }
}
