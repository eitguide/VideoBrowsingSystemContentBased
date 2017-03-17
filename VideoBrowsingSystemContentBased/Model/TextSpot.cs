using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Model
{
    public class TextSpot
    {
        //Name of the frame. Example TRECVID2016_35350.shot35350_1.RKF_0.Frame_14.jpg
        public String FileName { get; set; }

        //Text Extract from frame
        public String Text { get; set; }

        public TextSpot()
        {

        }

        public TextSpot(String fileName, String textPlot)
        {
            this.FileName = fileName;
            this.Text = textPlot;
        }
    }
}
