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

        public static PriceDbl Instance
        {
            get
            {

                if (_Instance.Value == 0)
                {

                    _Instance = new PriceDbl(1, CurrencySymbols.USD);

                }

                return _Instance;
            }
        }
        static PriceDbl _Instance;


        // nummerischer Anteil eines Preises
        public double Value; //{ get; set; }
        // Währungssymbol
        public CurrencySymbols CurSym;

        // Konstruktor (Initialisierungroutine), die das Anlegen
        // eines Preises erkleichtert
        public PriceDbl(double Value1, CurrencySymbols CurSym) //, double exRateEur = 1.275, double exRateSFr = 1.055)
        {
            // Zur Unterscheidung der Member von den gleichnamigen Parametern
            // wird den Membern das Schlüsselwort this. vorangestellt
            //_Value = 0;
            //_CurSym = CurrencySymbols.USD;
            //_Value = 0;
            this.Value = Value1;
            this.CurSym = CurSym;
            //this.exRateEur = exRateEur;
            //this.exRateSFr = exRateSFr;
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

        public int CompareTo(object obj)
        {
            PriceDbl derAnderePreis = (PriceDbl)obj;

            if (this.ToUSD() < derAnderePreis.ToUSD())
                return -1;
            else if (this.ToUSD() > derAnderePreis.ToUSD())
                return 1;
            else
                return 0;
        }


        //public int CompareTo(object obj)
        //{
        //    // Downcast von object in PreisDBL
        //    PriceDbl derAnderePreis = (PriceDbl)obj;

        //    int res = 0;

        //    if (this.ToUSD() < derAnderePreis.ToUSD())
        //    {
        //        res = -1;
        //    }
        //    else if (this.ToUSD() > derAnderePreis.ToUSD())
        //    {
        //        res = 1;
        //    }
        //    else
        //    {
        //        res = 0;
        //    }

        //    return res;

        //}
    }
}
