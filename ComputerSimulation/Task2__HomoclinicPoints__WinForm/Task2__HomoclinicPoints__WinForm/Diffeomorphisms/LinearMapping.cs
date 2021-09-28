using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2__HomoclinicPoints__WinForm.LinearAlgebra;

namespace Task2__HomoclinicPoints__WinForm.Diffeomorphisms
{
    class LinearMapping : Diffeomorphism
    {
        private Vector2 _k;
        private Vector2 _b;

        public override double MaxEigenvalue => throw new NotImplementedException();
        public override double MinEigenvalue => throw new NotImplementedException();


        public LinearMapping(double k, double b)
        {
            _k = new Vector2(k, k); ;
            _b = new Vector2(b, b);
        }

        public LinearMapping(double k, Vector2 b)
        {
            _k = new Vector2(k, k); ;
            _b = b;
        }

        public LinearMapping(Vector2 k, double b)
        {
            _k = k;
            _b = new Vector2(b, b);
        }

        public LinearMapping(Vector2 k, Vector2 b)
        {
            _k = k;
            _b = b;
        }

        

        public override Vector2 Apply(Vector2 point)
        {
            return _k * point + _b;
        }

        protected override Vector2 GetEigenvector(double eigenvalue)
        {
            throw new NotImplementedException();
        }

        public override Vector2 ApplyReverse(Vector2 point)
        {
            throw new NotImplementedException();
        }
    }
}
