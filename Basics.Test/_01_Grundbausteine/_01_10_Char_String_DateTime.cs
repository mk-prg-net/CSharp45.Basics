using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Basics.Test._01_Grundbausteine
{
    [TestClass]
    public class _01_10_Char_String_DateTime
    {
        [TestMethod]
        public void _01_10_Char_String_DateTime_Test()
        {

            string txt = "<datum>2014-07-23</datum><id>12345</id><preis>2,99€</preis>";

            for (int i = 0; i < txt.Length; i++)
            {
                // Zugriff auf einzelne Zeichen über Arrayzugriffsoperator
                char c = txt[i];

                if (char.IsDigit(c))
                    Debug.WriteLine(c.ToString() + " ist ein Digit");

                if (char.IsLetter(c))
                    Debug.WriteLine(c.ToString() + " ist ein Letter");

                if (char.IsPunctuation(c))
                    Debug.WriteLine(c.ToString() + " ist ein Punktuation");

                if (char.IsSeparator(c))
                    Debug.WriteLine(c.ToString() + " ist ein Separator");

                if (char.IsSurrogate(c))
                    Debug.WriteLine(c.ToString() + " ist ein Surrogate");

                if (char.IsSymbol(c))
                    Debug.WriteLine(c.ToString() + " ist ein Symbol");

            }


            string csvTxt = "2014-07-23 ; 12345  ;  2,99€";

            // Auftrennen von Zeichenfolgen

            string[] Spalten = csvTxt.Split(';');

            foreach (string spalte in Spalten)
            {
                Debug.WriteLine("[" + spalte + "]");
            }

            // Leerzeichen entfernen
            Debug.WriteLine("Leerzeichen entfernen");
            foreach (string spalte in Spalten)
            {
                Debug.WriteLine("[" + spalte.Trim() + "]");
            }


            string[] datumspartikelTxt = Spalten[0].Trim().Split('-');


            int Jahr = int.Parse(datumspartikelTxt[0]);
            int Monat = int.Parse(datumspartikelTxt[1]);
            int Tag = int.Parse(datumspartikelTxt[2]);

            // Einen Datumswert erzeugen
            DateTime heute = new DateTime(Jahr, Monat, Tag);

            // Wiviel Tage lebe ich schon
            DateTime gbt = new DateTime(1968, 7, 6);

            long LebenszeitInTicks = heute.Ticks - gbt.Ticks;

            var Zeitspanne = new TimeSpan(LebenszeitInTicks);

            double LebenszeitInTagen = Zeitspanne.TotalDays;
            Debug.WriteLine("Ich lebe schon " + LebenszeitInTagen + " Tage");


        }
    }
}
