using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2__HomoclinicPoints__WinForm.LinearAlgebra
{
    struct Vector2
    {
        public double x { get; private set; }
        public double y { get; private set; }
        public double Magnitude => Math.Sqrt(x * x + y * y);


        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }


        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator +(Vector2 a, double coefficient) => new Vector2(a.x + coefficient, a.y + coefficient);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator -(Vector2 a, double coefficient) => new Vector2(a.x - coefficient, a.y - coefficient);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(b.x * a.x, b.y * a.y);
        public static Vector2 operator *(Vector2 a, double coefficient) => new Vector2(coefficient * a.x, coefficient * a.y);
        public static Vector2 operator *(double coefficient, Vector2 a) => new Vector2(coefficient * a.x, coefficient * a.y);
        public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a.x / b.x, a.y / b.y);
        public static Vector2 operator /(Vector2 a, double coefficient) => new Vector2(a.x / coefficient, a.y / coefficient);


        public double Sum() => x + y;


        public static Vector2 LinearInterpolation(Vector2 from, Vector2 to, double t)
        {
            return from + t * (to - from);
        }

        public static implicit operator PointF(Vector2 point)
        {
            return new PointF((float)point.x, (float)point.y);
        }

        public static implicit operator Point(Vector2 point)
        {
            return new Point((int)point.x, (int)point.y);
        }


        public override string ToString()
        {
            return $"[{x}, {y}]";
        }
    }

}
