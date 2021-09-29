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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var s1 = new Segment(new Vector2(0, 0), new Vector2(1, 1));
            var s2 = new Segment(new Vector2(0, 1), new Vector2(1, 0));
            Console.WriteLine(s1.TryGetIntersectionPoint(s2, out Vector2 i));

            Vector2 low = new Vector2(-2, -2);
            Vector2 high = new Vector2(2, 2);
            Rectangle drawArea = new Rectangle(low, high);

            double alpha = 0.4;
            Diffeomorphism f = new HomeTaskMapping(alpha);

            int maxIterationCount = 30;

            MainForm form = new MainForm(drawArea, f, maxIterationCount);

            Application.Run(form);
        }
    }
}
