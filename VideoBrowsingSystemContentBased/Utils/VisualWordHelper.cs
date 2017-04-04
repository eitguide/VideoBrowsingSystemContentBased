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
        public static List<VisualWordCell> CreateVisualWordCell()
        {
            List<VisualWordCell> listVisualWord = new List<VisualWordCell>();
          

            List<Color> colorVisualWord = ColorHelper.GenerateColorVisualWord();

            foreach (Color item in colorVisualWord)
	        {
		        for (int xIndex = 0; xIndex < PCTIndexing.NUMBER_OF_HORIZONTAL_REGION; xIndex++)
                {
                    for (int yIndex = 0; yIndex < PCTIndexing.NUMBER_OF_VERTICAL_REGION; yIndex++)
                    {
                        listVisualWord.Add(new VisualWordCell(xIndex, yIndex, item));
                    }
                }
	        }

            return listVisualWord;
        }
    }
}
