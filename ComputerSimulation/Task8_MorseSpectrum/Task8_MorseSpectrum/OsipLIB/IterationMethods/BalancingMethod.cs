using System;
using System.Collections.Generic;
using System.Linq;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.IterationMethods
{
    public static class BalancingMethod
    {
        public static void Iterate(ref SparseMatrix matrix, double eps)
        {
            if (matrix.RowCount != matrix.ColumnCount)
            {
                throw new Exception("Matrix should be (n x n)");
            }
            
            Console.WriteLine(matrix.Indices.Length);
            /*foreach (var index in matrix.Indices)
            {
                Console.WriteLine(index);
            }*/
            
            var differences = new List<double>() {eps + 1};

            int iteration = 0;
            while (differences.Max() > eps)
            {
                Console.WriteLine($"===ITERATION {iteration++} {differences.Max()}===");
                differences = new List<double>();
                
                matrix.NormalizeInplace();
                
                Console.WriteLine("Star calculate sums");
                CalculateSums(
                    matrix, 
                    out Dictionary<int, double> rowSums, 
                    out Dictionary<int, double>  columnSums
                    );
                Console.WriteLine("Stop calculate sums");
                var newMatrix = new SparseMatrix(matrix.RowCount, matrix.ColumnCount);
                
                Console.WriteLine("Star ROW");
                for (int row = 0; row < matrix.RowCount; row++)
                {
                    /*var columns = matrix.Indices
                        .Where(index => index.Item1 == row)
                        .Select(index => index.Item2)
                        .ToArray();*/

                    if (columnSums.TryGetValue(row, out var v) == false) continue;
                    foreach (var index in matrix.Indices)
                    {
                        if (index.Item1 != row) continue;
                        var column = index.Item2;
                        
                        if (column == row)
                            newMatrix[row, column] = matrix[row, column];
                        else
                        {
                            double rowMultiplier = Math.Sqrt(columnSums[row] / rowSums[row]);
                            newMatrix[row, column] = matrix[row, column] * rowMultiplier;
                            differences.Add(Math.Abs(newMatrix[row, column] - matrix[row, column]));
                        }
                    }
                }
                Console.WriteLine("Star Column");
                for (int column = 0; column < matrix.ColumnCount; column++)
                {
                    if (rowSums.TryGetValue(column, out var v) == false) continue;
                    foreach (var index in matrix.Indices)
                    {
                        if (index.Item2 != column) continue;
                        var row = index.Item1;
                        
                        if (row == column)
                            newMatrix[row, column] = matrix[row, column];
                        else
                        {
                            
                            var columnMultiplier = Math.Sqrt(rowSums[column] / columnSums[column]);
                            newMatrix[row, column] = matrix[row, column] * columnMultiplier;
                            differences.Add(Math.Abs(newMatrix[row, column] - matrix[row, column]));
                        }
                    }
                }
                
                matrix = newMatrix;
            }
            Console.WriteLine("================================");
        }

        private static void CalculateSums(SparseMatrix matrix, out Dictionary<int, double> rowSums, out Dictionary<int, double> columnSums)
        {
            rowSums = new Dictionary<int, double>();
            columnSums = new Dictionary<int, double>();

            foreach (var index in matrix.Indices)
            {
                int row = index.Item1;
                int column = index.Item2;

                if (row == column) continue;

                double value = matrix[row, column];

                if (rowSums.TryGetValue(row, out var rowSum))
                    rowSums[row] += value;
                else
                    rowSums[row] = value;
                

                if (columnSums.TryGetValue(column, out var columnSum))
                    columnSums[column] += value;
                else
                    columnSums[column] = value;
            }
        }
    }
}