using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2__HomoclinicPoints.LinearAlgebra;

namespace Task2__HomoclinicPoints.Diffeomorphism
{
    abstract class Diffeomorphism
    {
        public abstract Vector2 Apply(Vector2 point);


        public abstract Vector2 ApplyDerivative(Vector2 point);


        public Vector2[] Apply(Vector2[] points)
        {
            return points.Select(point => Apply(point)).ToArray();
        }


        public Vector2 ApplyDerivative(Vector2 point, double accuracy)
        {
            return (Apply(point + accuracy) - Apply(point - accuracy)) / 2.0;
        }


        public Vector2[] ApplyDerivative(Vector2[] points, double accuracy)
        {
            return points.Select(point => ApplyDerivative(point, accuracy)).ToArray();
        }
    }
}
