using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro.inMem
{
    public class Galaxie : Astro.Galaxie
    {
        /// <summary>
        /// Konstruktor ist nur für Implementierung der Klassenfabriken in Universum- Klasse gedacht- 
        /// deshalb internal Modifikator
        /// </summary>
        /// <param name="Name"></param>
        internal Galaxie(string Name)
        {
            _Name = Name;
            
        }

        /// <summary>
        /// Alle Sterne einer Galaxie werden durch eine Abfrage auf dem Universum bestimmt
        /// </summary>
        public override IEnumerable<Astro.Stern> Sterne
        {
            get {
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


        // Nullobjekt als Singelton
        public static Galaxie Null
        {
            get
            {
                if (_Null == null)
                {
                    _Null = new Galaxie("Null");
                }
                return _Null;
            }
        }
        static Galaxie _Null;

    }
}
