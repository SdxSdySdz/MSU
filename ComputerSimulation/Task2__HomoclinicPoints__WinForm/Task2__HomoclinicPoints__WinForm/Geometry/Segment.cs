using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2__HomoclinicPoints__WinForm.LinearAlgebra;

namespace Task2__HomoclinicPoints__WinForm.Geometry
{
    class Segment
    {
        public Vector2 Start { get; private set; }
        public Vector2 End { get; private set; }
        public double Length { get; private set; }
        public Vector2 Center => (End + Start) / 2.0;

        public Segment(Vector2 start, Vector2 end)
        {
            Start = start;
            End = end;

            Length = (end - start).Magnitude;
        }


        public Vector2 Interpolate(double time)
        {
            return Start + time * (End - Start);
        }

        public Vector2[] Interpolate(IEnumerable<double> times)
        {
            return times.Select(time => Vector2.LinearInterpolation(Start, End, time)).ToArray();
        }
    }
}
