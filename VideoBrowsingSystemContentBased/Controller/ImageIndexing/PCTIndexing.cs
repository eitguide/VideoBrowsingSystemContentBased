
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

            foreach (String folderPath in SubDirs)
            {
                Console.WriteLine(folderPath);
                FileInfo[] fileInfos = FileManager.GetInstance().GetAllFileInFolder(folderPath);
                int sizeFiles = fileInfos.Length;
                for (int i = 0; i < sizeFiles; i++)
                {
                    PCTFeature pct = PCTReadingFeature.ReadingFeatureFromFile(fileInfos[i].FullName);
                    float cellWidth = pct.Width / (float)9;
                    float cellHeight = pct.Height / (float)6;

                    foreach (Dot item in pct.ListColorPoint)
                    {
                        int xIndex = (int)(item.location.X / cellWidth);
                        int yIndex = (int)(item.location.Y / cellHeight);

                        Color color = colorVisualWord[DistanceHelper.ColorKNN(item.color, colorVisualWord)];

                        String key = color.R + "_" + color.G + "_" + color.R + "_" + xIndex + "_" + yIndex;
                        dic[key].Add(pct.FrameName);
                    }

                }
            }

            String json = JsonConvert.SerializeObject(dic);
            FileManager.GetInstance().WriteFile(json, Path.Combine(imageIndexStoragePath, "index.json"));

        }

        public static List<String> Searching(Dictionary<String, List<String>> dic, List<Dot> listDot, Size input)
        {
            if (listDot == null && listDot.Count == 0)
                return null;
            List<String> result;

            float cellWidth = input.Width / (float)9;
            float cellHeight = input.Height / 6;

            Dot dot = listDot[0];
            int xinIndex = (int)(listDot[0].location.X / cellWidth);
            int yIndex = (int)(listDot[0].location.Y / cellHeight);

            List<Color> colorVisualWord = ColorHelper.GenerateColorVisualWord();
            Color color = colorVisualWord[DistanceHelper.ColorKNN(dot.color, colorVisualWord)];
            String key = color.R + "_" + color.G + "_" + color.B + "_" + xinIndex + "_" + yIndex;
            if (dic.ContainsKey(key))
                return dic[key];

            return null;
        }

        public static Dictionary<String, List<String>> LoadImageIndexStrorage(String path)
        {
            String filePath = Path.Combine(path, "index.json");
            String json = FileManager.GetInstance().ReadContentFile(filePath);

            Dictionary<String, List<String>> dic = JsonConvert.DeserializeObject<Dictionary<String, List<String>>>(json);
            return dic;
        }
    }
}
