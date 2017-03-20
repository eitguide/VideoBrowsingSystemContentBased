using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VideoBrowsingSystemContentBased.Model;

namespace VideoBrowsingSystemContentBased.Utils
{
   public class Decoder
    {
       public static Frame DecodeFrameFromName(String name)
       {
           if (String.IsNullOrEmpty(name))
               return null;
           Frame frame = new Frame();
           //using regex to extract data of frame
           String parttern = @"^TRECVID2016_(\d+).shot\d+_(\d+).*.Frame_(\d+).jpg";

           Regex regex = new Regex(parttern);

           Match match = regex.Match(name);
           if (match.Success)
           {
               String videoId = match.Groups[1].Value;
               int shot = Int32.Parse(match.Groups[2].Value);

               frame.Shot = shot;
               frame.VideoId = videoId;
               frame.FrameNumber = int.Parse(match.Groups[3].Value);
           }

           return frame;
       }
    }
}
