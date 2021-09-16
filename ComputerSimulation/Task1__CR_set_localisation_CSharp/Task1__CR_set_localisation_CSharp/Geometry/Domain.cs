using System;
using System.Collections.Generic;
using System.Text;
using Task1__CR_set_localisation_CSharp.LinearAlgebra;

namespace Task1__CR_set_localisation_CSharp.Geometry
{
    class Domain
    {
        private double _rowSplitting;
        private double _columnSplitting;

        public Vector2 Low { get; private set; }
        public Vector2 High { get; private set; }
        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }

        public Domain(Vector2 low, Vector2 high, int rowCount, int columnCount)
        {
            if (low.x >= high.x || low.y >= high.y)
                throw new Exception("Each component of high point should be > than corresponding low point`s component");

            if (rowCount < 1)
                throw new Exception("rowCount should be >= 1");

            if (columnCount < 1)
                throw new Exception("columnCount should be >= 1");

            Low = low;
            High = high;
            RowCount = rowCount;
            ColumnCount = columnCount;

            Vector2 splitting = (high - low) / new Vector2(columnCount, rowCount);

            _rowSplitting = splitting.y;
            _columnSplitting = splitting.x;
        }

        public void Split()
        {
            _columnSplitting /= 2.0;
            _rowSplitting /= 2.0;

            ColumnCount *= 2;
            RowCount *= 2;
        }

        public Cell GetCell(int id)
        {
            if (id < 0 || id >= ColumnCount * RowCount)
                throw new Exception("Cell id out of domain");

            int row = id / ColumnCount;
            int column = id - ColumnCount * row;

            Vector2 splitting = new Vector2(_columnSplitting, _rowSplitting);
            Vector2 low = new Vector2(column, row) * splitting + Low;
            Vector2 high = low + splitting;

            return new Cell(low, high);
        }
    }
}
