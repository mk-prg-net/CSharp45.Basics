using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Basics;

namespace Basics.Test._01_Grundbausteine
{
    [TestClass]
    public class _01_05_01_DatenstrukturenTests
    {

        PriceDbl Add(PriceDbl a, PriceDbl b)
        {
            // Beide Preise in die einheitliche Währung USD umrechene
            double aUSD = a.ToUSD();
            double bUSD = b.ToUSD();

            return new PriceDbl(aUSD + bUSD, CurrencySymbols.USD);
        }

        /// <summary>
        /// Alternative Implementierung als Prozedur
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="SummeInUSD"></param>
        void Add(PriceDbl a, PriceDbl b, PriceDbl SummeInUSD)
        {
            // Beide Preise in die einheitliche Währung USD umrechene
            double aUSD = a.ToUSD();
            double bUSD = b.ToUSD();

            SummeInUSD.Value = aUSD + bUSD;
            SummeInUSD.CurSym = CurrencySymbols.USD;
        }

        void Add_korrekt(PriceDbl a, PriceDbl b, out PriceDbl SummeInUSD)
        {
            // Beide Preise in die einheitliche Währung USD umrechene
            double aUSD = a.ToUSD();
            double bUSD = b.ToUSD();

            SummeInUSD.Value = aUSD + bUSD;
            SummeInUSD.CurSym = CurrencySymbols.USD;
        }


        [TestMethod]
        public void _01_05_01_Datenstrukturen()
        {
            // Preisdatensätze anlegen

            // Preis einer Computermaus mit Default- Konstruktor anlegen
            PriceDbl pMouse;
            pMouse.CurSym = CurrencySymbols.EUR;
            pMouse.Value = 29.99;

            // Preis einer mobilen Festplatte mit Parametrierbaren Konstruktor anlegen
            var pHDD = new Basics.PriceDbl(79.90, CurrencySymbols.SFr);


            // Preise in USD mittels statischer Methoden von Preis umrechnen und addieren
            double SumUSD = PriceDbl.ToUSD(pMouse) + PriceDbl.ToUSD(pHDD);

            // Preise umrechnen mittels Memberfunktion
            double SumUSD2 = pMouse.ToUSD() + pHDD.ToUSD();

            // Summe in Euro umrechnen
            var SumInEUR = PriceDbl.Exchange(new PriceDbl(SumUSD, CurrencySymbols.USD), CurrencySymbols.EUR);

            // Preis der Festplatte in Euro umrechnen
            var pHDD_EUR = PriceDbl.Exchange(pHDD, CurrencySymbols.EUR);

            // Europreise addierern

            var SumInEUR_2 = new PriceDbl(pMouse.Value + pHDD_EUR.Value, CurrencySymbols.EUR);


            Assert.AreEqual(SumInEUR.Value, SumInEUR_2.Value, 0.001);

            PriceDbl SummeInUSD = new PriceDbl();

            // Achtung: Datenstrukturen sind Wertetypen. Bei der Parametereingabe erfolgt Call by Value-> 
            // Ergebnisrückgabe scheitert !
            Add(pHDD, pMouse, SummeInUSD);
            Assert.AreEqual(SummeInUSD.Value, 0.0);

            // wie bei Wertetypen üblich mittels out ein Call bei Reference anfordern
            Add_korrekt(pHDD, pMouse, out SummeInUSD);
            Assert.AreNotEqual(SummeInUSD, 0.0);



        }
    }
}
