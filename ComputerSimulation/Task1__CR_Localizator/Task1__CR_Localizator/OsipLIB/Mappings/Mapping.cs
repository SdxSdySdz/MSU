using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsipLIB.Geometry;
using OsipLIB.Geometry.PointSamplers;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Mappings
{
    public abstract class Mapping
    {
        private PointSampler _pointSampler;

        protected Mapping(PointSampler pointSampler)
        {
            _pointSampler = pointSampler;
        }

        public abstract Vector2 Apply(Vector2 point);

        public Vector2[] Apply(Vector2[] points)
        {
            Vector2[] newPoints = new Vector2[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                newPoints[i] = Apply(points[i]);
            }

            return newPoints;
        }

        public Vector2[] ApplyToArea(Cell cell)
        {
            Vector2[] samples = _pointSampler.Sample(cell);

            return Apply(samples);
        }
    }
}