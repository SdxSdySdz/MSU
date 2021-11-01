using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public Cell GetCell(Vector2Int node)
        {
            if (ContainsNode(node) == false) throw new Exception("Domain does not contain this node");

            Vector2 low = new Vector2(node.Column * ColumnSplitting, node.Row * RowSplitting);
            Vector2 high = new Vector2((node.Column + 1) * ColumnSplitting, (node.Row + 1) * RowSplitting);

            return new Cell(low + Low, high + Low);
        }

        // TODO: if point.x or point.y belongs to the integer grid
        public Vector2Int GetNode(Vector2 point)
        {
            point = point - Low;
            point = point / Splitting + Vector2.One;
            
            return new Vector2Int((int)point.y, (int)point.x);
        }

        public Vector2Int[] GetSubNodes(Vector2Int node)
        {
            int row = node.Row;
            int column = node.Column;

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


        public bool ContainsNode(Vector2Int node)
        {
            return 0 <= node.Row && node.Row < RowCount &&
                   0 <= node.Column && node.Column < ColumnCount;
        }


        public bool ContainsPoint(Vector2 point)
        {
            return Low.x <= point.x && point.x < High.x &&
                   Low.y <= point.y && point.y < High.y;
        }
        /*        public bool ContainsPoint(Vector2 point)
                {
                    return Low.x <= point.x && point.x <= High.x &&
                           Low.y <= point.y && point.y <= High.y;
                }*/
    }
}
