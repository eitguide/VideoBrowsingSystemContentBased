using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBrowsingSystemContentBased.Controller;
using VideoBrowsingSystemContentBased.Controller.TextIndexing;
using VideoBrowsingSystemContentBased.Model;
using VideoBrowsingSystemContentBased.TextIndexing;

namespace VideoBrowsingSystemContentBased.View
{
    public partial class IndexProcessing : Form
    {

        BackgroundWorker bk;
        private IndexStorage textSpotIndexStorage;
        private IndexStorage textCaptionStorage;
        public IndexProcessing()
        {
            InitializeComponent();
            btnTextCaptionIndexing.Click += btnTextCaptionIndexing_Click;
            btnTextSpotIndexing.Click += btnTextSpotIndexing_Click;
            btnParseXML.Click += btnParseXML_Click;
            btnParseJson.Click += btnParseJson_Click;
            btnSearchCap.Click += btnSearchCap_Click;

            textCaptionStorage = new IndexStorage(ConfigCommon.CAPTION_INDEX_STORAGE);
            textCaptionStorage.OpenIndexStore();

            textSpotIndexStorage = new IndexStorage(ConfigCommon.TEXTSPOTTING_INDEX_STORAGE);
            textSpotIndexStorage.OpenIndexStore();

        }

        void btnSearchCap_Click(object sender, EventArgs e)
        {
            List<Object> result = Searching.SearchByQuery(textCaptionStorage, ConfigCommon.TOP_RANK, txtQuery.Text, SearchType.CAPTION);

            if (result != null && result.Count > 0)
            {
                foreach (TextCaption c in result)
                {
                    Console.WriteLine(c.FrameName + "\t" + c.Caption);
                }
            }
        }

        void btnParseJson_Click(object sender, EventArgs e)
        {
            FileManager.GetInstance().DecodeTextCaptionFromDencap(ConfigCommon.JSON_DENSECAP_FOLDER_PATH, ConfigCommon.TEXT_CAPTION_PATH);
        }

        void btnParseXML_Click(object sender, EventArgs e)
        {
            List<TextSpot> textSpot = XMLParser.ProcessingXmlData(ConfigCommon.XML_FOLDER_PATH);
            FileManager.GetInstance().SeriablizeObjectToJson(textSpot, ConfigCommon.TEXT_PLOTTING_PATH);
            Console.WriteLine(textSpot.Count);
            textSpot.Clear();
            textSpot = null;
        }

        void btnTextSpotIndexing_Click(object sender, EventArgs e)
        {
            btnTextSpotIndexing.Enabled = false;
            List<TextSpot> textSpot = FileManager.GetInstance().DeserializeJson(ConfigCommon.TEXT_PLOTTING_PATH);
            IndexStorage indexStorage = new IndexStorage(ConfigCommon.TEXTSPOTTING_INDEX_STORAGE);
            indexStorage.OpenIndexStore();

            Indexing.IndexFromDatabaseStorage(indexStorage, textSpot);

            indexStorage.CloseIndexStorage();

            btnTextSpotIndexing.Enabled = true;
        }

        void btnTextCaptionIndexing_Click(object sender, EventArgs e)
        {
            btnTextCaptionIndexing.Enabled = false;

            lblStatus.Text = "Convert Data Json to List TextCaption";

            lblStatus.Text = "Create IndexStorage";
            IndexStorage indexStorage = new IndexStorage(ConfigCommon.CAPTION_INDEX_STORAGE);
            indexStorage.OpenIndexStore();

            //FileInfo[] files = FileManager.GetInstance().GetAllFileInFolder(ConfigCommon.TEXT_CAPTION_PATH);
            //foreach (FileInfo f in files)
            //{
            //    List<TextCaption> caption = JsonConvert.DeserializeObject<List<TextCaption>>(FileManager.GetInstance().ReadContentFile(f.FullName));
            //    Console.WriteLine(caption.Count);
            //    lblStatus.Text = "Indexing....";
            //    Indexing.IndexFromDatabaseStorage(indexStorage, caption);
            //}
            List<TextCaption> caption = ReadTextCaptionsIndex(@"D:\SoureThesis\Data\textcaption_old.txt");
            Console.WriteLine(caption.Count);
            lblStatus.Text = "Indexing....";
            Indexing.IndexFromDatabaseStorage(indexStorage, caption);

            //int numberOfJsonFiles = 3;      
            //for (int i = 0; i < numberOfJsonFiles; i++)
            //{
            //    List<TextCaption> _caption = ReadTextCaptionsIndex("textcaption_" + i + ".txt");
            //    Indexing.IndexFromDatabaseStorage(indexStorage, _caption);
            //}



            lblStatus.Text = "Close IndexStorage";
            indexStorage.CloseIndexStorage();
            btnTextCaptionIndexing.Enabled = true;


        }

        private void IndexProcessing_Load(object sender, EventArgs e)
        {

        }

        private void btnDoWork_Click(object sender, EventArgs e)
        {
            pbTest.Maximum = 10000;
            bk = new BackgroundWorker();
            bk.WorkerReportsProgress = true;
            bk.WorkerSupportsCancellation = true;
            bk.DoWork += bk_DoWork;
            bk.ProgressChanged += bk_ProgressChanged;
            bk.RunWorkerCompleted += bk_RunWorkerCompleted;

            bk.RunWorkerAsync();
        }

        void bk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "Suscess";
        }

