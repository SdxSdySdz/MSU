using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;
using OsipLIB.Geometry;
using OsipLIB.Graphs;
using OsipLIB.Graphs.Tools;

namespace OsipLIB.LinearAlgebra
{
    public class SparseMatrix
    {
        private Dictionary<(int, int), double> _matrix;

        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }
        public (int, int)[] Indices => _matrix.Keys.ToArray();

        public SparseMatrix(int rowCount, int columnCount)
        {
            if (rowCount <= 0 || columnCount <= 0)
            {
                throw new Exception("Row and column count should be > 0");
            }
            _matrix = new Dictionary<(int, int), double>();
            RowCount = rowCount;
            ColumnCount = columnCount;
        }

        public SparseMatrix(int rowCount) : this(rowCount, rowCount)
        {
        }

        public SparseMatrix(SparseMatrix other)
        {
            _matrix = new Dictionary<(int, int), double>();
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
                if (IsAvailableIndex(row, column) == false)
                    throw new IndexOutOfRangeException($"{row} {column}");
                return _matrix.TryGetValue((row, column), out var value) ? value : 0;
            }

            set
            {
                if (IsAvailableIndex(row, column) == false)
                    throw new IndexOutOfRangeException($"{row} {column}");

                if (value == 0)
                    _matrix.Remove((row, column));
                else
                    _matrix[(row, column)] = value;
            }
        }

        public void NormalizeInplace()
        {
            DivideInplace(Sum());
        }


        public void DivideInplace(double coefficient)
        {
            foreach (var index in Indices)
            {
                _matrix[index] /= coefficient;
            }
        }
        
        public double Sum()
        {
            return _matrix.Values.Sum();
        }

        public double RowSum(int row)
        {
            double sum = 0;
            foreach (var index in _matrix.Keys)
            {
                if (index.Item1 == row)
                    sum += _matrix[index];
            }

            return sum;
        }
        
        public double ColumnSum(int column)
        {
            double sum = 0;
            foreach (var index in _matrix.Keys)
            {
                if (index.Item2 == column)
                    sum += _matrix[index];
            }

            return sum;
        }

        public bool Contains(int row, int column)
        {
            return _matrix.TryGetValue((row, column), out var value);
        }

        // TODO SymbolicImageGraph -> Graph
        public static SparseMatrix FromGraph(SymbolicImageGraph graph)
        {
            Domain domain = graph.Domain;
            var matrix = new SparseMatrix(domain.ColumnCount * domain.RowCount);

            
            var edges = graph.Edges;
            foreach (var edge in edges)
            {
                Node sourceNode = NodeTransformer.Transform(edge.Source, domain);
                Node outNode = NodeTransformer.Transform(edge.Destination, domain);
                
                matrix[sourceNode.Id, outNode.Id] = 1;
            }

            return matrix;
        }
        
        public Dictionary<int, double> GetRowSums()
        {
            Dictionary<int, double> rowSums = new Dictionary<int, double>();
            foreach (var index in _matrix.Keys)
            {
                if (rowSums.TryGetValue(index.Item1, out var value))
                    rowSums[index.Item1] += value;
                else
                    rowSums[index.Item1] = value;
            }

            return rowSums;
        }

        private bool IsAvailableIndex(int row, int column)
        {
            return (0 <= row && row < RowCount) && (0 <= column && column < ColumnCount);
        }
    }
}
