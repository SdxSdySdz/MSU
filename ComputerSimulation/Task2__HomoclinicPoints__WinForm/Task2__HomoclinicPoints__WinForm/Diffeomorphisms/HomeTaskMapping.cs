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

        public override double MaxEigenvalue => (2.0 + _alpha + Math.Sqrt(_alpha* (_alpha + 4.0))) / 2.0;
        public override double MinEigenvalue => (2.0 + _alpha - Math.Sqrt(_alpha* (_alpha + 4.0))) / 2.0;


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


        public override Vector2 ApplyReverse(Vector2 point)
        {
            double x = point.x;
            double y = point.y;

            double newX = x - y;
            double newY = y - _alpha * (x - y) * (1 - (x - y) * (x - y));

            return new Vector2(newX, newY);
        }


        protected override Vector2 GetEigenvector(double eigenvalue) => new Vector2(eigenvalue, eigenvalue - 1);   
    }
}
