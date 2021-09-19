using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2__HomoclinicPoints__WinForm.LinearAlgebra;

namespace Task2__HomoclinicPoints__WinForm.Diffeomorphisms
{
    class IdentityMapping : Diffeomorphism
    {
        public override Vector2 Apply(Vector2 point)
        {
            return point;
        }
    }
}
