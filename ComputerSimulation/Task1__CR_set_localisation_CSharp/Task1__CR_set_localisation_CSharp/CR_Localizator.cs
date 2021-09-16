using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using Task1__CR_set_localisation_CSharp.Geometry;
using Task1__CR_set_localisation_CSharp.Graph;

namespace Task1__CR_set_localisation_CSharp
{
    class CR_Localizator
    {
        
        private int _iterationsMaxCount;
        private SymbolicImageGraph _graph;
        private Stopwatch _stopwatch;

        public CR_Localizator(int iterationsMaxCount)
        {
            _iterationsMaxCount = iterationsMaxCount;
        }
        
        public void Solve(Homemorphism f, Domain domain)
        {
            int iterationNumber = 0;

            while (iterationNumber < _iterationsMaxCount)
            {
                Console.WriteLine($"===Iteration {iterationNumber}===");

                ConstructGraph(f, domain);

                DeleteNonReturnableNodes();

                domain.Split();
            }
        }

        private void ConstructGraph(Homemorphism f, Domain domain)
        {
            _stopwatch.Start();
            _graph = new SymbolicImageGraph(f, domain);
            _stopwatch.Stop();

            Console.WriteLine($"Construct Symbolic Image Graph  {_stopwatch.ElapsedMilliseconds / 100.0}");
        }

        private void DeleteNonReturnableNodes()
        {
            _stopwatch.Start();
            _graph.DeleteNonReturnableNodes(out bool successfullyDeleted);
            _stopwatch.Stop();
            if (successfullyDeleted == false)
            {
                throw new NotImplementedException();
            }

            Console.WriteLine($"Delete non-returnable vertexes {_stopwatch.ElapsedMilliseconds}");
        }
    }
}
