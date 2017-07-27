using ColorMine.ColorSpaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBrowsingSystemContentBased.Controller;
using VideoBrowsingSystemContentBased.Controller.ImageIndexing;
using VideoBrowsingSystemContentBased.Controller.TextIndexing;
using VideoBrowsingSystemContentBased.Model;

namespace VideoBrowsingSystemContentBased.View
{
    public partial class EvaluationForm : Form
    {
        public EvaluationForm()
        {
            InitializeComponent();

            btnGetResultForTrecEval.Click += btnGetResultForTrecEval_Click;
            numNumberOfTopGet.Value = 50;
            //ShrinkTo1FramePerShot();
        }

        void btnGetResultForTrecEval_Click(object sender, EventArgs e)
        {
            // load index for search
            IndexStorage textCaptionIndexStorage = new IndexStorage(ConfigCommon.CAPTION_INDEX_STORAGE);
            textCaptionIndexStorage.OpenIndexStore();

            // read queries
            Dictionary<string, string> dicQueries = ReadTopicFile(ConfigEvaluation.topicFile);
            foreach (var item in dicQueries)
            {
                Console.WriteLine(string.Format("'{0}'", item.Value));
            }

            // search for each query
            FileStream fs = File.Create(ConfigEvaluation.resultsFile);
            fs.Close();
            StreamWriter sw = new StreamWriter(ConfigEvaluation.resultsFile);
            foreach (var query in dicQueries)
            {
                // example: 301	Q0	FR940202-2-00150	104	  2.129133	STANDARD
                List<float> listScores;
                List<Object> listTextCaptions = Searching.SearchByQueryPlusScore(textCaptionIndexStorage, ConfigCommon.TOP_RANK, query.Value, SearchType.CAPTION, out listScores);
                if (listTextCaptions == null)
                {
                    sw.Write(query.Key + "\tQ0\tNULL\tNULL\tNULL\tNULL\n");
                    continue;
                }

                HashSet<string> hsDocRetrieval = new HashSet<string>();
                List<float> listScoresNew = new List<float>();
                for (int i = 0; i < listTextCaptions.Count; i++)
                {
                    string docRetrieval = GetDocRetrieval(((TextCaption)listTextCaptions[i]).FrameName);
                    if (!hsDocRetrieval.Contains(docRetrieval))
                    {
                        hsDocRetrieval.Add(docRetrieval);
                        listScoresNew.Add(listScores[i]);
                    }
                    if (hsDocRetrieval.Count == numNumberOfTopGet.Value)
                        break;
                }
                for (int i = 0; i < hsDocRetrieval.Count; i++)
                {
                    //string docRelevanced = GetDocRelevanced(((TextCaption)listTextCaptions[i]).FrameName);
                    string record = string.Format("{0}\tQ0\t{1}\t{2}\t{3}\tRUN_0", query.Key, hsDocRetrieval.ElementAt(i), (i + 1), listScoresNew[i]);
                    //Console.WriteLine(record);
                    sw.Write(record + "\n");
                }
                Console.WriteLine(query.Key);
            }
            sw.Close();
            Console.WriteLine("Finish");
        }

        private string GetDocRetrieval(string frameName)
        {
            // frameName eg: /home/nghianv/data/frame/TRECVID2016_39181\TRECVID2016_39181.shot39181_24.RKF_3.Frame_13330.jpg
            string docRelevanced = Regex.Match(frameName, @"shot\d+_\d+").Value;

            return docRelevanced;
        }

