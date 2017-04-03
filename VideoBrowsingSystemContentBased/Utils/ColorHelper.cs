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
            List<Color> visualWord = new List<Color>();
            int COLOR_MAX = 255;
            int STEP = 256 / 5;

            int MIX = STEP / 2;
            for (int R = MIX; R <= COLOR_MAX; R += STEP)
            {
                for (int G = MIX; G <= COLOR_MAX; G += STEP)
                {
                    for (int B = MIX; B <= COLOR_MAX; B += STEP)
                    {
                        Color color = Color.FromArgb(255, R, G, B);
                        visualWord.Add(color);
                    }
                }
            }

            return visualWord;
        }
    }
}
