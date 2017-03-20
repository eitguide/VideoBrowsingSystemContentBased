using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBrowsingSystemContentBased.Model
{
    //using for TextCation run by Densecap model
    public class TextCaption
    {
        //Name of the frame. Example TRECVID2016_35350.shot35350_1.RKF_0.Frame_14.jpg
        public String FrameName { get; set; }

        //Caption Extract from frame
        public String Caption { get; set; }

        public TextCaption()
        {

        }

        public TextCaption(String frameName, String caption)
        {
            this.FrameName = frameName;
            this.Caption = caption;
        }
    }


    public class Opt
    {
        public string output_dir { get; set; }
        public int num_to_draw { get; set; }
        public double final_nms_thresh { get; set; }
        public int use_cudnn { get; set; }
        public int text_size { get; set; }
        public int max_images { get; set; }
        public int gpu { get; set; }
        public string splits_json { get; set; }
        public string outputname { get; set; }
        public string checkpoint { get; set; }
        public int num_proposals { get; set; }
        public double rpn_nms_thresh { get; set; }
        public int image_size { get; set; }
        public int box_width { get; set; }
        public string input_image { get; set; }
        public string input_split { get; set; }
        public int output_vis { get; set; }
        public string input_dir { get; set; }
        public string output_vis_dir { get; set; }
        public string vg_img_root_dir { get; set; }
    }

    public class Result
    {
        public string img_name { get; set; }
        public List<double> scores { get; set; }
        public List<string> captions { get; set; }
        public List<List<double>> boxes { get; set; }
    }

    public class DenseCap
    {
        public Opt opt { get; set; }
        public List<Result> results { get; set; }
    }
}
