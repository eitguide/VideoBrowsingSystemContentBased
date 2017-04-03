using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        static int count = 0;

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
                    reader.Close();
                    reader.Dispose();
                }

                fileStream.Close();
                fileStream.Dispose();
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
                    writer.Close();
                    writer.Dispose();
                }

                fileStrean.Close();
                fileStrean.Dispose();
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
            json = null;
        }

        /// <summary>
        /// Deserialize json to Object C#
        /// </summary>
        /// <param name="path">Path file store json</param>
        /// <returns></returns>
        public List<TextSpot> DeserializeJson(String path)
        {
            String json = File.ReadAllText(path);
            List<TextSpot> texts = JsonConvert.DeserializeObject<List<TextSpot>>(json);
            json = null;
            return texts;
        }

        public DenseCap DecodeDenseCap(String filePath)
        {
            String json = ReadContentFile(filePath);
            Console.WriteLine("READ" + count);
            count++;
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

            files = null;
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

        public void DecodeTextCaptionFromDencap(String jsonCaptionPath, String ouputFile)
        {
            int take = 10;
            
            if (!Directory.Exists(jsonCaptionPath))
                return;

            String[] files = Directory.GetFiles(jsonCaptionPath);

            List<TextCaption> textCaptions = new List<TextCaption>();


            for (int index = 0; index < files.Length; index++)
            {
                DenseCap itemDenseCap = DecodeDenseCap(files[index]);
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
                    builder = null;
                    textCaptions.Add(textCaption);
                }

                if ((index != 0 && (index % 500 == 0)) || index == (files.Length - 1))
                {
                    Console.WriteLine("WriteJson");
                    String str = JsonConvert.SerializeObject(textCaptions);
                    WriteFile(str, "densecap_json_" + index.ToString() + ".json" );
                    textCaptions.Clear();
                }
                itemDenseCap = null;
            }

            textCaptions = null;
        }

        public void SaveBitmapToPNG(Bitmap _bitmap, string _fileNamePath)
        {
            _bitmap.Save(_fileNamePath, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
