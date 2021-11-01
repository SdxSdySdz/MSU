using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsipLIB.LinearAlgebra;
using OsipLIB.Graphs;

namespace OsipLIB.Graphs
{
    public class Graph
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

        public List<(Vector2Int Source, Vector2Int Destination)> Edges
        {
            get
            {
                var edges = new List<(Vector2Int Source, Vector2Int Destination)>();

                foreach (var node in _graph.Keys)
                {
                    foreach (var outNode in _graph[node])
                    {
                        edges.Add((node, outNode));
                    }
                }

                return edges;
            }
        }

        public Dictionary<Vector2Int, HashSet<Vector2Int>> TransposedDictionary => GetTransposedDictionary();

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


        public HashSet<Vector2Int> GetOutNodes(Vector2Int node) => new HashSet<Vector2Int>(_graph[node]);


        public void DeleteNonReturnableNodes()
        {
            var extraNodes = GetNonReturnableNodes();
            DeleteNodes(extraNodes);
        }


        private List<Vector2Int> GetNonReturnableNodes()
        {
            List<List<Vector2Int>> stronglyConnectedComponents = GetStronglyConnectedComponents();
            List<Vector2Int> nonReturnableNodes = new List<Vector2Int>();

            foreach (var component in stronglyConnectedComponents)
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


        public List<Vector2Int> ApplyDFS()
        {
            List<Vector2Int> result = new List<Vector2Int>();

            List<List<Vector2Int>> components = GetStronglyConnectedComponents();
            foreach (var component in components)
            {
                foreach (var node in component)
                {
                    result.Add(node);
                }
            }

            return result;
        }


        private List<List<Vector2Int>> GetStronglyConnectedComponents()
        {

            List<List<Vector2Int>> components = new List<List<Vector2Int>>();

            Dictionary<Vector2Int, bool> used = new Dictionary<Vector2Int, bool>();
            List<Vector2Int> order = new List<Vector2Int>();

            foreach (var node in _graph.Keys)
            {
                if (used.TryGetValue(node, out var value) == false)
                {
                    DFSWithoutRecursion(node, ref used, ref order);
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
                    TransposedDFSWithoutRecursion(node, ref graphT, ref used, ref component);
                    components.Add(new List<Vector2Int>(component));
                    component.Clear();
                }
            }

            return components;

        }


        /*** ADDING ***/
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


        /*** DFS ***/
        public List<Vector2Int> MakeDeepFirstSearch(Vector2Int node)
        {
            List<Vector2Int> order = new List<Vector2Int>();
            Dictionary<Vector2Int, bool> used = new Dictionary<Vector2Int, bool>();
            DFSWithoutRecursion(node, ref used, ref order);

            return order;
        }


        protected void DFSWithoutRecursion(Vector2Int node, ref Dictionary<Vector2Int, bool> used, ref List<Vector2Int> order)
        {
            Stack<Vector2Int> memory = new Stack<Vector2Int>();
            memory.Push(node);

            Vector2Int currentNode;

            bool allUsed;
            while (memory.Count > 0)
            {
                allUsed = true;
                currentNode = memory.Peek();
                used[currentNode] = true;

                HashSet<Vector2Int> remainingOutNodes = _graph[currentNode];

                if (remainingOutNodes.Count > 0)
                {
                    foreach (var outNode in new HashSet<Vector2Int>(remainingOutNodes))
                    {
                        if (used.TryGetValue(outNode, out var value) == false)
                        {
                            allUsed = false;
                            memory.Push(outNode);
                            currentNode = outNode;
                            break;
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


        protected void TransposedDFSWithoutRecursion(Vector2Int node, ref Dictionary<Vector2Int, HashSet<Vector2Int>> graphT, ref Dictionary<Vector2Int, bool> used, ref List<Vector2Int> component)
        {
            Stack<Vector2Int> memory = new Stack<Vector2Int>();
            memory.Push(node);

            Vector2Int currentNode;
            bool allUsed;
            while (memory.Count > 0)
            {
                allUsed = true;
                currentNode = memory.Peek();



                // component.Add(currentNode);

                if (used.TryGetValue(currentNode, out var _) == false)
                {
                    component.Add(currentNode);
                    used[currentNode] = true;
                }
                
                

                HashSet<Vector2Int> remainingOutNodes = graphT[currentNode];

                if (remainingOutNodes.Count > 0)
                {
                    foreach (var outNode in remainingOutNodes)
                    {
                        if (used.TryGetValue(outNode, out var value) == false)
                        {
                            allUsed = false;
                            memory.Push(outNode);
                            break;
                        }
                    }
                }


                if (allUsed)
                {
                    memory.Pop();
                }
            }
        }


        /*** ***/
        private Dictionary<Vector2Int, HashSet<Vector2Int>> GetTransposedDictionary()
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


        private bool ContainsNode(Vector2Int node)
        {
            return _graph.TryGetValue(node, out var value);
        }
    }
}
