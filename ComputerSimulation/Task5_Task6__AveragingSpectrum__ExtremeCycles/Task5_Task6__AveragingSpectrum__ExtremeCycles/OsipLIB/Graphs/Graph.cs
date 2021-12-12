using System;
using System.Collections.Generic;

namespace OsipLIB.Graphs
{
    public class Graph<TNode> where TNode : INode
    {
        public Dictionary<TNode, HashSet<TNode>> GraphDictionary;

        public Graph()
        {
            GraphDictionary = new Dictionary<TNode, HashSet<TNode>>();
        }

        public Graph(Dictionary<TNode, HashSet<TNode>> graph) : this()
        {
            foreach (var item in graph)
            {
                GraphDictionary[item.Key] = new HashSet<TNode>(item.Value);
            }
        }

        public int NodesCount => GraphDictionary.Keys.Count;

        public TNode[] Nodes
        {
            get
            {
                TNode[] nodes = new TNode[GraphDictionary.Count];

                int count = 0;
                foreach (var node in GraphDictionary.Keys)
                {
                    nodes[count] = node;
                    count++;
                }

                return nodes;
            }
        }

        public List<(TNode Source, TNode Destination)> Edges
        {
            get
            {
                var edges = new List<(TNode Source, TNode Destination)>();

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

        public Dictionary<TNode, HashSet<TNode>> TransposedDictionary => GetTransposedDictionary();

        public HashSet<TNode> GetOutNodes(TNode node) => new HashSet<TNode>(GraphDictionary[node]);

        public void DeleteNonReturnableNodes()
        {
            var extraNodes = GetNonReturnableNodes();
            DeleteNodes(extraNodes);
        }

        public List<List<TNode>> GetStronglyConnectedComponents()
        {

            List<List<TNode>> components = new List<List<TNode>>();

            Dictionary<TNode, bool> used = new Dictionary<TNode, bool>();
            List<TNode> order = new List<TNode>();

            foreach (var node in GraphDictionary.Keys)
            {
                if (used.TryGetValue(node, out var value) == false)
                {
                    DFSWithoutRecursion(node, ref used, ref order);
                    // DFS(node, ref used, ref order);
                }
            }

            Dictionary<TNode, HashSet<TNode>> graphT = TransposedDictionary;
            List<TNode> component = new List<TNode>();
            used.Clear();
            for (int i = 0; i < order.Count; i++)
            {
                TNode node = order[order.Count - 1 - i];

                if (used.TryGetValue(node, out var value) == false)
                {
                    TransposedDFSWithoutRecursion(node, ref graphT, ref used, ref component);
                    // TransposedDFS(node, ref graphT, ref used, ref component);
                    components.Add(new List<TNode>(component));
                    component.Clear();
                }
            }

            return components;
        }

        /*** ADDING ***/
        public virtual void AddNode(TNode node)
        {
            if (GraphDictionary.TryGetValue(node, out HashSet<TNode> outNodes))
            {
                outNodes.Add(node);
            }
            else
            {
                GraphDictionary.Add(node, new HashSet<TNode>());
            }
        }

        public virtual void AddEdge(TNode node, TNode outNode)
        {
            if (GraphDictionary.TryGetValue(outNode, out var value) == false)
            {
                GraphDictionary.Add(outNode, new HashSet<TNode>());
            }

            if (GraphDictionary.TryGetValue(node, out HashSet<TNode> outNodes))
            {
                outNodes.Add(outNode);
            }
            else
            {
                GraphDictionary.Add(node, new HashSet<TNode> { outNode });
            }
        }

        /*** REMOVING ***/
        public void DeleteNode(TNode node)
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

        public void DeleteNodes(IEnumerable<TNode> extraNodes)
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
        public List<TNode> ApplyDFS()
        {
            List<TNode> result = new List<TNode>();

            List<List<TNode>> components = GetStronglyConnectedComponents();
            foreach (var component in components)
            {
                foreach (var node in component)
                {
                    result.Add(node);
                }
            }

            return result;
        }

        public List<TNode> MakeDeepFirstSearch(TNode node)
        {
            List<TNode> order = new List<TNode>();
            Dictionary<TNode, bool> used = new Dictionary<TNode, bool>();
            DFSWithoutRecursion(node, ref used, ref order);

            return order;
        }

        protected void DFSWithoutRecursion(TNode node, ref Dictionary<TNode, bool> used, ref List<TNode> order)
        {
            Stack<TNode> memory = new Stack<TNode>();
            memory.Push(node);

            TNode currentNode;

            bool allUsed;
            while (memory.Count > 0)
            {
                allUsed = true;
                currentNode = memory.Peek();
                used[currentNode] = true;

                HashSet<TNode> remainingOutNodes = GraphDictionary[currentNode];

                if (remainingOutNodes.Count > 0)
                {
                    foreach (var outNode in new HashSet<TNode>(remainingOutNodes))
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

/*        private void DFS(TNode node, ref Dictionary<TNode, bool> used, ref List<TNode> order)
        {
            used[node] = true;
            foreach (var outNode in GraphDictionary[node])
            {
                if (used.TryGetValue(outNode, out bool _) == false)
                // if (used[outNode] == false)
                {
                    DFS(outNode, ref used, ref order);
                }
            }

            order.Add(node);
        }*/

        protected void TransposedDFSWithoutRecursion(
            TNode node,
            ref Dictionary<TNode, HashSet<TNode>> graphT,
            ref Dictionary<TNode, bool> used,
            ref List<TNode> component)
        {
            Stack<TNode> memory = new Stack<TNode>();
            memory.Push(node);

            TNode currentNode;
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

                HashSet<TNode> remainingOutNodes = graphT[currentNode];

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

/*        private void TransposedDFS(TNode node,
            ref Dictionary<TNode, HashSet<TNode>> graphT,
            ref Dictionary<TNode, bool> used,
            ref List<TNode> component)
        {
            used[node] = true;
            component.Add(node);
            foreach (var outNode in graphT[node])
            {
                if (used.TryGetValue(outNode, out var _) == false)
                    TransposedDFS(outNode, ref graphT, ref used, ref component);
            } 
        }*/

        /*** ***/
        private List<TNode> GetNonReturnableNodes()
        {
            List<List<TNode>> stronglyConnectedComponents = GetStronglyConnectedComponents();
            List<TNode> nonReturnableNodes = new List<TNode>();

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

        private Dictionary<TNode, HashSet<TNode>> GetTransposedDictionary()
        {
            var graphT = new Dictionary<TNode, HashSet<TNode>>();

            foreach (TNode node in GraphDictionary.Keys)
            {
                if (graphT.TryGetValue(node, out var value) == false)
                {
                    graphT[node] = new HashSet<TNode>();
                }

                var outNodes = GraphDictionary[node];

                if (outNodes.Count == 0)
                {
                    graphT[node] = new HashSet<TNode>();
                    continue;
                }

                foreach (TNode outNode in outNodes)
                {
                    if (graphT.TryGetValue(outNode, out var outOutNodes))
                    {
                        outOutNodes.Add(node);
                    }
                    else
                    {
                        graphT.Add(outNode, new HashSet<TNode> { node });
                    }
                }
            }

            return graphT;
        }

        private bool ContainsNode(TNode node)
        {
            return GraphDictionary.TryGetValue(node, out var value);
        }
    }
}