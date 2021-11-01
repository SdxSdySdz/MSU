﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OsipLIB.Geometry;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.Graphs;
using OsipLIB.Graphs.Tools;
using OsipLIB.Homeomorphisms;
using OsipLIB.IterationMethods;
using OsipLIB.LinearAlgebra;
using Tao.OpenGl;
using Tao.FreeGlut; 
using Tao.Platform.Windows;



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
            int pointsCountInRow = 10;
            PointSampler pointSampler = new UniformSampler(pointsCountInRow, pointsCountInRow, 0);
            Homeomorphism f = new IkedaMapping(pointSampler, .6, .4, .9, 10);
            // Homeomorphism f = new QuadraticMapping(pointSampler, 0.2, 0.5);
            
            Vector2 low = new Vector2(-4, -4);
            Vector2 high = new Vector2(4, 4);
            Domain domain = new Domain(low, high, 10, 10);
            
            var graph = new SymbolicImageGraph(f, domain);
            graph.DeleteNonReturnableNodes();
            graph = graph.Splitted();
            graph.DeleteNonReturnableNodes();
            graph = graph.Splitted();
            graph.DeleteNonReturnableNodes();
            graph = graph.Splitted();
            graph.DeleteNonReturnableNodes();
            graph = graph.Splitted();
            graph.DeleteNonReturnableNodes();
            graph = graph.Splitted();
            graph.DeleteNonReturnableNodes();
            graph = graph.Splitted();
            graph.DeleteNonReturnableNodes();

            var _densityMatrix = SparseMatrix.FromGraph(graph);
            BalancingMethod.Iterate(ref _densityMatrix, 0.001);
            
            DomainDensity density = new DomainDensity(graph.Domain, _densityMatrix, 10);
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new MainForm(graph, null));
            Application.Run(new MainForm(graph, density));
        }
    }
}
