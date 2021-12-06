using System.Collections.Generic;
using System.Linq;

namespace OsipLIB.Graphs.Tools
{
    public static class TopologicalSorter
    {
        public static NodesSubstitution Sort(SymbolicImageGraph graph)
        {
            IEnumerable<INode> newNodes = graph
                                            .ApplyDFS()
                                            .Select(node => (INode)node);
            IEnumerable<INode> previousNodes = graph.Nodes
                                                .OrderBy(graph.Domain.GetCellId)
                                                .Select(node => (INode)node);

            return new NodesSubstitution(previousNodes, newNodes);
        }
    }
}
