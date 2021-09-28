using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2__HomoclinicPoints__WinForm.LinearAlgebra;

namespace Task2__HomoclinicPoints__WinForm.Diffeomorphisms
{
    class RotationMapping : Diffeomorphism
    {
        public override double MaxEigenvalue => 1.0;

        public override double MinEigenvalue => 1.0;

        public override Vector2 Apply(Vector2 point)
        {
            double phi = Math.PI / 4;
            double sinPhi = Math.Sin(phi);
            double cosPhi = Math.Cos(phi);

            return new Vector2(point.x * cosPhi - point.y * sinPhi, point.x * sinPhi + point.y * cosPhi);
        }

        public override Vector2 ApplyReverse(Vector2 point)
        {
            throw new NotImplementedException();
        }

        protected override Vector2 GetEigenvector(double eigenvalue)
        {
            throw new NotImplementedException();
        }
    }
}
