using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics
{
    public class Preis : IComparable
    {
        // Speichert einen PReis als Festkommabetrag
        // z.B. 4,99 Euro -> 499 (*100)
        int _Preis;

        public Preis(int PreisFestkomma)
        {
            _Preis = PreisFestkomma;
        }

        public Preis()
        {
            _Preis = 0;
        }

        public Preis(int Euro, int Cent)
        {
            _Preis = Euro * 100 + Cent;
        }

        /// <summary>
        /// Liefert den ganzen Euroanteil eines Preises
        /// </summary>
        /// <returns></returns>
        public int GetEuro()
        {
            return _Preis / 100;
        }

        /// <summary>
        /// Liefert den Cent- Anteil eines Preise
        /// </summary>
        /// <returns></returns>
        public int GetCent()
        {
            return _Preis - GetEuro() * 100;
        }


        public void SetPreis(double Preis)
        {
            _Preis =(int)(Preis * 100);
        }

        public static Preis Add(Preis a, Preis b)
        {
            return new Preis(a._Preis + b._Preis);
        }

        public override string ToString()
        {
            return "" + GetEuro() + "," + GetCent() + " €";
        }


        int IComparable.CompareTo(object obj)
        {
            // Downcast von obj in ein Preis
            var derAnderePreis = (Preis)obj;

            // PReise vergleichen
            if (_Preis < derAnderePreis._Preis)
                return -1;
            else if (_Preis > derAnderePreis._Preis)
                return 1;
            else
                return 0;
        }



        //public int CompareTo(object obj)
        //{
        //    throw new NotImplementedException();
        //}

        //int IComparable.CompareTo(object obj)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
