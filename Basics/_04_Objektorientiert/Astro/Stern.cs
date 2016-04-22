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
    public abstract class Stern : Himmelskörper
    {
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
        /// 1:n Beziehung zwischen Galaxie und Sterne:
        /// Verweist auf die Heimatgalaxie des Sterns
        /// </summary>
        public abstract Galaxie Heimatgalaxie { get; }


        /// <summary>
        /// Liste aller Planeten, die den Stern umkreisen
        /// </summary>
        public abstract IEnumerable<Planet> Planetensystem { get; }

    }
}
