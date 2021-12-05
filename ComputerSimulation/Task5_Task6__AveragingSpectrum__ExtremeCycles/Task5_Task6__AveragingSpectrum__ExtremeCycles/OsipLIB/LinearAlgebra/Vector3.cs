using System;

namespace OsipLIB.LinearAlgebra
{
    public class Vector3
    {
        public double x { get; private set; }
        public double y { get; private set; }
        public double z { get; private set; }

        public static int Size => 3;
        public static Vector3 Zero => new Vector3(0, 0, 0);
        public static Vector3 One => new Vector3(1, 1, 1);
        public static Vector3 Up => new Vector3(0, 0, 1);
        public static Vector3 Down => new Vector3(0, 0, -1);
        public static Vector3 Right => new Vector3(1, 0, 0);
        public static Vector3 Left => new Vector3(-1, 0, 0);

        public double Magnitude => Math.Sqrt(x * x + y * y + z * z);
        public Vector3 Normalized => this / Magnitude;
        
        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector3 operator *(Vector3 a, Vector3 b) => new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        public static Vector3 operator *(Vector3 a, double coefficient) => new Vector3(coefficient * a.x, coefficient * a.y, coefficient * a.z);
        public static Vector3 operator *(double coefficient, Vector3 a) => new Vector3(coefficient * a.x, coefficient * a.y, coefficient * a.z);
        public static Vector3 operator /(Vector3 a, Vector3 b) => new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
        public static Vector3 operator /(Vector3 a, double coefficient) => new Vector3(a.x / coefficient, a.y / coefficient, a.z / coefficient);


        public static Vector3 LinearInterpolation(Vector3 from, Vector3 to, double t)
        {
            return from + t * (to - from);
        }

        public override string ToString()
        {
            return $"[{x}, {y}, {z}]";
        }
    }
}