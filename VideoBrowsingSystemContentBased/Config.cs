using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased
{
    public class Config
    {

        public static String CAPTION_INDEX_STORAGE = @"D:/SoureThesis/Data/caption_indexing/";
        public static String TEXTSPOTTING_INDEX_STORAGE = @"D:/SoureThesis/Data/textspot_indexing/";

        public static String FRAME_DATA_PATH = "";
        public static String VIDEO_DATA_PATH = "";

        public static String MAPPING_VIDEO_NAME_PATH = @"D:/SoureThesis/Data/video_name.txt";
        public static String XML_FOLDER_PATH = @"D:/SoureThesis/Data/xml";
        public static String TEXT_PLOTTING_PATH = @"D:/SoureThesis/Data/textplotting.txt";

        public static int TOP_RANK = 100;
    }
}
