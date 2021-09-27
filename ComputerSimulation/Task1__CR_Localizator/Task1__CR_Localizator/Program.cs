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
            int pointCountInRow = 5;
            PointSampler pointSampler = new UniformSampler(pointCountInRow, pointCountInRow, 0);
            // Homeomorphism f = new QuadraticMapping(pointSampler, 0.29, -0.1);
            Homeomorphism f = new QuadraticMapping(pointSampler, 0.29, -0.1);
            // Homeomorphism f = new ControlTaskMapping(pointSampler, 1.05, -0.9, 1.2);

            Vector2 low = new Vector2(-3, -3);
            Vector2 high = new Vector2(3, 3);
            int rowCount = 5;
            int columnCount = 5;
            Domain domain = new Domain(low, high, rowCount, columnCount);

            int iterationMaxCount = 10;

            
            // graph

            /*** TEST ZONE ***/


            /*****************/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(iterationMaxCount, f, domain));
        }
    }
}
