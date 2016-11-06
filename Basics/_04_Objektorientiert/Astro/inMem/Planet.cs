using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro.inMem
{
    public class Planet : Astro.IPlanet
    {
        internal Planet(string Name, double Masse_in_Erdmassen, Astro.Stern Zentralstern)
        {
            _Name = Name;
            _Masse_in_Erdmassen = Masse_in_Erdmassen;
            _Zentralstern = Zentralstern;
        }

        public Astro.Stern Zentralstern
        {
            get {
                return _Zentralstern;
            }
        }
        Astro.Stern _Zentralstern;

        public string Name
        {
            get { return _Name; }
        }
        string _Name;

        public double Masse_in_kg
        {
            get { return Masse_in_Erdmassen * mko.Newton.Mass.MassOfEarth.Value; }
        }

        public double Masse_in_Erdmassen
        {
            get { return _Masse_in_Erdmassen; }
        }
        double _Masse_in_Erdmassen;
    }
}
