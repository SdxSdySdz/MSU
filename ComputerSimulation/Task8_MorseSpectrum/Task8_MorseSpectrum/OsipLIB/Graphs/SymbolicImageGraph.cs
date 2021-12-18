using System;
using System.Collections.Generic;
using System.Linq;
using OsipLIB.Geometry;
using OsipLIB.LinearAlgebra;
using OsipLIB.Mappings;

namespace OsipLIB.Graphs
{
    public class SymbolicImageGraph : Graph<Vector2Int>
    {
        private Mapping _f;
        private Domain _domain;

        private SymbolicImageGraph() : base()
        {
        }

        public SymbolicImageGraph(Mapping f, Domain domain)
        {
            _f = f;
            _domain = domain;

            for (int row = 0; row < domain.RowCount; row++)
            {
                for (int column = 0; column < domain.ColumnCount; column++)
                {
                    Vector2Int sourceCoordinates = new Vector2Int(row, column);
                    Cell cell = domain.GetCell(sourceCoordinates);

                    Vector2[] imagePoints = _f.ApplyToArea(cell);

                    foreach (var imagePoint in imagePoints)
                    {
                        if (_domain.TryGetCellCoordinates(imagePoint, out Vector2Int outCoordinates))
                        {
                            AddEdge(sourceCoordinates, outCoordinates);
                        }
                    }
                }
            }
        }

        public Domain Domain => new Domain(_domain);

        public override void AddNode(Vector2Int node)
        {
            if (_domain.ContainsCellCoordinates(node))
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
            if (_domain.ContainsCellCoordinates(node) && _domain.ContainsCellCoordinates(outNode))
            {
                base.AddEdge(node, outNode);
            }
            else
            {
                throw new Exception($"Edge [{node} -> {outNode}] is out of domain");
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
                        if (IsPointInSymbolicImage(imagePoint))
                        {
                            if (splittedDomain.TryGetCellCoordinates(imagePoint, out Vector2Int outCoordinates))
                            {
                                splittedGraph.AddEdge(subNode, outCoordinates);
                            }
                        }
                    }
                }
            }

            return splittedGraph;
        }

        public List<Cell> GetCells()
        {
            return GraphDictionary.Keys.Select(node => _domain.GetCell(node)).ToList();
        }

        private bool IsPointInSymbolicImage(Vector2 point)
        {
            return _domain.TryGetCellCoordinates(point, out Vector2Int sourceCoordinates) &&
                    GraphDictionary.TryGetValue(sourceCoordinates, out var _);
        }
    }
}