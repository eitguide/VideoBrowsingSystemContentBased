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
        }

        void btnGetResultForTrecEval_Click(object sender, EventArgs e)
        {
            // load index for search
            IndexStorage textCaptionIndexStorage = new IndexStorage(ConfigCommon.CAPTION_INDEX_STORAGE);
            textCaptionIndexStorage.OpenIndexStore();

            // read queries
            Dictionary<string, string> dicQueries = ReadQueriesFile(ConfigEvaluation.queriesFile);
            foreach (var item in dicQueries)
            {
                Console.WriteLine(string.Format("'{0}'", item.Value));
            }

            // search for each query
            FileStream fs = File.Create(ConfigEvaluation.resultsFile);
            fs.Close();
            StreamWriter sw = new StreamWriter(ConfigEvaluation.resultsFile);
            foreach (var item in dicQueries)
            {
                // example: 301	Q0	FR940202-2-00150	104	  2.129133	STANDARD
                List<float> listScores;
                List<Object> listTextCaptions = Searching.SearchByQueryPlusScore(textCaptionIndexStorage, ConfigCommon.TOP_RANK, item.Value, SearchType.CAPTION, out listScores);
                if (listTextCaptions == null)
                {
                    sw.Write(item.Key + "\tQ0\tNULL\tNULL\tNULL\tNULL\n");
                    continue;
                }

                HashSet<string> hsDocRelevanced = new HashSet<string>();
                List<float> listScoresNew = new List<float>();
                for (int i = 0; i < listTextCaptions.Count; i++)
                {
                    string docRelevanced = GetDocRelevanced(((TextCaption)listTextCaptions[i]).FrameName);
                    if (!hsDocRelevanced.Contains(docRelevanced))
                    {
                        hsDocRelevanced.Add(docRelevanced);
                        listScoresNew.Add(listScores[i]);
                    }
                    if (hsDocRelevanced.Count == 50)
                        break;
                }
                for (int i = 0; i < hsDocRelevanced.Count; i++)
                {
                    //string docRelevanced = GetDocRelevanced(((TextCaption)listTextCaptions[i]).FrameName);
                    string record = string.Format("{0}\tQ0\t{1}\t{2}\t{3}\tRUN_0", item.Key, hsDocRelevanced.ElementAt(i), (i + 1), listScoresNew[i]);
                    //Console.WriteLine(record);
                    sw.Write(record + "\n");
                }
                //for (int i = 0; i < listTextCaptions.Count; i++)
                //{
                //    string docRelevanced = GetDocRelevanced(((TextCaption)listTextCaptions[i]).FrameName);
                //    string record = string.Format("{0}\tQ0\t{1}\t{2}\t{3}\tRUN_0", item.Key, docRelevanced, (i + 1), listScores[i]);
                //    Console.WriteLine(record);
                //}
                Console.WriteLine(item.Key);
            }
            sw.Close();
            Console.WriteLine("Finish");
        }

        private string GetDocRelevanced(string frameName)
        {
            // frameName eg: /home/nghianv/data/frame/TRECVID2016_39181\TRECVID2016_39181.shot39181_24.RKF_3.Frame_13330.jpg
            string docRelevanced = Regex.Match(frameName, @"shot\d+_\d+").Value;

            return docRelevanced;
        }

        private Dictionary<string, string> ReadQueriesFile(string queryContentFile)
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
    }
}
