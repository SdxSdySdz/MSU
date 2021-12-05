using OsipLIB.LinearAlgebra;

namespace OsipLIB.Geometry
{
    public class Cell : Rectangle
    {
        public Cell(Vector2 low, Vector2 high) : base(low, high) { }

        public Cell(Cell cell) : base(cell) { }
    }
}
