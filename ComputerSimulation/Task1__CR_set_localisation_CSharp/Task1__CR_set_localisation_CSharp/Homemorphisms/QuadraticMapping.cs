using Task1__CR_set_localisation_CSharp.Geometry;
using Task1__CR_set_localisation_CSharp.Geometry.PointsSamplers;
using Task1__CR_set_localisation_CSharp.LinearAlgebra;

namespace Task1__CR_set_localisation_CSharp.Homemorphisms
{
    class QuadraticMapping : Homemorphism
    {
        private double _realCoefficient;
        private double _imaginaryCoefficient;

        public QuadraticMapping(double realCoefficient, double imaginaryCoefficient, PointsSampler pointsSampler) : base(pointsSampler) 
        {
            _realCoefficient = realCoefficient;
            _imaginaryCoefficient = imaginaryCoefficient;
        }

        protected override Vector2 Apply(Vector2 point)
        {
            double x = point.x * point.x - point.y * point.y + _realCoefficient;
            double y = 2 * point.x * point.y + _imaginaryCoefficient;
            return new Vector2(x, y);
        }
    }
}
