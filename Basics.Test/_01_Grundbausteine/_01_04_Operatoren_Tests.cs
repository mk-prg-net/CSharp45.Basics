using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ctx = Basics._01_Grundbausteine._01_04_Operatoren;
using System.Diagnostics;

namespace Basics.Test._01_Grundbausteine
{
    [TestClass]
    public class _01_04_Operatoren_Tests
    {
        [TestMethod]
        public void _01_04_Operatoren_BitopsTest()
        {
            string dz = Ctx.In_Dualzahl_konvertieren_mit_Bitops(8);
            Assert.AreEqual(dz, "OOOOOOOOOOOOOOOOOOOOOOOOOOOOLOOO");

            dz = Ctx.In_Dualzahl_konvertieren_mit_Bitops(0xFFFFFFFFu);
            Assert.AreEqual(dz, "LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL");

            dz = Ctx.In_Dualzahl_konvertieren_mit_Bitops(12345);
            Trace.WriteLine("12345 in Dual = " + dz);
        }

        
        public void _01_04_Operatoren_LogikopsTest()
        {
            Assert.IsTrue(Ctx.Logische_Operatoren_in_Aussagen());
        }


        [TestMethod]
        public void Inkrement_Dekrement()
        {

            int i = 1, j = 1;

            int res = i++ + j;
            Assert.AreEqual(2, res);

            //goto SPRUNGMARKE;

            i = 1; j = 1;
            int res2 = i + ++j;
            Assert.AreEqual(3, res2);

            i = 1; j = 1;
            int res2_2 = i +++j;
            Assert.AreEqual(2, res2_2);


            i = 1; j = 1;
            int res3 = i+++j;
            Assert.AreEqual(2, res3);

SPRUNGMARKE:
            i = 1; j = 1;
            int res4 = ++i + j;
            Assert.AreEqual(3, res4);

            i = 1; j = 1;
            //int res5 = --i;
            //int res5 = (i++)+++++++++++++++ ? +++++j++ : +++++++++++++j;
            //Assert.AreEqual(3, res4);


        }


        [TestMethod]
        public void _01_04_Operatoren_FestkommaoperatorenTest()
        {
            Assert.IsTrue(Ctx.Gepruefte_Festkommaoperatoren());
            Assert.IsTrue(Ctx.Ungepruefte_Festkommaoperatoren());

            // Bsp.: Preise durch Festkommawerte darstellen, indem 2 stellen Fest für die 
            // Cents definiert sind

            int preis1 = 9950;
            // Entspricht 99,50 €
            int preis2 = 38560;
            // Entspricht 385,60 €
            int Gesamtpreis = preis1 + preis2;            

            // Für die Ausgabe sollten die Vor und Nachkommastellen Isoliert werden, um sie 
            // getrennt auszugeben

            // a / b ergibt als Ergebnis einen Double- Wert
            // a \ b ergibt als Ergebnis einen Integer- Wert
            int GesamtpreisEuro = Gesamtpreis / 100;            // Integerdivision
            double GesamtpreisEuroDbl = Gesamtpreis / 100.0;    // Double- Division
            int GesamtpreisCent = Gesamtpreis - GesamtpreisEuro * 100;

            Assert.AreEqual(485, GesamtpreisEuro);
            Assert.AreEqual(10, GesamtpreisCent);


            // Vereinfachen der Festkommarechnung für Preise mittels Hilfsfunktionen
            int preis3 = Ctx.Preis(99,50);
            int preis4 = Ctx.Preis(385,60);

            int Gesamtpreis2 = preis3 + preis4;

            Assert.AreEqual(485, Ctx.PreisEuroAnteil(Gesamtpreis2));
            Assert.AreEqual(10, Ctx.PreisCentAnteil(Gesamtpreis2));

        }

        [TestMethod]
        public void _01_04_Operatoren_GleitkommaoperatorenTest()
        {
            double dPReis1 = 99.5;
            double dPreis2 = 385.6;

            double dGesamt = dPReis1 + dPreis2;
            Assert.AreEqual("485,10", dGesamt.ToString("N2"));

            double d01 = 0.3;

            // Jedoch können in Gleitkommarechnungen Rundungsfehler erbarmungslos zuschlagen
            //float EntfernungRaketeVonErde = (float)19999998.0; // f;
            float EntfernungRaketeVonErde = 19999998.0f;

            for (int i = 1; i <= 10; i++)
            {
                //EntfernungRaketeVonErde += (float)1.0;
                EntfernungRaketeVonErde += 1.0f;
            }

            Assert.AreEqual(2.0e7, EntfernungRaketeVonErde);
        }


        [TestMethod]
        public void _01_04_Operatoren_ZeichenkettenTest()
        {
            // Zeichenkettenwerte haben den Datentyp string
            string A = "1";
            string B = "2";

            var C = A + B;

            Assert.AreEqual("12", C);

            int iA = 1;
            int iB = 2;

            var iC = iA + iB;

            Assert.AreEqual(3, iC);

            // Streng typisierte Sprache wie C# verhindern Fehler
            //int iC2 = A + B;



            
        }
    }
}
