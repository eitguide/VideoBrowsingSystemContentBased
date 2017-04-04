
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBrowsingSystemContentBased.Model;
using VideoBrowsingSystemContentBased.Utils;

namespace VideoBrowsingSystemContentBased.Controller.ImageIndexing
{
    public class PCTIndexing
    {
        public static int NUMBER_OF_HORIZONTAL_REGION = 3;
        public static int NUMBER_OF_VERTICAL_REGION = 2;

        public static void WriteVisualWordCell(String folder)
        {
            List<VisualWordCell> visualWordCells = VisualWordHelper.CreateVisualWordCell();

            foreach (VisualWordCell item in visualWordCells)
            {

            }
        }

        public static void RunIndexing(String imageIndexStoragePath)
        {
            List<Color> colorVisualWord = ColorHelper.GenerateColorVisualWord();
            Dictionary<String, List<String>> dic = new Dictionary<String, List<String>>();
            List<VisualWordCell> visualWordCells = VisualWordHelper.CreateVisualWordCell();
            foreach (var item in visualWordCells)
            {
                String key = item.Color.R + "_" + item.Color.G + "_" + item.Color.B + "_" + item.XIndex + "_" + item.YIndex;
                dic.Add(key, new List<String>());
            }


            string[] SubDirs = Directory.GetDirectories(Config.PCT_OUPUT_PATH);

            // Indexing for each files of each folders
            int count = 0;
            foreach (String folderPath in SubDirs)
            {
                Console.WriteLine((++count) + ". " + folderPath);
                FileInfo[] fileInfos = FileManager.GetInstance().GetAllFileInFolder(folderPath);
                int sizeFiles = fileInfos.Length;
                for (int i = 0; i < sizeFiles; i++)
                {
                    // Read color feature from file (PCT)
                    PCTFeature pct = PCTReadingFeature.ReadingFeatureFromFile(fileInfos[i].FullName);
                    float cellWidth = pct.Width / (float)NUMBER_OF_HORIZONTAL_REGION;
                    float cellHeight = pct.Height / (float)NUMBER_OF_VERTICAL_REGION;

                    // Indexing each color of a frame
                    foreach (Dot colorPoint in pct.ListColorPoint)
                    {
                        //int xIndex = (int)(item.location.X / cellWidth);
                        //int yIndex = (int)(item.location.Y / cellHeight);
                        List<RegionOfImage> listRegionDotBelongTo = GetListRegionDotBelongTo(colorPoint, pct.Width, pct.Height);

                        Color color = colorVisualWord[DistanceHelper.ColorKNN(colorPoint.color, colorVisualWord)];

                        foreach (RegionOfImage region in listRegionDotBelongTo)
                        {
                            String key = color.R + "_" + color.G + "_" + color.B + "_" + region.X + "_" + region.Y;
                            dic[key].Add(pct.FrameName);
                        }
                    }

                }
            }

            String json = JsonConvert.SerializeObject(dic);
            FileManager.GetInstance().WriteFile(json, Path.Combine(imageIndexStoragePath, "index.json"));

        }

        struct RegionOfImage
        {
            public int X;
            public int Y;
            public RegionOfImage(int xIndex, int yIndex) { this.X = xIndex; this.Y = yIndex; }
        }

