using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task1__CR_Localizator.Geometry;
using Task1__CR_Localizator.Graphs;
using Task1__CR_Localizator.Homeomorphisms;
using Task1__CR_Localizator.LinearAlgebra;

namespace Task1__CR_Localizator
{
    public partial class MainForm : Form
    {
        private SymbolicImageGraph _graph;
        private Domain _domain;

        private Pen _testPen;
        private Pen _axesPen;
        private Pen _edgePen;
        private Pen _cellPen;
        private Pen _gridPen;

        private Brush _edgeBrush;
        private Brush _cellBrush;


        internal MainForm(int iterationMaxCount, Homeomorphism f, Domain domain)
        {
            InitDrawVariables();

            _domain = domain;

            _graph = new SymbolicImageGraph(f, domain);

            for (int iterationCount = 0; iterationCount < iterationMaxCount; iterationCount++)
            {
                _graph.DeleteNonReturnableNodes();

                _graph = _graph.Splitted();
                _domain = _graph.Domain;
            }

            InitializeComponent();
        }


        private void InitDrawVariables()
        {
            var axesColor = Color.FromArgb(45, 64, 89);
            var axesPenWidth = 0.01f;
            _axesPen = new Pen(axesColor, axesPenWidth);

            var testPenColor = Color.Pink;
            var testPenWidth = 0.01f;
            _testPen = new Pen(testPenColor, testPenWidth);

            var cellColor = Color.Green;
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
            NormalizeView(e.Graphics);
            
            // DrawAxes(e.Graphics);

            DrawCircle(e.Graphics, _testPen, 0, 0, 1);

            DrawGraph(e.Graphics);
            // DrawGrid(e.Graphics);
        }


        private void DrawGraph(Graphics graphics)
        {
            DrawNodes(graphics);
            // DrawEdges(graphics);      
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
            // graphics.DrawRectangle(_cellPen, (float)cell.Low.x, (float)cell.Low.y, (float)size.x, (float)size.y);
            graphics.FillRectangle(_cellBrush, (float)cell.Low.x, (float)cell.Low.y, (float)size.x, (float)size.y);
        }


        private void DrawEdge(Graphics graphics, Cell from, Cell to)
        {
            var fromCenter = from.Center;
            var toCenter = to.Center;
            var difference = toCenter - fromCenter;
            double distance = difference.Magnitude;
            double cellRadius = Math.Min(from.Width, from.Height) / 2.0;
            double percent = 1.0 - cellRadius / (2 * distance);

            _edgePen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            graphics.DrawLine(_edgePen, fromCenter.ToPointF(), (fromCenter + percent * difference).ToPointF());
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
            float alphaDomain = Convert.ToSingle(_domain.Width / _domain.Height);

            float targetWidth = Math.Max(alpha, alphaDomain) *  (float)_domain.Height / 2f;

            float scale = Canvas.Width / 2f / targetWidth;

            graphics.TranslateTransform(Canvas.Width / 2f, Canvas.Height / 2f);
            graphics.ScaleTransform(scale, -scale);

            graphics.TranslateTransform((float)-_domain.Center.x, (float)-_domain.Center.y);
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
    }
}
