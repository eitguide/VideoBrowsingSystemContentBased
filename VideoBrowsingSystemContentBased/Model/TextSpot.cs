using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Model
{
    public class TextSpot
    {
        public String FileName { get; set; }
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
