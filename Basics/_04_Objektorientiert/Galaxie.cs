using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert
{
    public class Galaxie : Himmelskörper
    {
        public Galaxie(Stern[] Sterne_der_Galaxie)
        {
            _Sterne = Sterne_der_Galaxie;
        }

        Stern[] _Sterne;

        public override double BerechneMasseAbstract()
        {
            double Masse = 0.0;
            foreach (var stern in _Sterne)
            {
                Masse += stern.BerechneMasseAbstract();
            }

            return Masse;
        }
    }
}
