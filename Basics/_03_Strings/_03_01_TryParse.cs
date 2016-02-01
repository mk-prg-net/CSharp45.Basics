using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._03_Strings
{
    public class _03_01_TryParse
    {

        /// <summary>
        /// Einlesen einer Gleitkommazahl in der Kultr des Systems
        /// </summary>
        /// <param name="valTxt"></param>
        /// <returns></returns>
        public static double ReadDouble(string valTxt)
        {
            // dank out kann auf die Initialisierung von val verzichtetwerden
            //double val = 0.0;
            double val;
            if (double.TryParse(valTxt, out val))
                return val;
            else
                return double.NaN;

        }

        /// <summary>
        /// Einlesen der Gleitkommazahl in CH- Kultur
        /// </summary>
        /// <param name="valTxt"></param>
        /// <returns></returns>
        public static double ReadDouble_ch(string valTxt)
        {
            // Aktuelle Kultur des Threads wird ausgelesen

            var cult = System.Threading.Thread.CurrentThread.CurrentCulture;

            var ch = new System.Globalization.CultureInfo("de-CH");           


            // dank out kann auf die Initialisierung von val verzichtetwerden
            //double val = 0.0;
            double val;
            if (double.TryParse(valTxt, System.Globalization.NumberStyles.Any, ch, out val))
                return val;
            else
                return double.NaN;
        }

    }
}
