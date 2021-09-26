using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Task1__CR_Localizator.Geometry;
using Task1__CR_Localizator.Graphs;
using Task1__CR_Localizator.Homeomorphisms;

namespace Task1__CR_Localizator
{
    class CR_SetLocalizator
    {
        private int _iterarionMaxCount;
        private Stopwatch _stopWatch;


        public CR_SetLocalizator(int iterarionsMaxCount)
        {
            if (iterarionsMaxCount < 1)
            {
                throw new Exception("Iterarions max count should be > 0");
            }

            _iterarionMaxCount = iterarionsMaxCount;
            _stopWatch = new Stopwatch();
        }

        public IEnumerable<SymbolicImageGraph> Solve(Homeomorphism f, Domain domain)
        {
            SymbolicImageGraph graph = new SymbolicImageGraph(f, domain);

            for (int iteraionCount = 0; iteraionCount < _iterarionMaxCount; iteraionCount++)
            {
                Console.WriteLine($"===Iteration {iteraionCount + 1}===");

                DeleteNonReturnableVertexes(ref graph);

                graph = graph.Splitted();
                yield return graph;
            }

            yield break;
        }


        private void DeleteNonReturnableVertexes(ref SymbolicImageGraph graph)
        {
            _stopWatch.Start();
            graph.DeleteNonReturnableNodes();
            _stopWatch.Stop();

            Console.WriteLine($"Deleting non-returnable vertexes {_stopWatch.ElapsedMilliseconds}");

            if (graph.NodesCount > 0)
            {
                throw new Exception("There is no attractors in the domain");
            }
        }


        private void Split(ref SymbolicImageGraph graph)
        {
            _stopWatch.Start();
            graph = graph.Splitted();
            _stopWatch.Stop();

            Console.WriteLine($"Splitting {_stopWatch.ElapsedMilliseconds}");
        }
    }
}
