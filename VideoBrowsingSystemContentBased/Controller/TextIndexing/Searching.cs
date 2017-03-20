using Lucene.Net.Documents;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBrowsingSystemContentBased.Model;

namespace VideoBrowsingSystemContentBased.Controller.TextIndexing
{
    public class Searching
    {
        /// <summary>
        /// Searching based on text query
        /// </summary>
        /// <param name="indexStorage">Index Storage</param>
        /// <param name="topRank">Top result you want to search</param>
        /// <param name="query">text query</param>
        /// <param name="searchType">Support Two Searc Type [ORC, CAPTION]</param>
        /// <returns></returns>
        public static List<Object> SearchByQuery(IndexStorage indexStorage, int topRank, String query, SearchType searchType)
        {
            IndexSearcher indexSearch = new IndexSearcher(indexStorage.DirectoryIndexing);

            //var parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_30, new[]{
            //    Indexing.TEXT_SPOT}, indexStorage.analyzer);

            Lucene.Net.QueryParsers.QueryParser queryParser = null;
            if (searchType == SearchType.ORC)
                queryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, Indexing.TEXT_SPOT, indexStorage.analyzer);
            else if (searchType == SearchType.CAPTION)
                queryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, Indexing.TEXT_CAPTION, indexStorage.analyzer);


            Query q = queryParser.Parse(query);
            TopDocs topDocs = indexSearch.Search(q, topRank);

            if (topDocs == null || topDocs.ScoreDocs.Length == 0)
                return null;

            List<Object> result = new List<Object>();
            for (int i = 0; i < topDocs.ScoreDocs.Length; i++)
            {
                ScoreDoc scoreDoc = topDocs.ScoreDocs[i];
                float score = scoreDoc.Score;
                int docId = scoreDoc.Doc;

                Document doc = indexSearch.Doc(docId);

                if (searchType == SearchType.ORC)
                    result.Add(new TextSpot(doc.Get(Indexing.FRAME_NAME), doc.Get(Indexing.TEXT_SPOT)));
                else if (searchType == SearchType.CAPTION)
                    result.Add(new TextCaption(doc.Get(Indexing.FRAME_NAME), doc.Get(Indexing.TEXT_CAPTION)));
            }
            return result;
        }

        /// <summary>
        /// Find All files In a shot in video
        /// </summary>
        /// <param name="frame">Frame store Video Id And Video Shot</param>
        /// <param name="folderPath">Folder path you want to find</param>
        /// <returns></returns>
        public static String[] GetShotFrame(Frame frame, String folderPath)
        {
            String pattern = String.Format("TRECVID2016_{0}.shot{1}_{2}.*jpg", frame.VideoId, frame.VideoId, frame.Shot);
            String[] files = System.IO.Directory.GetFiles(folderPath, pattern);
            return files;
        }


    }
}
