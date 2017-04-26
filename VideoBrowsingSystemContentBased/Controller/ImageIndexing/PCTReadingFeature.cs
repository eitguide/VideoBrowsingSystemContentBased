using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBrowsingSystemContentBased.Model;

namespace VideoBrowsingSystemContentBased.Controller.ImageIndexing
{
    public class PCTReadingFeature
    {
        public static PCTFeature_RGB ReadingFeatureFromFile_RGB(String filePath)
        {
            if (!File.Exists(filePath))
                return null;

            String path = Path.GetFileNameWithoutExtension(filePath);

            String content = FileManager.GetInstance().ReadContentFile(filePath);

            String[] rows = content.Split('\n');
            String[] header = rows[0].Split('\t');
            int numberColorPoint = int.Parse(header[0]);
            int widthFrame = int.Parse(header[1]);
            int heightFrame = int.Parse(header[2]);

            PCTFeature_RGB pct = new PCTFeature_RGB();
            pct.FrameName = path;
            pct.NumberColorPoint = numberColorPoint;
            pct.Width = widthFrame;
            pct.Height = heightFrame;

            for (int index = 2; index < pct.NumberColorPoint + 2; index++)
            {
                String[] str = rows[index].Split('\t');
                int x = int.Parse(str[0].Trim());
                int y = int.Parse(str[1].Trim());
                int radius = int.Parse(str[2].Trim());

                int b = int.Parse(str[3].Trim());
                int g = int.Parse(str[4].Trim());
                int r = int.Parse(str[5].Trim());

                Dot_RGB dot = new Dot_RGB(new Point(x, y), radius, Color.FromArgb(255, r, g, b));
                pct.ListColorPoint.Add(dot);

            }

            return pct;
        }


        public static PCTFeature_Lab ReadingFeatureFromFile_Lab(String filePath)
        {
            PCTFeature_RGB pctFeature_RGB = ReadingFeatureFromFile_RGB(filePath);
            if (pctFeature_RGB == null) return null;

            PCTFeature_Lab pctFeature_Lab = pctFeature_RGB.ToPCTFeature_Lab();
            return pctFeature_Lab;
        }

    }
}
