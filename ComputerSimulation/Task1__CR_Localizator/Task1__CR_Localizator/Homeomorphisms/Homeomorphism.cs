using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1__CR_Localizator.Geometry;
using Task1__CR_Localizator.Geometry.PointSamplers;
using Task1__CR_Localizator.LinearAlgebra;

namespace Task1__CR_Localizator.Homeomorphisms
{
    abstract class Homeomorphism
    {
        protected PointSampler PointSampler;


        protected Homeomorphism(PointSampler pointSampler)
        {
            PointSampler = pointSampler;
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
            Vector2[] samples = PointSampler.Sample(cell);

            return Apply(samples);
        }
    }
}
