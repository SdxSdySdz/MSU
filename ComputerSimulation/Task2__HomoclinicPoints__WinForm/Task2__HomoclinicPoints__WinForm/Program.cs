using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task2__HomoclinicPoints__WinForm.Diffeomorphisms;
using Task2__HomoclinicPoints__WinForm.Geometry;
using Task2__HomoclinicPoints__WinForm.LinearAlgebra;

namespace Task2__HomoclinicPoints__WinForm
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            double minSideLength = 0.001;
            double eigenvectorLength = 0.1;


            Vector2 low = new Vector2(-2, -2);
            Vector2 high = new Vector2(2, 2);
            Rectangle drawArea = new Rectangle(low, high);

            double alpha = 0.43;
            Diffeomorphism f = new HomeTaskMapping(alpha);

            int maxIterationCount = 5;

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm(
                drawArea,
                f,
                maxIterationCount,
                minSideLength,
                eigenvectorLength
                ));
        }
    }
}
