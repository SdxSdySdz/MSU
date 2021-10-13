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

        private Color _backgroundColor;
        private Pen _testPen;
        private Pen _axesPen;
        private Pen _stableCurvePen;
        private Pen _unstableCurvePen;
        private Brush _intersectionPointBrush;

        private double _eigenvectorLength;
        private Polyline _stableCurve;
        private Polyline _unstableCurve;


        internal MainForm(
            Geometry.Rectangle domain, 
            Diffeomorphism f, 
            int maxIterationCount,
            double minSideLength,
            double eigenvectorLength
            )
        {
            InitializeComponent();

            _stopwatch = new Stopwatch();
            InitDrawVariables();
            _drawArea = domain;
            _eigenvectorLength = eigenvectorLength;


            CurveIterator curveIterator = new CurveIterator(f, maxIterationCount, minSideLength);

            Console.WriteLine(f.MaxEigenvector);
            Console.WriteLine(f.MinEigenvector);

            /*** SOLVING STABLE CURVE ***/
            Segment stableSegment = new Segment(f.MaxEigenvector * _eigenvectorLength);
            _stableCurve = curveIterator.Solve(stableSegment, IterationDirection.Positive);

            /*** SOLVING UNSTABLE CURVE ***/
            Segment unstableSegment = new Segment(f.MinEigenvector * _eigenvectorLength);
            _unstableCurve = curveIterator.Solve(unstableSegment, IterationDirection.Negative);
        }


        private void InitDrawVariables()
        {
            _backgroundColor = Color.FromArgb(50, 50, 50);

            var axesColor = Color.FromArgb(25, 240, 245, 249);
            var axesPenWidth = 0.01f;
            _axesPen = new Pen(axesColor, axesPenWidth);

            var stableCurvePenColor = Color.FromArgb(234, 221, 41);
            var stableCurvePenWidth = 0.01f;
            _stableCurvePen = new Pen(stableCurvePenColor, stableCurvePenWidth);

            var unstableCurvePenColor = Color.FromArgb(84, 141, 212);
            var unstableCurvePenWidth = 0.01f;
            _unstableCurvePen = new Pen(unstableCurvePenColor, unstableCurvePenWidth);

            var testPenColor = Color.Pink;
            var testPenWidth = 0.01f;
            _testPen = new Pen(testPenColor, testPenWidth);

            var intersectionPointColor = Color.Red; // Color.FromArgb(247, 251, 252);
            _intersectionPointBrush = new SolidBrush(intersectionPointColor);
        }


        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(_backgroundColor);
            NormalizeView(e.Graphics);

            // DrawGrid(e.Graphics);
            DrawAxes(e.Graphics);

            DrawPolyline(e.Graphics, _stableCurve, _stableCurvePen);
            DrawPolyline(e.Graphics, _unstableCurve, _unstableCurvePen);

            /*if (_stableCurve.TryGetFirstIntersectionPoint(_unstableCurve, out Vector2 intersectionPoint, out double angle))
            {
                Console.WriteLine($"[Eigenvector length] {_eigenvectorLength} [Intersection point] {intersectionPoint} [Angle] {angle}");
                FillCircle(e.Graphics, _intersectionPointBrush, (float)intersectionPoint.x, (float)intersectionPoint.y, 0.02f);
                // DrawCircle(e.Graphics, _axesPen, (float)intersectionPoint.x, (float)intersectionPoint.y, 0.1f);
            }*/

            FillCircle(e.Graphics, _intersectionPointBrush, (float)1.1050348915755, (float)-0.353424112723881, 0.02f);
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
            float minValue = -5;
            float maxValue = 5;

            graphics.DrawLine(_axesPen, minValue, 0, maxValue, 0);
            graphics.DrawLine(_axesPen, 0, minValue, 0, maxValue);
        }


        private void DrawCircle(Graphics graphics, Pen pen, float centerX, float centerY, float radius)
        {
            graphics.DrawEllipse(pen, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
        }


        private void FillCircle(Graphics graphics, Brush brush, float centerX, float centerY, float radius)
        {
            graphics.FillEllipse(brush, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
        }


        private void ScaleBar_ValueChanged(object sender, EventArgs e)
        {
/*            float scale = (float)ScaleBar.Value / (ScaleBar.Maximum - ScaleBar.Minimum);

            if (_polyline != null)
                Draw(scale, _minRightEdgeValue, _maxRightEdgeValue);*/


        }
    }
}
