using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using System.IO;

namespace VideoBrowsingSystemContentBased.Controller.TextIndexing
{
    public class IndexStorage
    {
        public String FolderPathIndexing { get; set; }
        public StandardAnalyzer analyzer { get; private set; }
        public IndexWriter IndexWriter { get; private set; }
        public IndexReader IndexReader { get; private set; }

        public FSDirectory DirectoryIndexing { get; private set; }

        public IndexStorage(String folderPathIndexing)
        {
            this.FolderPathIndexing = folderPathIndexing;
            analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);

        }

        public void OpenIndexStore()
        {
            if (DirectoryIndexing == null)
            {
                this.DirectoryIndexing = FSDirectory.Open(this.FolderPathIndexing);
            }
        }

        public IndexWriter GetIndexWriter()
        {
            if (IndexWriter == null)
            {
                try
                {
                    IndexWriter = new IndexWriter(DirectoryIndexing, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED);
                }catch(IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return IndexWriter;
        }

        public IndexReader GetIndexReader()
        {
            return null;
        }

        public void CloseIndexWriter()
        {
            if (IndexWriter != null)
            {
                IndexWriter.Optimize();
                IndexWriter.Commit();
                IndexWriter.Dispose();
            }
        }

        public void CloseIndexReader()
        {
            if (IndexReader != null)
            {
                IndexReader.Dispose();
            }
        }

        public void CloseIndexStorage()
        {
            CloseIndexWriter();
            CloseIndexReader();
        }
    }
}
