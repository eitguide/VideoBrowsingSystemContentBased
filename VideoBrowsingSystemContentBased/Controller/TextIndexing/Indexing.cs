using Lucene.Net.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBrowsingSystemContentBased.Model;

namespace VideoBrowsingSystemContentBased.Controller.TextIndexing
{
    public class Indexing
    {
        public static String FRAME_NAME = "frame_name";
        public static String TEXT_SPOT = "text_spot";
        public static String TEXT_CAPTION = "text_caption";

        public static void AddDocumentToIndexStorage(IndexStorage indexStorage, TextSpot textSpot)
        {
            Document doc = new Document();
            doc.Add(new Field(FRAME_NAME, textSpot.FileName, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field(TEXT_SPOT, textSpot.Text, Field.Store.YES, Field.Index.ANALYZED));
          
            indexStorage.GetIndexWriter().AddDocument(doc);
        }

        public static void AddDocumentToIndexStorage(IndexStorage indexStorage, TextCaption textCaption)
        {
            Document doc = new Document();
            doc.Add(new Field(FRAME_NAME, textCaption.FrameName, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field(TEXT_SPOT, textCaption.Caption, Field.Store.YES, Field.Index.ANALYZED));

            indexStorage.GetIndexWriter().AddDocument(doc);
        }

        public static void IndexFromDatabaseStorage(IndexStorage indexStorage, List<TextSpot> textSpot)
        {
            if (textSpot != null && textSpot.Count > 0)
            {
                foreach (TextSpot item in textSpot)
                {
                    AddDocumentToIndexStorage(indexStorage, item);
                }
            }
        }


        public static void IndexFromDatabaseStorage(IndexStorage indexStorage, List<TextCaption> textCaption)
        {
            if (textCaption != null && textCaption.Count > 0)
            {
                foreach (TextCaption item in textCaption)
                {
                    AddDocumentToIndexStorage(indexStorage, item);
                }
            }
        }
    }
}
