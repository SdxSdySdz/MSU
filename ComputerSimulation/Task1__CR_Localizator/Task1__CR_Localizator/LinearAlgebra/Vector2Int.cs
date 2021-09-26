using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1__CR_Localizator.LinearAlgebra
{
    struct Vector2Int
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int Row => x;
        public int Column => y;

        public static Vector2Int Zero => new Vector2Int(0, 0);
        public static Vector2Int One => new Vector2Int(1, 1);
        public static Vector2Int Up => new Vector2Int(0, 1);
        public static Vector2Int Down => new Vector2Int(0, -1);
        public static Vector2Int Right => new Vector2Int(1, 0);
        public static Vector2Int Left => new Vector2Int(-1, 0);


        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }


        public Vector2Int(Vector2Int vector) : this(vector.x, vector.y) { }


        public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new Vector2Int(a.x + b.x, a.y + b.y);
        public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new Vector2Int(a.x - b.x, a.y - b.y);
        public static Vector2Int operator *(Vector2Int a, Vector2Int b) => new Vector2Int(a.x * b.x, a.y * b.y);
        public static Vector2Int operator *(Vector2Int a, int coefficient) => new Vector2Int(coefficient * a.x, coefficient * a.y);
        public static Vector2Int operator *(int coefficient, Vector2Int a) => new Vector2Int(coefficient * a.x, coefficient * a.y);
        /*        public static Vector2Int operator /(Vector2Int a, Vector2Int b) => new Vector2Int(a.x / b.x, a.y / b.y);
                public static Vector2Int operator /(Vector2Int a, int coefficient) => new Vector2Int(a.x / coefficient, a.y / coefficient);*/
        public static bool operator ==(Vector2Int a, Vector2Int b) => a.x == b.x && a.y == b.y;
        public static bool operator !=(Vector2Int a, Vector2Int b) => a.x != b.x || a.y != b.y;


        public override bool Equals(object obj)
        {
            bool isCorrectType = obj is Vector2Int;
            if (isCorrectType)
            {
                Vector2Int other = (Vector2Int)obj;
                return x == other.x && y == other.y;
            }
            else
            {
                throw new Exception("Can`t compare vector with object");
            }

        }


        public override int GetHashCode()
        {
            return (x, y).GetHashCode();
        }


        public override string ToString()
        {
            return $"[{x}, {y}]";
        }
    }
}
