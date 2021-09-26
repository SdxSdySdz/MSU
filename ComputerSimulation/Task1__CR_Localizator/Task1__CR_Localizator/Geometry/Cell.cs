using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1__CR_Localizator.LinearAlgebra;

namespace Task1__CR_Localizator.Geometry
{
    class Cell : Rectangle
    {
        public Cell(Vector2 low, Vector2 high) : base(low, high) { }


        public Cell(Cell cell) : base(cell) { }
    }
}
