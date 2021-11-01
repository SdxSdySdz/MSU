using System;
using OsipLIB.Geometry;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Graphs.Tools
{
    public static class NodeTransformer
    {
        public static Node Transform(Vector2Int cellCoordinates, Domain domain)
        {
            if (domain.ContainsNode(cellCoordinates) == false) throw new IndexOutOfRangeException();
            return new Node(cellCoordinates.Column + domain.ColumnCount * cellCoordinates.Row);
        }

        public static Vector2Int TransformNode(Node node, Domain domain)
        {
            int id = node.Id;

            int row = id / domain.ColumnCount;
            int column = id - domain.ColumnCount * row;

            return new Vector2Int(row, column);
        }
    }
}