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
            int pointCountInRow = 3;
            PointSampler pointSampler = new UniformSampler(pointCountInRow, pointCountInRow, 0);
            // Homeomorphism f = new QuadraticMapping(pointSampler, 0.29, -0.1);
            // Homeomorphism f = new QuadraticMapping(pointSampler, 0.29, -0.1);
            Homeomorphism f = new ControlTaskMapping(pointSampler, 1.05, -0.9, 1.2);

            Vector2 low = new Vector2(-3, -3);
            Vector2 high = new Vector2(3, 3);
            int rowCount = 4;
            int columnCount = 4;
            Domain domain = new Domain(low, high, rowCount, columnCount);

            int iterationMaxCount = 8;


            // graph


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(iterationMaxCount, f, domain));




            /*** TEST ZONE ***/
            /*            Graph g = new Graph();
                        g.AddEdge(Vector2Int.One, Vector2Int.One * 2);
                        g.AddEdge(Vector2Int.One, Vector2Int.One * 3);
                        g.AddEdge(Vector2Int.One * 3, Vector2Int.One * 4);
                        g.AddEdge(Vector2Int.One * 3, Vector2Int.One * 5);
                        g.AddEdge(Vector2Int.One * 2, Vector2Int.One * 3);
                        g.AddEdge(Vector2Int.One * 2, Vector2Int.One * 5);
                        g.AddEdge(Vector2Int.One * 5, Vector2Int.One * 1);

                        Console.WriteLine(g);

                        Dictionary<Vector2Int, bool> used = new Dictionary<Vector2Int, bool>();
                        List<Vector2Int> order = new List<Vector2Int>();
                        g.DFS1WithoutRecursion(Vector2Int.One, ref used, ref order);
                        foreach (var item in order)
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadLine();*/
            /*****************/
        }
    }
}
