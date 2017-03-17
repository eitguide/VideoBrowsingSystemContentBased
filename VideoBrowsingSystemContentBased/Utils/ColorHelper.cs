using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Utils
{
   public class ColorHelper
    {
       /// <summary>
       /// Convert hex color string to Color Object
       /// </summary>
       /// <param name="hex">Hex Color String start with '#'character</param>
       /// <returns></returns>
        public static Color ConvertToARGB(string hex)
        {
            ColorConverter colorConverter = new ColorConverter();
            return (Color)colorConverter.ConvertFromString(hex);
        }
    }
}
