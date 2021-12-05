using System;
using OsipLIB.Geometry;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.Graphs;
using OsipLIB.Graphs.Tools;
using OsipLIB.LinearAlgebra;
using OsipLIB.Mappings;

namespace Task3__TopologicalSorting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Vector2 low = new Vector2(-1.15, -1);
            Vector2 high = new Vector2(1.15, 1);
            int pointsAmountInRow = 50;
            PointSampler pointSampler = new UniformSampler(pointsAmountInRow, pointsAmountInRow, 0);

            Mapping f = new MishaMapping(pointSampler);
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