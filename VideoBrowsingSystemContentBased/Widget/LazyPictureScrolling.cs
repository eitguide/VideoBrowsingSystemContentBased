using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace VideoBrowsingSystemContentBased.Widget
{
    /// <summary>
    /// The container for showing a lot of pictures, scroll to the bottom to load more.
    /// - input: list url pictures (by call the startLazyShow() function)
    /// - output: showing first <NUMBER_OF_FIRST_PICS> pics, scroll to bottom to load more <NUMBER_OF_JUMP_PICS>, the max pics is shown is <NUMBER_OF_MAX_PICS>.
    /// </summary>
    public partial class LazyPictureScrolling : UserControl
    {
        #region Naming convention
        /*
         * only "pic" : real pic
         * "Picbx", "PictureBox", ... : PictureBox control 
         */
        #endregion

        #region Class's Fields

        private const int NUMBER_OF_MAX_PICS = 1000;
        private const int NUMBER_OF_FIRST_PICS = 70;    // giá trị này phải tính dựa vào chiều cao của container và chiều cao của picturebox, nhưng hiện tại tạm thời gán tay (!)
        private const int NUMBER_OF_JUMP_PICS = 10;

        private List<string> listUrlPicsToShow;         // input
        private List<PictureBox> listAllPictureBoxs;    // for list PictureBox for easier access (list size = NUMBER_OF_MAX_PICS)
        private int lastPicbxIndexShowing;              // để nhận biết cho việc load more hình ảnh
        private bool loadedAllPics;                     // để nhận biết có load thêm không khi scroll xuống cuối

        public delegate void NumberOfPicsShownChange(object sender, int numberOfPicsShown, int totalOfPics, int maxOfPicsCanShown);
        public event NumberOfPicsShownChange numberOfPicsShownChange;                       // để notify cho lister khi load thêm ảnh, notify cùng với những thông tin đi kèm, eg: sender, numberOfPicsShown, ...
        public delegate void AnyPicClicked(object sender, EventArgs e);
        public event AnyPicClicked anyPickClicked; 
        #endregion


        // START POINT
        public LazyPictureScrolling()
        {
            InitializeComponent();

            #region Init fields
            listAllPictureBoxs = new List<PictureBox>();
            lastPicbxIndexShowing = -1;
            #endregion

            #region Init UC's controls properties
            flowlpnlPicsContainer.Dock = DockStyle.Fill;
            flowlpnlPicsContainer.FlowDirection = FlowDirection.LeftToRight;
            flowlpnlPicsContainer.AutoScroll = true;
            flowlpnlPicsContainer.WrapContents = true;
            #endregion

            #region Init events
            flowlpnlPicsContainer.MouseWheel += flowlpnlPicsContainer_MouseWheel;
            flowlpnlPicsContainer.Scroll += flowlpnlPicsContainer_Scroll;
            #endregion

            #region Init all pictureboxs, and hide them
            for (int i = 0; i < NUMBER_OF_MAX_PICS; i++)
            {
                PictureBox picBox = new PictureBox();
                picBox.Width = 100;     // 320 ratio
                picBox.Height = 75;     // 240 ratio
                picBox.Hide();
                picBox.ImageLocation = null;
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                picBox.Click += picBox_Click;
                listAllPictureBoxs.Add(picBox);
                flowlpnlPicsContainer.Controls.Add(picBox);
            }
            #endregion
        }

        #region Public Methods
        public void startLazyShowing(List<string> _listUrlPicsToShow)
        {
            #region Get inputs
            this.listUrlPicsToShow = _listUrlPicsToShow;
            #endregion

            #region Reload at first pics
            flowlpnlPicsContainer.VerticalScroll.Value = 0; // scroll to top

            // get the last index from previous section
            int lastPicbxIndexInPreviousShowing = lastPicbxIndexShowing;

            // nếu tổng số ảnh <= NUMBER_OF_FIRST_PICS : hiển thị tổng số ảnh đấy
            if (listUrlPicsToShow.Count <= NUMBER_OF_FIRST_PICS)
            {
                ShowPicsFromIndex0To(listUrlPicsToShow.Count - 1);
                #region Update class's fields
                loadedAllPics = true;
                #endregion
            }
            // nếu tổng số ảnh > NUMBER_OF_FIRST_PICS : hiển thị NUMBER_OF_FIRST_PICS ảnh
            else
            {
                ShowPicsFromIndex0To(NUMBER_OF_FIRST_PICS - 1);
                #region Update class's fields
                loadedAllPics = false;
                #endregion
            }

            // ẩn các picbox còn lại đến lastPicbxIndexInPreviousShowing (nếu được)
            flowlpnlPicsContainer.SuspendLayout();
            for (int i = lastPicbxIndexShowing + 1; i <= lastPicbxIndexInPreviousShowing; i++)
            {
                listAllPictureBoxs[i].Hide();
                listAllPictureBoxs[i].ImageLocation = null;
            }
            flowlpnlPicsContainer.ResumeLayout();
            #endregion
        }
        #endregion

        #region Private Methods
        private void ShowPicsFromIndex0To(int toIndex)
        {
            for (int i = 0; i <= toIndex; i++)
            {
                listAllPictureBoxs[i].ImageLocation = listUrlPicsToShow[i];
                listAllPictureBoxs[i].Show();

                #region notify listeners for num of pics shown changed.
                if (numberOfPicsShownChange != null)
                    numberOfPicsShownChange(this, i + 1, listUrlPicsToShow.Count, NUMBER_OF_MAX_PICS);
                #endregion
            }
            lastPicbxIndexShowing = toIndex;
        }
        private void ShowMorePics()
        {
            int i = lastPicbxIndexShowing + 1;
            int maxIndex = (listAllPictureBoxs.Count < listUrlPicsToShow.Count ? listAllPictureBoxs.Count : listUrlPicsToShow.Count) - 1;
            for (; i <= maxIndex && i < lastPicbxIndexShowing + NUMBER_OF_JUMP_PICS + 1; i++)
            {
                listAllPictureBoxs[i].ImageLocation = listUrlPicsToShow[i];
                listAllPictureBoxs[i].Show();

                #region notify listeners for num of pics shown changed.
                if (numberOfPicsShownChange != null)
                    numberOfPicsShownChange(this, i + 1, listUrlPicsToShow.Count, NUMBER_OF_MAX_PICS);
                #endregion
            }
            #region Update class's fields
            lastPicbxIndexShowing = i - 1; 
            #endregion
            if (lastPicbxIndexShowing == maxIndex)
            {
                #region Update class's fields
                loadedAllPics = true;
                #endregion
            }
        }
        private bool ScrollReachedBottom(FlowLayoutPanel flowLayoutPnl)
        {
            VScrollProperties vs = flowLayoutPnl.VerticalScroll;
            if (vs.Value == vs.Maximum - vs.LargeChange + 1)
                return true;

            return false;
        }
        #endregion

        #region Events
        void flowlpnlPicsContainer_Scroll(object sender, ScrollEventArgs e)
        {
            // If reached bottom & not yet loaded all pics, show more pics
            if (!loadedAllPics && ScrollReachedBottom(flowlpnlPicsContainer))
            {
                ShowMorePics();
            }
        }
        void flowlpnlPicsContainer_MouseWheel(object sender, MouseEventArgs e)
        {
            // If reached bottom & not yet loaded all pics, show more pics
            if (!loadedAllPics && ScrollReachedBottom(flowlpnlPicsContainer))
            {
                ShowMorePics();
            }
        }
        void picBox_Click(object sender, EventArgs e)
        {
            if (anyPickClicked != null)
                anyPickClicked(sender, e);
        }
        #endregion
    }
}
