using System;
using System.Collections.Generic;
using System.Text;
using Task1__CR_set_localisation_CSharp.LinearAlgebra;

namespace Task1__CR_set_localisation_CSharp.Geometry
{
    struct Cell
    {
        public Vector2 Low { get; private set; }
        public Vector2 High { get; private set; }

        public Cell(Vector2 low, Vector2 high)
        {
            Low = low;
            High = high;
        }

    }
}
