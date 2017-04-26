using ColorMine.ColorSpaces;
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

        public static List<Color> GenerateColorVisualWord_Rgb()
        {
            //List<Color> visualWord = new List<Color>();
            //int COLOR_MAX = 255;
            //int STEP = 256 / 6;

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
                ColorHelper.ConvertToARGB("#005E1A"),
            };

            return visualWord;
        }

        public static List<Lab> GenerateColorVisualWord_Lab()
        {
            List<Lab> visualWord = new List<Lab>()
            {
                RgbToLab(new Rgb{R = 0,		G = 0,		B = 0}),
                RgbToLab(new Rgb{R = 88,	G = 88,		B = 88}),
                RgbToLab(new Rgb{R = 136,	G = 0,		B = 27}),
                RgbToLab(new Rgb{R = 236,	G = 28,		B = 36}),
                RgbToLab(new Rgb{R = 255,	G = 127,	B = 39}),
                RgbToLab(new Rgb{R = 255,	G = 242,	B = 0}),
                RgbToLab(new Rgb{R = 14,	G = 209,	B = 69}),
                RgbToLab(new Rgb{R = 0,		G = 168,	B = 243}),
                RgbToLab(new Rgb{R = 63,	G = 72,		B = 204}),
                RgbToLab(new Rgb{R = 184,	G = 61,		B = 186}),
                RgbToLab(new Rgb{R = 255,	G = 255,	B = 255}),
                RgbToLab(new Rgb{R = 195,	G = 195,	B = 195}),
                RgbToLab(new Rgb{R = 185,	G = 122,	B = 86}),
                RgbToLab(new Rgb{R = 255,	G = 174,	B = 200}),
                RgbToLab(new Rgb{R = 255,	G = 202,	B = 24}),
                RgbToLab(new Rgb{R = 253,	G = 236,	B = 166}),
                RgbToLab(new Rgb{R = 196,	G = 255,	B = 14}),
                RgbToLab(new Rgb{R = 140,	G = 255,	B = 251}),
                RgbToLab(new Rgb{R = 0,	    G = 94, 	B = 26})
            };

            return visualWord;
        }

        public static Lab RgbToLab(Rgb rgbColor)
        {
            return rgbColor.To<Lab>();
        }

        public static Rgb LabToRgb(Lab labColor)
        {
            return labColor.To<Rgb>();
        }

        public static Color GetBlackOrWhiteColorContrast(Color c)
        {
            return c.GetBrightness() > 0.5 ? Color.Black : Color.White;
        }
    }
}
