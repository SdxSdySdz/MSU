using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1__CR_Localizator.LinearAlgebra;

namespace Task1__CR_Localizator.Graphs
{
    class Graph
    {
        protected Dictionary<Vector2Int, HashSet<Vector2Int>> _graph;


        public int NodesCount => _graph.Keys.Count;
        public Vector2Int[] Nodes
        {
            get
            {
                Vector2Int[] nodes = new Vector2Int[_graph.Count];

                int count = 0;
                foreach (var node in _graph.Keys)
                {
                    nodes[count] = new Vector2Int(node);
                    count++;
                }

                return nodes;
            }
        }
        public List<List<Vector2Int>> StronglyConnectedComponents
        {
            get
            {
                List<List<Vector2Int>> components = new List<List<Vector2Int>>();

                Dictionary<Vector2Int, bool> used = new Dictionary<Vector2Int, bool>();
                List<Vector2Int> order = new List<Vector2Int>();

                foreach (var node in _graph.Keys)
                {
                    if (used.TryGetValue(node, out var value) == false)
                    {
                        // DFS1(node, ref used, ref order);
                        DFS1WithoutRecursion(node, ref used, ref order);
                    }
                }

                Dictionary<Vector2Int, HashSet<Vector2Int>> graphT = TransposedDictionary;
                List<Vector2Int> component = new List<Vector2Int>();
                used.Clear();
                for (int i = 0; i < order.Count; i++)
                {
                    Vector2Int node = order[order.Count - 1 - i];

                    if (used.TryGetValue(node, out var value) == false)
                    {
                        DFS2(node, ref graphT, ref used, ref component);
                        components.Add(new List<Vector2Int>(component));
                        component.Clear();
                    }
                }

                return components;
            }
        }
        public List<Vector2Int> ReturnableNodes
        {
            get
            {
                List<List<Vector2Int>> stronglyConnectedComponents = StronglyConnectedComponents;
                List<Vector2Int> returnableNodes = new List<Vector2Int>();

                foreach (var component in StronglyConnectedComponents)
                {
                    if (component.Count == 1)
                    {
                        var node = component[0];
                        if (_graph[node].Contains(node))
                        {
                            returnableNodes.Add(node);
                        }

                        continue;
                    }

                    foreach (var node in component)
                    {
                        returnableNodes.Add(node);
                    }
                }

                return returnableNodes;
            }
        }
        public List<Vector2Int> NonReturnableNodes
        {
            get
            {
                List<List<Vector2Int>> stronglyConnectedComponents = StronglyConnectedComponents;
                List<Vector2Int> nonReturnableNodes = new List<Vector2Int>();

                foreach (var component in StronglyConnectedComponents)
                {
                    if (component.Count == 1)
                    {
                        var node = component[0];
                        if (_graph[node].Contains(node) == false)
                        {
                            nonReturnableNodes.Add(node);
                        }
                    }
                }

                return nonReturnableNodes;
            }
        }
        public Dictionary<Vector2Int, HashSet<Vector2Int>> TransposedDictionary
        {
            get
            {
                var graphT = new Dictionary<Vector2Int, HashSet<Vector2Int>>();

                foreach (Vector2Int node in _graph.Keys)
                {
                    if (graphT.TryGetValue(node, out var value) == false)
                    {
                        graphT[node] = new HashSet<Vector2Int>();
                    }

                    var outNodes = _graph[node];

                    if (outNodes.Count == 0)
                    {
                        graphT[node] = new HashSet<Vector2Int>();
                        continue;
                        // throw new NotImplementedException();
                    }



                    foreach (Vector2Int outNode in outNodes)
                    {

                        if (graphT.TryGetValue(outNode, out var outOutNodes))
                        {
                            outOutNodes.Add(node);
                            
                        }
                        else
                        {
                            graphT.Add(outNode, new HashSet<Vector2Int> { node });
                        }
                    }
                }

                return graphT;
            }
        }

        public Graph()
        {
            _graph = new Dictionary<Vector2Int, HashSet<Vector2Int>>();
        }


        public Graph(Dictionary<Vector2Int, HashSet<Vector2Int>> graph) : this()
        {
            foreach (var item in graph)
            {
                _graph[item.Key] = new HashSet<Vector2Int>(item.Value);
            }
        }