        private Dictionary<string, string> ReadTopicFile(string queryContentFile)
        {
            Dictionary<string, string> dicQueries = new Dictionary<string, string>();

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(queryContentFile);
            while ((line = file.ReadLine()) != null)
            {
                int indexFirstSpaceChar = line.IndexOf(' ');
                string queryId = line.Substring(0, indexFirstSpaceChar);
                string queryContent = line.Substring(indexFirstSpaceChar + 1);
                dicQueries.Add(queryId, queryContent);
            }

            file.Close();


            return dicQueries;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (txtTrecEvalResult.Text.Trim() == string.Empty)
                return;

            txtResultCalculation.Text = string.Empty;

            List<string> listQueryId = new List<string>();
            List<int> listRet = new List<int>();
            List<int> listRel = new List<int>();
            List<int> listRelRet = new List<int>();
            List<float> listPrecision = new List<float>();
            List<float> listRecall = new List<float>();

            MatchCollection matching = Regex.Matches(txtTrecEvalResult.Text, @"num_ret .+");
            for (int i = 0; i < matching.Count - 1; i++)
            {
                listRet.Add(int.Parse(Regex.Matches(matching[i].Value, @"\d+")[1].Value));
                listQueryId.Add(Regex.Matches(matching[i].Value, @"\d+")[0].Value);
            }

            matching = Regex.Matches(txtTrecEvalResult.Text, @"num_rel .+");
            for (int i = 0; i < matching.Count - 1; i++)
                listRel.Add(int.Parse(Regex.Matches(matching[i].Value, @"\d+")[1].Value));

            matching = Regex.Matches(txtTrecEvalResult.Text, @"num_rel_ret .+");
            for (int i = 0; i < matching.Count - 1; i++)
                listRelRet.Add(int.Parse(Regex.Matches(matching[i].Value, @"\d+")[1].Value));

            float sumPrecision = 0, sumRecall = 0;
            txtResultCalculation.Text += string.Format("query\tret\trel\trel_ret\tprecision\tRecall") + Environment.NewLine;
            for (int i = 0; i < listRel.Count; i++)
            {
                float precision = (float)listRelRet[i] / (float)listRet[i];
                float recall = (float)listRelRet[i] / (float)listRel[i];
                txtResultCalculation.Text += string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", listQueryId[i], listRet[i],
                    listRel[i], listRelRet[i], Math.Round(precision * (float)100, 2), Math.Round(recall * (float)100, 2)) + Environment.NewLine;
                if (listRel[i] == 0)
                    continue;

                listPrecision.Add(precision);
                listRecall.Add(recall);
                sumPrecision += precision;
                sumRecall += recall;
            }
            txtResultCalculation.Text += string.Format("Precision tb: {0} %",
                (sumPrecision / (float)listPrecision.Count) * (float)100) + Environment.NewLine;
            txtResultCalculation.Text += string.Format("Recall tb: {0} %",
                (sumRecall / (float)listRecall.Count) * (float)100) + Environment.NewLine;
            //tbxResultCalculation.Text += matching[i].Value + Environment.NewLine;
        }

        private void btnGetResultForTrecEvalTextSpotting_Click(object sender, EventArgs e)
        {
            // load index for search
            IndexStorage textSpotingIndexStorage = new IndexStorage(ConfigCommon.TEXTSPOTTING_INDEX_STORAGE);
            textSpotingIndexStorage.OpenIndexStore();

            // read queries
            Dictionary<string, string> dicTopics = ReadTopicFile(ConfigEvaluation.topicFile_textSpotting);
            foreach (var item in dicTopics)
            {
                Console.WriteLine(string.Format("'{0}'", item.Value));
            }

            // read scaled videos
            HashSet<string> hsScaledVideos = new HashSet<string>(File.ReadAllLines(ConfigEvaluation.scaledvideo_textSpotting));

            // search for each query
            FileStream fs = File.Create(ConfigEvaluation.resultsFile_textSpotting);
            fs.Close();
            StreamWriter sw = new StreamWriter(ConfigEvaluation.resultsFile_textSpotting);
            foreach (var query in dicTopics)
            {
                // example: 301	Q0	FR940202-2-00150	104	  2.129133	STANDARD
                List<float> listScores;
                List<Object> listTextCaptions = Searching.SearchByQueryPlusScore(textSpotingIndexStorage, ConfigCommon.TOP_RANK, query.Value, SearchType.OCR, out listScores);
                if (listTextCaptions == null)
                {
                    sw.Write(query.Key + "\tQ0\tNULL\tNULL\tNULL\tNULL\n");
                    continue;
                }

                HashSet<string> hsDocRetrieval = new HashSet<string>();
                List<float> listScoresNew = new List<float>();
                int countDocRetrieval = hsDocRetrieval.Count;
                for (int i = 0; i < listTextCaptions.Count; i++)
                {
                    string docRetrieval = GetDocRetrieval(((TextSpot)listTextCaptions[i]).FileName);
                    if (!hsScaledVideos.Contains(docRetrieval.Split('_')[0].Split('t')[1]))
                        continue;

                    if (!hsDocRetrieval.Contains(docRetrieval))
                    {
                        hsDocRetrieval.Add(docRetrieval);
                        listScoresNew.Add(listScores[i]);
                    }
                }
                if (countDocRetrieval == hsDocRetrieval.Count)
                {
                    sw.Write(query.Key + "\tQ0\tNULL\tNULL\tNULL\tNULL\n");
                    Console.WriteLine(query.Key);
                    continue;
                }

                for (int i = 0; i < hsDocRetrieval.Count; i++)
                {
                    //string docRelevanced = GetDocRelevanced(((TextCaption)listTextCaptions[i]).FrameName);
                    string record = string.Format("{0}\tQ0\t{1}\t{2}\t{3}\tRUN_0", query.Key, hsDocRetrieval.ElementAt(i), (i + 1), listScoresNew[i]);
                    //Console.WriteLine(record);
                    sw.Write(record + "\n");
                }
                Console.WriteLine(query.Key);
            }
            sw.Close();
            Console.WriteLine("Finish");
        }

