
using ColorMine.ColorSpaces;
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
        public static string GetIndexFileNameExtension()
        {
            string colorSpace = null;
            string formula = null;
            if (ConfigPCT.COLOR_SPACE_USING == ConfigPCT.ColorSpace.RGB)
            {
                colorSpace = "rgb";
                if (ConfigPCT.FORMULA_RGB_USING == ConfigPCT.FormulaRGB.RGB_Euclid)
                    formula = "euclid";
            }
            else if (ConfigPCT.COLOR_SPACE_USING == ConfigPCT.ColorSpace.Lab)
            {
                colorSpace = "lab";
                if (ConfigPCT.FORMULA_LAB_USING == ConfigPCT.FormulaLab.Lab_CIE76)
                    formula = "cie76";
                else if (ConfigPCT.FORMULA_LAB_USING == ConfigPCT.FormulaLab.Lab_CMCIC)
                    formula = "cmcic";
                else if (ConfigPCT.FORMULA_LAB_USING == ConfigPCT.FormulaLab.Lab_CIE94)
                    formula = "cie94";
                else if (ConfigPCT.FORMULA_LAB_USING == ConfigPCT.FormulaLab.Lab_CIE2000)
                    formula = "cie2000";
            }
            int nearThreshold;
            if (ConfigPCT.ACCEPT_REGION_NEAR_EQUAL)
                nearThreshold = ConfigPCT.THRESHOLD_PIXEL_NEAR_EQUAL_FOR_ACCEPT;
            else
                nearThreshold = 0;


            string indexFileName = string.Format("pct_index_{0}_{1}_{2}x{3}_step{4}_radius{5}_noise{6}_near{7}.json",
                colorSpace, formula, ConfigPCT.PCT_NUMBER_OF_HORIZONTAL_REGION, ConfigPCT.PCT_NUMBER_OF_VERTICAL_REGION,
                ConfigPCT.PCT_STEP_INDEX_FILE, ConfigPCT.RADIUS_THRESHOLD, ConfigPCT.COLOR_NOISE_THRESHOLD, nearThreshold);

            return indexFileName;
        }

        public static void RunIndexing_RGB(string imageIndexStoragePath)
        {
            #region init
            List<Color> visualWordColor = ColorHelper.GenerateColorVisualWord_Rgb();    // *
            Dictionary<string, List<string>> visualWordMain = new Dictionary<String, List<string>>();
            List<VisualWordCell_RGB> listKeys = VisualWordHelper.CreateListVWKeys_Rgb(); // *
            foreach (var item in listKeys)
            {
                // *
                String key = item.Color.R + "_" + item.Color.G + "_" + item.Color.B + "_" + item.XIndex + "_" + item.YIndex;
                visualWordMain.Add(key, new List<String>());
            }
            string indexFileNameExtension = GetIndexFileNameExtension();
            #endregion

            // for each folder
            int count = 0;
            string[] SubDirs = Directory.GetDirectories(ConfigCommon.PCT_OUTPUT_PATH);
            foreach (String folderPath in SubDirs)
            {
                Console.WriteLine((++count) + ". " + folderPath);
                FileInfo[] fileInfos = FileManager.GetInstance().GetAllFileInFolder(folderPath);
                int sizeFiles = fileInfos.Length;
                // for each X file (X = PCTConfig.PCT_STEP_INDEX_FILE)
                for (int i = 0; i < sizeFiles; i += ConfigPCT.PCT_STEP_INDEX_FILE)
                {
                    // read data PCT from file
                    PCTFeature_RGB dataPCT = PCTReadingFeature.ReadingFeatureFromFile_RGB(fileInfos[i].FullName); // *

                    // if number of color visual-word > Y, skip (Y = PCTConfig.COLOR_NOISE_THRESHOLD)
                    int numberColor = CountColorsVW_RGB(dataPCT, visualWordColor);
                    if (numberColor > ConfigPCT.COLOR_NOISE_THRESHOLD)
                        continue;

                    foreach (Dot_RGB colorPoint in dataPCT.ListColorPoint)
                    {
                        // if radius >= Z, index it (Z = PCTConfig.RADIUS_THRESHOLD)
                        if (colorPoint.radius >= ConfigPCT.RADIUS_THRESHOLD)
                        {
                            List<RegionOfFrame> listRegionDotBelongTo = Utils.RegionOfFrameHelper.GetListRegionDotBelongTo(colorPoint.location, colorPoint.radius, dataPCT.Width, dataPCT.Height);
                            Color color = visualWordColor[DistanceHelper.ColorKNN_RGB(colorPoint.color, visualWordColor)];

                            foreach (RegionOfFrame region in listRegionDotBelongTo)
                            {
                                String key = color.R + "_" + color.G + "_" + color.B + "_" + region.X + "_" + region.Y;
                                visualWordMain[key].Add(dataPCT.FrameName);
                            }
                        }
                    }
                }
            }
            
            foreach (var item in listKeys)
            {
                string key = item.Color.R + "_" + item.Color.G + "_" + item.Color.B + "_" + item.XIndex + "_" + item.YIndex;
                visualWordMain[key] = visualWordMain[key].Distinct().ToList();
            }
            // save the indexing to a file
            //String json = JsonConvert.SerializeObject(visualWordMain);
            //FileManager.GetInstance().WriteFile(json, Path.Combine(imageIndexStoragePath, "index.json"));
            string fileSavePath = Path.Combine(imageIndexStoragePath, indexFileNameExtension);
            if (File.Exists(fileSavePath))
                File.Delete(fileSavePath);
            FileManager.GetInstance().WriteDicIndexingToFiles(visualWordMain, fileSavePath);
        }

        public static void RunIndexing_Lab(string imageIndexStoragePath)
        {
            #region init
            List<Lab> visualWordColor = ColorHelper.GenerateColorVisualWord_Lab();    // *
            Dictionary<string, List<string>> visualWordMain = new Dictionary<string, List<string>>();
            List<VisualWordCell_Lab> listKeys = VisualWordHelper.CreateListVWKeys_Lab(); // *
            foreach (var item in listKeys)
            {
                // *
                string key = item.Color.L + "_" + item.Color.A + "_" + item.Color.B + "_" + item.XIndex + "_" + item.YIndex;
                visualWordMain.Add(key, new List<String>());
            }
            string indexFileNameExtension = GetIndexFileNameExtension();
            #endregion

            // for each folder
            int count = 0;
            string[] SubDirs = Directory.GetDirectories(ConfigCommon.PCT_OUTPUT_PATH);
            foreach (String folderPath in SubDirs)
            {
                Console.WriteLine((++count) + ". " + folderPath);
                FileInfo[] fileInfos = FileManager.GetInstance().GetAllFileInFolder(folderPath);
                int sizeFiles = fileInfos.Length;
                // for each X file (X = PCTConfig.PCT_STEP_INDEX_FILE)
                for (int i = 0; i < sizeFiles; i += ConfigPCT.PCT_STEP_INDEX_FILE)
                {
                    // read data PCT from file
                    PCTFeature_Lab dataPCT = PCTReadingFeature.ReadingFeatureFromFile_Lab(fileInfos[i].FullName); // *

                    // if number of color visual-word > Y, skip (Y = PCTConfig.COLOR_NOISE_THRESHOLD)
                    int numberColor = CountColorsVW_Lab(dataPCT, visualWordColor);
                    if (numberColor > ConfigPCT.COLOR_NOISE_THRESHOLD)
                        continue;

                    foreach (Dot_Lab colorPoint in dataPCT.ListColorPoint)
                    {
                        // if radius >= Z, index it (Z = PCTConfig.RADIUS_THRESHOLD)
                        if (colorPoint.radius >= ConfigPCT.RADIUS_THRESHOLD)
                        {
                            List<RegionOfFrame> listRegionDotBelongTo = Utils.RegionOfFrameHelper.GetListRegionDotBelongTo(colorPoint.location, colorPoint.radius, dataPCT.Width, dataPCT.Height);
                            Lab color = visualWordColor[DistanceHelper.ColorKNN_Lab(colorPoint.color, visualWordColor)];

                            foreach (RegionOfFrame region in listRegionDotBelongTo)
                            {
                                //Key_PCTIndexDicLab key = new Key_PCTIndexDicLab(color.L, color.A, color.B, region.X + "_" + region.Y);
                                string key = color.L + "_" + color.A + "_" + color.B + "_" + region.X + "_" + region.Y;
                                visualWordMain[key].Add(dataPCT.FrameName);
                                //if (!visualWordMain[key].Contains(dataPCT.FrameName)) // slow
                                //    visualWordMain[key].Add(dataPCT.FrameName);
                            }
                        }
                    }
                }
            }

            foreach (var item in listKeys)
            {
                string key = item.Color.L + "_" + item.Color.A + "_" + item.Color.B + "_" + item.XIndex + "_" + item.YIndex;
                Console.WriteLine("Distincting value of key " + key + " ...");
                visualWordMain[key] = visualWordMain[key].Distinct().ToList();
            }
            // save the indexing to a file
            //String json = JsonConvert.SerializeObject(visualWordMain);
            //FileManager.GetInstance().WriteFile(json, Path.Combine(imageIndexStoragePath, "index.json"));
            string fileSavePath = Path.Combine(imageIndexStoragePath, indexFileNameExtension);
            if (File.Exists(fileSavePath))
                File.Delete(fileSavePath);
            //FileManager.GetInstance().WriteDicIndexingToJsonFile(visualWordMain, fileSavePath);
            FileManager.GetInstance().WriteDicIndexingToFiles(visualWordMain, fileSavePath);
        }

        private static int CountColorsVW_RGB(PCTFeature_RGB pct, List<Color> colorVisualWord)
        {
            //Dictionary<String, Color> map = new Dictionary<string, Color>();
            List<string> listColorVWs = new List<string>();

            foreach (var item in pct.ListColorPoint)
            {
                Color color = colorVisualWord[DistanceHelper.ColorKNN_RGB(item.color, colorVisualWord)];
                String key = color.R + "_" + color.G + "_" + color.B;
                if (!listColorVWs.Contains(key))
                    listColorVWs.Add(key);
                //if (!map.ContainsKey(key))
                //    map.Add(key, color);

            }
            //int totalColor = map.Count;
            //return totalColor;
            return listColorVWs.Count;
        }

        private static int CountColorsVW_Lab(PCTFeature_Lab pct, List<Lab> colorVisualWord)
        {
            //Dictionary<String, Color> map = new Dictionary<string, Color>();
            List<Lab> listColorVWs = new List<Lab>();

            foreach (var item in pct.ListColorPoint)
            {
                Lab color = colorVisualWord[DistanceHelper.ColorKNN_Lab(item.color, colorVisualWord)];
                if (!listColorVWs.Contains(color))
                    listColorVWs.Add(color);
                //if (!map.ContainsKey(key))
                //    map.Add(key, color);

            }
            //int totalColor = map.Count;
            //return totalColor;
            return listColorVWs.Count;
        }

        public static Dictionary<String, List<String>> LoadImageIndexStrorage(String path)
        {
            //string indexFileNameExtension = GetIndexFileNameExtension();
            //String filePath = Path.Combine(path, indexFileNameExtension);
            //String json = FileManager.GetInstance().ReadContentFile(filePath);

            //Dictionary<String, List<String>> dic = JsonConvert.DeserializeObject<Dictionary<String, List<String>>>(json);
            //return dic;
            string indexFileNameExtension = GetIndexFileNameExtension();
            String filePath = Path.Combine(path, indexFileNameExtension);
            using (StreamReader sr = new StreamReader(filePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                Dictionary<String, List<String>> dic = serializer.Deserialize<Dictionary<String, List<String>>>(reader);
                return dic;
            }
        }

        public static Dictionary<string, string> LoadImageIndexStrorageV2(string indexFilePath)
        {
            string indexFileNameExtension = GetIndexFileNameExtension();
            string jsonFilePath = Path.Combine(indexFilePath, indexFileNameExtension);
            using (StreamReader sr = new StreamReader(jsonFilePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                Dictionary<string, string> dic = serializer.Deserialize<Dictionary<string, string>>(reader);
                return dic;
            }
        }

        //public static Dictionary<Key_PCTIndexDicLab, List<String>> LoadImageIndexStrorage_Lab(String path)
        //{
        //    string indexFileNameExtension = GetIndexFileNameExtension();
        //    String filePath = Path.Combine(path, indexFileNameExtension);
        //    using (StreamReader sr = new StreamReader(filePath))
        //    using (JsonReader reader = new JsonTextReader(sr))
        //    {
        //        JsonSerializer serializer = new JsonSerializer();
        //        Dictionary<string, List<String>> dicTemp = serializer.Deserialize<Dictionary<string, List<String>>>(reader);
        //        Dictionary<Key_PCTIndexDicLab, List<string>> dic = new Dictionary<Key_PCTIndexDicLab, List<string>>();

        //        foreach(string keyTemp in dicTemp.Keys)
        //        {
        //            string[] arr = keyTemp.Split(',');
        //            double L = double.Parse(arr[0].Trim());
        //            double a = double.Parse(arr[1].Trim());
        //            double b = double.Parse(arr[2].Trim());
        //            string region = arr[3].Trim();
        //            Key_PCTIndexDicLab key = new Key_PCTIndexDicLab(L, a, b, region);
        //            dic.Add(key, dicTemp[keyTemp]);
        //        }

        //        return dic;
        //    }
        //}

        public static void LogTheIndexData(Dictionary<String, List<String>> dic)
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
