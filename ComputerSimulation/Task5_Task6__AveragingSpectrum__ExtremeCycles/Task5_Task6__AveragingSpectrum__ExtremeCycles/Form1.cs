using OsipLIB.Geometry;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.Graphs;
using OsipLIB.LinearAlgebra;
using OsipLIB.Mappings;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Task5_Task6__AveragingSpectrum__ExtremeCycles
{
    public partial class MainForm : Form
    {
        private Stopwatch _stopwatch;

        private SymbolicImageGraph _graph;
        private Domain _domain;

        private OsipLIB.Geometry.Rectangle _drawArea;
        private Color _backgroundColor;

        private Pen _axesPen;
        private Pen _cellPen;
        private Brush _cellBrush;

        public MainForm()
        {
            InitializeComponent();
            _stopwatch = new Stopwatch();
            
            InitDrawVariables();
            TryCalculate();
        }

        private void InitDrawVariables()
        {
            Vector2 low = new Vector2(-5, -5);
            Vector2 high = new Vector2(5, 5);
            _drawArea = new OsipLIB.Geometry.Rectangle(low, high);

            _backgroundColor = Color.FromArgb(50, 50, 50);

            var axesColor = Color.FromArgb(50, 240, 245, 249);
            var axesPenWidth = 0.01f;
            _axesPen = new Pen(axesColor, axesPenWidth);

            var cellColor = Color.FromArgb(234, 221, 41);
            var cellPenWidth = 0.01f;
            _cellPen = new Pen(cellColor, cellPenWidth);
            _cellBrush = new SolidBrush(cellColor);
        }

        private void TryCalculate()
        {
            if (TryParsePositiveIntInput(IterationCountInput, out int maxIterationCount) &&
                TryParseDoubleInput(AInput, out double a) &&
                TryParseDoubleInput(BInput, out double b))
            {
                Calculate(maxIterationCount, a, b);
                NodesCountTextBox.Text = _graph.NodesCount.ToString();
                Canvas.Invalidate();
            }
            else
                MessageBox.Show("Incorrect input");
        }

        private void Calculate(int maxIterationCount, double a, double b)
        {
            Vector2 low = new Vector2(-5, -5);
            Vector2 high = new Vector2(5, 5);
            int rowCount = 1;
            int columnCount = 3 * rowCount;

            int pointCountInRow = 10;
            PointSampler pointSampler = new UniformSampler(pointCountInRow, pointCountInRow, 0.01);

            int pointsCountInCell = 100;
            PointSampler pointsSampler = new UniformSampler(
                (int)Math.Sqrt(pointsCountInCell),
                (int)Math.Sqrt(pointsCountInCell),
                0.01
                );

            Mapping f = new IkedaMapping(pointSampler, a, .4, .9, b);
            _domain = new Domain(low, high, rowCount, columnCount);

            ConstructGraph(f, _domain);

            double totalTime = 0;
            for (int iterationCount = 0; iterationCount < maxIterationCount; iterationCount++)
            {
                Console.WriteLine($"===Iteration {iterationCount + 1}===");

                DeleteNonReturnableNodes(out double deletingTime);

                SplitGraph(out double splittingTime);
                _domain = _graph.Domain;

                totalTime += deletingTime + splittingTime;
            }

            Console.WriteLine($"Total time: {totalTime}");
        }

        private void ConstructGraph(Mapping f, Domain domain)
        {
            Console.WriteLine("Construct Graph");
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            _graph = new SymbolicImageGraph(f, domain);

            _stopwatch.Stop();

            Console.WriteLine($"[Time] Constructing graph {_stopwatch.ElapsedMilliseconds / 1000.0}");
        }

        private void DeleteNonReturnableNodes(out double deletingTime)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            _graph.DeleteNonReturnableNodes();

            _stopwatch.Stop();

            deletingTime = _stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"[Time] Deleting non returnable nodes {deletingTime / 1000.0}");
        }

        private void SplitGraph(out double splittingTime)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            _graph = _graph.Splitted();

            _stopwatch.Stop();

            splittingTime = _stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"[Time] Splitting {splittingTime / 1000.0}");
        }

        private bool TryParseDoubleInput(TextBox input, out double result)
        {
            string value = input.Text;

            if (double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result) == false &&
                double.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) == false &&
                double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result) == false)
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

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (_graph == null) return;

            e.Graphics.Clear(_backgroundColor);
            NormalizeView(e.Graphics);
            DrawAxes(e.Graphics);
            DrawGraph(e.Graphics);
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

        private void DrawCell(Graphics graphics, Cell cell)
        {
            var size = cell.Size;
            graphics.FillRectangle(_cellBrush, (float)cell.Low.x, (float)cell.Low.y, (float)size.x, (float)size.y);
        }

        private void CalculationButton_Click(object sender, EventArgs e)
        {
            TryCalculate();
        }
    }
}
