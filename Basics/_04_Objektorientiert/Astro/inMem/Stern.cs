using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro.inMem
{
    public class Stern : Astro.Stern
    {



        public override ISpektralklasse Spektralklasse
        {
            get { throw new NotImplementedException(); }
        }

        public override Astro.Galaxie Heimatgalaxie
        {
            get { throw new NotImplementedException(); }
        }

        public override IEnumerable<Planet> Planetensystem
        {
            get { throw new NotImplementedException(); }
        }

        public override string Name
        {
            get { return _Name; }
        }
        string _Name;

        protected override double BerechneMasseInKg()
        {
            throw new NotImplementedException();
        }
    }
}
