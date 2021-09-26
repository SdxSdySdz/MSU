using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1__CR_Localizator.Geometry.PointSamplers;
using Task1__CR_Localizator.LinearAlgebra;

namespace Task1__CR_Localizator.Homeomorphisms
{
    class QuadraticMapping : Homeomorphism
    {
        private double _real;
        private double _imaginary;


        public QuadraticMapping(PointSampler pointSampler, double real, double imaginary) : base(pointSampler)
        {
            _real = real;
            _imaginary = imaginary;
        }


        public override Vector2 Apply(Vector2 point)
        {
            double x = point.x;
            double y = point.y;

            return new Vector2(x * x - y * y + _real, 2 * x * y + _imaginary);
        }
    }
}
