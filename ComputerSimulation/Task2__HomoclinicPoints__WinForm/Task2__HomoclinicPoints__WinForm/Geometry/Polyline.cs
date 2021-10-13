using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2__HomoclinicPoints__WinForm.LinearAlgebra;

namespace Task2__HomoclinicPoints__WinForm.Geometry
{
    class Polyline
    {
        private List<Vector2> _vertexes;

        public int SideCount => _vertexes.Count - 1;
        public Vector2[] Vertexes => _vertexes.ToArray();

        public Polyline()
        {
            _vertexes = new List<Vector2>();
        }


        public Polyline(Segment segment) : this()
        {
            _vertexes.Add(segment.Start);
            _vertexes.Add(segment.End);
        }

        public Polyline(IEnumerable<Vector2> vertexes)
        {
            _vertexes = vertexes.ToList();
        }


        public Vector2 GetVertex(int index) => _vertexes[index];


        public Segment GetSide(int index) => new Segment(_vertexes[index], _vertexes[index + 1]);


        public void SplitSide(int index)
        {
            Vector2 point = GetSide(index).Center;

            _vertexes.Insert(index + 1, point);
        }

        public void Insert(Vector2 point, int sideIndex)
        {
            _vertexes.Insert(sideIndex + 1, point);
        }


        public bool TryGetFirstIntersectionPoint(Polyline other, out Vector2 intersection, out double angle)
        {
            bool isFirstIntersection = true;
            for (int sideIndex = 0; sideIndex < SideCount; sideIndex++)
            {
                Segment thisSegment = GetSide(sideIndex);
                for (int otherSideIndex = 0; otherSideIndex < other.SideCount; otherSideIndex++)
                {
                    Segment otherSegment = other.GetSide(otherSideIndex);
                    /*                    if ((thisSegment.Center - otherSegment.Center).Magnitude < 0.01)
                                        {
                                            if (isFirstIntersection == false)
                                            {
                                                Console.WriteLine(thisSegment);
                                                Console.WriteLine(otherSegment);
                                                intersection = (thisSegment.Center + otherSegment.Center) / 2.0;
                                                return true;
                                            }

                                            isFirstIntersection = false;
                                        }*/

                    if (thisSegment.TryGetIntersectionPoint(otherSegment, out intersection, out angle))
                    {
                        return true;
                    }
                }
            }

            intersection = new Vector2(double.PositiveInfinity, double.PositiveInfinity);
            angle = 0;
            return false;
        }


        public override string ToString()
        {
            string output = "Polyline { ";
            foreach (var vertex in _vertexes)
            {
                output += vertex.ToString() + " ";
            }
            output += "}";

            return output;
        }
    }
}
