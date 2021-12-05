using System;
using OsipLIB.Geometry;
using OsipLIB.LinearAlgebra;
using OsipLIB.Mappings;

namespace OsipLIB.Graphs
{
    public class SymbolicImageGraph : Graph<Vector2Int>
    {
        private Mapping _f;
        private Domain _domain;

        public SymbolicImageGraph(Mapping f, Domain domain)
        {
            _f = f;
            _domain = domain;

            for (int row = 1; row <= domain.RowCount; row++)
            {
                for (int column = 1; column <= domain.ColumnCount; column++)
                {
                    Vector2Int node = new Vector2Int(row, column);
                    Cell cell = domain.GetCell(node);

                    Vector2[] imagePoints = _f.ApplyToArea(cell);

                    foreach (var imagePoint in imagePoints)
                    {
                        if (_domain.ContainsPoint(imagePoint))
                        {
                            Vector2Int outNode = _domain.GetNode(imagePoint);
                            AddEdge(node, outNode);
                        }
                    }
                }
            }
        }

        private SymbolicImageGraph() : base()
        {
        }

        public Domain Domain => new Domain(_domain);

        public override void AddNode(Vector2Int node)
        {
            if (_domain.ContainsNode(node))
            {
                base.AddNode(node);
            }
            else
            {
                throw new Exception("Node is out of domain");
            }
        }

        public override void AddEdge(Vector2Int node, Vector2Int outNode)
        {
            if (_domain.ContainsNode(node) && _domain.ContainsNode(outNode))
            {
                base.AddEdge(node, outNode);
            }
            else
            {
                throw new Exception("Node is out of domain");
            }
        }

        public SymbolicImageGraph Splitted()
        {
            Domain splittedDomain = _domain.Splitted();

            SymbolicImageGraph splittedGraph = new SymbolicImageGraph();
            splittedGraph._f = _f;
            splittedGraph._domain = splittedDomain;

            foreach (var node in GraphDictionary.Keys)
            {
                Vector2Int[] subNodes = _domain.GetSubNodes(node);
                foreach (var subNode in subNodes)
                {
                    Cell subCell = splittedDomain.GetCell(subNode);

                    Vector2[] imagePoints = _f.ApplyToArea(subCell);

                    foreach (var imagePoint in imagePoints)
                    {
                        if (_domain.ContainsPoint(imagePoint))
                        {
                            Vector2Int nodeBefore = _domain.GetNode(imagePoint);

                            if (GraphDictionary.TryGetValue(nodeBefore, out var value))
                            {
                                Vector2Int outNode = splittedDomain.GetNode(imagePoint);
                                splittedGraph.AddEdge(subNode, outNode);
                            }
                        }
                    }
                }
            }

            return splittedGraph;
        }
    }
}