using System.Collections.Generic;
using System.Linq;
using Task2__HomoclinicPoints__WinForm.Geometry;
using Task2__HomoclinicPoints__WinForm.LinearAlgebra;

namespace Task2__HomoclinicPoints__WinForm.Diffeomorphisms
{
    abstract class Diffeomorphism
    {
        public abstract double MaxEigenvalue { get; }
        public abstract double MinEigenvalue { get; }


        public Vector2 MaxEigenvector => GetEigenvector(MaxEigenvalue);
        public Vector2 MinEigenvector => GetEigenvector(MinEigenvalue);


        public abstract Vector2 Apply(Vector2 point);
        public abstract Vector2 ApplyReverse(Vector2 point);


        public Segment Apply(Segment segment)
        {
            Vector2 start = Apply(segment.Start);
            Vector2 end = Apply(segment.End);
            return new Segment(start, end);
        }


        public Segment ApplyReverse(Segment segment)
        {
            Vector2 start = ApplyReverse(segment.Start);
            Vector2 end = ApplyReverse(segment.End);
            return new Segment(start, end);
        }


        public Vector2[] Apply(IEnumerable<Vector2> points)
        {
            return points.Select(point => Apply(point)).ToArray();
        }


        public Polyline Apply(Polyline polyline)
        {

            return new Polyline(polyline.Vertexes.Select(vertex => Apply(vertex)));
        }


        protected abstract Vector2 GetEigenvector(double eigenvalue);
    }
}
