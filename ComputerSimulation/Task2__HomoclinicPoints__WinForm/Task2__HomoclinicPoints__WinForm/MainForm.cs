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
using Task2__HomoclinicPoints__WinForm.CurveIteration;
using System.Diagnostics;

namespace Task2__HomoclinicPoints__WinForm
{
    public partial class MainForm : Form
    {
        private Geometry.Rectangle _drawArea;

        private Stopwatch _stopwatch;

        private Pen _testPen;
        private Pen _axesPen;
        private Pen _stableCurvePen;
        private Pen _unstableCurvePen;

        private Polyline _stableCurve;
        private Polyline _unstableCurve;


        internal MainForm(Geometry.Rectangle domain, Diffeomorphism f, int maxIterationCount)
        {
            InitializeComponent();

            _stopwatch = new Stopwatch();
            InitDrawVariables();

            _drawArea = domain;

            double accuracy = 0.1;
            CurveIterator curveIterator = new CurveIterator(f, maxIterationCount, accuracy);

            double eigenvectorLength = 0.00001;

            /*** SOLVING STABLE CURVE ***/
            Segment stableSegment = new Segment(f.MaxEigenvector * eigenvectorLength);
            _stableCurve = curveIterator.Solve(stableSegment, IterationDirection.Positive);

            /*** SOLVING UNSTABLE CURVE ***/
            Segment unstableSegment = new Segment(f.MinEigenvector * eigenvectorLength);
            _unstableCurve = curveIterator.Solve(unstableSegment, IterationDirection.Negative);


            Console.WriteLine(f.MinEigenvector.ToString());
            Console.WriteLine(f.MaxEigenvector);
        }


        private void InitDrawVariables()
        {
            var axesColor = Color.FromArgb(45, 64, 89);
            var axesPenWidth = 0.01f;
            _axesPen = new Pen(axesColor, axesPenWidth);

            var stableCurvePenColor = Color.Red;
            var stableCurvePenWidth = 0.01f;
            _stableCurvePen = new Pen(stableCurvePenColor, stableCurvePenWidth);

            var unstableCurvePenColor = Color.Blue;
            var unstableCurvePenWidth = 0.01f;
            _unstableCurvePen = new Pen(unstableCurvePenColor, unstableCurvePenWidth);

            var testPenColor = Color.Pink;
            var testPenWidth = 0.01f;
            _testPen = new Pen(testPenColor, testPenWidth);
        }


        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            NormalizeView(e.Graphics);

            // DrawGrid(e.Graphics);
            // DrawAxes(e.Graphics);

            DrawPolyline(e.Graphics, _stableCurve, _stableCurvePen);
            DrawPolyline(e.Graphics, _unstableCurve, _unstableCurvePen);

            if (_stableCurve.TryGetFirstIntersectionPoint(_unstableCurve, out Vector2 intersectionPoint))
            {
                Console.Write("WOOOOOOOOOOOOOOOOW");
                DrawCircle(e.Graphics, _axesPen, (float)intersectionPoint.x, (float)intersectionPoint.y, 0.1f);
            }
        }


        private void DrawPolyline(Graphics graphics, Polyline polyline, Pen pen)
        {
            graphics.DrawLines(pen, polyline.Vertexes.Select(vertex => (PointF)vertex).ToArray());
        }


        private void NormalizeView(Graphics graphics)
        {
            float alpha = Convert.ToSingle(Canvas.Width) / Convert.ToSingle(Canvas.Height);
            float alphaDomain = Convert.ToSingle(_drawArea.Width / _drawArea.Height);

            float targetWidth = Math.Max(alpha, alphaDomain) * (float)_drawArea.Height / 2f;

            float scale = Canvas.Width / 2f / targetWidth;

            graphics.TranslateTransform(Canvas.Width / 2f, Canvas.Height / 2f);
            graphics.ScaleTransform(scale, -scale);

            graphics.TranslateTransform((float)-_drawArea.Center.x, (float)-_drawArea.Center.y);
        }


        private void DrawAxes(Graphics graphics)
        {
            graphics.DrawEllipse(_axesPen, 1 - 2 * 0.01f, 0 - 2 * 0.01f, 2 * 2 * 0.01f, 2 * 2 * 0.01f);

            /*            float minValue = (float)Math.Min(_domain.Low.x, _domain.Low.y);
                        float maxValue = (float)Math.Max(_domain.High.x, _domain.High.y);*/

            float minValue = -5;
            float maxValue = 5;

            graphics.DrawLine(_axesPen, minValue, 0, maxValue, 0);
            graphics.DrawLine(_axesPen, 0, minValue, 0, maxValue);
        }


        private void DrawCircle(Graphics graphics, Pen pen, float centerX, float centerY, float radius)
        {
            graphics.DrawEllipse(pen, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
        }


        private void ScaleBar_ValueChanged(object sender, EventArgs e)
        {
/*            float scale = (float)ScaleBar.Value / (ScaleBar.Maximum - ScaleBar.Minimum);

            if (_polyline != null)
                Draw(scale, _minRightEdgeValue, _maxRightEdgeValue);*/


        }
    }
}
