using System;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Mappings
{
    public class ControlTaskMapping : Mapping
    {
        private readonly double _r;
        private readonly double _a;
        private readonly double _b;

        public ControlTaskMapping(PointSampler pointSampler, double r, double a, double b) : base(pointSampler)
        {
            _r = r;
            _a = a;
            _b = b;
        }

        public override Vector2 Apply(Vector2 point)
        {
            double x = point.x;
            double y = point.y;

            double tao = 0.4 - 6.0 / (1.0 + x * x + y * y);

            double x_ = _r + _a * (x * Math.Cos(tao) - y * Math.Sin(tao));
            double y_ = _b * (x * Math.Sin(tao) + y * Math.Cos(tao));

            return new Vector2(x_, y_);
        }
    }
}