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

            Console.WriteLine("Start Density");
            for (int row = 0; row < matrix.RowCount; row++)
            {
                Cell cell = domain.GetCell(row);
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