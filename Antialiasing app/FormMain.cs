using Antialiasing_app.Curves;
using Antialiasing_app.Graphic_classes;
using Antialiasing_app.Tools;
using CustomAntialiasing.Drawing2DMath;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Antialiasing_app
{
    public partial class FormMain : Form
    {
        private List<Images> img;
        private int clicker_counter;
        private bool clicked;
        private Stopwatch stopwatch;
        private List<Point2D> pointBuffer;
        private int speed;
        private BezierCurve bezierCurve;
        private Point mousept;

        public int Speed { get { return speed; } set { speed = value; } }         

        public FormMain()
        {
            InitializeComponent();

            speed = (int)uControlAntialiasParams.numericUpDownDegPerSec.Value;

            clicked = false;
            clicker_counter = 0;

            img = new List<Images>();

            pointBuffer = new List<Point2D>();

            Random rand = new Random(); 

            // vygenerovat body
            for (int i = 0; i < 100; i++)
            {
                pointBuffer.Add(new Point2D(
                    new PointF(rand.Next((int)Math2DCalculations.xMin, (int)Math2DCalculations.xMax), rand.Next((int)Math2DCalculations.yMin, (int)Math2DCalculations.yMax))));
            }

            timerMain.Interval = 10;
            timerMain.Start();

            stopwatch = new Stopwatch();
            stopwatch.Start();

            // vytvorenie novej bezierovej krivky
            bezierCurve = new BezierCurve(
                Matrix.GetVectorPointXY(-80, -80),
                Matrix.GetVectorPointXY(160, -80));

            bezierCurve.AddControlVertex(Matrix.GetVectorPointXY(80, -80));
            bezierCurve.AddControlVertex(Matrix.GetVectorPointXY(0, 0));
            bezierCurve.AddControlVertex(Matrix.GetVectorPointXY(-80, 80));
            bezierCurve.AddControlVertex(Matrix.GetVectorPointXY(-80, 160));
            bezierCurve.AddControlVertex(Matrix.GetVectorPointXY(160, 160));

        }

        /// <summary>
        /// Timer ticks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerMain_Tick(object sender, EventArgs e)
        {
            panelCenter.Invalidate();
        }

        /// <summary>
        /// Udalost prekreslenia panela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelCenter_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // zmena polohy bodov
            long s = stopwatch.ElapsedMilliseconds;
            if (s <= 0)
                return;

            // vykreslenie vsetkych bodov
            foreach (var point in pointBuffer)
            {
                point.Rotate(s, Speed);
                point.Antialiased = uControlAntialiasParams.checkBoxAntialias.Checked; 
                point.Color = uControlAntialiasParams.panelPixelColor.BackColor; 
                point.Draw(g);
            }

            // vykreslenie bezierovej krivky
            bezierCurve.Draw(g, new Pen(uControlAntialiasParams.panelPixelColor.BackColor));

            if (uControlAntialiasParams.plane_sended > 0) {
                if (img.Count < uControlAntialiasParams.plane_sended)
                {
                    img.Add(new Images(bezierCurve.getBezierPoints()));
                }

                List<Images> help = new List<Images>();

                foreach (var i in img)
                {
                    if (i.Draw(g)){
                        help.Add(i);
                    }
                }

                foreach (var i in help)
                {
                    img.Remove(i);
                    uControlAntialiasParams.plane_sended--;
                }
            }


            // vykreslenie selection boxu
            if (SelectionBox.IsActive)
            {
                SelectionBox.Draw(g);
            }
        }

        /// <summary>
        /// Mouse down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void panelCenter_MouseDown(object sender, MouseEventArgs e)
		{

            clicked = true;

            if (uControlAntialiasParams.only_one)
            {
                bezierCurve.clearSelection();
                bezierCurve.SelectPoint(e.Location);
                panelCenter.Invalidate();
            }
            else
            {
                if (clicker_counter == 1)
                {
                    mousept = e.Location;
                }
                else
                {
                    SelectionBox.InitSelectionBox(e.Location);
                }
            }

            timerMain.Stop();
            stopwatch.Stop();
        }

        /// <summary>
        /// Mouse up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void panelCenter_MouseUp(object sender, MouseEventArgs e)
		{
            clicked = false;

            SelectionBox.DisableSelectionBox();

            timerMain.Start();
            stopwatch.Start();

            if (uControlAntialiasParams.only_one || clicker_counter == 1)
            {
                bezierCurve.clearSelection();
                clicker_counter = 0;
            }
            else {
                Point strt = SelectionBox.StartPoint();
                Point end = e.Location;
                if (!bezierCurve.SelectArea(strt, end))
                    clicker_counter = 0;
                else
                    clicker_counter++;
            }

            panelCenter.Invalidate();
        }

        /// <summary>
        /// Mouse move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void panelCenter_MouseMove(object sender, MouseEventArgs e)
		{
            if (uControlAntialiasParams.only_one)
            {
                List<Matrix> start = bezierCurve.GetBezierPointSelected();
                
                if (clicked && start.Count > 0)
                {
                    Point ptnow = e.Location;
                    bezierCurve.ChangeVertex(start[0], Matrix.GetVectorPointXY(ptnow.X - (592 / 2), (450 / 2) - ptnow.Y));
                    panelCenter.Invalidate();
                }
            }
            else
            {
                if (SelectionBox.IsActive && clicker_counter == 0)
                {
                    using (Region r = SelectionBox.Track(e.Location))
                    {
                        panelCenter.Invalidate(r);
                    }
                }
                else {
                    if (clicked && clicker_counter == 1)
                    {
                        Point start = mousept;
                        Point ptnow = e.Location;

                        int diffX = ptnow.X - start.X;
                        int diffY = start.Y - ptnow.Y;

                        bezierCurve.MoveVertex(diffX, diffY);
                        panelCenter.Invalidate();

                        mousept = ptnow;
                    }
                }
            }
        }
	}
}
