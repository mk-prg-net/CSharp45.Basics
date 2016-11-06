using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro.inMem
{
    public class GalaxieWithStrategie : Astro.GalaxieWithStrategie
    {
        internal GalaxieWithStrategie(string Name, IStrategieBerechneMasseGalaxie strategie)
            : base(strategie)
        {
            _Name = Name;
        }


        public override IEnumerable<Astro.Stern> Sterne
        {
            get
            {
                if (Universum.Instance.Sterne.Any(s => s.Heimatgalaxie == this))
                {
                    return Universum.Instance.Sterne.Where(s => s.Heimatgalaxie == this);
                }
                else
                {
                    return new Astro.Stern[] { };
                }

            }
        }

        public override string Name
        {
            get { return _Name; }
        }
        string _Name;
    }
}
