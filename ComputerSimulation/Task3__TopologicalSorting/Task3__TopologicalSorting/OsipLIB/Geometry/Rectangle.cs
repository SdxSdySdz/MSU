using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Geometry
{
    class Rectangle
    {
        public Vector2 Low { get; protected set; }
        public Vector2 High { get; protected set; }
        public Vector2 Center => (Low + High) / 2.0;
        public Vector2 Size => High - Low;
        public double MinX => Low.x;
        public double MaxX => High.x;
        public double MinY => Low.y;
        public double MaxY => High.y;
        public double Width => High.x - Low.x;
        public double Height => High.y - Low.y;


        public Rectangle(Vector2 low, Vector2 high)
        {
            if (low.x >= high.x || low.y >= high.y)
            {
                throw new Exception("Low shoulde be < than High");
            }

            Low = low;
            High = high;
        }


        public Rectangle(Rectangle other) : this(other.Low, other.High) { }


        public void Centerize(Vector2 newCenter)
        {
            Vector2 difference = newCenter - Center;
            Low += difference;
            High += difference;
        }
    }
}
