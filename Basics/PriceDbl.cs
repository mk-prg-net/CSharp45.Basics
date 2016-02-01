using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public enum CurrencySymbols { EUR, USD, SFr };

    // PriceDbl verpflichtet sich, die IComparable- Schnittstelle/Vertrag zu implementieren/erfüllen
    public struct PriceDbl : IComparable
    {
        // nummerischer Anteil eines Preises
        public double Value;

        // Währungssymbol
        public CurrencySymbols CurSym;

        // Konstruktor (Initialisierungroutine), die das Anlegen
        // eines Preises erkleichtert
        public PriceDbl(double Value, CurrencySymbols CurSym)
        {
            // Zur Unterscheidung der Member von den gleichnamigen Parametern
            // wird den Membern das Schlüsselwort this. vorangestellt
            this.Value = Value;
            this.CurSym = CurSym;
        }

        /// <summary>
        /// Liefert den Wechselkurs für den Umtausch einer Währung in USD
        /// vom 13.10.2014
        /// </summary>
        /// <param name="From"></param>
        /// <returns></returns>
        public static double ExchangeRateToUSD(CurrencySymbols From)
        {
            // Kurse vom 13.10.2014
            switch (From)
            {
                case CurrencySymbols.EUR:
                    return 1.275;
                case CurrencySymbols.SFr:
                    return 1.055;
                case CurrencySymbols.USD:
                    return 1.0;
                default: throw new ArgumentOutOfRangeException(From.ToString());
            }
        }


        /// <summary>
        /// Rechnet einen Preis in USD um
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static double ToUSD(PriceDbl price)
        {
            return price.Value * ExchangeRateToUSD(price.CurSym);
        }

        /// <summary>
        /// Membermetohde: hat Zugriff auf das Objekt und all seine Daten
        /// </summary>
        /// <returns></returns>
        public double ToUSD()
        {
            //return ToUSD(this);
            return Value * ExchangeRateToUSD(CurSym);
        }

        /// <summary>
        /// Währungstausch in Wunschwährung
        /// </summary>
        /// <param name="ValueInUSD"></param>
        /// <param name="ToCurSym"></param>
        /// <returns></returns>
        public static PriceDbl Exchange(PriceDbl price, CurrencySymbols ToCurSym)
        {
            return new PriceDbl(ToUSD(price) / ExchangeRateToUSD(ToCurSym), ToCurSym);
        }

        public override string ToString()
        {
            return Value.ToString() + " " + CurSym.ToString();
        }

        //public int CompareTo(object obj)
        //{
        //    throw new NotImplementedException();
        //}

        int IComparable.CompareTo(object obj)
        {
            // 1. Konvertieren von obj in ein PriceDbl
            PriceDbl derAnderePreis = (PriceDbl)obj;

            // 2. Vergleichen auf Basis von USD
            if (this.ToUSD() < derAnderePreis.ToUSD())
                return -1;
            else if (this.ToUSD() > derAnderePreis.ToUSD())
                return 1;
            else
                return 0;
        }
    }
}
