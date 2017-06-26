using ColorMine.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBrowsingSystemContentBased.Model;
using VideoBrowsingSystemContentBased.Utils;

namespace VideoBrowsingSystemContentBased.Controller.ImageIndexing
{
    public class PCTSearching
    {
        public static List<String> Searching(Dictionary<String, List<String>> dicVisualWords, List<Dot_RGB> listDot, Size input)
        {
            if (listDot == null || listDot.Count == 0)
                return null;

            float cellWidth = input.Width / (float)ConfigPCT.PCT_NUMBER_OF_HORIZONTAL_REGION;
            float cellHeight = input.Height / (float)ConfigPCT.PCT_NUMBER_OF_VERTICAL_REGION;

            Dot_RGB dot = listDot[0];
            int xIndex = (int)(listDot[0].location.X / cellWidth);
            int yIndex = (int)(listDot[0].location.Y / cellHeight);

            List<Color> colorVisualWord = ColorHelper.GenerateColorVisualWord_Rgb();
            Color color = colorVisualWord[DistanceHelper.ColorKNN_RGB(dot.color, colorVisualWord)];
            String key = color.R + "_" + color.G + "_" + color.B + "_" + xIndex + "_" + yIndex;
            if (dicVisualWords.ContainsKey(key))
                return dicVisualWords[key];

            return null;
        }

        public static List<String> SearchingV2_RGB(Dictionary<string, List<string>> dicVisualWords, List<Dot_RGB> listDotDrawn, Size paperDrawingSize)
        {
            if (listDotDrawn == null || listDotDrawn.Count == 0)
                return null;

            // init
            bool SEARCH_MULTI_REGION_FOR_INPUT_DOTS = true;
            List<Color> colorsVisualWord = ColorHelper.GenerateColorVisualWord_Rgb();

            // Get list visual-words match the list input colors >> dicMatched
            Dictionary<string, List<string>> dicInputColorsMatchedTheIndex = new Dictionary<string, List<string>>();
            foreach (Dot_RGB dot in listDotDrawn)
            {
                Color color = dot.color;
                color = colorsVisualWord[DistanceHelper.ColorKNN_RGB(dot.color, colorsVisualWord)];
                List<RegionOfFrame> listRegionsDotBelongTo = Utils.RegionOfFrameHelper.GetListRegionDotBelongTo(dot.location, dot.radius, paperDrawingSize.Width, paperDrawingSize.Height);
                foreach (RegionOfFrame region in listRegionsDotBelongTo)
                {
                    String key = color.R + "_" + color.G + "_" + color.B + "_" + region.X + "_" + region.Y;
                    if (!dicInputColorsMatchedTheIndex.ContainsKey(key))
                        dicInputColorsMatchedTheIndex.Add(key, dicVisualWords[key]);
                    if (!SEARCH_MULTI_REGION_FOR_INPUT_DOTS)
                        break;
                }
            }

            // Intersect all item in dicMatched
            List<string> listFramesResult = dicInputColorsMatchedTheIndex.ElementAt(0).Value;
            for (int i = 1; i < dicInputColorsMatchedTheIndex.Count; i++)
            {
                listFramesResult = dicInputColorsMatchedTheIndex.ElementAt(i).Value.Intersect(listFramesResult).ToList();
            }

            return listFramesResult;
        }

        public static List<String> SearchingV3_RGB(Dictionary<string, string> dicVisualWords, List<Dot_RGB> listDotDrawn, Size paperDrawingSize)
        {
            if (listDotDrawn == null || listDotDrawn.Count == 0)
                return null;

            // init
            bool SEARCH_MULTI_REGION_FOR_INPUT_DOTS = true;
            List<Color> colorsVisualWord = ColorHelper.GenerateColorVisualWord_Rgb();

            // Get list visual-words match the list input colors >> dicMatched
            Dictionary<string, List<string>> dicInputColorsMatchedTheIndex = new Dictionary<string, List<string>>();
            List<string> listKeyMatchTheInputDot = new List<string>();
            foreach (Dot_RGB dot in listDotDrawn)
            {
                Color color = colorsVisualWord[DistanceHelper.ColorKNN_RGB(dot.color, colorsVisualWord)];
                List<RegionOfFrame> listRegionsDotBelongTo = Utils.RegionOfFrameHelper.GetListRegionDotBelongTo(dot.location, dot.radius, paperDrawingSize.Width, paperDrawingSize.Height);
                foreach (RegionOfFrame region in listRegionsDotBelongTo)
                {
                    string key = color.R + "_" + color.G + "_" + color.B + "_" + region.X + "_" + region.Y;
                    //if (!dicInputColorsMatchedTheIndex.ContainsKey(key))
                    //{
                    //    dicInputColorsMatchedTheIndex.Add(key, dicVisualWords[key]);
                    //}
                    if (!listKeyMatchTheInputDot.Contains(key))
                        listKeyMatchTheInputDot.Add(key);
                    if (!SEARCH_MULTI_REGION_FOR_INPUT_DOTS)
                        break;
                }
            }

            // Intersect all item in dicMatched (để lọc bỏ frame trùng ở kết quả)
            //List<string> listFramesResult = dicInputColorsMatchedTheIndex.ElementAt(0).Value;
            List<string> listFramesResult = FileManager.GetInstance().GetAllLinesFromFile(dicVisualWords[listKeyMatchTheInputDot[0]]);
            for (int i = 1; i < listKeyMatchTheInputDot.Count; i++)
            {
                //listFramesResult = dicInputColorsMatchedTheIndex.ElementAt(i).Value.Intersect(listFramesResult).ToList();
                List<string> listFrame = FileManager.GetInstance().GetAllLinesFromFile(dicVisualWords[listKeyMatchTheInputDot[i]]);
                listFramesResult = listFramesResult.Intersect(listFrame).ToList();
            }

            return listFramesResult;
        }

