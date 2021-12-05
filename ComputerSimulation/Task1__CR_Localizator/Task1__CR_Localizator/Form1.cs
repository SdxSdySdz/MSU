using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using OsipLIB.Geometry;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.Graphs;
using OsipLIB.LinearAlgebra;
using OsipLIB.Mappings;

namespace Task1__CR_Localizator
{
    public partial class MainForm : Form
    {
        private SymbolicImageGraph _graph;
        private Domain _domain;

        private Stopwatch _stopwatch;

        private OsipLIB.Geometry.Rectangle _drawArea;
        private Color _backgroundColor;

        private Pen _testPen;
        private Pen _axesPen;
        private Pen _edgePen;
        private Pen _cellPen;
        private Pen _gridPen;

        private Brush _edgeBrush;
        private Brush _cellBrush;

        private Dictionary<TextBox, bool> _inputValidities;

        internal MainForm(OsipLIB.Geometry.Rectangle drawArea, int iterationMaxCount, Mapping f, Domain domain)
        {
            InitializeComponent();
            InitDrawVariables();

            _inputValidities = new Dictionary<TextBox, bool>
            {
                { ReInput, false },
                { ImInput, false },
            };

            _stopwatch = new Stopwatch();
            _drawArea = drawArea;

            _domain = domain;

            TryCalculate();
        }

        private void ConstructGraph(Mapping f, Domain domain)
        {
            _stopwatch.Start();
            _graph = new SymbolicImageGraph(f, domain);
            _stopwatch.Stop();
            Console.WriteLine($"[Time] Constructing graph {_stopwatch.ElapsedMilliseconds / 1000.0}");
        }

        private void DeleteNonReturnableNodes(out double deletingTime)
        {
            _stopwatch.Restart();
            _graph.DeleteNonReturnableNodes();
            _stopwatch.Stop();
            deletingTime = _stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"[Time] Deleting non returnable nodes {deletingTime / 1000.0}");
        }

