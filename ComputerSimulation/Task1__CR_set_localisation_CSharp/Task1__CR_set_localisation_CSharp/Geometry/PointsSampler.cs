using System;
using System.Collections.Generic;
using System.Text;
using Task1__CR_set_localisation_CSharp.LinearAlgebra;

namespace Task1__CR_set_localisation_CSharp.Geometry
{
    abstract class PointsSampler
    {
        public abstract Vector2[] Sample(Cell cell);
    }
}
