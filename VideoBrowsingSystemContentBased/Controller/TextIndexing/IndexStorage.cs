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
        //Path store data of indexing
        public String FolderPathIndexing { get; set; }

        public StandardAnalyzer analyzer { get; private set; }
        public IndexWriter IndexWriter { get; private set; }
        public IndexReader IndexReader { get; private set; }

        public FSDirectory DirectoryIndexing { get; private set; }

        public bool IsOpen { get; set; }

        public IndexStorage()
        {
            this.IsOpen = false;
        }
        public IndexStorage(String folderPathIndexing)
        {
            this.IsOpen = false;
            this.FolderPathIndexing = folderPathIndexing;
            analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);

        }

        /// <summary>
        /// Open IndexStorage
        /// </summary>
        public void OpenIndexStore()
        {
            if (!IsOpen)
            {
                if (DirectoryIndexing == null)
                {
                    this.DirectoryIndexing = FSDirectory.Open(this.FolderPathIndexing);
                }
                this.IsOpen = true;
            }
        }

        /// <summary>
        /// Get IndexWriter for writing document to IndexStorage
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Close IndexWriter
        /// </summary>
        public void CloseIndexWriter()
        {
            if (IndexWriter != null)
            {
                IndexWriter.Optimize();
                IndexWriter.Commit();
                IndexWriter.Dispose();
            }
        }


        /// <summary>
        /// Close IndexReader
        /// </summary>
        public void CloseIndexReader()
        {
            if (IndexReader != null)
            {
                IndexReader.Dispose();
            }
        }

        //Close Index Storage
        public void CloseIndexStorage()
        {
            CloseIndexWriter();
            CloseIndexReader();
            this.IsOpen = false; 
        }
    }
}
