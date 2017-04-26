using ColorMine.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBrowsingSystemContentBased.Controller.ImageIndexing;
using VideoBrowsingSystemContentBased.Model;

namespace VideoBrowsingSystemContentBased.Utils
{
    public class VisualWordHelper
    {
        public static List<VisualWordCell_RGB> CreateListVWKeys_Rgb()
        {
            List<VisualWordCell_RGB> listVisualWord = new List<VisualWordCell_RGB>();
          

            List<Color> colorVisualWord = ColorHelper.GenerateColorVisualWord_Rgb();

            foreach (Color item in colorVisualWord)
	        {
                for (int xIndex = 0; xIndex < ConfigPCT.PCT_NUMBER_OF_HORIZONTAL_REGION; xIndex++)
                {
                    for (int yIndex = 0; yIndex < ConfigPCT.PCT_NUMBER_OF_VERTICAL_REGION; yIndex++)
                    {
                        listVisualWord.Add(new VisualWordCell_RGB(xIndex, yIndex, item));
                    }
                }
	        }

            return listVisualWord;
        }

        public static List<VisualWordCell_Lab> CreateListVWKeys_Lab()
        {
            List<VisualWordCell_Lab> listVisualWord = new List<VisualWordCell_Lab>();


            List<Lab> colorVisualWord = ColorHelper.GenerateColorVisualWord_Lab();

            foreach (Lab item in colorVisualWord)
            {
                for (int xIndex = 0; xIndex < ConfigPCT.PCT_NUMBER_OF_HORIZONTAL_REGION; xIndex++)
                {
                    for (int yIndex = 0; yIndex < ConfigPCT.PCT_NUMBER_OF_VERTICAL_REGION; yIndex++)
                    {
                        listVisualWord.Add(new VisualWordCell_Lab(xIndex, yIndex, item));
                    }
                }
            }

            return listVisualWord;
        }
    }
}
