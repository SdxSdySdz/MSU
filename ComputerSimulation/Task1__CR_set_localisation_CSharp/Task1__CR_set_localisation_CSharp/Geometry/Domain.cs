﻿using System;
using System.Collections.Generic;
using System.Text;
using Task1__CR_set_localisation_CSharp.LinearAlgebra;

namespace Task1__CR_set_localisation_CSharp.Geometry
{
    class Domain
    {
        public Vector2 Low { get; private set; }
        public Vector2 High { get; private set; }

        public Domain(Vector2 low, Vector2 high)
        {
            if (low.x >= high.x || low.y >= high.y)
                throw new Exception("Each component of high point should be > than corresponding low point`s component");

            Low = low;
            High = high;
        }

        public void Split()
        {
            throw new NotImplementedException();
        }

        public Cell GetCell(int id)
        {
            throw new NotImplementedException();
        }
    }
}
