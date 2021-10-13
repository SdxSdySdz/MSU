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
        public double MinX => Math.Min(Start.x, End.x);
        public double MaxX => Math.Max(Start.x, End.x);
        public double MinY => Math.Min(Start.y, End.y);
        public double MaxY => Math.Max(Start.y, End.y);
        public Rectangle BoundingBox
        {
            get
            {
                Vector2 low = new Vector2(MinX, MinY);
                Vector2 high = new Vector2(MaxX, MaxY);
                return new Rectangle(low, high);
            }
        }
        public Segment OrderedByX
        {
            get
            {
                if (Start.x > End.x)
                {
                    return new Segment(End, Start);
                }
                else
                {
                    return new Segment(Start, End);
                }
            }
        }


        public Segment(Vector2 end) : this(new Vector2(0, 0), end) { }


        public Segment(Vector2 start, Vector2 end)
        {
            Start = start;
            End = end;

            Length = (end - start).Magnitude;
        }


        public bool TryGetIntersectionPoint(Segment other, out Vector2 intersection, out double angle)
        {
            Vector2 end1 = End;
            Vector2 start1 = Start;
            Vector2 end2 = other.End;
            Vector2 start2 = other.Start;

            Vector2 dir1 = end1 - start1;
            Vector2 dir2 = end2 - start2;

            //считаем уравнения прямых проходящих через отрезки
            double a1 = -dir1.y;
            double b1 = +dir1.x;
            double d1 = -(a1 * start1.x + b1 * start1.y);

            double a2 = -dir2.y;
            double b2 = +dir2.x;
            double d2 = -(a2 * start2.x + b2 * start2.y);

            //подставляем концы отрезков, для выяснения в каких полуплоскотях они
            double seg1_line2_start = a2 * start1.x + b2 * start1.y + d2;
            double seg1_line2_end = a2 * end1.x + b2 * end1.y + d2;

            double seg2_line1_start = a1 * start2.x + b1 * start2.y + d1;
            double seg2_line1_end = a1 * end2.x + b1 * end2.y + d1;

            //если концы одного отрезка имеют один знак, значит он в одной полуплоскости и пересечения нет.
            if (seg1_line2_start * seg1_line2_end >= 0 || seg2_line1_start * seg2_line1_end >= 0)
            {
                angle = 0;
                intersection = new Vector2(double.PositiveInfinity, double.PositiveInfinity);
                return false;
            }
                

            double u = seg1_line2_start / (seg1_line2_start - seg1_line2_end);
            intersection = start1 + u * dir1;

            Vector2 product = dir1 * dir2;
            double scalar_product = product.x + product.y;
            angle = Math.Acos(Math.Abs(scalar_product) / (dir1.Magnitude * dir2.Magnitude)) * 180.0 / Math.PI;
            return true;







            /*if (BoundingBox.Intersects(other.BoundingBox) == false)
            {
                intersection = new Vector2(double.PositiveInfinity, double.PositiveInfinity);
                return false;
            }


            double Area(Vector2 v1, Vector2 v2, Vector2 v3)
            {
                return (v2.x - v1.x) * (v3.y - v1.y) - (v2.y - v1.y) * (v3.x - v1.x);
            }

            Vector2 a = Start;
            Vector2 b = End;
            Vector2 c = Start;
            Vector2 d = End;
            
            if (Area(a, b, c) >= 0 && Area(a, b, d) >= 0)
            {
                intersection = new Vector2(double.PositiveInfinity, double.PositiveInfinity);
                return false;
            }

            if (Area(a, b, c) < 0 && Area(a, b, d) < 0)
            {
                intersection = new Vector2(double.PositiveInfinity, double.PositiveInfinity);
                return false;
            }


            if (Area(c, d, a) >= 0 && Area(c, d, b) >= 0)
            {
                intersection = new Vector2(double.PositiveInfinity, double.PositiveInfinity);
                return false;
            }

            if (Area(c, d, a) < 0 && Area(c, d, b) < 0)
            {
                intersection = new Vector2(double.PositiveInfinity, double.PositiveInfinity);
                return false;
            }

            // TODO
            // It is not correct, but for small segments its works
            intersection = (Center + other.Center) / 2.0;
            return true;*/
        }


        public Vector2 Interpolate(double time)
        {
            return Start + time * (End - Start);
        }

        public Vector2[] Interpolate(IEnumerable<double> times)
        {
            return times.Select(time => Vector2.LinearInterpolation(Start, End, time)).ToArray();
        }

        public override string ToString()
        {
            return $"Segment {Start} {End}";
        }
    }
}
