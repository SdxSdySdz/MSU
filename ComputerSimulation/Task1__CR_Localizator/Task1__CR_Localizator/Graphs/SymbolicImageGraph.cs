using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1__CR_Localizator.Geometry;
using Task1__CR_Localizator.Homeomorphisms;
using Task1__CR_Localizator.LinearAlgebra;

namespace Task1__CR_Localizator.Graphs
{
    class SymbolicImageGraph : Graph
    {
        private Homeomorphism _f;
        private Domain _domain;

        public Domain Domain => new Domain(_domain);


        public SymbolicImageGraph(Homeomorphism f, Domain domain)
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
                    // imagePoints = _domain.Filter(imagePoints);

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


        private SymbolicImageGraph() : base() { }


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
            

            foreach (var node in _graph.Keys)
            {
                Vector2Int[] subNodes = _domain.GetSubNodes(node);
                foreach (var subNode in subNodes)
                {
                    Cell subCell = splittedDomain.GetCell(subNode);

                    Vector2[] imagePoints = _f.ApplyToArea(subCell);
                    //imagePoints = splittedDomain.Filter(imagePoints);

                    foreach (var imagePoint in imagePoints)
                    {
                        if (_domain.ContainsPoint(imagePoint))
                        {
                            Vector2Int nodeBefore = _domain.GetNode(imagePoint);

                            if (_graph.TryGetValue(nodeBefore, out var value))
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
