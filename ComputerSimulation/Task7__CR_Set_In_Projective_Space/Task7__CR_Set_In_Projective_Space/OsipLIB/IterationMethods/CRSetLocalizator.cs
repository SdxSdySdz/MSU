using System.Collections;
using System.Collections.Generic;
using OsipLIB.Geometry;
using OsipLIB.Graphs;
using OsipLIB.Mappings;

namespace OsipLIB.IterationMethods
{
    public static class CRSetLocalizator
    {
        public static SymbolicImageGraph MakeIterations(Mapping f, Domain domain, int maxIterationsCount)
        {
            SymbolicImageGraph graph = new SymbolicImageGraph(f, domain);
            for (int i = 0; i < maxIterationsCount; i++)
            {
                graph.DeleteNonReturnableNodes();
                graph = graph.Splitted();
            }

            return graph;
        }
        
        public static IEnumerable<SymbolicImageGraph> MakeIterationsStepByStep(Mapping f, Domain domain, int maxIterationsCount)
        {
            SymbolicImageGraph graph = new SymbolicImageGraph(f, domain);
            for (int i = 0; i < maxIterationsCount; i++)
            {
                graph.DeleteNonReturnableNodes();
                yield return graph;
                
                graph = graph.Splitted();
            }

            yield return graph;
        }
    }
}