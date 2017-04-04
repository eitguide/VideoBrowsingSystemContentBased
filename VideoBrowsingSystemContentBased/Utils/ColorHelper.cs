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

        public static List<Color> GenerateColorVisualWord()
        {
            //List<Color> visualWord = new List<Color>();
            //int COLOR_MAX = 255;
            //int STEP = 256 / 2;

            //int MIX = STEP / 2;
            //for (int R = MIX; R <= COLOR_MAX; R += STEP)
            //{
            //    for (int G = MIX; G <= COLOR_MAX; G += STEP)
            //    {
            //        for (int B = MIX; B <= COLOR_MAX; B += STEP)
            //        {
            //            Color color = Color.FromArgb(255, R, G, B);
            //            visualWord.Add(color);
            //        }
            //    }
            //}

            List<Color> visualWord = new List<Color>()
            {
                ColorHelper.ConvertToARGB("#000000"),
                ColorHelper.ConvertToARGB("#585858"),
                ColorHelper.ConvertToARGB("#88001B"),
                ColorHelper.ConvertToARGB("#EC1C24"),
                ColorHelper.ConvertToARGB("#FF7F27"),
                ColorHelper.ConvertToARGB("#FFF200"),
                ColorHelper.ConvertToARGB("#0ED145"),
                ColorHelper.ConvertToARGB("#00A8F3"),
                ColorHelper.ConvertToARGB("#3F48CC"),
                ColorHelper.ConvertToARGB("#B83DBA"),
                ColorHelper.ConvertToARGB("#FFFFFF"),
                ColorHelper.ConvertToARGB("#C3C3C3"),
                ColorHelper.ConvertToARGB("#B97A56"),
                ColorHelper.ConvertToARGB("#FFAEC8"),
                ColorHelper.ConvertToARGB("#FFCA18"),
                ColorHelper.ConvertToARGB("#FDECA6"),
                ColorHelper.ConvertToARGB("#C4FF0E"),
                ColorHelper.ConvertToARGB("#8CFFFB"),
            };

            return visualWord;
        }
    }
}
