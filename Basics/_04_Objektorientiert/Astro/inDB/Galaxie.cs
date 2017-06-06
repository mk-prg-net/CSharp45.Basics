using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro.inDB
{
    public class Galaxie : Astro.Galaxie
    {
        public override string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override IEnumerable<Stern> Sterne
        {
            get
            {
                // Hier müsste der Datebankabruf implementiert werden,
                // der die Sterne aus der DB lädt
                throw new NotImplementedException();
            }
        }
    }
}