        private static List<RegionOfImage> GetListRegionDotBelongTo(Dot dot, int widthFrame, int heightFrame)
        {
            List<RegionOfImage> resultListRegionDotBelongTo = new List<RegionOfImage>();
            float regionWidth = widthFrame / (float)NUMBER_OF_HORIZONTAL_REGION;
            float regionHeight = heightFrame / (float)NUMBER_OF_VERTICAL_REGION;

            // add first region that dot already belong to
            RegionOfImage firstRegion;
            firstRegion.X = (int)(dot.location.X / regionWidth);
            firstRegion.Y = (int)(dot.location.Y / regionHeight);
            resultListRegionDotBelongTo.Add(firstRegion);

            double distance;
            // check left regions
            if (firstRegion.X > 0)
            {
                #region middle left
                for (int x = firstRegion.X - 1; x >= 0; x--)
                {
                    distance = dot.location.X - regionWidth * (x + 1);
                    if (dot.radius > distance)
                    {
                        RegionOfImage roi = new RegionOfImage(x, firstRegion.Y);
                        resultListRegionDotBelongTo.Add(roi);
                    }
                    else
                        break;
                }
                #endregion
                #region top left
                if (firstRegion.Y > 0)
                    for (int y = firstRegion.Y - 1; y >= 0; y--)
                    {
                        for (int x = firstRegion.X - 1; x >= 0; x--)
                        {
                            distance = DistanceHelper.CalDistance(dot.location, new Point((int)regionWidth * (x + 1), (int)regionHeight * (y + 1)));
                            if (dot.radius > distance)
                            {
                                RegionOfImage roi = new RegionOfImage(x, y);
                                resultListRegionDotBelongTo.Add(roi);
                            }
                            else
                                break;
                        }
                    }
                #endregion
                #region bottom left
                if (firstRegion.Y < NUMBER_OF_VERTICAL_REGION - 1)
                    for (int y = firstRegion.Y + 1; y < NUMBER_OF_VERTICAL_REGION; y++)
                    {
                        for (int x = firstRegion.X - 1; x >= 0; x--)
                        {
                            distance = DistanceHelper.CalDistance(dot.location, new Point((int)regionWidth * (x + 1), (int)regionHeight * y));
                            if (dot.radius > distance)
                            {
                                RegionOfImage roi = new RegionOfImage(x, y);
                                resultListRegionDotBelongTo.Add(roi);
                            }
                            else
                                break;
                        }
                    }
                #endregion
            }
            // check right regions
            if (firstRegion.X < NUMBER_OF_HORIZONTAL_REGION - 1)
            {
                #region middle right
                for (int x = firstRegion.X + 1; x < NUMBER_OF_HORIZONTAL_REGION; x++)
                {
                    distance = regionWidth * x - dot.location.X;
                    if (dot.radius > distance)
                    {
                        RegionOfImage roi = new RegionOfImage(x, firstRegion.Y);
                        resultListRegionDotBelongTo.Add(roi);
                    }
                    else
                        break;
                }
                #endregion
                #region top right
                if (firstRegion.Y > 0)
                    for (int y = firstRegion.Y - 1; y >= 0; y--)
                    {
                        for (int x = firstRegion.X + 1; x < NUMBER_OF_HORIZONTAL_REGION; x++)
                        {
                            distance = DistanceHelper.CalDistance(dot.location, new Point((int)regionWidth * x, (int)regionHeight * (y + 1)));
                            if (dot.radius > distance)
                            {
                                RegionOfImage roi = new RegionOfImage(x, y);
                                resultListRegionDotBelongTo.Add(roi);
                            }
                            else
                                break;
                        }
                    }
                #endregion
                #region bottom right
                if (firstRegion.Y < NUMBER_OF_VERTICAL_REGION - 1)
                    for (int y = firstRegion.Y + 1; y < NUMBER_OF_VERTICAL_REGION; y++)
                    {
                        for (int x = firstRegion.X + 1; x < NUMBER_OF_HORIZONTAL_REGION; x++)
                        {
                            distance = DistanceHelper.CalDistance(dot.location, new Point((int)regionWidth * x, (int)regionHeight * y));
                            if (dot.radius > distance)
                            {
                                RegionOfImage roi = new RegionOfImage(x, y);
                                resultListRegionDotBelongTo.Add(roi);
                            }
                            else
                                break;
                        }
                    }
                #endregion
            }
            // check middle regions
            #region check and add region at middle top
            if (firstRegion.Y > 0)
                for (int y = firstRegion.Y - 1; y >= 0; y--)
                {
                    distance = dot.location.Y - regionHeight * (y + 1);
                    if (dot.radius > distance)
                    {
                        RegionOfImage roi = new RegionOfImage(firstRegion.X, y);
                        resultListRegionDotBelongTo.Add(roi);
                    }
                    else
                        break;
                }
            #endregion
            #region check and add region at middle bottom
            if (firstRegion.Y < NUMBER_OF_VERTICAL_REGION - 1)
                for (int y = firstRegion.Y + 1; y < NUMBER_OF_HORIZONTAL_REGION; y++)
                {
                    distance = regionHeight * y - dot.location.Y;
                    if (dot.radius > distance)
                    {
                        RegionOfImage roi = new RegionOfImage(firstRegion.X, y);
                        resultListRegionDotBelongTo.Add(roi);
                    }
                    else
                        break;
                }
            #endregion

            return resultListRegionDotBelongTo;
        }

