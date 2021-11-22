using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task1__CR_Localizator.Geometry;
using Task1__CR_Localizator.Geometry.PointSamplers;
using Task1__CR_Localizator.Graphs;
using Task1__CR_Localizator.Homeomorphisms;
using Task1__CR_Localizator.LinearAlgebra;

namespace Task1__CR_Localizator
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int iterationMaxCount = 5;
            int pointCountInRow = 5;
            Vector2 low = new Vector2(-2.5, -2.5);
            Vector2 high = new Vector2(2.5, 2.5);
            int rowCount = 33;
            int columnCount = 33;


            PointSampler pointSampler = new UniformSampler(pointCountInRow, pointCountInRow, 0);
            Homeomorphism f = new QuadraticMapping(pointSampler, 0.29, -0.1);

            Domain domain = new Domain(low, high, rowCount, columnCount);


            low = new Vector2(-2.5, -2.5);
            high = new Vector2(2.5, 2.5);
            Rectangle drawArea = new Rectangle(low, high);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(drawArea, iterationMaxCount, f, domain));
        }
    }
}
