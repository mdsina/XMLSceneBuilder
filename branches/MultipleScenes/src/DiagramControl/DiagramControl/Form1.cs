using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Arrows;


namespace DiagramControl
{
    public partial class Form1 : Form
    {
        enum ArrowEditState
        {
            SelectingFirstObject,
            SelectingSecondObject
        };
        PanelControl _p;
        
        public bool IsArrowEditMode;
        ArrowEditState arrowEditState;
        Point pointFirstPanel;

        public List<PanelControl> PanelsList;
        public PanelControl selection;

        public Form1()
        {
            InitializeComponent();
            IsArrowEditMode = false;
            
            ResizeRedraw = true;
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            PanelsList = new List<PanelControl>();
        }

        private void CreateNewPanel()
        {
            _p = new DiagramControl.PanelControl(this);
            this.SuspendLayout();
            
            _p.Size = new System.Drawing.Size(200, 100);
            _p.BorderStyle = BorderStyle.FixedSingle;
            _p.Location = new Point(100, 100);
            _p.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ResumeLayout(false);

            this.Controls.Add(_p);

            PanelsList.Add(_p);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewPanel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
            IsArrowEditMode = true;
            arrowEditState = ArrowEditState.SelectingFirstObject;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            IsArrowEditMode = false;
        }

        public Point mousePoint;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mousePoint = e.Location;
            Text = e.X.ToString() + " | " + e.Y.ToString();

            if ((IsArrowEditMode) && (arrowEditState == ArrowEditState.SelectingSecondObject))
            {
                Invalidate();
            }
            
        }

        public void SelectingFirstObject(PanelControl panel)
        {
           if (arrowEditState == ArrowEditState.SelectingFirstObject)
           {
               pointFirstPanel = panel.Location;
               arrowEditState = ArrowEditState.SelectingSecondObject;
           }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.Clear(SystemColors.Control);

          //  Brush[] ab = new Brush[] { Brushes.Black, Brushes.Blue, Brushes.Red, Brushes.Green, Brushes.Yellow, Brushes.Violet, Brushes.Pink };
           
            //PointF pStart = new Point(i * ClientRectangle.Width / numArrows, 0);
            if (IsArrowEditMode)
            {
               // PointF pStart = new Point(_p.positionX, _p.positionY);
                PointF pStart = new Point(selection.Left, selection.Top);
               _p.DrawArrow(Brushes.Black, e.Graphics, pStart);
            }

        }

     

    }
}
