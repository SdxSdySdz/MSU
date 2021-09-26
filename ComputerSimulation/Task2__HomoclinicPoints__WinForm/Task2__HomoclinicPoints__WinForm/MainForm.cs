using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private Pen _pen;
        private Pen _axesPen;
        private Polyline _polyline;
        private float _startScaleBarPercent;
        private float _startRightEdgeValue;
        private float _minRightEdgeValue;
        private float _maxRightEdgeValue;

        private Point LeftPosition => new Point(0, Canvas.Height / 2);
        private Point RightPosition => new Point(Canvas.Width, Canvas.Height / 2);
        private Point TopPosition => new Point(Canvas.Width / 2, 0);
        private Point BottomPosition => new Point(Canvas.Width / 2, Canvas.Height);

        public MainForm()
        {
            InitializeComponent();

            _pen = new Pen(Color.Red);
            _axesPen = new Pen(Color.Black);

            _pen.Width = float.MinValue;
            _axesPen.Width = 0.015f;

            _graphics = Canvas.CreateGraphics();


            _minRightEdgeValue = 1;
            _maxRightEdgeValue = 10;
            _startRightEdgeValue = 2.5f;

            _startScaleBarPercent = _startRightEdgeValue / (_maxRightEdgeValue - _minRightEdgeValue);
            ScaleBar.Value = (int)(ScaleBar.Minimum + _startScaleBarPercent * (ScaleBar.Maximum - ScaleBar.Minimum));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void DrawPolyline()
        {
            _graphics.DrawLines(_pen, _polyline.Vertexes.Select(vertex => (PointF)vertex).ToArray());
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            _graphics.ScaleTransform(1, -1);


            double aplha = 0.4;
            Diffeomorphism f = new HomeTaskMapping(aplha);

            int maxIterationCount = 10;
            double accuracy = 0.1;
            CurveIterator curveIterator = new CurveIterator(f, maxIterationCount, accuracy);

            Vector2 start = new Vector2(0, 0);
            Vector2 end = new Vector2(1, 0.47f);
            Segment segment = new Segment(start, end);

            _polyline = curveIterator.Solve(segment);

            Draw(_startScaleBarPercent, _minRightEdgeValue, _maxRightEdgeValue);  
        }

        private void DrawAxes()
        {
            _graphics.DrawLine(_axesPen, LeftPosition, RightPosition);
            _graphics.DrawLine(_axesPen, BottomPosition, TopPosition);
        }


        private void Draw(float scalePercent, float minScale, float maxScale)
        {
            _graphics.ResetTransform();
            Vector2 canvasSize = new Vector2(Canvas.Size.Width, Canvas.Size.Height);
            Vector2 offset = canvasSize / 2.0;
            

            _graphics.Clear(Color.White);
            DrawAxes();
            _graphics.TranslateTransform((float)offset.x, (float)offset.y);

            float scale = minScale + scalePercent * (maxScale - minScale);
            _graphics.ScaleTransform(Canvas.Size.Width / 2f / scale, Canvas.Size.Width / 2f / scale);

            
            DrawPolyline();

            float radius = 0.25f;
            _graphics.DrawEllipse(_pen, -1 - radius, 0 + radius, 2 * radius, -2 * radius);
            _graphics.DrawEllipse(_pen, 1 - radius, 0 + radius, 2 * radius, -2 * radius);
            _graphics.DrawEllipse(_pen, 5 - radius, 0 + radius, 2 * radius, -2 * radius);

        }

        private void ScaleBar_ValueChanged(object sender, EventArgs e)
        {
            float scale = (float)ScaleBar.Value / (ScaleBar.Maximum - ScaleBar.Minimum);

            if (_polyline != null)
                Draw(scale, _minRightEdgeValue, _maxRightEdgeValue);
        }
    }
}