        private void SplitGraph(out double splittingTime)
        {
            _stopwatch.Restart();
            _graph = _graph.Splitted();
            _stopwatch.Stop();
            splittingTime = _stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"[Time] Splitting {splittingTime / 1000.0}");
        }

        private void InitDrawVariables()
        {
            _backgroundColor = Color.FromArgb(50, 50, 50);

            var axesColor = Color.FromArgb(50, 240, 245, 249);
            var axesPenWidth = 0.01f;
            _axesPen = new Pen(axesColor, axesPenWidth);

            var testPenColor = Color.Pink;
            var testPenWidth = 0.01f;
            _testPen = new Pen(testPenColor, testPenWidth);

            var cellColor = Color.FromArgb(234, 221, 41);
            var cellPenWidth = 0.01f;
            _cellPen = new Pen(cellColor, cellPenWidth);
            _cellBrush = new SolidBrush(cellColor);

            var gridColor = Color.FromArgb(184, 176, 176);
            var gridPenWidth = 0.01f;
            _gridPen = new Pen(gridColor, gridPenWidth);

            var edgeColor = Color.FromArgb(17, 153, 158);
            var edgePenWidth = 0.01f;
            _edgePen = new Pen(edgeColor, edgePenWidth);
            _edgeBrush = new SolidBrush(edgeColor);
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (_graph == null) return;

            Console.WriteLine("Draw");
            e.Graphics.Clear(_backgroundColor);
            NormalizeView(e.Graphics);
            DrawAxes(e.Graphics);
            DrawGraph(e.Graphics);
        }

        private void DrawGraph(Graphics graphics)
        {
            DrawNodes(graphics);
        }

        private void DrawNodes(Graphics graphics)
        {
            foreach (var node in _graph.Nodes)
            {
                Cell cell = _domain.GetCell(node);

                DrawCell(graphics, cell);
            }
        }

        private void DrawEdges(Graphics graphics)
        {
            foreach (var node in _graph.Nodes)
            {
                Cell cell = _domain.GetCell(node);

                var outNodes = _graph.GetOutNodes(node);
                foreach (var outNode in outNodes)
                {
                    if (node == outNode)
                    {
                        DrawLoop(graphics, cell);
                    }
                    else
                    {
                        Cell outCell = _domain.GetCell(outNode);
                        DrawEdge(graphics, cell, outCell);
                    }
                }
            }
        }

        private void DrawCell(Graphics graphics, Cell cell)
        {
            var size = cell.Size;
            graphics.FillRectangle(_cellBrush, (float)cell.Low.x, (float)cell.Low.y, (float)size.x, (float)size.y);
        }

        private void DrawEdge(Graphics graphics, Cell from, Cell to)
        {
            var fromCenter = from.Center;
            var toCenter = to.Center;
            var difference = toCenter - fromCenter;
            double distance = difference.Magnitude;
            double cellRadius = Math.Min(from.Width, from.Height) / 2.0;
            double percent = 1.0 - (cellRadius / (2 * distance));

            _edgePen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            graphics.DrawLine(_edgePen, fromCenter.ToPointF(), (fromCenter + (percent * difference)).ToPointF());
        }

        private void DrawLoop(Graphics graphics, Cell cell)
        {
            Vector2 center = cell.Center;
            DrawCircle(graphics, _edgePen, (float)center.x, (float)center.y, (float)(cell.Width / 2.0));
        }

        private void DrawGrid(Graphics graphics)
        {
            double columnSplitting = _domain.ColumnSplitting;
            double rowSplitting = _domain.RowSplitting;

            for (double y = _domain.MinY; y < _domain.MaxY; y += rowSplitting)
            {
                graphics.DrawLine(_gridPen, (float)_domain.MinX, (float)y, (float)_domain.MaxX, (float)y);
            }

            for (double x = _domain.MinX; x < _domain.MaxX; x += columnSplitting)
            {
                graphics.DrawLine(_gridPen, (float)x, (float)_domain.MinY, (float)x, (float)_domain.MaxY);
            }

            graphics.DrawLine(_gridPen, (float)_domain.MinX, (float)_domain.MaxY, (float)_domain.MaxX, (float)_domain.MaxY);
            graphics.DrawLine(_gridPen, (float)_domain.MaxX, (float)_domain.MinY, (float)_domain.MaxX, (float)_domain.MaxY);
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
            float minValue = -10;
            float maxValue = 10;

            graphics.DrawLine(_axesPen, minValue, 0, maxValue, 0);
            graphics.DrawLine(_axesPen, 0, minValue, 0, maxValue);
        }

        private void DrawCircle(Graphics graphics, Pen pen, float centerX, float centerY, float radius)
        {
            graphics.DrawEllipse(pen, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
        }

        private void ReInput_TextChanged(object sender, EventArgs e)
        {
            ProcessMappingParameterInput(ReInput);
        }

        private void ImInput_TextChanged(object sender, EventArgs e)
        {
            ProcessMappingParameterInput(ImInput);
        }

        private void IterationCountInput_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(IterationCountInput.Text, out int maxIterationCount) && maxIterationCount > 0)
            {
                OnCorrectUserInput(IterationCountInput);
            }
            else
            {
                OnIncorrectUserInput(IterationCountInput);
            }
        }

        private void ProcessMappingParameterInput(TextBox input)
        {
            if (TryParseInput(input, out double value))
            {
                OnCorrectUserInput(input);
            }
            else
            {
                OnIncorrectUserInput(input);
            }
        }

        private bool TryParseInput(TextBox input, out double result)
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

        private void OnCorrectUserInput(TextBox input)
        {
            _inputValidities[input] = true;
            input.ForeColor = Color.Black;
        }

        private void OnIncorrectUserInput(TextBox input)
        {
            _inputValidities[input] = false;
            input.ForeColor = Color.Red;
        }

        private void CalculationButton_Click(object sender, EventArgs e)
        {
            TryCalculate();
        }

        private void TryCalculate()
        {
            if (TryParseInput(IterationCountInput, out double maxIterationCount) &&
                TryParseInput(ReInput, out double re) &&
                TryParseInput(ImInput, out double im))
            {
                Calculate((int)maxIterationCount, re, im);
                NodesCountTextBox.Text = _graph.NodesCount.ToString();
                Canvas.Invalidate();
            }
            else
            {
                MessageBox.Show("Incorrect input");
            }
        }

        private void Calculate(int iterationMaxCount, double re, double im)
        {
            int pointCountInRow = 5;
            Vector2 low = new Vector2(-2.5, -2.5);
            Vector2 high = new Vector2(2.5, 2.5);
            int rowCount = 33;
            int columnCount = 33;

            PointSampler pointSampler = new UniformSampler(pointCountInRow, pointCountInRow, 0.01);
            Mapping f = new QuadraticMapping(pointSampler, re, im);

            _domain = new Domain(low, high, rowCount, columnCount);

            ConstructGraph(f, _domain);

            double totalTime = 0;
            for (int iterationCount = 0; iterationCount < iterationMaxCount; iterationCount++)
            {
                Console.WriteLine($"===Iteration {iterationCount + 1}===");

                DeleteNonReturnableNodes(out double deletingTime);

                SplitGraph(out double splittingTime);
                _domain = _graph.Domain;

                totalTime += deletingTime + splittingTime;
            }

            Console.WriteLine($"Total time: {totalTime}");
            TimeTextBox.Text = (totalTime / 1000.0).ToString();
        }
    }
}