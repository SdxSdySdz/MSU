using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OsipLIB.Geometry;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.LinearAlgebra;
using OsipLIB.Mappings;

namespace Task7__CR_Set_In_Projective_Space
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Run");
            
            int iterationMaxCount = 7;
            int pointCountInRow = 10;
            Vector2 low = new Vector2(0, 0);
            Vector2 high = new Vector2(6, 2);
            int rowCount = 1;
            int columnCount = 3 * rowCount;

            double[,] matrixArray =
            {
                {1, -2, 1},
                {0, 3, 3},
                {-1, 2, 1},
            };
            Matrix3x3 matrix = new Matrix3x3(matrixArray);

            PointSampler pointSampler = new UniformSampler(pointCountInRow, pointCountInRow, 0.01);
            Mapping f = new ProjectiveSpaceMapping(pointSampler, matrix);

            Domain domain = new Domain(low, high, rowCount, columnCount);


            low = new Vector2(-1, -1);
            high = new Vector2(6, 3);
            Rectangle drawArea = new Rectangle(low, high);
            
            
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(drawArea, iterationMaxCount, f, domain));
        }
    }
}