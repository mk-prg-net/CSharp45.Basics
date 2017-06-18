using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Basics.Test._01_Grundbausteine
{

    enum Flugzeugtyp
    {
        Ballon,
        Zeppelin,
        Doppeldecker,
        Jumbojet,
        Rakete
    }    

    [TestClass]
    public class _01_10_Kontrollstrukturen
    {

        string EinteilenDerTypen(Flugzeugtyp ftyp)
        {
            var meldung = "";

            switch (ftyp)
            {
                case Flugzeugtyp.Ballon:
                case Flugzeugtyp.Zeppelin:
                    {
                        meldung = "leichter als Luft";
                    }
                    break;
                case Flugzeugtyp.Doppeldecker:
                case Flugzeugtyp.Jumbojet:
                    return "schwerer als Luft";
                case Flugzeugtyp.Rakete:
                    return "fliegt auch ohne Luft";
                default:
                    throw new Exception("Unbekannter Flugzeugtyp: " + ftyp.ToString());
            }

            return meldung;
        }

        [TestMethod]
        public void _01_10_Kontrollstrukturen_Test()
        {

            // Berechnen der Summe von 1 bis b
            int summe = 0;
            for (int i = 0; i < 100; i += 1)
            {
                summe += i;
            }

            // for- Schleife für den Primzahltest

            int z = 1111;
            int Teiler = 2;

            for (; Teiler <= z - 1 && z % Teiler != 0; Teiler += 1);

            if (Teiler == z)
                Debug.WriteLine(z.ToString() + " ist Primzahl");
            else
                Debug.WriteLine(z.ToString() + " ist keine Primzahl");


            // Beispiel für Switch- Block
            int Romwert = Zahlensysteme.ValueOfRomanNumeral('M');
            Romwert = Zahlensysteme.ValueOfRomanNumeral('V');


            Debug.WriteLine(EinteilenDerTypen(Flugzeugtyp.Rakete));
            Debug.WriteLine(EinteilenDerTypen(Flugzeugtyp.Ballon));
            Debug.WriteLine(EinteilenDerTypen(Flugzeugtyp.Zeppelin));
            Debug.WriteLine(EinteilenDerTypen(Flugzeugtyp.Jumbojet));


        }
    }
}