        public static List<String> SearchingV2_Lab(Dictionary<string, List<string>> dicVisualWords, List<Dot_Lab> listDotDrawn, Size paperDrawingSize)
        {
            if (listDotDrawn == null || listDotDrawn.Count == 0)
                return null;

            // init
            bool SEARCH_MULTI_REGION_FOR_INPUT_DOTS = true;
            List<Lab> colorsVisualWord = ColorHelper.GenerateColorVisualWord_Lab();

            // Get list visual-words match the list input colors >> dicMatched
            Dictionary<string, List<string>> dicInputColorsMatchedTheIndex = new Dictionary<string, List<string>>();
            foreach (Dot_Lab dot in listDotDrawn)
            {
                Lab color = dot.color;
                color = colorsVisualWord[DistanceHelper.ColorKNN_Lab(dot.color, colorsVisualWord)];
                List<RegionOfFrame> listRegionsDotBelongTo = Utils.RegionOfFrameHelper.GetListRegionDotBelongTo(dot.location, dot.radius, paperDrawingSize.Width, paperDrawingSize.Height);
                foreach (RegionOfFrame region in listRegionsDotBelongTo)
                {
                    string key = color.L + "_" + color.A + "_" + color.B + "_" + region.X + "_" + region.Y;
                    if (!dicInputColorsMatchedTheIndex.ContainsKey(key))
                    {
                        dicInputColorsMatchedTheIndex.Add(key, dicVisualWords[key]);
                    }
                    if (!SEARCH_MULTI_REGION_FOR_INPUT_DOTS)
                        break;
                }
            }

            // Intersect all item in dicMatched
            List<string> listFramesResult = dicInputColorsMatchedTheIndex.ElementAt(0).Value;
            for (int i = 1; i < dicInputColorsMatchedTheIndex.Count; i++)
            {
                listFramesResult = dicInputColorsMatchedTheIndex.ElementAt(i).Value.Intersect(listFramesResult).ToList();
            }

            return listFramesResult;
        }

        public static List<String> SearchingV3_Lab(Dictionary<string, string> dicVisualWords, List<Dot_Lab> listDotDrawn, Size paperDrawingSize)
        {
            if (listDotDrawn == null || listDotDrawn.Count == 0)
                return null;

            // init
            bool SEARCH_MULTI_REGION_FOR_INPUT_DOTS = true;
            List<Lab> colorsVisualWord = ColorHelper.GenerateColorVisualWord_Lab();

            // Get list visual-words match the list input colors >> dicMatched
            Dictionary<string, List<string>> dicInputColorsMatchedTheIndex = new Dictionary<string, List<string>>();
            List<string> listKeyMatchTheInputDot = new List<string>();
            foreach (Dot_Lab dot in listDotDrawn)
            {
                Lab color = colorsVisualWord[DistanceHelper.ColorKNN_Lab(dot.color, colorsVisualWord)];
                List<RegionOfFrame> listRegionsDotBelongTo = Utils.RegionOfFrameHelper.GetListRegionDotBelongTo(dot.location, dot.radius, paperDrawingSize.Width, paperDrawingSize.Height);
                foreach (RegionOfFrame region in listRegionsDotBelongTo)
                {
                    string key = color.L + "_" + color.A + "_" + color.B + "_" + region.X + "_" + region.Y;
                    //if (!dicInputColorsMatchedTheIndex.ContainsKey(key))
                    //{
                    //    dicInputColorsMatchedTheIndex.Add(key, dicVisualWords[key]);
                    //}
                    if (!listKeyMatchTheInputDot.Contains(key))
                        listKeyMatchTheInputDot.Add(key);
                    if (!SEARCH_MULTI_REGION_FOR_INPUT_DOTS)
                        break;
                }
            }

            // Intersect all item in dicMatched (để lọc bỏ frame trùng ở kết quả)
            //List<string> listFramesResult = dicInputColorsMatchedTheIndex.ElementAt(0).Value;
            List<string> listFramesResult = FileManager.GetInstance().GetAllLinesFromFile(dicVisualWords[listKeyMatchTheInputDot[0]]);
            for (int i = 1; i < listKeyMatchTheInputDot.Count; i++)
            {
                //listFramesResult = dicInputColorsMatchedTheIndex.ElementAt(i).Value.Intersect(listFramesResult).ToList();
                List<string> listFrame = FileManager.GetInstance().GetAllLinesFromFile(dicVisualWords[listKeyMatchTheInputDot[i]]);
                listFramesResult = listFramesResult.Intersect(listFrame).ToList();
            }

            return listFramesResult;
        }
    }
}
