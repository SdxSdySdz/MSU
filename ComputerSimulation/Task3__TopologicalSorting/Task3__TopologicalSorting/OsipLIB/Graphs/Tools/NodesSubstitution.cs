using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OsipLIB.Graphs.Tools
{
    public class NodesSubstitution : IEnumerable<(INode PreviousNode, INode NewNode)>
    {
        private Dictionary<INode, INode> _substitution;

        public NodesSubstitution(IEnumerable<INode> previousNodes, IEnumerable<INode> newNodes)
        {
            if (previousNodes.Count() != newNodes.Count())
            {
                throw new Exception("Can`t create substitution because there are containers that has different lengths");
            }

            var previousNodesSet = new HashSet<INode>(previousNodes);
            var newNodesSet = new HashSet<INode>(newNodes);
            if (previousNodesSet.SetEquals(newNodesSet) == false)
            {
                throw new Exception("Can`t create substitution because there are containers that has different contents");
            }

            _substitution = new Dictionary<INode, INode>();
            Match(previousNodes.ToList(), newNodes.ToList());
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var item in _substitution)
            {
                result += $"{item.Key} -> {item.Value}\n";
            }

            return result;
        }

        public IEnumerator<(INode PreviousNode, INode NewNode)> GetEnumerator()
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

        private void Match(List<INode> previousNodes, List<INode> newNodes)
        {
            for (int i = 0; i < previousNodes.Count; i++)
            {
                _substitution[previousNodes[i]] = newNodes[i];
            }
        }
    }
}
