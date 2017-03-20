using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBrowsingSystemContentBased.Model;

namespace VideoBrowsingSystemContentBased.Widget
{
    public partial class ColorDottingUC : UserControl
    {
        public static VideoBrowsingForm Main;

        public ColorDottingUC()
        {
            InitializeComponent();
            UISetting();
        }

        private void UISetting()
        {
            colorPicker.Height = Convert.ToInt32(this.Height * 0.5);

            label.Location = new Point(10, colorPicker.Location.Y + colorPicker.Height + 10);

            int MARGIN_LB_PANELCOLR_SELECTED = 10;
            int MARGIN_PANELCOLR_SELECTED_COLORPICKER = 5;
            panelColorSelected.Location = new Point(label.Location.X + label.Width + MARGIN_LB_PANELCOLR_SELECTED, label.Location.Y - MARGIN_PANELCOLR_SELECTED_COLORPICKER);
            panelColorSelected.Width = Convert.ToInt32(this.Width * 0.1);

            int MARGIN_GBCOLORSELECT_MODE = 10;
            //txtMode.Location = new Point(panelColorSelected.Location.X + panelColorSelected.Width + MARGIN_GBCOLORSELECT_MODE, label.Location.Y);


            int MARGIN_GBDRAW_LB = 10;
            gbDraw.Location = new Point(label.Location.X - MARGIN_LB_PANELCOLR_SELECTED, label.Location.Y + label.Height + MARGIN_GBDRAW_LB);
            gbDraw.Width = this.Width;
            gbDraw.Height = this.Height - colorPicker.Height - panelColorSelected.Height - MARGIN_PANELCOLR_SELECTED_COLORPICKER - MARGIN_GBDRAW_LB;



            gbDraw.Refresh();
            drawUI.Width = gbDraw.Width - 5;
            drawUI.Height = gbDraw.Height - 20;

            drawUI.Tool = Variables.DrawingTools.Node;
            drawUI.colorNode = panelColorSelected.BackColor;

        }

        private void ColorDottingUC_SizeChanged(object sender, EventArgs e)
        {
            UISetting();
        }

        private void colorPickerUC1_MouseCaptureChanged(object sender, EventArgs e)
        {
            panelColorSelected.BackColor = colorPicker.GetColor();
            drawUI.colorNode = panelColorSelected.BackColor;
        }

        public void SearchByColour()
        {
            drawUI.GetAllInfos();
            Main.ShowResultFromSketchColor();

        }
        public void UpdateBackgroundImagePicker(Image image)
        {
            colorPicker.BackgroundImage = image;
            colorPicker.Refresh();
            colorPicker.UpdateBitmap();
        }
    }
}
