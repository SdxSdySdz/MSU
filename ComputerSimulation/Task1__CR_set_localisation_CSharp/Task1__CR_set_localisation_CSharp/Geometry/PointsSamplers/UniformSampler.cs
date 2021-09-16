using System;
using System.Collections.Generic;
using System.Text;
using Task1__CR_set_localisation_CSharp.LinearAlgebra;

namespace Task1__CR_set_localisation_CSharp.Geometry.PointsSamplers
{
    class UniformSampler : PointsSampler
    {
        private int _pointsCountInRow;
        public UniformSampler(int pointsCountInRow)
        {
            _pointsCountInRow = pointsCountInRow;
        }

        public override Vector2[] Sample(Cell cell)
        {
            int pointsCount = _pointsCountInRow * _pointsCountInRow;
            Vector2[] points = new Vector2[pointsCount];

            int index = 0;
            for (int row = 0; row < _pointsCountInRow; row++)
            {
                for (int column = 0; column < _pointsCountInRow; column++)
                {
                    double x = column;
                    double y = row;

                    Vector2 point = new Vector2(x, y);
                    point /= _pointsCountInRow - 1;
                    point *= cell.High - cell.Low;
                    point += cell.Low;

                    Console.WriteLine(index);
                    points[index] = point;
                    index++;
                }
            }

            return points;
        }
    }
}
