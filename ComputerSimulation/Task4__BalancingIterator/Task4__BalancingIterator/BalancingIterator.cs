using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task4__BalancingIterator
{
    class BalancingIterator
    {
        public void Iterate(ref SparseMatrix matrix, double eps)
        {
            if (matrix.RowCount != matrix.ColumnCount)
            {
                throw new Exception("Matrix should be (n x n)");
            }

            SparseMatrix newMatrix;

            double maxDifference = double.PositiveInfinity;
            double rowMultiplier;
            double columnMultiplier;
            while (maxDifference > eps)
            {
                matrix.NormalizeInplace();


                Dictionary<int, double> rowSums = new Dictionary<int, double>();
                Dictionary<int, double> columnSums = new Dictionary<int, double>();

                foreach (var index in matrix.Indices)
                {
                    int row = index.Item1;
                    int column = index.Item2;

                    if (row == column) continue;

                    double value = matrix[row, column];

                    if (rowSums.TryGetValue(row, out var rowSum))
                    {
                        rowSum += value;
                    }
                    else
                    {
                        rowSums[row] = value;
                    }

                    if (columnSums.TryGetValue(column, out var columnSum))
                    {
                        columnSum += value;
                    }
                    else
                    {
                        columnSums[row] = value;
                    }
                }


                newMatrix = new SparseMatrix(matrix.RowCount, matrix.ColumnCount);
                var indices = matrix.Indices;
                for (int diagIndex = 0; diagIndex < matrix.RowCount; diagIndex++)
                {
                    rowMultiplier = Math.Sqrt(columnSums[diagIndex] / rowSums[diagIndex]);
                    columnMultiplier = 1.0 / rowMultiplier;

                    foreach (var index in indices)
                    {
                        if (index.Item1 == index.Item2)
                        {
                            newMatrix[index.Item1, index.Item2] = matrix[index.Item1, index.Item2];
                        }
                        else
                        {
                            if (index.Item1 == diagIndex)
                            {
                                newMatrix[index.Item1, index.Item2] = matrix[index.Item1, index.Item2] * rowMultiplier;
                            }

                            if (index.Item2 == diagIndex)
                            {
                                newMatrix[index.Item1, index.Item2] = matrix[index.Item1, index.Item2] * columnMultiplier;
                            }
                        }
                    }
                }
                matrix = newMatrix;
            }
        }
    }
}
