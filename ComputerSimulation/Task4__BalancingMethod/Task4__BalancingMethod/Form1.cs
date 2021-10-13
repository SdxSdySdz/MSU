using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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


        public MainForm()
        {
            InitializeComponent();
            Canvas.InitializeContexts();

            _zoomValue = 1.0;
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





            //Glut.glutWireSphere(2, 32, 32); Gl.glPopMatrix(); Gl.glFlush(); Canvas.Invalidate();
            
            Draw();

            Canvas.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.OnMouseWheel);
        }
        

        private void Draw()
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


            DrawAxes();
            DrawDensity();
            DrawBase();

            Gl.glColor3f(1.0f, 0, 0);
            Gl.glBegin(Gl.GL_POLYGON);
            Tao.OpenGl.Gl.glVertex3f(0, 0, 1);
            Tao.OpenGl.Gl.glVertex3f((float)2, 0, 0);
            Tao.OpenGl.Gl.glVertex3f(0, 1, 0);
            Tao.OpenGl.Gl.glEnd();

            Gl.glPopMatrix();
            Gl.glFlush();
            Canvas.Invalidate();

            Console.WriteLine("Draw");
        }


        private void DrawBase()
        {

        }


        private void DrawDensity()
        {

        }


        private void DrawAxes()
        {
            // Gl.glColor3f(1.0f, 0, 0);
            Gl.glColor3f(201f / 255, 214f / 255, 223f / 255);
            Gl.glBegin(Gl.GL_LINES);
            Tao.OpenGl.Gl.glVertex3f(0, 0, 0);
            Tao.OpenGl.Gl.glVertex3f(5, 0, 0);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINES);
            Tao.OpenGl.Gl.glVertex3f(0, 0, 0);
            Tao.OpenGl.Gl.glVertex3f(0, 1, 0);
            Gl.glEnd();

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
