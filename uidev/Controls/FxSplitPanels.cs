﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Windows.Forms;

namespace uidev.Controls
{
    public partial class FxSplitPanels : FxBaseControl
    {
        private Pen borderPen = Class.uiCustoms.BorderPen;

        private bool MouseIsDown = false;

        public FxPanel fxPanel1 = new FxPanel();
        public FxPanel fxPanel2 = new FxPanel();

        private int _holdSpace = 4;
        public int HoldSpace
        {
            get
            {
                return _holdSpace;
            }
            set
            {
                _holdSpace = value;
                InitPanels();
                Refresh();
            }
        }

        private int _splitPoint;
        public int SplitPoint
        {
            get
            {
                return _splitPoint;
            }
            set
            {
                _splitPoint = value;
                InitPanels();
                Refresh();
            }
        }

        private Cursor _splitCursor = Cursors.SizeWE;
        public Cursor SplitCursor
        {
            get
            {
                return _splitCursor;
            }
            set
            {
                _splitCursor = value;
            }
        }

        private void InitPanels()
        {
            fxPanel1.Size = new Size(SplitPoint - HoldSpace, Height);
            fxPanel2.Size = new Size(SplitPoint - HoldSpace, Height);

            //fxPanel1.Location = new Point(0, 0);
            fxPanel2.Location = new Point(SplitPoint + HoldSpace / 2, 0);

            fxPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            fxPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            Refresh();
        }

        public FxSplitPanels()
        {
            InitializeComponent();

            _splitPoint = Width / 2;

            fxPanel1.Visible = false;
            fxPanel2.Visible = false;

            InitPanels();

            this.Controls.Add(fxPanel1);
            this.Controls.Add(fxPanel2);
        }

        private void FxSplitPanels_Paint(object sender, PaintEventArgs e)
        {


            e.Graphics.DrawLine(
                borderPen,
                new PointF((float)SplitPoint - (float)HoldSpace / 2F, 0),
                new PointF((float)SplitPoint - (float)HoldSpace / 2F, Height)
                );

            e.Graphics.DrawLine(
                borderPen,
                new PointF((float)SplitPoint + (float)HoldSpace / 2F, 0),
                new PointF((float)SplitPoint + (float)HoldSpace / 2F, Height)
                );

            if (Border)
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void FxSplitPanels_EnabledChanged(object sender, EventArgs e)
        {
            Color _borderColor = Class.uiCustoms.BorderPen.Color;

            if (!Enabled)
            {
                borderPen = new Pen(Class.Tools.rgb2gray(_borderColor));
            }
            else
            {
                borderPen = new Pen(_borderColor);
            }
            Refresh();
        }

        private void FxSplitPanels_Resize(object sender, EventArgs e)
        {
            InitPanels();
        }

        private bool GetMouseInSplit(int mouseX)
        {
            int halfs = (int)Math.Round((double)HoldSpace / 2.0);
            return (SplitPoint - halfs <= mouseX && mouseX <= SplitPoint + halfs);
        }

        private void FxSplitPanels_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseIsDown)
            {
                Cursor = SplitCursor;
                SplitPoint = e.Location.X;
                InitPanels();
            }
            else if (GetMouseInSplit(e.Location.X))
            {
                Cursor = SplitCursor;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void FxSplitPanels_MouseDown(object sender, MouseEventArgs e)
        {
            if (GetMouseInSplit(e.Location.X)) MouseIsDown = true;
        }

        private void FxSplitPanels_MouseUp(object sender, MouseEventArgs e)
        {
            MouseIsDown = false;
        }
    }
}