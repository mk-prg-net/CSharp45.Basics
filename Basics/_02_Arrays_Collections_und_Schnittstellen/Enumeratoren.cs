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
            mean, min, max
        }


        public static IEnumerable<string> AllOperatorsAsString
        {
            get
            {
                yield return Operators.mean.ToString();
                yield return Operators.min.ToString();
                yield return Operators.max.ToString();
            }
        }


        /// <summary>
        /// Erzeugt eine Liste aufsteigender Indizes
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static IEnumerable<int> IndexGenerator(int max)
        {
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
