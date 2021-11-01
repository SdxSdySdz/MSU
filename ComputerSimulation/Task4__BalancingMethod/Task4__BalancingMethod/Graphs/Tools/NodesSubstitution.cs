using OsipLIB.Graphs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsipLIB.Graphs.Tools
{
    class NodesSubstitution : IEnumerable<(Node PreviousNode, Node NewNode)>
    {
        private Dictionary<Node, Node> _substitution;


        public NodesSubstitution(IEnumerable<Node> previousNodes, IEnumerable<Node> newNodes)
        {
            if (previousNodes.Count() != newNodes.Count())
            {
                throw new Exception("Can`t create substitution because there are containers that has different lengths");
            }

            var previousNodesSet = new HashSet<Node>(previousNodes);
            var newNodesSet = new HashSet<Node>(newNodes);
            if (previousNodesSet.SetEquals(newNodesSet) == false)
            {
                throw new Exception("Can`t create substitution because there are containers that has different contents");
            }

            _substitution = new Dictionary<Node, Node>();
            Match(previousNodes.ToList(), newNodes.ToList());
        }


        public override string ToString()
        {
            string result = "";
            foreach (var item in _substitution)
            {
                result += $"{item.Key} -> {item.Value}\n";
            }

            return result;
        }


        public IEnumerator<(Node PreviousNode, Node NewNode)> GetEnumerator()
        {
            foreach (var item in _substitution)
            {
                yield return (item.Key, item.Value);
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        private void Match(List<Node> previousNodes, List<Node> newNodes)
        {
            for (int i = 0; i < previousNodes.Count; i++)
            {
                _substitution[previousNodes[i]] = newNodes[i];
            }
        }
    }
}
