using System;
using System.Collections.Generic;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Geometry
{
    public class Rectangle
    {
        public Rectangle(Rectangle other) : this(other.Low, other.High) { }

        public Rectangle(Vector2 low, Vector2 high)
        {
            if (low.x >= high.x || low.y >= high.y)
            {
                throw new Exception("Low shoulde be < than High");
            }

            Low = low;
            High = high;
        }

        public Vector2 Low { get; private set; }
        public Vector2 High { get; private set; }
        public Vector2 Center => (Low + High) / 2.0;
        public Vector2 Size => High - Low;
        public double MinX => Low.x;
        public double MaxX => High.x;
        public double MinY => Low.y;
        public double MaxY => High.y;
        public double Width => High.x - Low.x;
        public double Height => High.y - Low.y;
        public double Area => Width * Height;

        public List<Vector2> Vertexes =>
            new List<Vector2>()
            {
                Low,
                Low + Vector2.Right * Width,
                High,
                High + Vector2.Left * Width,
            };

        public bool ContainsPoint(Vector2 point)
        {
            return Low.x <= point.x && point.x <= High.x &&
                   Low.y <= point.y && point.y <= High.y;
        }

        public bool StronglyContainsPoint(Vector2 point)
        {
            return Low.x < point.x && point.x < High.x &&
                   Low.y < point.y && point.y < High.y;
        }

        public void Centerize(Vector2 newCenter)
        {
            Vector2 difference = newCenter - Center;
            Low += difference;
            High += difference;
        }
    }
}