using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoBrowsingSystemContentBased
{
    public class ConfigCommon
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

        public static String PCT_OUTPUT_PATH = @"D:/SoureThesis/Data/pct_output";

        public static String PCT_INDEX_STORAGE = @"D:/SoureThesis/Data/pct_indexing";
        public static String PCT_INDEX_STORAGE_EVAL = @"D:/SoureThesis/Data/pct_indexing_eval";
        //Rank for searching
        public static  int TOP_RANK = 500; // achived: 100

        //Hotkeys
        public static Keys HOTKEY_SEARCH_BY_TEXT_ORC = Keys.O;      // [Ctrl] + [O]
        public static Keys HOTKEY_SEARCH_BY_TEXT_CONTENT = Keys.P;  // [Ctrl] + [P]
        public static Keys HOTKEY_PICK_COLOR_FROM_FRAMES = Keys.X;  // [Ctrl] + [X]

    }

    public class ConfigPCT
    {
        public enum ColorSpace
        {
            RGB,    // indexing, searching will use System.Drawing.Color class
            Lab     // indexing, searching will use ColorMine.ColorSpaces.Lab class
        }
        public enum FormulaRGB // when remove/add value in this enum, after that edit in ColorKNN function
        {
            RGB_Euclid
        }
        public enum FormulaLab
        {
            Lab_CIE76,      
            Lab_CMCIC,      
            Lab_CIE94,      
            Lab_CIE2000     
        }
        // Search by dotting color config (if change [*] config, you must run indexing PCT again):
        public static ColorSpace COLOR_SPACE_USING = ColorSpace.Lab;                // [*]
        public static FormulaRGB FORMULA_RGB_USING = FormulaRGB.RGB_Euclid;         // [*]
        public static FormulaLab FORMULA_LAB_USING = FormulaLab.Lab_CIE2000;        // [*]
        public static int PCT_NUMBER_OF_HORIZONTAL_REGION = 4;                      // [*]
        public static int PCT_NUMBER_OF_VERTICAL_REGION = 3;                        // [*]
        public static int PCT_STEP_INDEX_FILE = 2;                                  // [*]. if this=1 will index every files
        public static int RADIUS_THRESHOLD = 8;                                     // [*]
        public static int COLOR_NOISE_THRESHOLD = 6;                                // [*]. if number colors visualed > this, skip 
        public static bool ACCEPT_REGION_NEAR_EQUAL = true;                         // [*]
        public static int THRESHOLD_PIXEL_NEAR_EQUAL_FOR_ACCEPT = 10;               // [*]
    }

    public class ConfigEvaluation
    {
        public static string trecEvalFile = @"C:\Users\puyed\Documents\trec_eval.9.0\trec_eval.exe";
        public static string qrelsFile = @"C:\Users\puyed\Documents\trec_eval.9.0\thesis\avs.qrels.my_fix.tv16";

        public static string topicFile = @"C:\Users\puyed\Documents\trec_eval.9.0\thesis\tv16.avs.topics.txt";
        public static string topicFile_textSpotting = @"C:\Users\puyed\Documents\trec_eval.9.0\thesis\textspotting.topics.txt";
        public static string topicFile_color = @"C:\Users\puyed\Documents\trec_eval.9.0\thesis\color.topics.txt";
        public static string resultsFile = @"C:\Users\puyed\Documents\trec_eval.9.0\thesis\avs.results.txt";
        public static string resultsFile_textSpotting = @"C:\Users\puyed\Documents\trec_eval.9.0\thesis\textspotting.results.txt";
        public static string resultsFile_color = @"C:\Users\puyed\Documents\trec_eval.9.0\thesis\color.results.txt";
        public static string scaledvideo_textSpotting = @"C:\Users\puyed\Documents\trec_eval.9.0\thesis\textspotting.scaledvideos.txt";
    }
}
