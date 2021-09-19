using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task2__HomoclinicPoints__WinForm.Diffeomorphisms;
using Task2__HomoclinicPoints__WinForm.Geometry;
using Task2__HomoclinicPoints__WinForm.LinearAlgebra;

namespace Task2__HomoclinicPoints__WinForm
{
    public partial class MainForm : Form
    {
        private Graphics _graphics;
        private Polyline _polyline;
        private Pen _pen;
        private Pen _axesPen;

        private Point LeftPosition => new Point(0, Canvas.Height / 2);
        private Point RightPosition => new Point(Canvas.Width, Canvas.Height / 2);
        private Point TopPosition => new Point(Canvas.Width / 2, 0);
        private Point BottomPosition => new Point(Canvas.Width / 2, Canvas.Height);

        public MainForm()
        {
            InitializeComponent();

            Canvas.MouseWheel += new MouseEventHandler(Canvas_MouseWheel);
            _graphics = Canvas.CreateGraphics();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void DrawPolyline(Polyline polyline)
        {
            _graphics.DrawLines(_pen, polyline.Vertexes.Select(vertex => (PointF)vertex).ToArray());
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            

            _graphics.Clear(Color.White);

            _pen = new Pen(Color.Red);
            _axesPen = new Pen(Color.Black);

            _pen.Width = float.MinValue;
            _axesPen.Width = 0.015f;

            DrawAxes();


            Vector2 canvasSize = new Vector2(Canvas.Size.Width, Canvas.Size.Height);
            Vector2 offset = canvasSize / 2.0;
            _graphics.TranslateTransform((float)offset.x, (float)offset.y);
            _graphics.ScaleTransform(1000, -1000);

            double aplha = 0.4;
            Diffeomorphism f = new HomeTaskMapping(aplha);

            int maxIterationCount = 30;
            double accuracy = 0.01;
            CurveIterator curveIterator = new CurveIterator(f, maxIterationCount, accuracy);

            Vector2 start = new Vector2(0, 0);
            Vector2 end = new Vector2(1, .45);
            Segment segment = new Segment(start, end);

            Polyline polyline = curveIterator.Solve(segment);

            // polyline = new Polyline(new Vector2[] { new Vector2(0, 0), new Vector2(100, 100) });

            DrawPolyline(polyline);
            
        }

        private void DrawAxes()
        {
            _graphics.DrawLine(_axesPen, LeftPosition, RightPosition);
            _graphics.DrawLine(_axesPen, BottomPosition, TopPosition);
        }


        private void Canvas_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _graphics.TranslateTransform(100, 100);
            
        }
    }
}
