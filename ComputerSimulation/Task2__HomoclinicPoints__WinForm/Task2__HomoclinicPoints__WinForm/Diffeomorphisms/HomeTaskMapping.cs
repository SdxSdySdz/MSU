using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2__HomoclinicPoints__WinForm.LinearAlgebra;

namespace Task2__HomoclinicPoints__WinForm.Diffeomorphisms
{
    class HomeTaskMapping : Diffeomorphism
    {
        private double _alpha;

        public HomeTaskMapping(double alpha)
        {
            _alpha = alpha;
        }


        public override Vector2 Apply(Vector2 point)
        {
            double x = point.x;
            double y = point.y;

            double newX = x + y + _alpha * x * (1 - x * x);
            double newY = y + _alpha * x * (1 - x * x);

            return new Vector2(newX, newY);
        }
    }
}
