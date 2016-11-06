using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro.inMem
{
    public class Stern : Astro.Stern
    {

        internal Stern(string Name, ISpektralklasse Spektralklasse, double Masse_in_Sonnenmassen, IGalaxie Heimatgalaxie)
        {
            _Name = Name;
            _Spektralklasse = Spektralklasse;
            _Galaxie = Heimatgalaxie;
            _Masse_in_Sonnenmassen = Masse_in_Sonnenmassen;
        }

        public override string Name
        {
            get { return _Name; }
        }
        string _Name;

        public override double Masse_in_Sonnenmassen
        {
            get { return _Masse_in_Sonnenmassen; }
        }
        double _Masse_in_Sonnenmassen;

        public override ISpektralklasse Spektralklasse
        {
            get { 
                return _Spektralklasse; 
            }
        }
        ISpektralklasse _Spektralklasse;


        public override IEnumerable<IPlanet> Planetensystem
        {
            get {
                if (Universum.Instance.Planeten.Any(p => p.Zentralstern == this))
                {
                    return Universum.Instance.Planeten.Where(p => p.Zentralstern == this);
                }
                else
                {
                    return new IPlanet[] { };
                }
                
            }
        }


        public override Astro.IGalaxie Heimatgalaxie
        {
            get { 
                return _Galaxie; 
            }
        }
        Astro.IGalaxie _Galaxie;
    }
}
