﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public class NumberTheory
    {
        public static bool IsPrime(long z)
        {
            // Entscheidungen für Sonderfälle wie 1 und 2 werden direkt getroffen
            // Für alle anderen werte wird mittels Rekursion die Probe auf Teilbarkeit 
            // mit allen möglichen Teilern durchgeführt
            return z == 2 || (z != 1) && (z % 2 != 0 && IsNotFactor(z, 3, z / 2));
        }

        private static bool IsNotFactor(long z, long factor, long maxPossibleFactor)
        {
            if (factor >= maxPossibleFactor)
                // Fall: alle möglichen Prüfungen auf Teilbarkeit blieben erfolglos
                return true;
            else
                // Fall: eine Prüfung wird durchgeführt und das Prüfergebnis mit
                // den Ergebnissen aus den restlichen noch anstehenden Prüfungen 
                // logisch UND verknüpft.
                return z % factor != 0 && IsNotFactor(z, factor + 2, maxPossibleFactor);
        }

        /// <summary>
        /// Erzeugt eine Liste aller Primzahlen im Intervall [a, b]
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static IEnumerable<long> PrimeScan(long a, long b)
        {
            if (a > b)
                return LISP.L<long>();
            else if (IsPrime(a))
                // Primzahliste besteht aus a und den restlichen Primzahlen zw. [a+1, b]
                return LISP.Concat(LISP.L(a), PrimeScan(a + 1, b));
            else
                // Primzahliste besteht aus den restlichen Primzahlen zw. [a+1, b]
                return PrimeScan(a + 1, b);
        }

    }
}
