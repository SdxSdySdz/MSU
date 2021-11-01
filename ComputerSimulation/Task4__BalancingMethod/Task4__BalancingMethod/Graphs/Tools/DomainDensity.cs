using System;
using System.Collections.Generic;
using OsipLIB.Geometry;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Graphs.Tools
{
    public class DomainDensity
    {
        private Dictionary<Vector2, double> _density;

        public Dictionary<Vector2, double> Density => _density;

        public DomainDensity(Domain domain, SparseMatrix matrix, double areaMultiplier)
        {
            if (domain.RowCount * domain.ColumnCount != matrix.RowCount)
            {
                throw new Exception("Domain and matrix are incompatible");
            }

            _density = new Dictionary<Vector2, double>();

            double area = domain.GetCell(Vector2Int.Zero).Area * areaMultiplier;

            /*Dictionary<int, double> rowSums = matrix.GetRowSums();
            foreach (var rowSum in rowSums)
            {
                Console.WriteLine("Start");
                int row = rowSum.Key;
                Vector2Int cellCoordinates = NodeTransformer.TransformNode(new Node(row), domain);
                Cell cell = domain.GetCell(cellCoordinates);
                _density[cell.Center] = rowSum.Value / area;
                Console.WriteLine("End");
            }*/
            Console.WriteLine("Start Density");
            for (int row = 0; row < matrix.RowCount; row++)
            {
                Vector2Int cellCoordinates = NodeTransformer.TransformNode(new Node(row), domain);
                Cell cell = domain.GetCell(cellCoordinates);
                double rowSum = matrix.RowSum(row);
                if (rowSum != 0)
                {
                    _density[cell.Center] = rowSum / area;
                }
            }
            Console.WriteLine("End Density");
        }
    }
}