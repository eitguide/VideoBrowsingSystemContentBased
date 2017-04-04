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
        public static double CalDistance(Color color1, Color color2)
        {
            double R_2 = Math.Pow(color1.R - color2.R, 2);
            double G_2 =  Math.Pow(color1.G - color2.G, 2);
            double B_2 = Math.Pow(color1.B - color2.B, 2);
            return Math.Sqrt(R_2 + G_2 + B_2);
        }

        public static double CalDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        /// <summary>
        /// Find Color nearest
        /// </summary>
        /// <param name="c"></param>
        /// <param name="listColor"></param>
        /// <returns></returns>
        public static int ColorKNN(Color c, List<Color> listColor)
        {
            if (listColor == null || listColor.Count == 0)
                return -1;

            double minDistance = CalDistance(c, listColor[0]);
            int size = listColor.Count;
            int indexColor = 0;
            for (int i = 1; i < size; i++)
            {
                double dis = CalDistance(c, listColor[i]);
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
