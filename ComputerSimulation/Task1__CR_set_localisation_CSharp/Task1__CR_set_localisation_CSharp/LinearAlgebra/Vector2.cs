using System;
using System.Collections.Generic;
using System.Text;

namespace Task1__CR_set_localisation_CSharp.LinearAlgebra
{
    struct Vector2
    {
        public double x { get; private set; }
        public double y { get; private set; }

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator *(Vector2 a, double coefficient) => new Vector2(coefficient * a.x, coefficient * a.y);
        public static Vector2 operator *(double coefficient, Vector2 a) => new Vector2(coefficient * a.x, coefficient * a.y);

        public override string ToString()
        {
            return $"[{x}, {y}]";
        }
    }
}