        void bk_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbTest.Value = e.ProgressPercentage;
        }

        void bk_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {
                bk.ReportProgress(i);
            }
        }

        private void btnSearchTextSpot_Click(object sender, EventArgs e)
        {
            List<Object> result = Searching.SearchByQuery(textSpotIndexStorage, ConfigCommon.TOP_RANK, txtQuery.Text, SearchType.OCR);
            if (result != null && result.Count > 0)
            {
                foreach (TextSpot c in result)
                {
                    Console.WriteLine(c.FileName + "\t" + c.Text);
                }
            }
        }

        private void btnExpandCaptionIndex_Click(object sender, EventArgs e)
        {
            string rootPath = @"C:\Users\puyed\Documents\merged_all_new";
            string[] entries = Directory.GetDirectories(rootPath);

            string oldCaptionDensecapFile = @"D:\SoureThesis\Data\textcaption_old.txt";
            List<TextCaption> captions = ReadTextCaptionsIndex(oldCaptionDensecapFile);

            Dictionary<string, string> dicCaptions = new Dictionary<string, string>();
            foreach (TextCaption item in captions)
            {
                string key = item.FrameName.Split('\\')[1].Trim();
                string value = item.Caption;
                dicCaptions.Add(key, value);
            }
            captions = null;

            foreach (string dir in entries)
            {
                if (dir.Contains("35345"))
                    continue;

                FileInfo[] fileInfos = FileManager.GetInstance().GetAllFileInFolder(dir);

                foreach (FileInfo file in fileInfos)
                {
                    string[] lines = File.ReadAllLines(file.FullName);
                    StringBuilder sb = new StringBuilder();
                    string firstLine = lines[0];
                    for (int i = 1; i < lines.Length; i++)
                    {
                        sb.Append(lines[i] + ", ");
                    }
                    lines = null;


                    List<String> listFrames = GetListFramesOfShot(file.Name);

                    //Console.WriteLine(listFrames.Count);

                    bool isContain = false;
                    String frameId = String.Empty;

                    foreach (var id in listFrames)
                    {
                        frameId = id;
                        if (dicCaptions.ContainsKey(id.Trim()))
                        {
                            isContain = true;
                            break;
                        }
                        else
                        {
                            isContain = false;
                        }
                    }

                    //Console.WriteLine(isContain);
                    if (isContain)
                    {
                        String value = dicCaptions[frameId];
                        value = value + ", " + sb.ToString();
                        dicCaptions[frameId] = value;
                    }
                    else
                    {
                        String value1 = firstLine + ", " + sb.ToString();
                        dicCaptions[frameId] = value1;
                    }

                    
                }
                Console.WriteLine(dir);
            }

            Console.WriteLine("Converting dictionary to list");
            List<TextCaption> listCaptionsResult = new List<TextCaption>();
            foreach (var item in dicCaptions)
            {
                string rootDir = @"/home/nghianv/data/frame/TRECVID2016_";
                string videoId = Utils.Decoder.DecodeFrameFromName(item.Key).VideoId;
                string frameName = rootDir + videoId + "\\" + item.Key;
                string caption = item.Value;
                listCaptionsResult.Add(new TextCaption(frameName, caption));
            }
            dicCaptions = null;


            Console.WriteLine("Writting to file");
            //string json = JsonConvert.SerializeObject(listCaptionsResult);
            //FileManager.GetInstance().WriteFile(json, "densecap.json");
            FileManager.GetInstance().WriteTextCaptionIndexingToJsonFile(listCaptionsResult, @"D:\SoureThesis\Data\textcaption.txt");
            Console.WriteLine("Finish!");
        }

        private List<String> GetListFramesOfShot(string shotFileName)
        {
            // shotFileName : TRECVID2016_35345.shot35345_1.ftr
            // output: firstFrameFilePath

            string rootDir = @"g:\net\dl380g7a\export\ddn11a2\ledduy\trecvid-avs\keyframe-5\tv2016\test.iacc.3";
            string[] subStrings = shotFileName.Split('.');
            string videoId = subStrings[0].Split('_')[1];  // TRECVID2016_35345
            string shot = subStrings[1].Split('_')[1];        // 1

            string[] files = Directory.GetFiles(rootDir + "\\TRECVID2016_" + videoId, string.Format("TRECVID2016_{0}.shot{1}_{2}.*", videoId, videoId, shot));


            return files.Select(p => Path.GetFileName(p)).ToList<String>();
        }

        private String GetFirstFramesOfShot(string shotFileName)
        {
            // shotFileName : TRECVID2016_35345.shot35345_1.ftr
            // output: firstFrameFilePath
            string firstFrameFilePath;

            string rootDir = @"g:\net\dl380g7a\export\ddn11a2\ledduy\trecvid-avs\keyframe-5\tv2016\test.iacc.3";
            string[] subStrings = shotFileName.Split('.');
            string videoId = subStrings[0].Split('_')[1];  // TRECVID2016_35345
            string shot = subStrings[1].Split('_')[1];        // 1

            string[] files = Directory.GetFiles(rootDir + "\\TRECVID2016_" + videoId, string.Format("TRECVID2016_{0}.shot{1}_{2}.*", videoId, videoId, shot));

            return files[0];
        }

        private List<TextCaption> ReadTextCaptionsIndex(string indexFile)
        {
            List<TextCaption> captions;
            using (StreamReader sr = new StreamReader(indexFile))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                captions = serializer.Deserialize<List<TextCaption>>(reader);
            }
            return captions;
        }

    }
}
