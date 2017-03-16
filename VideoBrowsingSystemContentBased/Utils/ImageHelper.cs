using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Utils
{
    public class ImageHelper
    {
        public static Image GetImageFromFile(String path)
        {
            return Image.FromFile(path);
        }

        public static Bitmap GetBitmapFromFile(String path)
        {
            return new Bitmap(GetImageFromFile(path));
        }
    }
}
