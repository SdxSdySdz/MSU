using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Geometry.PointSamplers
{
    class UniformSampler : PointSampler
    {
        private int _rowCount;
        private int _columnCount;
        private double _offsetPercent;
        

        public UniformSampler(int rowCount, int columnCount, double offsetPercent)
        {
            if (rowCount < 1 || columnCount < 1)
            {
                throw new Exception("Row count and column count should be > 0");
            } 

            if (offsetPercent < 0 || offsetPercent > 0.5)
            {
                throw new Exception("Offset percent should be between 0 and 0.5");
            }


            _rowCount = rowCount;
            _columnCount = columnCount;
            _offsetPercent = offsetPercent;
        }


        public override Vector2[] Sample(Cell cell)
        {
            Vector2 low = cell.Low;
            Vector2 high = cell.High;
            Vector2 offset = (high - low) * _offsetPercent;
            low += offset;
            high -= offset;

            Cell area = new Cell(low, high);

            double rowSplitting = area.Height / (_rowCount - 1);
            double columnSplitting = area.Width / (_columnCount - 1);

            Vector2[] samples = new Vector2[_rowCount * _columnCount];

            double x;
            double y = area.MinY;
            int index = 0;
            for (int row = 0; row < _rowCount; row++)
            {
                x = area.MinX;

                for (int column = 0; column < _columnCount; column++)
                {
                    samples[index] = new Vector2(x, y);
                    index++;

                    x += columnSplitting;
                }

                y += rowSplitting;
            }

            return samples;
        }
    }
}
