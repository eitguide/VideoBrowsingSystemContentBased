using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using VideoBrowsingSystemContentBased.Model;

namespace VideoBrowsingSystemContentBased.Widget
{
    public partial class PaperDottingUC : UserControl
    {
        public event EventHandler ContentChanged;
        public event EventHandler SelectedNodeChanged;
        public const int NODE_RADIUS = 12;
        public const int NODE_DIAMETER = NODE_RADIUS * 2;

        int SelectIndex;
        public Color colorNode;
        Point _p;

        public Variables.DrawingTools Tool;

        public PaperDottingUC()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Control.CheckForIllegalCrossThreadCalls = false;
            panel.Enabled = false;
            colorNode = Color.Green;
            Reset();
        }

        public void Reset()
        {
            this.Controls.Clear();
            Invalidate();
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Tool == Variables.DrawingTools.Node)
                {
                    AddNewNode(e.Location, colorNode);
                }
            }
            OnContentChanged(null, null);
            base.OnMouseDown(e);
        }

        private void AddNewNode(Point location, Color color)
        {
            NodeUC n = new NodeUC();
            n.Index = this.Controls.Count;
            n.DisplayName = (n.Index + 1).ToString();
            n.Location = location;
            n.BackColor = color;
            this.Controls.Add(n);
            n.DoCreatingAnimation();
            n.Width = NODE_DIAMETER;
            n.Height = NODE_DIAMETER;

            Console.WriteLine("Add note, Index: " + n.Index);
            Console.WriteLine("Note postion: " + n.Location.ToString() + " W/H: " + this.Width + " " + this.Height);
            n.MouseDown += new MouseEventHandler(Node_MouseDown);
            n.MouseMove += new MouseEventHandler(Node_MouseMove);
            n.MouseUp += new MouseEventHandler(Node_MouseUp);
        }


        protected virtual void OnContentChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null)
                ContentChanged(sender, null);
        }
        protected virtual void OnSeletedNodeChanged(object sender, EventArgs e)
        {
            if (SelectedNodeChanged != null)
                SelectedNodeChanged(sender, null);
        }

        #region Node Events

        void Node_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {

                foreach (Control ctr in this.Controls)
                {
                    NodeUC node = ctr as NodeUC;
                    node.Selected = false;
                    node.Invalidate();

                }

                NodeUC ctl = (NodeUC)sender;
                ctl.Selected = true;
                ctl.Invalidate();

                OnSeletedNodeChanged(sender, null);

                if (this.Tool == Variables.DrawingTools.Select || this.Tool == Variables.DrawingTools.Node)
                    _p = e.Location;
                else if (this.Tool == Variables.DrawingTools.Eraser)
                {

                    ctl.DoRemovingAnimation();
                    this.Controls.Remove(ctl);
                    Invalidate();
                    OnContentChanged(null, null);
                }
            }
        }

        void Node_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctl = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {

                Point p = this.PointToClient(ctl.PointToScreen(e.Location));
                if (this.Tool == Variables.DrawingTools.Select || this.Tool == Variables.DrawingTools.Node)
                {
                    if (p.X > 0 && p.Y > 0 && p.X < this.Width && p.Y < this.Height)
                    {
                        p.X -= _p.X;
                        p.Y -= _p.Y;

                        ctl.Location = p;
                        Invalidate();
                    }
                }

                else if (this.Tool == Variables.DrawingTools.Edge)
                {
                    Point p2 = this.PointToClient(ctl.PointToScreen(e.Location));
                    using (Graphics g = this.CreateGraphics())
                    {
                        g.DrawLine(Pens.Red, _p, p2);
                        Invalidate();
                    }
                }
            }
        }

        private void Node_MouseUp(object sender, MouseEventArgs e)
        {

            NodeUC ctl = (NodeUC)sender;
            if (e.Button == MouseButtons.Left)
            {
                Invalidate();
                OnContentChanged(null, null);
            }
        }

        #endregion


        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawRectangle(Pens.Black, 0, 0, this.Width - 1, this.Height - 1);
            base.OnPaint(e);
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            Refresh();
            base.OnSizeChanged(e);
        }


        public void GetAllInfos()
        {
            Refresh();
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"INPUT\\info.txt"))
            {
                foreach (Control ctr in this.Controls)
                {
                    NodeUC node = ctr as NodeUC;



                    int x = node.Location.X + this.Left;
                    if (x < 0) x = 0;
                    if (x > this.Width) x = this.Width;

                    int y = node.Location.Y + this.Top;
                    if (y < 0) y = 0;
                    if (y > this.Height) y = this.Height;

                    double LocationX = (double)x / this.Width;
                    double LocationY = (double)y / this.Height;


                    file.WriteLine(String.Format("{0} {1} {2} {3} {4}", LocationX, LocationY, node.BackColor.R, node.BackColor.G, node.BackColor.B));

                    /*
                    int x = node.Location.X;
                    if (x < 0) x = 0;
                    if (x > this.Width) x = this.Width;

                    int y = node.Location.Y;
                    if (y < 0) y = 0;
                    if (y > this.Height) y = this.Height;
                    
                   

                   
                     */
                }
            }

        }
        private void PaperDottingUC_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
