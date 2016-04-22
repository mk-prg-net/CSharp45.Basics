using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro.inMem
{
    public class Galaxie : Astro.Galaxie
    {
        public override IEnumerable<Stern> Sterne
        {
            get { throw new NotImplementedException(); }
        }

        public override string Name
        {
            get { return _Name; }
        }
        string _Name;
    }
}