        public bool CheckAllOutNodesAreContainedInGraph()
        {
            foreach (var outNodes in _graph.Values)
            {
                foreach (var outNode in outNodes)
                {
                    if (_graph.TryGetValue(outNode, out var value) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        public HashSet<Vector2Int> GetOutNodes(Vector2Int node) => new HashSet<Vector2Int>(_graph[node]);


        public void DeleteNonReturnableNodes()
        {
            DeleteNodes(NonReturnableNodes);
        }


        /*** ADDING ***/
        public void AddNode(int row, int column)
        {
            AddNode(new Vector2Int(row, column));
        }


        public virtual void AddNode(Vector2Int node)
        {
            if (_graph.TryGetValue(node, out HashSet<Vector2Int> outNodes))
            {
                outNodes.Add(node);
            }
            else
            {
                _graph.Add(node, new HashSet<Vector2Int>());
            }
        }


        public void AddEdge(int fromRow, int fromColumn, int toRow, int toColumn)
        {
            AddEdge(new Vector2Int(fromRow, fromColumn), new Vector2Int(toRow, toColumn));
        }


        public virtual void AddEdge(Vector2Int node, Vector2Int outNode)
        {
            if (_graph.TryGetValue(outNode, out var value) == false)
            {
                _graph.Add(outNode, new HashSet<Vector2Int>());
            }

            if (_graph.TryGetValue(node, out HashSet<Vector2Int> outNodes))
            {
                outNodes.Add(outNode);
            }
            else
            {
                _graph.Add(node, new HashSet<Vector2Int> { outNode });
            }
        }


        /*** REMOVING ***/


        public void DeleteNode(Vector2Int node)
        {
            if (ContainsNode(node) == false)
            {
                throw new Exception("Can not delete node");
            }

            _graph.Remove(node);

            foreach (var outNodes in _graph.Values)
            {
                outNodes.Remove(node);
            }
        }


        public void DeleteNodes(IEnumerable<Vector2Int> extraNodes)
        {
            foreach (var extraNode in extraNodes)
            {
                DeleteNode(extraNode);
            }
        }


        public override string ToString()
        {
            string graphStr = "";
            foreach (var node in _graph.Keys)
            {
                graphStr += $"{node} {{";
                foreach (var outNode in _graph[node])
                {
                    graphStr += $"{outNode} ";
                }

                graphStr += "}\n";
            }

            return graphStr;
        }


        protected void DFS1(Vector2Int node, ref Dictionary<Vector2Int, bool> used, ref List<Vector2Int> order)
        {
            used[node] = true;

            foreach (var outNode in _graph[node])
            {
                if (used.TryGetValue(outNode, out var value) == false)
                {
                    DFS1(outNode, ref used, ref order);
                }
            }

            order.Add(node);
        }


        public void DFS1WithoutRecursion(Vector2Int node, ref Dictionary<Vector2Int, bool> used, ref List<Vector2Int> order)
        {
            Stack<(Vector2Int, HashSet<Vector2Int>)> memory = new Stack<(Vector2Int, HashSet<Vector2Int>)>();
            memory.Push((node, new HashSet<Vector2Int>(_graph[node])));

            Vector2Int currentNode;
            
            bool allUsed;
            while (memory.Count > 0)
            {
                allUsed = true;
                HashSet<Vector2Int> remainingOutNodes = new HashSet<Vector2Int>();

                (currentNode, remainingOutNodes) = memory.Peek();
                used[currentNode] = true;

                if (remainingOutNodes.Count > 0)
                {
                    foreach (var outNode in new HashSet<Vector2Int>(remainingOutNodes))
                    {
                        //remainingOutNodes.Remove(outNode); ?????????????????????

                        if (used.TryGetValue(outNode, out var value) == false)
                        {
                            allUsed = false;
                            memory.Push((outNode, _graph[outNode]));
                            currentNode = outNode;
                            break;
                            // DFS1(outNode, ref used, ref order);
                        }
                    }
                }

                if (allUsed)
                {
                    order.Add(currentNode);
                    memory.Pop();
                }
            }
        }


        protected void DFS2(Vector2Int node, ref Dictionary<Vector2Int, HashSet<Vector2Int>> graphT, ref Dictionary<Vector2Int, bool> used, ref List<Vector2Int> component)
        {
            used[node] = true;
            component.Add(node);

            foreach (var outNode in graphT[node])
            {
                if (used.TryGetValue(outNode, out var value) == false)
                {
                    DFS2(outNode, ref graphT, ref used, ref component);
                }
            }
        }

        
        private bool ContainsNode(Vector2Int node)
        {
            return _graph.TryGetValue(node, out var value);
        }
    }
}
