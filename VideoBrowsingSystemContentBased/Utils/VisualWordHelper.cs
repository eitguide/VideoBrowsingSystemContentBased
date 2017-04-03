using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		        for (int xIndex = 0; xIndex < 9; xIndex++)
                {
                    for (int yIndex = 0; yIndex < 6; yIndex++)
                    {
                        listVisualWord.Add(new VisualWordCell(xIndex, yIndex, item));
                    }
                }
	        }

            return listVisualWord;
        }
    }
}
