using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using MaterialSkin;
using MaterialSkin.Controls;
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
using VideoBrowsingSystemContentBased.Utils;

namespace VideoBrowsingSystemContentBased
{
    public partial class VideoBrowsingForm : Form
    {
        private String textQuery;
        private IndexStorage textSpotingIndexStorage;
        private IndexStorage textCaptionIndexStorage;
        private Dictionary<String, String> mappingVideoName;
        private Dictionary<String, float> mappingFPS;
        private SearchType searchType = SearchType.CAPTION;

        public VideoBrowsingForm()
        {
            InitializeComponent();
            Load += VideoBrowsingForm_Load;
            this.MaximizeBox = false;
            //this.Width = 1080;
            //this.Height = 720;
            // StartPosition = FormStartPosition.CenterScreen;

            InitLayout();
            InitEvent();
        }

        private void InitEvent()
        {
            txtTextQuery.KeyDown += txtTextQuery_KeyDown;
            btnSearch.Click += btnSearch_Click;
        }

        void txtTextQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
                btnSearch_Click(sender, e);
            }
        }



        private void PreprocessXML()
        {
            List<TextSpot> textSpot = XMLParser.ProcessingXmlData(Config.XML_FOLDER_PATH);
            FileManager.GetInstance().SeriablizeObjectToJson(textSpot, Config.TEXT_PLOTTING_PATH);

        }

        void VideoBrowsingForm_Load(object sender, EventArgs e)
        {
            textSpotingIndexStorage = new IndexStorage(Config.TEXTSPOTTING_INDEX_STORAGE);
            textSpotingIndexStorage.OpenIndexStore();

            textCaptionIndexStorage = new IndexStorage(Config.CAPTION_INDEX_STORAGE);
            textCaptionIndexStorage.OpenIndexStore();

            mappingVideoName = FileManager.GetInstance().GetDictionaryVideoName(Config.MAPPING_VIDEO_NAME_PATH);
            mappingFPS = XMLParser.GetFPSDictionary(Config.FPS_VIDEO_PATH);
        }

        public void InitLayout()
        {

            //pnFrameShot.BackColor = ColorHelper.ConvertToARGB("#34495e");
            //pnListFrame.BackColor = ColorHelper.ConvertToARGB("#95a5a6");
            //grbxListFrame.BackColor = ColorHelper.ConvertToARGB("#95a5a6");
            axWMP.settings.autoStart = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; // disable resize form
            grbxSearchBySketch.Width = grbxSearchByText.Width;
            putColorAndSketch1.FixLayout(grbxSearchBySketch.Width);
            grbxSearchBySketch.Height = putColorAndSketch1.Height + 20;

            this.Font = new Font("Arial", 9);
            grbxVideoPlayer.Location = new Point(0, grbxSearchBySketch.Location.Y + grbxSearchBySketch.Height);
            grbxVideoPlayer.Width = grbxSearchBySketch.Width;
            grbxVideoPlayer.Height = tblpRoot.Height - grbxVideoPlayer.Location.Y - 8;
            axWMP.Dock = DockStyle.Fill;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            textQuery = txtTextQuery.Text;
            if (String.IsNullOrWhiteSpace(textQuery))
                return;

            List<String> listPath = new List<string>();
            if (searchType == SearchType.CAPTION)
            {
                List<Object> textCaption = Searching.SearchByQuery(textCaptionIndexStorage, 
                    Config.TOP_RANK, textQuery, searchType);
                if (textCaption != null && textCaption.Count > 0)
                {
                    
                    //String pathFolderParent = @"I:\net\dl380g7a\export\ddn11a2\ledduy\trecvid-avs\keyframe-5\tv2016\test.iacc.3/";
                    foreach (TextCaption text in textCaption)
                    {

                        String fileName = Path.GetFileName(text.FrameName);
                        Frame frame = Utils.Decoder.DecodeFrameFromName(fileName);

                        String root = Path.Combine(Config.FRAME_DATA_PATH, String.Format("TRECVID2016_{0}", frame.VideoId));
                        fileName = Path.Combine(root, fileName);

                        //Console.WriteLine(fileName);
                        listPath.Add(fileName);

                    }
                }
                
                if (textCaption == null)
                    Console.WriteLine("Ko co ket qua");
                else
                    Console.WriteLine("Search xong ne");
            }


            //List<Object> result = Searching.SearchByQuery(textSpotingIndexStorage, Config.TOP_RANK, textQuery, SearchType.ORC);
            //if (result == null)
            //{
            //    MessageBox.Show(string.Format("'{0}' not found", textQuery));
            //    return;
            //}

            //if (result != null && result.Count >= 0)
            //{
            //    foreach (TextSpot i in result)
            //    {
            //        Console.WriteLine(i.FileName + "\t" + i.Text);
            //    }
            //}

            //List<String> listPath = new List<string>();
            ////String pathFolderParent = @"I:\net\dl380g7a\export\ddn11a2\ledduy\trecvid-avs\keyframe-5\tv2016\test.iacc.3/";
            //foreach (TextSpot text in result)
            //{

            //    String fileName = Path.GetFileName(text.FileName);
            //    Frame frame = Utils.Decoder.DecodeFrameFromName(fileName);

            //    String root = Path.Combine(Config.FRAME_DATA_PATH, String.Format("TRECVID2016_{0}", frame.VideoId));
            //    fileName = Path.Combine(root, fileName);

            //    //Console.WriteLine(fileName);
            //    listPath.Add(fileName);

            //}

            ClearAndAddImagesToPanelFrame(listPath, pnListFrame);
        }


        private void ClearAndAddImagesToPanelFrame(List<string> listFilePath, Panel pn)
        {
            // Init for display
            int widthEachImg = pnListFrame.Width / 9, heightEachImg = pnListFrame.Height / 8;  // width & height for each image
            PictureBoxSizeMode displayMode = PictureBoxSizeMode.StretchImage;

            // Clear all controls in panel

            pn.Controls.Clear();

            // For each file, display it to panel pn
            pn.AutoScroll = true;
            {
                int x = 0, y = 0;
                foreach (string filePath in listFilePath)
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        PictureBox pic = new PictureBox();
                        pic.Tag = filePath;

                        pic.Click += pic_Click;
                        pic.Image = Image.FromFile(filePath);
                        pic.Location = new Point(x, y);
                        pic.Size = new Size(widthEachImg, heightEachImg);
                        pic.SizeMode = displayMode;
                        x += widthEachImg;
                        pn.Controls.Add(pic);

                        // go to new row if (x + width) > pn.width
                        if (x + widthEachImg > pn.Width)
                        {
                            x = 0;
                            y += heightEachImg;
                        }
                    }

                }
            }
        }

        private void ClearAndAddImagesToPanelShot(List<string> listFilePath, Panel pn)
        {
            // Init for display
            Image image = Image.FromFile(listFilePath[0]);
            float ratio = (float)image.Width / (float)image.Height;

            int heightEachImg = pnFrameShot.Height - SystemInformation.HorizontalScrollBarHeight; ;// width & height for each image
            int widthEachImg = (int)(heightEachImg * ratio);

            // if sum frame width > panel width
            if (listFilePath.Count * widthEachImg <= pnFrameShot.Width)
            {
                heightEachImg = pnFrameShot.Height;// width & height for each image
                widthEachImg = (int)(heightEachImg * ratio);
            }


            PictureBoxSizeMode displayMode = PictureBoxSizeMode.Zoom;

            // Clear all controls in panel

            pn.Controls.Clear();

            // For each file, display it to panel pn
            pn.AutoScroll = true;
            {
                int x = 0, y = 0;
                foreach (string filePath in listFilePath)
                {
                    PictureBox pic = new VideoBrowsingSystemContentBased.Widget.CustomPictureBox();
                    pic.MouseClick += pic_MouseClick;
                    pic.Tag = filePath;
                    pic.Image = Image.FromFile(filePath);
                    pic.Location = new Point(x, y);
                    pic.Size = new Size(widthEachImg, heightEachImg);
                    pic.SizeMode = displayMode;
                    x += widthEachImg;
                    pn.Controls.Add(pic);
                }
            }
        }

        void pic_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string filePath = ((PictureBox)sender).Tag as string;
                System.Diagnostics.Process.Start(filePath);
                //System.Diagnostics.Process photoViewer = new System.Diagnostics.Process();
                //photoViewer.StartInfo.FileName = @"The photo viewer file path";
                //photoViewer.StartInfo.Arguments = @"Your image file path";
                //photoViewer.Start();
            }
        }

        void pic_Click(object sender, EventArgs e)
        {
            String filePath = ((PictureBox)sender).Tag as String;
            String frameName = Path.GetFileName(filePath);

            Frame frame = Utils.Decoder.DecodeFrameFromName(frameName);

            String[] files = Searching.GetShotFrame(frame, Path.GetDirectoryName(filePath));
            foreach (String item in files)
            {
                Logger.d(item);
            }

            ClearAndAddImagesToPanelShot(files.ToList(), pnFrameShot);
            //Console.WriteLine(Path.Combine(Config.VIDEO_DATA_PATH, mappingVideoName[frame.VideoId]));
            axWMP.URL = Path.Combine(Config.VIDEO_DATA_PATH, mappingVideoName[frame.VideoId]);
            axWMP.Ctlcontrols.currentPosition = (double)(frame.FrameNumber / mappingFPS[frame.VideoId]); // in seconds
            //Console.WriteLine((double)(frame.FrameNumber));
            //Console.WriteLine((double)(mappingFPS[frame.VideoId]));
            //Console.WriteLine((double)(frame.FrameNumber / mappingFPS[frame.VideoId]));
        }

        public void ShowResultFromSketchColor()
        {
            //if (backgroundWorker_GetRsMATLAB.IsBusy)
            //{
            //    backgroundWorker_GetRsMATLAB.CancelAsync();

            //}
            //else
            //{
            //backgroundWorker_GetRsMATLAB.RunWorkerAsync();
            txtTextQuery.Enabled = false;
            btnSearch.Enabled = false;
            //}
        }
    }
}
