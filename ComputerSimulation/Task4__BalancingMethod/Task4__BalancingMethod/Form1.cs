using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OsipLIB.Geometry;
using OsipLIB.Graphs;
using OsipLIB.Graphs.Tools;
using OsipLIB.LinearAlgebra;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Task4__BalancingMethod
{
    public partial class MainForm : Form
    {
        private bool _isGraphicRotating;
        private Point _rotatingStartPoint;
        private Point _lastRotatingPoint;

        private double _zoomValue;
        private const double _minZoomValue = 0.1;
        private const double _zoomMultiplier = 0.001;

        private double _angle;

        private SymbolicImageGraph _graph;
        private Domain _domain;
        private DomainDensity _density;
        private Color _cellColor;

        internal MainForm(SymbolicImageGraph graph, DomainDensity domainDensity)
        {
            InitializeComponent();
            Canvas.InitializeContexts();
    
            _zoomValue = 1.0;
            _graph = graph;
            _domain = graph.Domain;
            _density = domainDensity;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);


            Glut.glutInit(); 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            // отчитка окна
            Gl.glClearColor(32f/255, 32f/255, 32f/255, 1); 
            // установка порта вывода в соответствии с размерами элемента Canvas
            Gl.glViewport(0, 0, Canvas.Width, Canvas.Height); 
            // настройка проекции
            Gl.glMatrixMode(Gl.GL_PROJECTION); 
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float)Canvas.Width / (float)Canvas.Height, 0.1, 200); 
            Gl.glMatrixMode(Gl.GL_MODELVIEW); 
            Gl.glLoadIdentity(); 
            // настройка параметров OpenGL для визуализации
            Gl.glEnable(Gl.GL_DEPTH_TEST);



            _cellColor = Color.FromArgb(233, 221, 41);

            Draw();

            Canvas.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.OnMouseWheel);
        }
        

        private void Draw()
        {
            InitDrawingConstants();

            DrawAxes();
            DrawDensity();
            DrawBase(_graph);
            

            Gl.glPopMatrix();
            Gl.glFlush();
            Canvas.Invalidate();

            Console.WriteLine("Draw");
        }

        private void InitDrawingConstants()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(32f / 255, 32f / 255, 32f / 255, 1);
            Gl.glLoadIdentity();


            Glu.gluLookAt(5, 5, 5, 0, 0, 0, 0, 0, 1);
            Gl.glPushMatrix();
            // Gl.glRotated(_eulerAngleGamma, 0, 0, 1);
            // Gl.glRotated(45, 1, -1, 0);
            Gl.glRotated(_angle, 0, 0, 1);
            Gl.glScaled(_zoomValue, _zoomValue, _zoomValue);
        }
        
        private void DrawDensity()
        {

            foreach (var item in _density.Density)
            {
                Vector2 point = item.Key;
                Gl.glColor3f(213f / 255,155f / 255,246f / 255);
                Tao.OpenGl.Gl.glBegin(Tao.OpenGl.Gl.GL_POINTS);
                Tao.OpenGl.Gl.glVertex3f((float) point.x, (float) point.y, (float) item.Value);
                Tao.OpenGl.Gl.glEnd();
            }
        }
        
        private void DrawBase(SymbolicImageGraph graph)
        {
            var cells = graph.GetCells();

            foreach (var cell in cells)
            {
                Draw(cell);
            }
        }

        private void Draw(Cell cell)
        {
            Draw(cell, 0);
        }
        
        private void Draw(Cell cell, float height)
        {
            List<Vector2> vertexes = cell.Vertexes;
            Gl.glColor3f(_cellColor.R / 255f, _cellColor.G / 255f, _cellColor.B / 255f);
            Gl.glBegin(Gl.GL_POLYGON);
            foreach (var vertex in vertexes)
            {
                Gl.glVertex3f((float)vertex.x, (float)vertex.y, height);
            }
            
            Gl.glEnd();
        }
        
        private void DrawAxes()
        {
            // Gl.glColor3f(1.0f, 0, 0);
            Gl.glColor3f(235f / 255, 76f / 255, 66f / 255);
            Gl.glBegin(Gl.GL_LINES);
            Tao.OpenGl.Gl.glVertex3f(0, 0, 0);
            Tao.OpenGl.Gl.glVertex3f(1, 0, 0);
            Gl.glEnd();
            
            Gl.glColor3f(80f / 255, 200f / 255, 120f / 255);
            Gl.glBegin(Gl.GL_LINES);
            Tao.OpenGl.Gl.glVertex3f(0, 0, 0);
            Tao.OpenGl.Gl.glVertex3f(0, 1, 0);
            Gl.glEnd();
            
            Gl.glColor3f(49f / 255, 140f / 255, 231f / 255);
            Gl.glBegin(Gl.GL_LINES);
            Tao.OpenGl.Gl.glVertex3f(0, 0, 0);
            Tao.OpenGl.Gl.glVertex3f(0, 0, 1);
            Gl.glEnd();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isGraphicRotating = true;
                _rotatingStartPoint = e.Location;
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isGraphicRotating)
            {

                /*if ((_lastRotatingPoint.Y - e.Y) < 0) _eulerAngleBeta--;
                if ((_lastRotatingPoint.Y - e.Y) > 0) _eulerAngleBeta++;
                if ((_lastRotatingPoint.X - e.X) < 0) _eulerAngleGamma--;
                if ((_lastRotatingPoint.X - e.X) > 0) _eulerAngleGamma++;

                if (_eulerAngleBeta > 359) _eulerAngleBeta = 0;
                if (_eulerAngleGamma > 359) _eulerAngleGamma = 0;
                if (_eulerAngleBeta < 0) _eulerAngleBeta = 359;
                if (_eulerAngleGamma < 0) _eulerAngleGamma = 359;*/
                

                if ((_lastRotatingPoint.X - e.X) < 0) _angle++;
                if ((_lastRotatingPoint.X - e.X) > 0) _angle--;


                if (_angle > 359) _angle = 0;
                if (_angle < 0) _angle = 359;

                _lastRotatingPoint = new Point(e.X, e.Y);
                Draw();
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isGraphicRotating = false;
            }
        }

        void OnMouseWheel(object sender, MouseEventArgs e)
        {
            _zoomValue += e.Delta * _zoomMultiplier;
            _zoomValue = Math.Max(_minZoomValue, _zoomValue);

            Draw();
        }
    }
}
