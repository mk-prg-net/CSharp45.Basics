using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    /// <summary>
    /// Klasse zum Darstellen und Rechnen mit römischen Zahlen. Es wird bei der 
    /// Implementierung auf Funktionen aus der Bibliothek mko.Algo zurückgegriffen.
    /// </summary>
    public class Romzahl
    {
        public Romzahl(string Rom)
        {
            Value = Rom;
        }

        public Romzahl(long intRom)
        {
            Value = Zahlensysteme.ConvertToRom(intRom);
        }

        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }

        /// <summary>
        /// Konvertierungsoperator: berechnet den Wert, der durch eine Romzahl dargestellt
        /// wird, und gibt ihn als long zurück
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static explicit operator long(Romzahl a)
        {
            return Zahlensysteme.ConvertToInt(a.Value);
        }

        /// <summary>
        /// Additionsoperator: Wandelt zunächst beide Summanden (Romzahlen) in longs um,
        /// summiert diese und wandelt die Summe in eine Romzahl zurück
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Romzahl operator +(Romzahl a, Romzahl b)
        {
            return new Romzahl((long)a + (long)b);
        }

    }
}
