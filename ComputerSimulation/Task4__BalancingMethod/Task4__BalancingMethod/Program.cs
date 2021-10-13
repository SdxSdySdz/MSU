using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 

using Tao.OpenGl; // для работы с библиотекой OpenGL
using Tao.FreeGlut; // для работы с библиотекой FreeGLUT
using Tao.Platform.Windows; // для работы с элементом управления SimpleOpenGLControl



namespace Task4__BalancingMethod
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
