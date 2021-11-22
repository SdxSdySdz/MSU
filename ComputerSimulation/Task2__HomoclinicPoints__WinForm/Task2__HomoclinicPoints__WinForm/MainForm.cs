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
using System.Globalization;

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
            
            TryCalculate();
        }

        private void TryCalculate()
        {
            if (TryParseAllInputs(out double alpha, out double eigenvectorLength, out int maxIterationCount, out double minSideLength))
            {
                Calculate(alpha, eigenvectorLength, maxIterationCount, minSideLength);
            }
            else
            {
                MessageBox.Show("Incorrect input");
            }
        }

        private void Calculate(double alpha, double eigenvectorLength, int maxIterationCount, double minSideLength)
        {
            Diffeomorphism f = new HomeTaskMapping(alpha);

            CurveIterator curveIterator = new CurveIterator(f, maxIterationCount, minSideLength);

            Console.WriteLine(f.MaxEigenvector);
            Console.WriteLine(f.MinEigenvector);

            /*** SOLVING STABLE CURVE ***/
            Segment stableSegment = new Segment(f.MaxEigenvector * eigenvectorLength);
            _stableCurve = curveIterator.Solve(stableSegment, IterationDirection.Positive);

            /*** SOLVING UNSTABLE CURVE ***/
            Segment unstableSegment = new Segment(f.MinEigenvector * eigenvectorLength);
            _unstableCurve = curveIterator.Solve(unstableSegment, IterationDirection.Negative);
        }

        private bool TryParseDoubleInput(TextBox input, out double result)
        {
            string value = input.Text;

            if (!double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                !double.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                !double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = double.NaN;
                return false;
            }

            return true;
        }

        private bool TryParsePositiveIntInput(TextBox input, out int result)
        {
            return int.TryParse(input.Text, out result) && result > 0;
        }

        private void OnCorrectUserInput(TextBox input)
        {
            input.ForeColor = Color.Black;
        }

        private void OnIncorrectUserInput(TextBox input)
        {
            input.ForeColor = Color.Red;
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
            if (TryParseAllInputs(out double alpha, out double eigenvectorLength, out int maxIterationCount, out double minSideLength) == false) return;

            e.Graphics.Clear(_backgroundColor);
            NormalizeView(e.Graphics);

            // DrawGrid(e.Graphics);
            DrawAxes(e.Graphics);

            DrawPolyline(e.Graphics, _stableCurve, _stableCurvePen);
            DrawPolyline(e.Graphics, _unstableCurve, _unstableCurvePen);

            if (_stableCurve.TryGetFirstIntersectionPoint(_unstableCurve, out Vector2 intersectionPoint, out double angle))
            {
                Console.WriteLine($"[Intersection point] {intersectionPoint} [Angle] {angle}");
                FillCircle(e.Graphics, _intersectionPointBrush, (float)intersectionPoint.x, (float)intersectionPoint.y, 0.02f);
                // DrawCircle(e.Graphics, _axesPen, (float)intersectionPoint.x, (float)intersectionPoint.y, 0.1f);
            }

            // FillCircle(e.Graphics, _intersectionPointBrush, (float)1.1050348915755, (float)-0.353424112723881, 0.02f);
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

        private bool TryParseAllInputs(out double alpha, out double eigenvectorLength, out int maxIterationCount, out double minSideLength)
        {
            bool[] conditions = new[]
            {
                TryParseDoubleInput(AlphaInput, out alpha),
                TryParseDoubleInput(EigenVectorLengthInput, out eigenvectorLength),
                TryParsePositiveIntInput(IterationCountInput, out maxIterationCount),
                TryParseDoubleInput(MinSideLengthInput, out minSideLength)
            };

            foreach (var condition in conditions)
            {
                if (condition == false)
                    return false;
            }

            return true;
        }

        private void ProcessDoubleInput(TextBox input)
        {
            if (TryParseDoubleInput(input, out double value))
            {
                OnCorrectUserInput(input);
            }
            else
            {
                OnIncorrectUserInput(input);
            }
        }

        private void ProcessIntInput(TextBox input)
        {
            if (TryParsePositiveIntInput(input, out var _))
            {
                OnCorrectUserInput(input);
            }
            else
            {
                OnIncorrectUserInput(input);
            }
        }

        private void AlphaInput_TextChanged(object sender, EventArgs e)
        {
            ProcessDoubleInput(AlphaInput);
        }

        private void IterationCountInput_TextChanged(object sender, EventArgs e)
        {
            ProcessIntInput(EigenVectorLengthInput);
        }

        private void MinSideLengthInput_TextChanged(object sender, EventArgs e)
        {
            ProcessDoubleInput(MinSideLengthInput);
        }

        private void CalculationButton_Click(object sender, EventArgs e)
        {
            TryCalculate();
            Canvas.Invalidate();
        }

        private void EigenVectorLengthInput_TextChanged(object sender, EventArgs e)
        {
            ProcessDoubleInput(EigenVectorLengthInput);
        }
    }
}
