using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics
{
    public class PrimSet : IEnumerable<long>
    {
        int[] _primz = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };

        // Felder, die den BEreich definieren, aus dem die zu liefernden Primzahlen
        // stammen
        long _von;
        long _bis;

        // Konstruktor
        public PrimSet(long von, long bis)
        {
            _von = von;
            _bis = bis;
        }

        public IEnumerator<long> GetEnumerator()
        {
            return new PrimEnumerator(_von, _bis);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            // Die GetEnumerator aus .NET 1.0-1.1 liefert das, was die moderne GetEnumerator
            // liefert.
            return GetEnumerator();
        }

        // Enumerator- Klasse
        public class PrimEnumerator : IEnumerator<long>
        {
            long _von;
            long _bis;
            long _current;

            // Konstruktor
            public PrimEnumerator(long von, long bis)
            {
                _von = von;
                _bis = bis;
                _current = von;
            }

            public long Current
            {
                get { return _current; }
            }

            public void Dispose()
            {
                // Hier könnte man externe Resourcen freigeben
            }

            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                // Die nächste, obere Primzahl bezüglich aktuellem _current bestimmen
                long prim = mko.Algo.NumberTheory.PrimeFactors.NextUpperPrime(_current);

                if (prim <= _bis)
                {
                    _current = prim;
                    return true;
                }
                else
                    return false;
            }

            public void Reset()
            {
                // Wieder von vorne beginnen
                _current = _von;
            }
        }
    }
}
