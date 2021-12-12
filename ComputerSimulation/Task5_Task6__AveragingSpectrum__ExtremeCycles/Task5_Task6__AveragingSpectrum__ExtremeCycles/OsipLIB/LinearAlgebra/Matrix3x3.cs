using System;

namespace OsipLIB.LinearAlgebra
{
    public class Matrix3x3
    {
        private readonly int _rowCount;
        private readonly int _columnCount;
        private double[,] _matrix;

        public Matrix3x3()
        {
            _rowCount = 3;
            _columnCount = 3;

            _matrix = new double[_rowCount, _columnCount];
        }

        public Matrix3x3(double[,] matrix) : this()
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new Exception("Matrix3x3 can only by square");

            if (matrix.GetLength(0) != _rowCount)
                throw new Exception("Matrix3x3 can only be of size 3 by 3");

            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {
                    _matrix[i, j] = matrix[i, j];
                }
            }
        }

        public Matrix3x3(Matrix3x3 other) : this(other._matrix)
        {
        }

        public static Matrix3x3 Eye
        {
            get
            {
                double[,] matrix = new double[,]
                {
                    { 1, 0, 0 },
                    { 0, 1, 0 },
                    { 0, 0, 1 },
                };

                return new Matrix3x3(matrix);
            }
        }

        public double this[int row, int column]
        {
            get => _matrix[row, column];

            set => _matrix[row, column] = value;
        }

        public static Vector3 operator *(Matrix3x3 matrix, Vector3 vector)
        {
            var result = new double[3];
            for (int i = 0; i < Vector3.Size; i++)
            {
                result[i] = vector.x * matrix._matrix[i, 0] +
                            vector.y * matrix._matrix[i, 1] +
                            vector.z * matrix._matrix[i, 2];
            }

            return new Vector3(result[0], result[1], result[2]);
        }
    }
}