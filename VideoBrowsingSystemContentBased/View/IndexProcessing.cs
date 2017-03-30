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

            textCaptionStorage = new IndexStorage(Config.CAPTION_INDEX_STORAGE);
            textCaptionStorage.OpenIndexStore();

            textSpotIndexStorage = new IndexStorage(Config.TEXTSPOTTING_INDEX_STORAGE);
            textSpotIndexStorage.OpenIndexStore();
        }

        void btnSearchCap_Click(object sender, EventArgs e)
        {
            List<Object> result = Searching.SearchByQuery(textCaptionStorage, Config.TOP_RANK, txtQuery.Text, SearchType.CAPTION);

            if(result != null && result.Count >  0)
            {
                foreach(TextCaption c in result){
                    Console.WriteLine(c.FrameName + "\t" + c.Caption);
                }
            }
        }

        void btnParseJson_Click(object sender, EventArgs e)
        {
            FileManager.GetInstance().DecodeTextCaptionFromDencap(Config.JSON_DENSECAP_FOLDER_PATH, Config.TEXT_CAPTION_PATH);
        }

        void btnParseXML_Click(object sender, EventArgs e)
        {
            List<TextSpot> textSpot = XMLParser.ProcessingXmlData(Config.XML_FOLDER_PATH);
            FileManager.GetInstance().SeriablizeObjectToJson(textSpot, Config.TEXT_PLOTTING_PATH);
            Console.WriteLine(textSpot.Count);
            textSpot.Clear();
            textSpot = null;
        }

        void btnTextSpotIndexing_Click(object sender, EventArgs e)
        {
            btnTextSpotIndexing.Enabled = false;
            List<TextSpot> textSpot = FileManager.GetInstance().DeserializeJson(Config.TEXT_PLOTTING_PATH);
            IndexStorage indexStorage = new IndexStorage(Config.TEXTSPOTTING_INDEX_STORAGE);
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
            IndexStorage indexStorage = new IndexStorage(Config.CAPTION_INDEX_STORAGE);
            indexStorage.OpenIndexStore();

           FileInfo[] files =  FileManager.GetInstance().GetAllFileInFolder(Config.TEXT_CAPTION_PATH);
           foreach (FileInfo f in files)
           {
               List<TextCaption> caption = JsonConvert.DeserializeObject<List<TextCaption>>(FileManager.GetInstance().ReadContentFile(f.FullName));
               Console.WriteLine(caption.Count);
               lblStatus.Text = "Indexing....";
               Indexing.IndexFromDatabaseStorage(indexStorage, caption);
           }
            
           

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
           bk= new BackgroundWorker();
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
            List<Object> result = Searching.SearchByQuery(textSpotIndexStorage, Config.TOP_RANK, txtQuery.Text, SearchType.ORC);
            if (result != null && result.Count > 0)
            {
                foreach (TextSpot c in result)
                {
                    Console.WriteLine(c.FileName + "\t" + c.Text);
                }
            }
        }
    }
}
