using System;
using Task1__CR_set_localisation_CSharp.LinearAlgebra;

namespace Task1__CR_set_localisation_CSharp.Geometry
{
    struct Cell
    {
        public Vector2 Low { get; private set; }
        public Vector2 High { get; private set; }

        public Cell(Vector2 low, Vector2 high)
        {
            if (low.x >= high.x || low.y >= high.y)
                throw new Exception("Each component of high point should be > than corresponding low point`s component");

            Low = low;
            High = high;
        }

        public override string ToString()
        {
            return $"Cell({Low} {High})";
        }
    }
}
