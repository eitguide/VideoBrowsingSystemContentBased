using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Model
{
    //using for TextCation run by Densecap model
    public class TextCaption
    {
        //Name of the frame. Example TRECVID2016_35350.shot35350_1.RKF_0.Frame_14.jpg
        public String FrameName { get; set; }

        //Caption Extract from frame
        public String Caption { get; set; }

        public TextCaption()
        {

        }

        public TextCaption(String frameName, String caption)
        {
            this.FrameName = frameName;
            this.Caption = caption;
        }
    }
}
