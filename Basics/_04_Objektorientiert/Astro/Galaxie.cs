
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro
{
    public abstract class Galaxie : Himmelskörper
    {
        /// <summary>
        /// 1:n Beziehung zwischen Galaxie und Sterne:
        /// Verweist auf alle Sterne einer Galaxie
        /// </summary>
        public abstract IEnumerable<Stern> Sterne { get; }

        public override double BerechneMasseInKg()
        {
            double Masse = 0.0;
            foreach (var stern in Sterne)
            {
                Masse += stern.Masse_in_kg;
                foreach (var planet in stern.Planetensystem)
                {
                    Masse += planet.Masse_in_kg;
                }
            }

            return Masse;
        }
        
    }
}
