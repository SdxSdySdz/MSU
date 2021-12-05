using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Mappings
{
    class IkedaMapping : Mapping
    {
        private double _d;
        private double _C1;
        private double _C2;
        private double _C3;

        public IkedaMapping(PointSampler pointSampler, double d, double C1, double C2, double C3) : base(pointSampler)
        {
            _d = d;
            _C1 = C1;
            _C2 = C2;
            _C3 = C3;
        }


        public override Vector2 Apply(Vector2 point)
        {
            double x = point.x;
            double y = point.y;

            double tao = _C1 - _C3 / (1.0 + x*x + y*y);

            double x_ = _d + _C2 * (x * Math.Cos(tao) - y * Math.Sin(tao));
            double y_ = _C2 * (x * Math.Sin(tao) + y * Math.Cos(tao));

            return new Vector2(x_, y_);
        }
    }
}
