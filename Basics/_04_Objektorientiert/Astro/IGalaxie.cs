using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro
{
    public interface IGalaxie : IHimmelskörper
    {
        IEnumerable<Stern> Sterne { get; }
    }

    public interface IGalaxieMitStrategie : IHimmelskörper
    {
        /// <summary>
        /// Schnittstelle so erweitert, dass die Masseberechnung flexibel 
        /// ist. Die Wahrung des Open closed Princip wird hierdurch besser garantiert.
        /// </summary>
        IStrategieBerechneMasseGalaxie Masseberechnungsalgo { set; }

        IEnumerable<Stern> Sterne { get; }
    }
}
