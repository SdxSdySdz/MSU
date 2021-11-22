using Task1__CR_Localizator.Geometry.PointSamplers;
using Task1__CR_Localizator.LinearAlgebra;

namespace Task1__CR_Localizator.Homeomorphisms
{
    class MishaMapping : Homeomorphism
    {
        public MishaMapping(PointSampler pointSampler) : base(pointSampler) { }


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