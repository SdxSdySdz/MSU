using OsipLIB.Geometry.PointSamplers;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Mappings
{
    public class MishaMapping : Mapping
    {
        public MishaMapping(PointSampler pointSampler) : base(pointSampler)
        {
        }

        public override Vector2 Apply(Vector2 point)
        {
            double x = point.x;
            double y = point.y;

            double newX = 4f / 3f * x - (x * x * x) / 3.0;
            double newY = .5 * y;

            return new Vector2(newX, newY);
        }
    }
}