using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public class Zahlensysteme
    {
        /// <summary>
        /// Wandelt einen Integer oder Long in eine Romzal um
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string ConvertToRom(long Value)
        {
            if (Value >= 1000)
                return "M" + ConvertToRom(Value - 1000);
            else if (Value >= 500)
                return "D" + ConvertToRom(Value - 500);
            else if (Value >= 100)
                return "C" + ConvertToRom(Value - 100);
            else if (Value >= 50)
                return "L" + ConvertToRom(Value - 50);
            else if (Value >= 10)
                return "X" + ConvertToRom(Value - 10);
            else if (Value >= 5)
                return "V" + ConvertToRom(Value - 5);
            else if (Value >= 1)
                return "I" + ConvertToRom(Value - 1);
            else
                return "";
        }

        static long RomZiffToLong(char c)
        {
            return ValueOfRomanNumeral(c);
        }

        /// <summary>
        /// Wandelt eine Romzahl in einen long- Wert um. 
        /// Konvertierung wird durch einen Linq- Ausdruck realisiert
        /// </summary>
        /// <param name="RomNumber"></param>
        /// <returns></returns>
        public static long ConvertToInt(string RomNumber)
        {
#if(DEBUG)
            // "MDCLXVI" => Array von Char: 'M', 'D', ..., 'I'
            //var listDez = RomNumber.Select(c => ValueOfRomanNumeral(c));
            var listDez = RomNumber.Select( new Func<char, long>(RomZiffToLong));
            long sum = listDez.Sum();
            return sum;

#else

            return RomNumber.Select(c => ValueOfRomanNumeral(c)).Sum();
#endif

        }

        /// <summary>
        /// Bestimmt den Wert einer römischen Ziffer
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int ValueOfRomanNumeral(char a)
        {
            switch (a)
            {
                case 'M':
                    return 1000;
                case 'D':
                    return 500;
                case 'C':
                    return 100;
                case 'L':
                    return 50;
                case 'X':
                    return 10;
                case 'V':
                    return 5;
                case 'I':
                    return 1;
                default: throw new Exception();
            }
        }

    }
}
