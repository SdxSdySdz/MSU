using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Task4__BalancingIterator
{
    class SparseMatrix
    {
        private Dictionary<(int, int), double> _matrix;

        public int RowCount;
        public int ColumnCount;
        public (int, int)[] Indices => _matrix.Keys.ToArray();

        public SparseMatrix(int rowCount, int columnCount)
        {
            if (rowCount <= 0 || columnCount <= 0)
            {
                throw new Exception("Row and column count should be > 0");
            }

            RowCount = rowCount;
            ColumnCount = columnCount;
        }


        public SparseMatrix(SparseMatrix other)
        {
            RowCount = other.RowCount;
            ColumnCount = other.ColumnCount;

            foreach (var index in other._matrix.Keys)
            {
                _matrix[index] = other._matrix[index];
            }
        }


        public double this[int row, int column]
        {
            get
            {
                if (RowCount <= row || row < 0) throw new IndexOutOfRangeException();
                if (ColumnCount <= column || column < 0) throw new IndexOutOfRangeException();

                if (_matrix.TryGetValue((row, column), out double value))
                {
                    return value;
                }
                else
                {
                    return 0.0;
                }
            }

            set
            {
                if (RowCount <= row || row < 0) throw new IndexOutOfRangeException();
                if (ColumnCount <= column || column < 0) throw new IndexOutOfRangeException();

                _matrix[(row, column)] = value;
            }
        }

        public void MultiplyColumnExcept(int targetColumn, double multiplier, int exceptColumn)
        {
            foreach (var index in _matrix.Keys)
            {
                if (index.Item2 != targetColumn) continue;

                _matrix[index] *= multiplier;
            }
        }


        public void MultiplyRowExcept(int targetRow, double multiplier, int exceptRow)
        {
            foreach (var index in _matrix.Keys)
            {
                if (index.Item1 != targetRow) continue;

                _matrix[index] *= multiplier;
            }
        }

        public void NormalizeInplace()
        {
            DivideInplace(Sum());
        }


        public void DivideInplace(double coefficient)
        {
            foreach (var index in _matrix.Keys)
            {
                _matrix[index] /= coefficient;
            }
        }


        public double Sum()
        {
            return _matrix.Values.Sum();
        }


        public bool Contains(int row, int column)
        {
            return _matrix.TryGetValue((row, column), out var value);
        }
    }
}
