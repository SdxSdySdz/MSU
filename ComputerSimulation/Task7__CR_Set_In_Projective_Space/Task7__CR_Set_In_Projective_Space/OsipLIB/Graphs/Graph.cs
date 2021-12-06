using System;
using System.Collections.Generic;

namespace OsipLIB.Graphs
{
    public class Graph<T> where T : INode
    {
        protected Dictionary<T, HashSet<T>> GraphDictionary;

        public int NodesCount => GraphDictionary.Keys.Count;

        public T[] Nodes
        {
            get
            {
                T[] nodes = new T[GraphDictionary.Count];

                int count = 0;
                foreach (var node in GraphDictionary.Keys)
                {
                    nodes[count] = node;
                    count++;
                }

                return nodes;
            }
        }

        public List<(T Source, T Destination)> Edges
        {
            get
            {
                var edges = new List<(T Source, T Destination)>();

                foreach (var node in GraphDictionary.Keys)
                {
                    foreach (var outNode in GraphDictionary[node])
                    {
                        edges.Add((node, outNode));
                    }
                }

                return edges;
            }
        }

        public Dictionary<T, HashSet<T>> TransposedDictionary => GetTransposedDictionary();

        public Graph()
        {
            GraphDictionary = new Dictionary<T, HashSet<T>>();
        }

        public Graph(Dictionary<T, HashSet<T>> graph) : this()
        {
            foreach (var item in graph)
            {
                GraphDictionary[item.Key] = new HashSet<T>(item.Value);
            }
        }

        public HashSet<T> GetOutNodes(T node) => new HashSet<T>(GraphDictionary[node]);

        public void DeleteNonReturnableNodes()
        {
            var extraNodes = GetNonReturnableNodes();
            DeleteNodes(extraNodes);
        }

        public List<T> ApplyDFS()
        {
            List<T> result = new List<T>();

            List<List<T>> components = GetStronglyConnectedComponents();
            foreach (var component in components)
            {
                foreach (var node in component)
                {
                    result.Add(node);
                }
            }

            return result;
        }

        /*** ADDING ***/
        public virtual void AddNode(T node)
        {
            if (GraphDictionary.TryGetValue(node, out HashSet<T> outNodes))
            {
                outNodes.Add(node);
            }
            else
            {
                GraphDictionary.Add(node, new HashSet<T>());
            }
        }

        public virtual void AddEdge(T node, T outNode)
        {
            if (GraphDictionary.TryGetValue(outNode, out var value) == false)
            {
                GraphDictionary.Add(outNode, new HashSet<T>());
            }

            if (GraphDictionary.TryGetValue(node, out HashSet<T> outNodes))
            {
                outNodes.Add(outNode);
            }
            else
            {
                GraphDictionary.Add(node, new HashSet<T> { outNode });
            }
        }

        /*** REMOVING ***/
        public void DeleteNode(T node)
        {
            if (ContainsNode(node) == false)
            {
                throw new Exception("Can not delete node");
            }

            GraphDictionary.Remove(node);

            foreach (var outNodes in GraphDictionary.Values)
            {
                outNodes.Remove(node);
            }
        }

        public void DeleteNodes(IEnumerable<T> extraNodes)
        {
            foreach (var extraNode in extraNodes)
            {
                DeleteNode(extraNode);
            }
        }

        public override string ToString()
        {
            string graphStr = string.Empty;
            foreach (var node in GraphDictionary.Keys)
            {
                graphStr += $"{node} {{";
                foreach (var outNode in GraphDictionary[node])
                {
                    graphStr += $"{outNode} ";
                }

                graphStr += "}\n";
            }

            return graphStr;
        }

        /*** DFS ***/
        public List<T> MakeDeepFirstSearch(T node)
        {
            List<T> order = new List<T>();
            Dictionary<T, bool> used = new Dictionary<T, bool>();
            DFSWithoutRecursion(node, ref used, ref order);

            return order;
        }

        protected void DFSWithoutRecursion(T node, ref Dictionary<T, bool> used, ref List<T> order)
        {
            Stack<T> memory = new Stack<T>();
            memory.Push(node);

            T currentNode;

            bool allUsed;
            while (memory.Count > 0)
            {
                allUsed = true;
                currentNode = memory.Peek();
                used[currentNode] = true;

                HashSet<T> remainingOutNodes = GraphDictionary[currentNode];

                if (remainingOutNodes.Count > 0)
                {
                    foreach (var outNode in new HashSet<T>(remainingOutNodes))
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

        protected void TransposedDFSWithoutRecursion(
            T node,
            ref Dictionary<T, HashSet<T>> graphT,
            ref Dictionary<T, bool> used,
            ref List<T> component)
        {
            Stack<T> memory = new Stack<T>();
            memory.Push(node);

            T currentNode;
            bool allUsed;
            while (memory.Count > 0)
            {
                allUsed = true;
                currentNode = memory.Peek();

                if (used.TryGetValue(currentNode, out var _) == false)
                {
                    component.Add(currentNode);
                    used[currentNode] = true;
                }

                HashSet<T> remainingOutNodes = graphT[currentNode];

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
        private List<T> GetNonReturnableNodes()
        {
            List<List<T>> stronglyConnectedComponents = GetStronglyConnectedComponents();
            List<T> nonReturnableNodes = new List<T>();

            foreach (var component in stronglyConnectedComponents)
            {
                if (component.Count == 1)
                {
                    var node = component[0];
                    if (GraphDictionary[node].Contains(node) == false)
                    {
                        nonReturnableNodes.Add(node);
                    }
                }
            }

            return nonReturnableNodes;
        }

        private List<List<T>> GetStronglyConnectedComponents()
        {

            List<List<T>> components = new List<List<T>>();

            Dictionary<T, bool> used = new Dictionary<T, bool>();
            List<T> order = new List<T>();

            foreach (var node in GraphDictionary.Keys)
            {
                if (used.TryGetValue(node, out var value) == false)
                {
                    DFSWithoutRecursion(node, ref used, ref order);
                }
            }

            Dictionary<T, HashSet<T>> graphT = TransposedDictionary;
            List<T> component = new List<T>();
            used.Clear();
            for (int i = 0; i < order.Count; i++)
            {
                T node = order[order.Count - 1 - i];

                if (used.TryGetValue(node, out var value) == false)
                {
                    TransposedDFSWithoutRecursion(node, ref graphT, ref used, ref component);
                    components.Add(new List<T>(component));
                    component.Clear();
                }
            }

            return components;
        }

        private Dictionary<T, HashSet<T>> GetTransposedDictionary()
        {
            var graphT = new Dictionary<T, HashSet<T>>();

            foreach (T node in GraphDictionary.Keys)
            {
                if (graphT.TryGetValue(node, out var value) == false)
                {
                    graphT[node] = new HashSet<T>();
                }

                var outNodes = GraphDictionary[node];

                if (outNodes.Count == 0)
                {
                    graphT[node] = new HashSet<T>();
                    continue;
                }

                foreach (T outNode in outNodes)
                {
                    if (graphT.TryGetValue(outNode, out var outOutNodes))
                    {
                        outOutNodes.Add(node);
                    }
                    else
                    {
                        graphT.Add(outNode, new HashSet<T> { node });
                    }
                }
            }

            return graphT;
        }

        private bool ContainsNode(T node)
        {
            return GraphDictionary.TryGetValue(node, out var value);
        }
    }
}