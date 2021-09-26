using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1__CR_Localizator.LinearAlgebra;

namespace Task1__CR_Localizator.Geometry.PointSamplers
{
    abstract class PointSampler
    {
        public abstract Vector2[] Sample(Cell area);
    }
}
