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
        public String FrameName { get; set; }
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
