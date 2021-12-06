using System;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Mappings
{
    public class IkedaMapping : Mapping
    {
        private readonly double _d;
        private readonly double _c1;
        private readonly double _c2;
        private readonly double _c3;

        public IkedaMapping(PointSampler pointSampler, double d, double c1, double c2, double c3) : base(pointSampler)
        {
            _d = d;
            _c1 = c1;
            _c2 = c2;
            _c3 = c3;
        }

        public override Vector2 Apply(Vector2 point)
        {
            double x = point.x;
            double y = point.y;

            double tao = _c1 - _c3 / (1.0 + x*x + y*y);

            double x_ = _d + _c2 * (x * Math.Cos(tao) - y * Math.Sin(tao));
            double y_ = _c2 * (x * Math.Sin(tao) + y * Math.Cos(tao));

            return new Vector2(x_, y_);
        }
    }
}
