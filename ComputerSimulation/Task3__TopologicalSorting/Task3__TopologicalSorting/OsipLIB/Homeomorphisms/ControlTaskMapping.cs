using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Homeomorphisms
{
    class ControlTaskMapping : Homeomorphism
    {
        private double _R;
        private double _a;
        private double _b;


        public ControlTaskMapping(PointSampler pointSampler, double R, double a, double b) : base(pointSampler)
        {
            _R = R;
            _a = a;
            _b = b;
        }


        public override Vector2 Apply(Vector2 point)
        {
            double x = point.x;
            double y = point.y;

            double tao = 0.4 - 6.0 / (1.0 + x * x + y * y);

            double x_ = _R + _a * (x * Math.Cos(tao) - y * Math.Sin(tao));
            double y_ = _b * (x * Math.Sin(tao) + y * Math.Cos(tao));

            return new Vector2(x_, y_);
        }
    }
}
