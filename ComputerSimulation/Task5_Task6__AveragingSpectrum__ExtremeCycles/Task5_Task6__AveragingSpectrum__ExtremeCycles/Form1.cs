using OsipLIB.Geometry;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.Graphs;
using OsipLIB.Graphs.Tools;
using OsipLIB.LinearAlgebra;
using OsipLIB.Mappings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Task5_Task6__AveragingSpectrum__ExtremeCycles.Andrew;

namespace Task5_Task6__AveragingSpectrum__ExtremeCycles
{
    public partial class MainForm : Form
    {
        private Stopwatch _stopwatch;

        private List<GFG> _gfgs;
        private Dictionary<Vector2Int, int> _nodesNumeration;

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
            Vector2 low = new Vector2(-2, -2);
            Vector2 high = new Vector2(3.5, 3.5);
            int rowCount = 1;
            int columnCount = 1;

            int pointsCountInCell = 100;
            PointSampler pointSampler = new UniformSampler(
                (int)Math.Sqrt(pointsCountInCell),
                (int)Math.Sqrt(pointsCountInCell),
                0.01
                );

            Mapping f = new IkedaMapping(pointSampler, 1, a, b);
            // Mapping f = new QuadraticMapping(pointSampler, a, b);
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

            

            _gfgs = new List<GFG>();
            Dictionary<Vector2Int, int> nodesNumeration = GetNodesNumeration(_graph);
            _nodesNumeration = nodesNumeration;

            Domain domain = _graph.Domain;
            List<List<Vector2Int>> components = _graph.GetStronglyConnectedComponents();

            int componentsCount = components.Count;
            int compponentNumber = 1;
            List<string> spectrums = new List<string>();
            foreach (var component in components)
            {
                if (component.Count == 1) continue;

                _stopwatch = new Stopwatch();
                _stopwatch.Start();

                List<int> strong_comp = ConvertComponent(component, nodesNumeration);
                List<float> weights = GetWeights(domain, nodesNumeration);
                Dictionary<int, int[]> graph = ConvertGraph(_graph, nodesNumeration);
                var gfg = new GFG(strong_comp, weights, graph);
                _gfgs.Add(gfg);

                _stopwatch.Stop();
                double componentSolvingTime = _stopwatch.ElapsedMilliseconds / 1000.0;
                Console.WriteLine($"<{gfg.min} {gfg.max}>");
                spectrums.Add($"Spectrum {compponentNumber} [{gfg.min} {gfg.max}]");
                Console.WriteLine($"[{compponentNumber} / {componentsCount}] Component Solving time: {componentSolvingTime}");
                compponentNumber++;
                totalTime += componentSolvingTime;
            }

            

            Console.WriteLine($"Total time: {totalTime}");
            SpectrumTextBox.Lines = spectrums.ToArray();
            TimeTextBox.Text = $"{totalTime}";
        }

        private Dictionary<Vector2Int, int> GetNodesNumeration(SymbolicImageGraph graph)
        {
            var nodesNumeration = new Dictionary<Vector2Int, int>();
            int nodeNumber = 0;
            foreach (var node in graph.Nodes)
            {
                nodesNumeration[node] = nodeNumber;
                nodeNumber++;
            }

            return nodesNumeration;
        }

        private List<int> ConvertComponent(List<Vector2Int> component, Dictionary<Vector2Int, int> nodesNumeration)
        {
            return component.Select(node => nodesNumeration[node]).ToList();
        }

        private List<float> GetWeights(Domain domain, Dictionary<Vector2Int, int> nodesNumeration)
        {
            var weights = new float[nodesNumeration.Keys.Count];
            foreach (var node in nodesNumeration.Keys)
            {
                float weight = GetWeight(node, domain);
                weights[nodesNumeration[node]] = weight;
            }

            return weights.ToList();
        }

        private float GetWeight(Vector2Int node, Domain domain)
        {
            Cell cell = domain.GetCell(node);
            Vector2 point = cell.Center;
            double x = point.x;
            double y = point.y;

            return (float)(x * x - y * y);
        }

        private Dictionary<int, int[]> ConvertGraph(SymbolicImageGraph graph, Dictionary<Vector2Int, int> nodesNumeration)
        {
            var result = new Dictionary<int, int[]>();

            var graphDictionary = graph.GraphDictionary;
            foreach (var item in graphDictionary)
            {
                Vector2Int node = item.Key;
                HashSet<Vector2Int> outNodes = item.Value;

                int key = nodesNumeration[node];
                int[] values = outNodes.Select(n => nodesNumeration[n]).ToArray();
                result.Add(key, values);
            }

            return result;
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

            deletingTime = _stopwatch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine($"[Time] Deleting non returnable nodes {deletingTime / 1000.0}");
        }

        private void SplitGraph(out double splittingTime)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            _graph = _graph.Splitted();

            _stopwatch.Stop();

            splittingTime = _stopwatch.ElapsedMilliseconds / 1000.0;
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
            foreach (var gfg in _gfgs)
            {
                DrawGFG(e.Graphics, gfg);
            }
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

        private void DrawGFG(Graphics graphics, GFG gfg)
        {
            HashSet<int> minCycleNumbers = gfg.Min_ver;
            HashSet<int> maxCycleNumbers = gfg.Max_ver;

            foreach (var nodeNumber in minCycleNumbers)
            {
                var node = _nodesNumeration.First(item => item.Value == nodeNumber).Key;
                Cell cell = _graph.Domain.GetCell(node);
                Brush brush = Brushes.Blue;
                DrawCell(graphics, cell, brush);
            }

            foreach (var nodeNumber in maxCycleNumbers)
            {
                var node = _nodesNumeration.First(item => item.Value == nodeNumber).Key;
                Cell cell = _graph.Domain.GetCell(node);
                Brush brush = Brushes.Red;
                DrawCell(graphics, cell, brush);
            }
        }

        private void DrawGraph(Graphics graphics)
        {
            DrawNodes(graphics);
        }

        private void DrawNodes(Graphics graphics)
        {
            /*Brush[] brushes = new Brush[] {
                Brushes.Orange,
                Brushes.Yellow,
                Brushes.Green,
                Brushes.Blue,
                Brushes.Purple,
                Brushes.White,
                Brushes.Pink,
                Brushes.Brown,
                Brushes.Coral,
                Brushes.DarkBlue,
            };
            int brushNumber = 0;
            foreach (var component in _graph.GetStronglyConnectedComponents())
            {
                if (component.Count == 1) continue;

                Brush brush = brushes[brushNumber];
                foreach (var node in component)
                {
                    Cell cell = _domain.GetCell(node);

                    DrawCell(graphics, cell, brush);
                }

                brushNumber++;
                brushNumber = brushNumber % brushes.Length;
            }*/
            foreach (var node in _graph.Nodes)
            {
                Cell cell = _domain.GetCell(node);

                DrawCell(graphics, cell);
            }
        }

        private void DrawCell(Graphics graphics, Cell cell)
        {
            DrawCell(graphics, cell, _cellBrush);
/*            var size = cell.Size;
            graphics.FillRectangle(_cellBrush, (float)cell.Low.x, (float)cell.Low.y, (float)size.x, (float)size.y);*/
        }

        private void DrawCell(Graphics graphics, Cell cell, Brush brush)
        {
            var size = cell.Size;
            graphics.FillRectangle(brush, (float)cell.Low.x, (float)cell.Low.y, (float)size.x, (float)size.y);
        }

        private void CalculationButton_Click(object sender, EventArgs e)
        {
            TryCalculate();
        }
    }
}
