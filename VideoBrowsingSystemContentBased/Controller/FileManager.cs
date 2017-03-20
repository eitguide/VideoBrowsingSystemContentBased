using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBrowsingSystemContentBased.Model;

namespace VideoBrowsingSystemContentBased.Controller
{
    /// <summary>
    /// File Manager implement with Singleton Parttern
    /// </summary>
    public class FileManager
    {
        private static FileManager mInstance;

        private FileManager()
        {

        }

        /// <summary>
        /// GetInstance
        /// </summary>
        /// <returns></returns>
        public static FileManager GetInstance()
        {
            if (mInstance == null)
            {
                mInstance = new FileManager();
            }

            return mInstance;
        }

        /// <summary>
        /// Get All File in a folder path
        /// </summary>
        /// <param name="folderPath">Folder Path</param>
        /// <returns></returns>
        public FileInfo[] GetAllFileInFolder(String folderPath)
        {
            if (!Directory.Exists(folderPath))
                return null;

            DirectoryInfo directory = new DirectoryInfo(folderPath);
            return directory.GetFiles();
        }


        /// <summary>
        /// Get all frame in videoid Path
        /// </summary>
        /// <param name="videoIdPath">VideoId folder path</param>
        /// <returns>List<Frame></returns>
        public List<Frame> GetAllFrameInVideoId(String videoIdPath)
        {
            if (!Directory.Exists(videoIdPath))
                return null;

            List<Frame> result = new List<Frame>();
            DirectoryInfo directory = new DirectoryInfo(videoIdPath);
            FileInfo[] fileInfo = directory.GetFiles();
            foreach (FileInfo f in fileInfo)
            {
                Frame frame = new Frame();
                frame.FrameName = f.Name;
            }

            return result;
        }


        /// <summary>
        /// Read content file
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <returns>String content of the file</returns>
        public String ReadContentFile(String fileName)
        {
            if (!File.Exists(fileName))
                return string.Empty;

            String content = String.Empty;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    content = reader.ReadToEnd();
                }
            }
            return content;
        }

        /// <summary>
        /// Load Dictionary VideoId mapping with VideoName
        /// </summary>
        /// <param name="fileName">file path</param>
        /// <returns>Dictionary<String, String></returns>
        public Dictionary<String, String> GetDictionaryVideoName(String fileName)
        {
            Dictionary<String, String> dic = new Dictionary<string, string>();
            if (!File.Exists(fileName))
                return null;

            String content = String.Empty;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    String str = null;
                    while ((str = reader.ReadLine()) != null)
                    {
                        String[] rowData = str.Split(' ');
                        if (rowData.Length > 0)
                        {
                            dic.Add(rowData[0], rowData[1]);
                        }
                    }
                }
            }
            return dic;
        }


        /// <summary>
        /// Write content to file with path specific
        /// </summary>
        /// <param name="content">Content you want to write</param>
        /// <param name="filePath">File Path</param>
        public void WriteFile(String content, String filePath)
        {
            using (FileStream fileStrean = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fileStrean))
                {
                    writer.Write(content);
                }
            }
        }


        /// <summary>
        /// Serialize Object in C# Program to Json and write it to file with a specific path
        /// </summary>
        /// <param name="obj">Object you want serialize</param>
        /// <param name="path">Path store json content</param>
        public void SeriablizeObjectToJson(Object obj, String path)
        {
            String json = JsonConvert.SerializeObject(obj);
            WriteFile(json, path);

        }

        /// <summary>
        /// Deserialize json to Object C#
        /// </summary>
        /// <param name="path">Path file store json</param>
        /// <returns></returns>
        public List<TextSpot> DeserializeJson(String path)
        {
            String json = ReadContentFile(path);
            return JsonConvert.DeserializeObject<List<TextSpot>>(json);
        }

        public DenseCap DecodeDenseCap(String filePath)
        {
            String json = ReadContentFile(filePath);
            return JsonConvert.DeserializeObject<DenseCap>(json);
        }


        public List<DenseCap> GetDenseCaps(String folderPath)
        {
            if (!Directory.Exists(folderPath))
                return null;

            String[] files = Directory.GetFiles(folderPath);

            List<DenseCap> result = new List<DenseCap>();


            foreach (String item in files)
            {
                var den = DecodeDenseCap(item);
                if (den != null)
                {
                    result.Add(den);
                }
            }

            return result;
        }

        public List<TextCaption> GetTextCaptionFromDencap(List<DenseCap> denseCap)
        {
            int take = 10;
            if (denseCap == null || denseCap.Count <= 0)
                return null;
            List<TextCaption> textCaptions = new List<TextCaption>();

            //4593 file
            foreach (DenseCap itemDenseCap in denseCap)
            {
                String inputDir = itemDenseCap.opt.input_dir;


                for (int i = 0; i < itemDenseCap.results.Count; i++)
                {
                    TextCaption textCaption = new TextCaption();
                    textCaption.FrameName = Path.Combine(inputDir, itemDenseCap.results[i].img_name);
                    StringBuilder builder = new StringBuilder();

                    int takeCaption = Math.Min(take, itemDenseCap.results[i].captions.Count);

                    for (int j = 0; j < takeCaption; j++)
                    {
                        builder.Append(itemDenseCap.results[i].captions[j] + ",");
                    }
                    textCaption.Caption = builder.ToString();
                    textCaptions.Add(textCaption);
                }
            }
            return textCaptions;
        }
    }
}
