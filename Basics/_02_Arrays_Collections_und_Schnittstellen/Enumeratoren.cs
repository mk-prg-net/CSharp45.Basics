using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Basics
{
    public class Enumeratoren
    {

        public enum Operators
        {
            mean, min, max, varianz
        }


        public static IEnumerable<string> AllOperatorsAsString
        {
            get
            {
                // yield ist eine Anweisung an den Compiler der Art:
                // Beim 1. Aufruf von .MoveNext(), .Current -> Operators.mean.ToString();
                yield return Operators.mean.ToString();

                // ... beim 2. Aufruf von .MoveNext(), .Current -> Operators.min.ToString();
                yield return Operators.min.ToString();

                // ... beim 3. Aufruf von .MoveNext(), .Current -> Operators.max.ToString();
                yield return Operators.max.ToString();

                // ... beim 4. Aufruf von .MoveNext(), .Current -> Operators.varianz.ToString();
                yield return Operators.varianz.ToString();

                // yield wird nicht zur Laufzeit, sondern zur Entwurfszeit ausgeführt durch den Compiler
            }
        }


        /// <summary>
        /// Erzeugt eine Liste aufsteigender Indizes
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static IEnumerable<int> IndexGenerator(int max)
        {
            // Achtung: die for- Schleife wird nicht zur Laufzeit ausgeführt
            // for ist rein symbolisch, und der Compiler liest aus der for- Schleife ab,
            // das 0- max yield- Anweisungen zu definieren sind
            for (int i = 0; i <= max; i++)
                yield return i;

        }

        public static IEnumerable<bool> BoolFieldGenerator(bool value, int max)
        {
            for (int i = 0; i <= max; i++)
                yield return value;

        }

        public static IEnumerable<Tuple<int, int, bool>> TableGenerator(int[] Col1, bool[] Col2)
        {
            for (int line = 0; line < Col1.Length; line++)
                yield return new Tuple<int, int, bool>(line, Col1[line], Col2[line]);
        }
    }
}
