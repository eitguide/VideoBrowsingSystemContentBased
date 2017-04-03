using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased
{
    public class Config
    {

        //Path of folder store cattion indexing
        public static String CAPTION_INDEX_STORAGE = @"D:/SoureThesis/Data/caption_indexing/";

        public static String TEXT_CAPTION_PATH = @"D:/SoureThesis/Data/caption_processed/";

        public static String JSON_DENSECAP_FOLDER_PATH = @"D:/SoureThesis/Data/densecap_json";
        //path of folder store textspoting indexing
        public static String TEXTSPOTTING_INDEX_STORAGE = @"D:/SoureThesis/Data/textspot_indexing/";
        //Path of folder which store frame data
        public static String FRAME_DATA_PATH = @"G:\net\dl380g7a\export\ddn11a2\ledduy\trecvid-avs\keyframe-5\tv2016\test.iacc.3/";
        
        //Path of folder which store video data
        public static String VIDEO_DATA_PATH = "G:/iacc.3/";

        // Path of file store vide name and video id
        public static String MAPPING_VIDEO_NAME_PATH = @"D:/SoureThesis/Data/video_name.txt";

        //Path of folder store ouput of textspotting model
        public static String XML_FOLDER_PATH = @"D:/SoureThesis/Data/xml";

        //Path of foder which store final result of textspotting
        public static String TEXT_PLOTTING_PATH = @"D:/SoureThesis/Data/textplotting.txt";

        public static String FPS_VIDEO_PATH = @"D:/SoureThesis/Data/video_fps.xml";

        public static String PCT_OUPUT_PATH = @"D:/SoureThesis/Data/pct_output";

        public static String PCT_INDEX_STORAGE = @"D:/SoureThesis/Data/pct_indexing";
        //Rank for searching
        public static int TOP_RANK = 100;
    }
}
