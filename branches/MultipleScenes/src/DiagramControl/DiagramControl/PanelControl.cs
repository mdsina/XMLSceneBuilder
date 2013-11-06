using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Arrows;

namespace DiagramControl
{
    public partial class PanelControl : Panel
    {
        bool canMove = false;
        Point p;
        Form1 _parentForm;
        public int positionX;
        public int positionY;
        public List<ArrowRenderer> ArrowList;
        ArrowRenderer arrow;

        public PanelControl(Form1 parentForm)
        {
            _parentForm = parentForm;
            InitializeComponent();
            arrow = new ArrowRenderer(10, 0.20f, true);
            ArrowList = new List<ArrowRenderer>();
        }

        public PanelControl()
        {
            InitializeComponent();
            ArrowList = new List<ArrowRenderer>();
        }

        private void PanelControl_MouseUp(object sender, MouseEventArgs e)
        {
            canMove = false;
//             Panel panel = (Panel)sender;
//             
//             positionX = panel.Left;
//             positionY = panel.Top;
        }

        private void PanelControl_MouseDown(object sender, MouseEventArgs e)
        {
            canMove = true;
            p = e.Location;
            Panel panel = (Panel)sender;
            panel.BringToFront();

            _parentForm.selection = this;

        }

        private void PanelControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (canMove)
            {
                Panel panel = (Panel)sender;

                if (panel.Bottom > _parentForm.ClientRectangle.Height)
                {
                    panel.Top = _parentForm.ClientRectangle.Height - panel.Height - 1;
                    canMove = false;
                }
                else if (panel.Top < 0)
                {
                    panel.Top = 1;
                    canMove = false;
                }
                else if (panel.Left < 0)
                {
                    panel.Left = 1;
                    canMove = false;
                }
                else if (panel.Right > _parentForm.ClientRectangle.Width)
                {
                    panel.Left = _parentForm.ClientRectangle.Width - panel.Width - 1;
                    canMove = false;
                }
                else
                {
                    panel.Top += e.Y - p.Y;
                    panel.Left += e.X - p.X;
                    
                }
            }

        }

        private void PanelControl_Click(object sender, EventArgs e)
        {
            ArrowRenderer arrow = new ArrowRenderer();
            if (_parentForm.IsArrowEditMode)
            {
                ArrowList.Add(arrow);
                _parentForm.SelectingFirstObject(this);
            }
        }

        public void DrawArrow(Brush brush, Graphics g, PointF pStart)
        {
            Vector v;
            Point mousePoint = _parentForm.mousePoint;
            PointF pEnd = mousePoint;

            v = new Vector(pEnd.X - pStart.X, pEnd.Y - pStart.Y);
            arrow.DrawArrow(g, Pens.Black, brush, pStart, pEnd);
        }

        private void PanelControl_Paint(object sender, PaintEventArgs e)
        {
//             if (_parentForm.IsArrowEditMode)
//             {
//                 PointF pStart = new Point(positionX, positionY);
// 
//                 DrawArrow(Brushes.Black, e.Graphics, pStart);
//             }
        }
        
    }
}
