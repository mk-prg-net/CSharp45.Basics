using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro
{
    /// <summary>
    /// Abstrakte Klasse für Stern. Hier werden zusätzliche Strukturmerkmale eines Sterns als besondere Art von 
    /// Himmelskörper definiert. Die Implementierung ist dann die Aufgabe abgeleiteter Klassen
    /// </summary>
    public abstract class Stern : IHimmelskörper
    {
        public abstract string Name
        {
            get;
        }

        public double Masse_in_kg
        {
            get
            {
                return Masse_in_Sonnenmassen * mko.Newton.Mass.MassOfSun.Value;
            }
        }


        /// <summary>
        /// Spektralklassen werden über den Lichtspektren (Regenbogen) der Sterne gebildet.
        /// Nach der Theorie des schwarzen Strahlers strahlen kühlere Sterne eher langwelliges Licht (rot),
        /// und heisse erher kurzwelliges Licht (blau) ab.
        /// Über eine Spektralklasse kann die Öberflächentemperatur und die subjekttive Farberscheinung 
        /// (eher rot, oder eher blau leuuchtend) bestimmt werden. 
        /// </summary>
        public abstract ISpektralklasse Spektralklasse
        {
            get;
        }


        /// <summary>
        /// Liefert die Masse in Vielfachend der Sonnenmasse.
        /// </summary>
        public abstract double Masse_in_Sonnenmassen
        {
            get;
        }
        

        /// <summary>
        /// 1:n Beziehung zwischen Galaxie und Sterne:
        /// Verweist auf die Heimatgalaxie des Sterns
        /// </summary>
        public abstract IGalaxie Heimatgalaxie { get; }


        /// <summary>
        /// Liste aller Planeten, die den Stern umkreisen
        /// </summary>
        public abstract IEnumerable<IPlanet> Planetensystem { get; }


        public class NullStern : Stern
        {

            public override string Name
            {
                get { return "NullStern"; }
            }

            public override ISpektralklasse Spektralklasse
            {
                get { return Astro.Spektralklasse.G(); }
            }

            public override double Masse_in_Sonnenmassen
            {
                get { return -1; }
            }

            public override IGalaxie Heimatgalaxie
            {
                get { throw new NotImplementedException(); }
            }

            public override IEnumerable<IPlanet> Planetensystem
            {
                get { throw new NotImplementedException(); }
            }
        }

        /// <summary>
        /// Null- Objekt als Singleton- Pattern
        /// </summary>
        public static NullStern Null
        {
            get
            {
                if(_Null == null){
                    _Null = new NullStern();     
                }
                return _Null;
            }
            
        }
        static NullStern _Null;

    }
}