        private void btnGetResultForTrecEvalColor_Click(object sender, EventArgs e)
        {
            // load index for search
            Dictionary<string, string> pctIndexingDataEval = PCTIndexing.LoadImageIndexStrorageV2(ConfigCommon.PCT_INDEX_STORAGE_EVAL);

            // read queries
            Dictionary<string, string> dicQueries = ReadTopicFile(ConfigEvaluation.topicFile_color);
            foreach (var item in dicQueries)
                Console.WriteLine(string.Format("'{0}'", item.Value));

            // search for each query
            FileStream fs = File.Create(ConfigEvaluation.resultsFile_color);
            fs.Close();
            StreamWriter sw = new StreamWriter(ConfigEvaluation.resultsFile_color);
            foreach (var query in dicQueries)
            {
                // example: 301	Q0	FR940202-2-00150	104	  2.129133	STANDARD
                List<float> listScores;
                List<string> listFrameName = SearchByColor(pctIndexingDataEval, query.Value);
                if (listFrameName == null)
                {
                    sw.Write(query.Key + "\tQ0\tNULL\tNULL\tNULL\tNULL\n");
                    continue;
                }

                HashSet<string> hsDocRetrieval = new HashSet<string>();
                for (int i = 0; i < listFrameName.Count; i++)
                {
                    string docRetrieval = GetDocRetrieval(listFrameName[i]);
                    if (!hsDocRetrieval.Contains(docRetrieval))
                        hsDocRetrieval.Add(docRetrieval);

                    if (hsDocRetrieval.Count == 100)
                        break;
                }
                for (int i = 0; i < hsDocRetrieval.Count; i++)
                {
                    //string docRelevanced = GetDocRelevanced(((TextCaption)listTextCaptions[i]).FrameName);
                    string record = string.Format("{0}\tQ0\t{1}\t{2}\t{3}\tRUN_0", query.Key, hsDocRetrieval.ElementAt(i), (i + 1), 0);
                    //Console.WriteLine(record);
                    sw.Write(record + "\n");
                }
                Console.WriteLine(query.Key);
            }
            sw.Close();
            Console.WriteLine("Finish");
        }

        private List<string> SearchByColor(Dictionary<string, string> pctIndexingData, string query)
        {
            List<string> listFrameName = new List<string>();
            List<Dot_Lab> listDotsDrawed_Lab = new List<Dot_Lab>();

            // query : 238_101-140_255_251^^^41_99-140_255_251^^^141_98-236_28_36
            string[] values = query.Split(new string[] { "^^^" }, StringSplitOptions.None);
            foreach (var value in values)
	        {
		        string[]  _values = value.Split('_');
                Dot_Lab dot = new Dot_Lab(new Point(int.Parse(_values[0]), int.Parse(_values[1])), 17.5f, 
                    new Rgb(){R=int.Parse(_values[2]), G=int.Parse(_values[3]), B=int.Parse(_values[4])}.To<Lab>());
                listDotsDrawed_Lab.Add(dot);
	        }

            List<String> result = PCTSearching.SearchingV3_Lab(pctIndexingData, listDotsDrawed_Lab, new Size(316, 204));
            return result == null || result.Count == 0 ? null : result;
        }

        private void ShrinkTo1FramePerShot()
        {
            string dir = @"C:\Users\puyed\Desktop\videos\";
            string tarDir = @"C:\Users\puyed\Desktop\videos_shrinked\";

            foreach (var _dir in Directory.GetDirectories(dir))
            {
                string videoId = _dir.Split('_')[1];
                Directory.CreateDirectory(tarDir + "TRECVID2016_" + videoId);
                // TRECVID2016_36268.shot36268_1.RKF_0.Frame_16.jpg
                int shotId = 0;
                while (true)
                {
                    string[] filesSearched = Directory.GetFiles(_dir, string.Format("TRECVID2016_{0}.shot{1}_{2}.*",
                         videoId, videoId, ++shotId));
                    if (filesSearched.Length == 0)
                    {
                        Console.WriteLine(shotId - 1);
                        break;
                    }

                    File.Copy(filesSearched[filesSearched.Length / 2], tarDir + "TRECVID2016_" + videoId + "\\" + Path.GetFileName(filesSearched[filesSearched.Length / 2]));
                }



                //string[] files = Directory.GetFiles(_dir);
                //Frame lastFrame = Utils.Decoder.DecodeFrameFromName(Path.GetFileName(files[files.Length - 1]));
                //for (int i = 1; i <= lastFrame.Shot; i++)
                //{
                //    // TRECVID2016_36268.shot36268_1.RKF_0.Frame_16.jpg
                //    string [] filesSearched = Directory.GetFiles(_dir, string.Format("TRECVID2016_{0}.shot{1}_{2}.*",
                //        lastFrame.VideoId, lastFrame.VideoId, i));
                //    File.Copy(filesSearched[filesSearched.Length / 2], tarDir + Path.GetFileName(filesSearched[filesSearched.Length/2]));
                //}
            }
        }
    }
}
