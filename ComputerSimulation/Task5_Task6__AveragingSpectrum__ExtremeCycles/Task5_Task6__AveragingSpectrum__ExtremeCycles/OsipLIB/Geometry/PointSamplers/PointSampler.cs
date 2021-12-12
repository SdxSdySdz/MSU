using OsipLIB.LinearAlgebra;

namespace OsipLIB.Geometry.PointSamplers
{
    public abstract class PointSampler
    {
        public abstract Vector2[] Sample(Cell area);
    }
}