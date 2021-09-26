using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1__CR_Localizator.LinearAlgebra
{
    struct Vector2
    {
        public double x { get; private set; }
        public double y { get; private set; }
        
        public static Vector2 Zero => new Vector2(0, 0);
        public static Vector2 One => new Vector2(1, 1);
        public static Vector2 Up => new Vector2(0, 1);
        public static Vector2 Down => new Vector2(0, -1);
        public static Vector2 Right => new Vector2(1, 0);
        public static Vector2 Left => new Vector2(-1, 0);

        public double Magnitude => Math.Sqrt(x * x + y * y);
        public Vector2 Normalized => this / Magnitude;


        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }


        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.x * b.x, a.y * b.y);
        public static Vector2 operator *(Vector2 a, double coefficient) => new Vector2(coefficient * a.x, coefficient * a.y);
        public static Vector2 operator *(double coefficient, Vector2 a) => new Vector2(coefficient * a.x, coefficient * a.y);
        public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a.x / b.x, a.y / b.y);
        public static Vector2 operator /(Vector2 a, double coefficient) => new Vector2(a.x / coefficient, a.y / coefficient);


        public static Vector2 LinearInterpolation(Vector2 from, Vector2 to, double t)
        {
            return from + t * (to - from);
        }


        // public Point ToPoint() => new Point((int) x, (int) y);


        public PointF ToPointF() => new PointF((float)x, (float)y);


        public Vector2Int ToVector2Int()
        {
            return new Vector2Int((int)x, (int)y);
        }

        public override string ToString()
        {
            return $"[{x}, {y}]";
        }
    }
}
