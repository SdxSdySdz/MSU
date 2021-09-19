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
