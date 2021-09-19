using System.Collections.Generic;
using System.Linq;
using Task2__HomoclinicPoints__WinForm.Geometry;
using Task2__HomoclinicPoints__WinForm.LinearAlgebra;

namespace Task2__HomoclinicPoints__WinForm.Diffeomorphisms
{
    abstract class Diffeomorphism
    {
        public abstract Vector2 Apply(Vector2 point);


        public Vector2[] Apply(IEnumerable<Vector2> points)
        {
            return points.Select(point => Apply(point)).ToArray();
        }


        public Polyline Apply(Polyline polyline)
        {

            return new Polyline(polyline.Vertexes.Select(vertex => Apply(vertex)));
        }
    }
}
