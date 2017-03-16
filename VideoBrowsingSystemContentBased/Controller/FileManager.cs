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
    public class FileManager
    {
        private static FileManager mInstance;

        private FileManager()
        {

        }

        public static FileManager GetInstance()
        {
            if (mInstance == null)
            {
                mInstance = new FileManager();
            }

            return mInstance;
        }

        public FileInfo[] GetAllFileInFolder(String folderPath)
        {
            if (!Directory.Exists(folderPath))
                return null;

            DirectoryInfo directory = new DirectoryInfo(folderPath);
            return directory.GetFiles();
        }

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

        public void SeriablizeObjectToJson(Object obj, String path)
        {
            String json = JsonConvert.SerializeObject(obj);
            WriteFile(json, path);
           
        }

        public List<TextSpot> DeserializeJson(String path)
        {
            String json = ReadContentFile(path);
            return JsonConvert.DeserializeObject<List<TextSpot>>(json);
        }

    }


}
