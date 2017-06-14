using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBrowsingSystemContentBased.Utils;
using VideoBrowsingSystemContentBased.View;

namespace VideoBrowsingSystemContentBased
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DistanceHelper.InitPCT();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ViewPCTImage());
            //Application.Run(new ImageIndexing());
            Application.Run(new VideoBrowsingForm());
        }
    }
}
