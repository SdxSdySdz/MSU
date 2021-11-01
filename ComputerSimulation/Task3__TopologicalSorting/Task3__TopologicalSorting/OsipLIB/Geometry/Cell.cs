using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsipLIB.LinearAlgebra;

namespace OsipLIB.Geometry
{
    class Cell : Rectangle
    {
        public Cell(Vector2 low, Vector2 high) : base(low, high) { }


        public Cell(Cell cell) : base(cell) { }
    }
}
