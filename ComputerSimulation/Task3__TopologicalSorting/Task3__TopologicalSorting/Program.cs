using System;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.Geometry;
using OsipLIB.Graphs;
using OsipLIB.Graphs.Tools;
using OsipLIB.Homeomorphisms;
using OsipLIB.LinearAlgebra;
using System.Collections.Generic;
using System.Linq;

namespace Task3__TopologicalSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector2 low = new Vector2(-1.15, -1);
            Vector2 high = new Vector2(1.15, 1);
            int pointsAmountInRow = 50;
            PointSampler pointSampler = new UniformSampler(pointsAmountInRow, pointsAmountInRow, 0);

            Homeomorphism f = new MishaMapping(pointSampler);
            Domain domain = new Domain(low, high, 10, 10);

            SymbolicImageGraph graph = new SymbolicImageGraph(f, domain);
            NodesSubstitution substitution = TopologicalSorter.Sort(graph);

            foreach (var item in substitution)
            {
                int previousId = graph.Domain.GetCellId((Vector2Int)item.PreviousNode);
                int newId = graph.Domain.GetCellId((Vector2Int)item.NewNode);

                Console.WriteLine($"{previousId} -> {newId}");
            }
        }
    }
}
