using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Model
{
    public class Frame
    {
        public String FrameName { get; set; }
        public String SemanticContent { get; set; }
        public String VideoId { get; set; }
        public int Shot { get; set; }
        public String VideoName { get; set; }
        public String Thumb { get; set; }
        public Bitmap FrameImage { get; set; }
        public int FrameNumber { get; set; }



        public Frame()
        {
           
        }

        public Frame(String frameName, String semanticContent, String videoId, int shot, String videoName, String thumb, int frameNumber )
        {
            this.FrameName = frameName;
            this.SemanticContent = semanticContent;
            this.VideoId = videoId;
            this.Shot = shot;
            this.VideoName = this.VideoName;
            this.Thumb = thumb;
            this.FrameNumber = frameNumber;
        }
    }
}
