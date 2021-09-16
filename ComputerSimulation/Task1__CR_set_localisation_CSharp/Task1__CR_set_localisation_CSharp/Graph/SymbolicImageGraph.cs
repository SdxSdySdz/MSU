using System;
using System.Collections.Generic;
using System.Text;
using Task1__CR_set_localisation_CSharp.Geometry;
using Task1__CR_set_localisation_CSharp.LinearAlgebra;

namespace Task1__CR_set_localisation_CSharp.Graph
{
    class SymbolicImageGraph
    {
        private Dictionary<int, HashSet<int>> _graph;


        public SymbolicImageGraph(Homemorphism f, Domain domain)
        {
            _graph = new Dictionary<int, HashSet<int>>();

            foreach (var cell_id in _graph.Keys)
            {
                Vector2[] imagePoints = f.ApplyToCell(domain.GetCell(cell_id));
            }

            
        }


        public void DeleteNonReturnableNodes(out bool successfullyDeleted)
        {
            throw new NotImplementedException();
        }
    }
}