        public static List<String> Searching(Dictionary<String, List<String>> dicVisualWords, List<Dot> listDot, Size input)
        {
            if (listDot == null || listDot.Count == 0)
                return null;

            float cellWidth = input.Width / (float)NUMBER_OF_HORIZONTAL_REGION;
            float cellHeight = input.Height / (float)NUMBER_OF_VERTICAL_REGION;

            Dot dot = listDot[0];
            int xIndex = (int)(listDot[0].location.X / cellWidth);
            int yIndex = (int)(listDot[0].location.Y / cellHeight);

            List<Color> colorVisualWord = ColorHelper.GenerateColorVisualWord();
            Color color = colorVisualWord[DistanceHelper.ColorKNN(dot.color, colorVisualWord)];
            String key = color.R + "_" + color.G + "_" + color.B + "_" + xIndex + "_" + yIndex;
            if (dicVisualWords.ContainsKey(key))
                return dicVisualWords[key];

            return null;
        }

        public static List<String> SearchingV2(Dictionary<String, List<String>> dicVisualWords, List<Dot> listDot, Size paperDrawingSize)
        {
            if (listDot == null || listDot.Count == 0)
                return null;

            float cellWidth = paperDrawingSize.Width / (float)NUMBER_OF_HORIZONTAL_REGION;
            float cellHeight = paperDrawingSize.Height / (float)NUMBER_OF_VERTICAL_REGION;

            List<Color> colorVisualWord = ColorHelper.GenerateColorVisualWord();
            //Color color = colorVisualWord[DistanceHelper.ColorKNN(dot.color, colorVisualWord)];
            //String key = color.R + "_" + color.G + "_" + color.B + "_" + xIndex + "_" + yIndex;

            // Get list visual-words match the list colors > dicMatched
            //listDot = new List<Dot>() { new Dot(new Point(50, 120), 50, colorVisualWord[2]) };
            Dictionary<string, List<string>> dicMatched = new Dictionary<string, List<string>>();
            foreach (Dot dot in listDot)
            {
                Color color = colorVisualWord[DistanceHelper.ColorKNN(dot.color, colorVisualWord)];
                List<RegionOfImage> listRegions = GetListRegionDotBelongTo(dot, paperDrawingSize.Width, paperDrawingSize.Height);
                foreach (RegionOfImage region in listRegions)
                {
                    String key = color.R + "_" + color.G + "_" + color.B + "_" + region.X + "_" + region.Y;
                    if (!dicMatched.ContainsKey(key))
                        dicMatched.Add(key, dicVisualWords[key]);
                }
            }

            // Intersect all item in dicMatched
            List<string> listFramesResult = dicMatched.ElementAt(0).Value;
            for (int i = 1; i < dicMatched.Count; i++)
            {
                listFramesResult = dicMatched.ElementAt(i).Value.Intersect(listFramesResult).ToList();
            }

            return listFramesResult;
        }

        public static Dictionary<String, List<String>> LoadImageIndexStrorage(String path)
        {
            String filePath = Path.Combine(path, "index.json");
            String json = FileManager.GetInstance().ReadContentFile(filePath);

            Dictionary<String, List<String>> dic = JsonConvert.DeserializeObject<Dictionary<String, List<String>>>(json);
            return dic;
        }

        public static void LogDic(Dictionary<String, List<String>> dic)
        {
            int count = 0;
            foreach (KeyValuePair<string, List<String>> entry in dic)
            {
                if (entry.Value.Count == 0)
                {
                    //Console.WriteLine(entry.Key);
                    count++;
                }
            }

            Console.WriteLine("Visual Word Empty: " + count);
        }
    }
}
