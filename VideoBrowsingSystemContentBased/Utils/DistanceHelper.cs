using ColorMine.ColorSpaces;
using ColorMine.ColorSpaces.Comparisons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBrowsingSystemContentBased.Model;

namespace VideoBrowsingSystemContentBased.Utils
{
    public class DistanceHelper
    {
        public delegate double CalDistanceLabDlgt(ColorSpace color1, ColorSpace color2);
        public static CalDistanceLabDlgt calDistanceLabHandler = null;
        public static void InitPCT()
        {
            if (ConfigPCT.COLOR_SPACE_USING == ConfigPCT.ColorSpace.Lab)
            {
                if (ConfigPCT.FORMULA_LAB_USING == ConfigPCT.FormulaLab.Lab_CIE76)
                    calDistanceLabHandler = CalDistance_CIE76;
                else if (ConfigPCT.FORMULA_LAB_USING == ConfigPCT.FormulaLab.Lab_CMCIC)
                    calDistanceLabHandler = CalDistance_CMCIC;
                else if (ConfigPCT.FORMULA_LAB_USING == ConfigPCT.FormulaLab.Lab_CIE94)
                    calDistanceLabHandler = CalDistance_CIE94;
                else if (ConfigPCT.FORMULA_LAB_USING == ConfigPCT.FormulaLab.Lab_CIE2000)
                    calDistanceLabHandler = CalDistance_CIE2000;
            }
        }

        public static double CalDistanceBetween2Points(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public static double CalDistance_RGBEuclid(Color color1, Color color2)
        {
            double R_2 = Math.Pow(color1.R - color2.R, 2);
            double G_2 = Math.Pow(color1.G - color2.G, 2);
            double B_2 = Math.Pow(color1.B - color2.B, 2);
            return Math.Sqrt(R_2 + G_2 + B_2);
        }

        public static double CalDistance_CIE76(ColorSpace color1, ColorSpace color2)
        {
            //double deltaE = color1.Compare(color2, new Cie1976Comparison());
            double deltaE = 0;
            Lab c1 = color1.To<Lab>();
            Lab c2 = color2.To<Lab>();

            double _L = (c1.L - c2.L) * (c1.L - c2.L);
            double _a = (c1.A - c2.A) * (c1.A - c2.A);
            double _b = (c1.B - c2.B) * (c1.B - c2.B);
            deltaE = Math.Sqrt(_L + (_a + _b) * 3);

            return deltaE;
        }

        public static double CalDistance_CMCIC(ColorSpace color1, ColorSpace color2)
        {
            double deltaE = color1.Compare(color2, new CmcComparison(lightness: 2, chroma: 1));
            return deltaE;
        }

        public static double CalDistance_CIE94(ColorSpace color1, ColorSpace color2)
        {
            double deltaE = color1.Compare(color2, new Cie94Comparison(Cie94Comparison.Application.GraphicArts));
            return deltaE;
        }

        public static double CalDistance_CIE2000(ColorSpace color1, ColorSpace color2)
        {
            double deltaE = color1.Compare(color2, new CieDe2000Comparison());
            return deltaE;
        }

        /// <summary>
        /// Find Color nearest
        /// </summary>
        /// <param name="color"></param>
        /// <param name="listColor"></param>
        /// <returns></returns>
        public static int ColorKNN_RGB(Color color, List<Color> listColor)
        {
            if (listColor == null || listColor.Count == 0)
                return -1;

            double minDistance = CalDistance_RGBEuclid(color, listColor[0]);

            int size = listColor.Count;
            int indexColor = 0;
            for (int i = 1; i < size; i++)
            {
                double dis = CalDistance_RGBEuclid(color, listColor[i]);

                if (dis < minDistance)
                {
                    minDistance = dis;
                    indexColor = i;
                }
            }
            return indexColor;
        }

        public static int ColorKNN_Lab(Lab color, List<Lab> listColor)
        {
            if (listColor == null || listColor.Count == 0)
                return -1;

            double minDistance = calDistanceLabHandler(color, listColor[0]);

            int size = listColor.Count;
            int indexColor = 0;
            for (int i = 1; i < size; i++)
            {
                double dis = calDistanceLabHandler(color, listColor[i]);

                if (dis < minDistance)
                {
                    minDistance = dis;
                    indexColor = i;
                }
            }
            return indexColor;
        }

        // force to use a formula to calculate
        public static int ColorKNN(Color c, List<Color> listColor, ConfigPCT.ColorSpace colorSpace, ConfigPCT.FormulaRGB formulaRGBForUse, ConfigPCT.FormulaLab formulaLabForUse)
        {
            if (listColor == null || listColor.Count == 0)
                return -1;

            CalDistanceLabDlgt calDistanceHandlerLocal = null;
            if (colorSpace == ConfigPCT.ColorSpace.Lab)
            {
                if (formulaLabForUse == ConfigPCT.FormulaLab.Lab_CIE76)
                    calDistanceHandlerLocal = CalDistance_CIE76;
                else if (formulaLabForUse == ConfigPCT.FormulaLab.Lab_CMCIC)
                    calDistanceHandlerLocal = CalDistance_CMCIC;
                else if (formulaLabForUse == ConfigPCT.FormulaLab.Lab_CIE94)
                    calDistanceHandlerLocal = CalDistance_CIE94;
                else if (formulaLabForUse == ConfigPCT.FormulaLab.Lab_CIE2000)
                    calDistanceHandlerLocal = CalDistance_CIE2000;
            }

            Lab labColor = ColorHelper.RgbToLab(new Rgb { R = c.R, G = c.G, B = c.B });
            double minDistance;
            if (colorSpace == ConfigPCT.ColorSpace.RGB)
                minDistance = CalDistance_RGBEuclid(c, listColor[0]);
            else
                minDistance = calDistanceHandlerLocal(labColor, ColorHelper.RgbToLab(new Rgb { R = listColor[0].R, G = listColor[0].G, B = listColor[0].B }));

            int size = listColor.Count;
            int indexColor = 0;
            for (int i = 1; i < size; i++)
            {
                double dis;
                if (colorSpace == ConfigPCT.ColorSpace.RGB)
                    dis = CalDistance_RGBEuclid(c, listColor[i]);
                else
                    dis = calDistanceHandlerLocal(labColor, ColorHelper.RgbToLab(new Rgb { R = listColor[i].R, G = listColor[i].G, B = listColor[i].B }));

                if (dis < minDistance)
                {
                    minDistance = dis;
                    indexColor = i;
                }
            }
            return indexColor;
        }
    }
}
