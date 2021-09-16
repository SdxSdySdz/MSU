using Task1__CR_set_localisation_CSharp.Geometry.PointsSamplers;
using Task1__CR_set_localisation_CSharp.LinearAlgebra;

namespace Task1__CR_set_localisation_CSharp.Geometry
{
    abstract class Homemorphism
    {
        private PointsSampler _pointsSampler;

        public Homemorphism(PointsSampler pointsSampler)
        {
            _pointsSampler = pointsSampler;
        }

        public Vector2[] ApplyToCell(Cell cell)
        {
            Vector2[] points = _pointsSampler.Sample(cell);
            Vector2[] imagePoints = new Vector2[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                imagePoints[i] = Apply(points[i]);
            }

            return imagePoints;
        }

        protected abstract Vector2 Apply(Vector2 point);
    }
}

