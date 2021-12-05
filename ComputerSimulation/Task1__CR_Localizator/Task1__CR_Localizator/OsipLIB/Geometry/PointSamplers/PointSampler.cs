using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Geometry.PointSamplers
{
    public abstract class PointSampler
    {
        public abstract Vector2[] Sample(Cell area);
    }
}
