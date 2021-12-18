using System;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Mappings
{
    public class IkedaMapping : Mapping
    {
        private double _a;
        private double _b;
        private double _d;

        public IkedaMapping(PointSampler pointSampler, double d, double a, double b) : base(pointSampler)
        {
            _d = d;
            _a = a;
            _b = b;
        }

        public override Vector2 Apply(Vector2 point)
        {
            double x = point.x;
            double y = point.y;

            double tao = .4 - 6.0 / (1.0 + x * x + y * y);

            double x_ = _d + _a * (x * Math.Cos(tao) - y * Math.Sin(tao));
            double y_ = _b * (x * Math.Sin(tao) + y * Math.Cos(tao));

            return new Vector2(x_, y_);
        }
    }
}
