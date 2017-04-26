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
using VideoBrowsingSystemContentBased.Controller.ImageIndexing;
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
        private int NUMBER_OF_MAX_RESULT_FRAMES = 500;
        private int countPicFrameIsShowing;
        private Dictionary<String, List<String>> pctIndexingData;

        public VideoBrowsingForm()
        {
            InitializeComponent();
            Load += VideoBrowsingForm_Load;
            this.MaximizeBox = false;
            //this.Width = 1080;
            //this.Height = 720;
            // StartPosition = FormStartPosition.CenterScreen;
            bgWorker_LoadFrames.WorkerReportsProgress = true;

            InitTheLayout();
            InitEvent();
        }

        void VideoBrowsingForm_Load(object sender, EventArgs e)
        {
            textSpotingIndexStorage = new IndexStorage(ConfigCommon.TEXTSPOTTING_INDEX_STORAGE);
            textSpotingIndexStorage.OpenIndexStore();

            textCaptionIndexStorage = new IndexStorage(ConfigCommon.CAPTION_INDEX_STORAGE);
            textCaptionIndexStorage.OpenIndexStore();

            mappingVideoName = FileManager.GetInstance().GetDictionaryVideoName(ConfigCommon.MAPPING_VIDEO_NAME_PATH);
            mappingFPS = XMLParser.GetFPSDictionary(ConfigCommon.FPS_VIDEO_PATH);

            pctIndexingData = PCTIndexing.LoadImageIndexStrorage(ConfigCommon.PCT_INDEX_STORAGE);
        }

        public void InitTheLayout()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; // disable resize form
            this.Font = new Font("Arial", 9);

            pnListFrame.AutoScroll = true;
            //pnFrameShot.BackColor = ColorHelper.ConvertToARGB("#34495e");
            //pnListFrame.BackColor = ColorHelper.ConvertToARGB("#95a5a6");
            //grbxListFrame.BackColor = ColorHelper.ConvertToARGB("#95a5a6");
            axWMP.settings.autoStart = false;
            axWMP.Dock = DockStyle.Fill;

            grbxSearchBySketch.Width = grbxSearchByText.Width;
            putColorAndSketchV2.FixLayout(grbxSearchBySketch.Width);
            btnSearchByImage.Location = new Point((grbxSearchBySketch.Width - btnSearchByImage.Width) / 2, putColorAndSketchV2.Height + 18);
            grbxSearchBySketch.Height = putColorAndSketchV2.Height + btnSearchByImage.Height + 20;

            grbxVideoPlayer.Location = new Point(0, grbxSearchBySketch.Location.Y + grbxSearchBySketch.Height);
            grbxVideoPlayer.Width = grbxSearchBySketch.Width;
            grbxVideoPlayer.Height = tblpRoot.Height - grbxVideoPlayer.Location.Y - 8;

            rbtnORC.Checked = true;

            for (int i = 0; i < NUMBER_OF_MAX_RESULT_FRAMES; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Visible = false;
                pnListFrame.Controls.Add(pic);
                pic.Click += pic_Click;
            }
        }

        private void InitEvent()
        {
            txtTextQuery.KeyDown += txtTextQuery_KeyDown;
            btnSearchByText.Click += btnSearch_Click;
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
            List<TextSpot> textSpot = XMLParser.ProcessingXmlData(ConfigCommon.XML_FOLDER_PATH);
            FileManager.GetInstance().SeriablizeObjectToJson(textSpot, ConfigCommon.TEXT_PLOTTING_PATH);

        }

        private void ClearAndAddImagesToPanelFrame(List<string> listFilePath)
        {
            if (listFilePath.Count == 0)
                return;

            for (int i = 0; i < countPicFrameIsShowing; i++)
            {
                (pnListFrame.Controls[i] as PictureBox).Visible = false;
            }
            bgWorker_LoadFrames.RunWorkerAsync(listFilePath);
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
                    pic.MouseDoubleClick += pic_MouseDoubleClick;
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
            btnSearchByText.Enabled = false;
            //}
        }

        private void DrawDot(Graphics g, Dot_RGB dot)
        {
            SolidBrush brush = new SolidBrush(dot.color);
            g.FillEllipse(brush, dot.location.X - dot.radius, dot.location.Y - dot.radius, dot.radius * 2, dot.radius * 2);
        }

        #region Events
        // Form
        private void VideoBrowsingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == ConfigCommon.HOTKEY_SEARCH_BY_TEXT_ORC)
                {
                    rbtnORC.Checked = true;
                    txtTextQuery.Focus();
                }
                else if (e.KeyCode == ConfigCommon.HOTKEY_SEARCH_BY_TEXT_CONTENT)
                {
                    rbtnContent.Checked = true;
                    txtTextQuery.Focus();
                }
                else if (e.KeyCode == ConfigCommon.HOTKEY_PICK_COLOR_FROM_FRAMES)
                {
                    // get cursor position at client
                    Point cursorPosition = pnListFrame.PointToClient(Cursor.Position);

                    // get color
                    if (cursorPosition.X >= 0 && cursorPosition.X < pnListFrame.Width && cursorPosition.Y >= 0 && cursorPosition.Y < pnListFrame.Height)
                    {
                        Bitmap bitmapMainFrames = new Bitmap(pnListFrame.Width, pnListFrame.Height);
                        pnListFrame.DrawToBitmap(bitmapMainFrames, new Rectangle(0, 0, pnListFrame.Width, pnListFrame.Height));
                        Color c = bitmapMainFrames.GetPixel(cursorPosition.X, cursorPosition.Y);
                        putColorAndSketchV2.SetColorForBrush(c);
                    }
                }
            }
        }
        // Button
        private void btnSearch_Click(object sender, EventArgs e)
        {

            textQuery = txtTextQuery.Text;
            if (String.IsNullOrWhiteSpace(textQuery))
                return;

            List<String> listPath = new List<string>();

            if (rbtnContent.Checked)
                searchType = SearchType.CAPTION;
            else if (rbtnORC.Checked)
                searchType = SearchType.ORC;

            if (searchType == SearchType.CAPTION)
            {
                List<Object> textCaption = Searching.SearchByQuery(textCaptionIndexStorage,
                    ConfigCommon.TOP_RANK, textQuery, searchType);

                if (textCaption != null && textCaption.Count > 0)
                {

                    //String pathFolderParent = @"I:\net\dl380g7a\export\ddn11a2\ledduy\trecvid-avs\keyframe-5\tv2016\test.iacc.3/";
                    foreach (TextCaption text in textCaption)
                    {

                        String fileName = Path.GetFileName(text.FrameName);
                        Frame frame = Utils.Decoder.DecodeFrameFromName(fileName);

                        String root = Path.Combine(ConfigCommon.FRAME_DATA_PATH, String.Format("TRECVID2016_{0}", frame.VideoId));
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
            else if (searchType == SearchType.ORC)
            {
                List<Object> textSpots = Searching.SearchByQuery(textSpotingIndexStorage,
                    ConfigCommon.TOP_RANK, textQuery, searchType);

                if (textSpots != null && textSpots.Count > 0)
                {

                    //String pathFolderParent = @"I:\net\dl380g7a\export\ddn11a2\ledduy\trecvid-avs\keyframe-5\tv2016\test.iacc.3/";
                    foreach (TextSpot text in textSpots)
                    {
                        String fileName = Path.GetFileName(text.FileName);
                        Frame frame = Utils.Decoder.DecodeFrameFromName(fileName);

                        String root = Path.Combine(ConfigCommon.FRAME_DATA_PATH, String.Format("TRECVID2016_{0}", frame.VideoId));
                        fileName = Path.Combine(root, fileName);

                        //Console.WriteLine(fileName);
                        listPath.Add(fileName);

                    }
                }

                if (textSpots == null)
                    Console.WriteLine("Ko co ket qua");
                else
                    Console.WriteLine("Search xong ne");
            }

            ClearAndAddImagesToPanelFrame(listPath);
        }
        private void btnSearchByImage_Click(object sender, EventArgs e)
        {
            List<Dot_RGB> listDotsDrawed_RGB = null;
            List<Dot_Lab> listDotsDrawed_Lab = null;
            if (ConfigPCT.COLOR_SPACE_USING == ConfigPCT.ColorSpace.RGB)
                listDotsDrawed_RGB = putColorAndSketchV2.GetListDotsDrawed_RGB(); //*
            else if (ConfigPCT.COLOR_SPACE_USING == ConfigPCT.ColorSpace.Lab)
                listDotsDrawed_Lab = putColorAndSketchV2.GetListDotsDrawed_Lab();

            // Save list line-drawing to file
            //Bitmap bitmapListLineDrawingDrawed = putColorAndSketchV2.GetBitmapListLineDrawingDrawed();
            //FileManager.GetInstance().SaveBitmapToPNG(bitmapListLineDrawingDrawed, "D:/phuc.png");
            //MessageBox.Show("PNG Image was saved!");

            List<String> result = null;
            if (ConfigPCT.COLOR_SPACE_USING == ConfigPCT.ColorSpace.RGB)
                result = PCTSearching.SearchingV2_RGB(this.pctIndexingData, listDotsDrawed_RGB, putColorAndSketchV2.GetPaperDrawingWidthHeight()); //*
            else if (ConfigPCT.COLOR_SPACE_USING == ConfigPCT.ColorSpace.Lab)
                result = PCTSearching.SearchingV2_Lab(this.pctIndexingData, listDotsDrawed_Lab, putColorAndSketchV2.GetPaperDrawingWidthHeight()); 


            if (result == null || result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            result = result.Take(NUMBER_OF_MAX_RESULT_FRAMES).ToList();

            List<string> listPath = new List<string>();
            foreach (string item in result)
            {
                string fileName = item + ".jpg";
                Frame frame = Utils.Decoder.DecodeFrameFromName(fileName);

                String root = Path.Combine(ConfigCommon.FRAME_DATA_PATH, String.Format("TRECVID2016_{0}", frame.VideoId));
                fileName = Path.Combine(root, fileName);

                //Console.WriteLine(fileName);
                listPath.Add(fileName);
            }


            ClearAndAddImagesToPanelFrame(listPath);
        }
        // PictureBox
        void pic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
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
            //foreach (String item in files)
            //{
            //    Logger.d(item);
            //}

            ClearAndAddImagesToPanelShot(files.ToList(), pnFrameShot);
            //Console.WriteLine(Path.Combine(Config.VIDEO_DATA_PATH, mappingVideoName[frame.VideoId]));
            axWMP.URL = Path.Combine(ConfigCommon.VIDEO_DATA_PATH, mappingVideoName[frame.VideoId]);
            axWMP.Ctlcontrols.currentPosition = (double)(frame.FrameNumber / mappingFPS[frame.VideoId]); // in seconds
            //Console.WriteLine((double)(frame.FrameNumber));
            //Console.WriteLine((double)(mappingFPS[frame.VideoId]));
            //Console.WriteLine((double)(frame.FrameNumber / mappingFPS[frame.VideoId]));
        }
        // RadioButton
        private void rbtnORC_Click(object sender, EventArgs e)
        {
            txtTextQuery.Focus();
        }
        private void rbtnContent_Click(object sender, EventArgs e)
        {
            txtTextQuery.Focus();
        }
        // BackgroundWorker
        struct MyUserState
        {
            public int index;
            public int totalFile;
            public Point location;
            public Size size;
            public string file_url;
        }
        private void bgWorker_LoadFrames_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> listFilePath = e.Argument as List<string>;
            MyUserState userState = new MyUserState();
            PictureBoxSizeMode displayMode = PictureBoxSizeMode.StretchImage;

            // Init for display
            int widthEachImg = pnListFrame.Width / 9, heightEachImg = pnListFrame.Height / 8;  // width & height for each image

            // Clear all controls in panel
            //pn.Controls.Clear();

            // Load default images
            {
                int x = 0, y = 0;
                countPicFrameIsShowing = 0;
                for (int i = 0; i < listFilePath.Count; i++)
                {
                    if (System.IO.File.Exists(listFilePath[i]))
                    {
                        // PictureBox pic = new PictureBox();
                        //PictureBox pic = pnListFrame.Controls[i] as PictureBox;
                        countPicFrameIsShowing++;
                        //pic.Visible = true;
                        //pic.Image = Properties.Resources.default_picture;
                        //pic.Location = new Point(x, y);
                        //pic.Size = new Size(widthEachImg, heightEachImg);
                        //pic.SizeMode = displayMode;
                        //userState.index = i;
                        //userState.totalFile = listFilePath.Count;
                        //userState.location = new Point(x, y);
                        //userState.size = new Size(widthEachImg, heightEachImg);
                        //userState.file_url = listFilePath[i];
                        //bgWorker_LoadFrames.ReportProgress(0, userState);
                        Invoke((Action)(() =>
                        {
                            pnListFrame.AutoScroll = false;

                            PictureBox pic = pnListFrame.Controls[i] as PictureBox;
                            pic.Visible = true;
                            pic.Image = Image.FromFile(listFilePath[i]);
                            pic.Tag = listFilePath[i];
                            pic.Location = new Point(x, y);
                            pic.Size = new Size(widthEachImg, heightEachImg);
                            pic.SizeMode = displayMode;

                            statusBar1.Panels[0].Text = "Loading " + (i + 1) + "/" + listFilePath.Count + " images";
                        }));
                        x += widthEachImg;
                        //pn.Controls.Add(pic);

                        // go to new row if (x + width) > pn.width
                        if (x + widthEachImg > pnListFrame.Width)
                        {
                            x = 0;
                            y += heightEachImg;
                        }
                    }
                }
            }

            // Load true images
            //for (int i = 0; i < listFilePath.Count; i++)
            //{
            //    //PictureBox pic = pnListFrame.Controls[i] as PictureBox;
            //    //pic.Image = Image.FromFile(listFilePath[i]);
            //    //pic.Tag = listFilePath[i];

            //    ifi.state = BG_STATE.LOAD_TRUE;
            //    ifi.index = i;
            //    ifi.file_url = listFilePath[i];
            //    bgWorker_LoadFrames.ReportProgress(0, ifi);
            //}
        }
        private void bgWorker_LoadFrames_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MyUserState userState = (MyUserState)e.UserState;
            PictureBoxSizeMode displayMode = PictureBoxSizeMode.StretchImage;

            PictureBox pic = pnListFrame.Controls[userState.index] as PictureBox;
            pic.Location = userState.location;
            pic.Size = userState.size;
            //pic.Image = Properties.Resources.default_picture;
            pic.Image = Image.FromFile(userState.file_url);
            pic.Tag = userState.file_url;
            pic.SizeMode = displayMode;
            pic.Visible = true;

            statusBar1.Panels[0].Text = "Loading " + (userState.index + 1).ToString() + "/" + userState.totalFile.ToString() + " images";
        }
        private void bgWorker_LoadFrames_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusBar1.Panels[0].Text = "Total: " + countPicFrameIsShowing + " (images)";
            pnListFrame.AutoScroll = true;
        }
        // AxWindowsMediaPlayer
        private void axWMP_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.O)
                {
                    rbtnORC.Checked = true;
                    txtTextQuery.Focus();
                }
                else if (e.KeyCode == Keys.P)
                {
                    rbtnContent.Checked = true;
                    txtTextQuery.Focus();
                }
            }
        }
        #endregion

    }
}
