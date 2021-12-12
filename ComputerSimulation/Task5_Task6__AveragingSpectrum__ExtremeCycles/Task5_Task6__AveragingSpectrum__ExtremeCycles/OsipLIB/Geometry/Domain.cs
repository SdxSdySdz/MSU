using System;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Geometry
{
    public class Domain : Rectangle
    {
        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }
        public double RowSplitting => (High.y - Low.y) / RowCount;
        public double ColumnSplitting => (High.x - Low.x) / ColumnCount;
        public Vector2 Splitting => new Vector2(ColumnSplitting, RowSplitting);

        public Domain(Vector2 low, Vector2 high, int rowCount, int columnCount) : base(low, high)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
        }

        public Domain(Domain domain) : this(domain.Low, domain.High, domain.RowCount, domain.ColumnCount) { }

        public Cell GetCell(int cellId)
        {
            int row = cellId / ColumnCount;
            int column = cellId - ColumnCount * row;

            return GetCell(new Vector2Int(row, column));
        }

        public Cell GetCell(Vector2Int cellCoordinates)
        {
            if (ContainsCellCoordinates(cellCoordinates) == false)
                throw new Exception($"Domain does not contain cell with coordinates {cellCoordinates}");

            Vector2 low = new Vector2(cellCoordinates.Column * ColumnSplitting, cellCoordinates.Row * RowSplitting);
            Vector2 high = new Vector2((cellCoordinates.Column + 1) * ColumnSplitting, (cellCoordinates.Row + 1) * RowSplitting);

            return new Cell(low + Low, high + Low);
        }

        public bool TryGetCellCoordinates(Vector2 point, out Vector2Int cellCoordinates)
        {
            cellCoordinates = GetCellCoordinates(point);
            return ContainsCellCoordinates(cellCoordinates);
        }

        // TODO: if point.x or point.y belongs to the integer grid
        public Vector2Int GetCellCoordinates(Vector2 point)
        {
            point = point - Low;
            point = point / Splitting;

            Console.WriteLine(new Vector2(point.y, point.x));
            return new Vector2Int((int)point.y, (int)point.x);
        }

        public int GetCellId(Vector2Int cellCoordinates)
        {
            return cellCoordinates.Column + ColumnCount * cellCoordinates.Row;
        }

        public Vector2Int[] GetSubNodes(Vector2Int cellIndex)
        {
            int row = cellIndex.Row;
            int column = cellIndex.Column;

            return new Vector2Int[]
            {
                new Vector2Int(2 * row, 2 * column),
                new Vector2Int(2 * row, 2 * column + 1),
                new Vector2Int(2 * row + 1, 2 * column),
                new Vector2Int(2 * row + 1, 2 * column + 1),
            };
        }

        public Domain Splitted()
        {
            return new Domain(Low, High, 2 * RowCount, 2 * ColumnCount);
        }


        public bool ContainsCellCoordinates(Vector2Int cellIndex)
        {
            return 0 <= cellIndex.Row && cellIndex.Row < RowCount &&
                   0 <= cellIndex.Column && cellIndex.Column < ColumnCount;
        }

        public bool IsCellIdValid(int cellId)
        {
            return 0 <= cellId && cellId < RowCount * ColumnCount;
        }
    }
}
