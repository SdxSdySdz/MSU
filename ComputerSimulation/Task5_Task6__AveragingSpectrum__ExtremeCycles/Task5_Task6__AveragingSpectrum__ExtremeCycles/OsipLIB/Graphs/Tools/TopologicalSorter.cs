using OsipLIB.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsipLIB.Graphs.Tools
{
    static class TopologicalSorter
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
