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
        /*public static NodesSubstitution Sort(SymbolicImageGraph graph)
        {
            IEnumerable<Node> newNodes = graph
                                            .ApplyDFS()
                                            .Select(node => (Node)node);
            IEnumerable<Node> previousNodes = graph.Nodes
                                                .OrderBy(graph.Domain.GetCellId)
                                                .Select(node => (Node)node);
            

            return new NodesSubstitution(previousNodes, newNodes);
        }*/
    }
}
