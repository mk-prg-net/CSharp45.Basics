using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert
{
    public class Stern : Himmelskörper
    {
        public Stern(double Masse)
        {
            _Masse = Masse;
        }
        double _Masse;

        public override double BerechneMasseAbstract()
        {
            return _Masse;
        }
    }
}
