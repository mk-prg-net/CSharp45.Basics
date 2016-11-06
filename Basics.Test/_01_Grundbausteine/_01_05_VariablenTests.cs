using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ctx = Basics._01_Grundbausteine._01_05_Variablen;
using System.Diagnostics;

namespace Basics.Test._01_Grundbausteine
{
    [TestClass]
    public class _01_05_VariablenTests
    {
        [TestMethod]
        public void _01_05_01_Variablen_NamenUndDeklarationTest()
        {
            // Sonderzeichen sind nicht erlaubt
            //double  Preis_in_€ = 99.9;

            double akt_Ölpreis_in_Dollar = 100.0;
            double akt_Kohlepreis;

            // Die statische Memebervariable x muss nicht intialisiert werden
            xStatic++;

            // Lokale Variablen müssen vor ihrer Verwendung 
            // initialisiert werden
            akt_Kohlepreis = 43.88;
            double Summe = akt_Kohlepreis + akt_Ölpreis_in_Dollar;

            // Fehler, da Gleipunktkonstaten per default vom Typ double
            //float x0 = 3.14;           

            // Korrektur 1: Konvertierung
            float x = (float)3.14;

            // Implizite konvertierung float in double
            double d1 = x;

            // Korrektur 2: float- Literal
            float x2 = 3.14F;

        }

        // Statische Member müssen nicht initialisiert werden
        // Wird automatisch mit 0 initialisert
        static int xStatic;

        public int yMemeber;

        static void Variablen_in_Static()
        {
            // Die statische Memebervariable x muss nicht intialisiert werden
            xStatic++;

            // allg. Memeber einer Klasse müssen nicht initialisiert werden
            var obj = new _01_05_VariablenTests();
            obj.yMemeber++;

            int y = 0;
            y++;

        }


        [TestMethod]
        public void _01_05_02_Variablen_TypinferenzTest()
        {
            // Typinferenz: Deklaration ohne Typspezifikation-> Typ wird aus dem zugewiesenen Wert bestimmt
            var ii = 0;

            // int können keine null- Werte verwalten
            //ii = null;

            // Nullables schon...
            Nullable<int> iNull = null;           

            // int? ist Kurzform für Nullable<int>
            int? iNull2 = null;
            var iNull3 = new Nullable<int>();

            var str = "Hallo Welt";
            var dd = 0.0;
            var ff = 0.0f;

            dd = 11;
            ff = 11;
            //ff = dd;

            // ii ist nach wie vor streng typisiert
            //ii = "Hallo Welt";    // => Fehler, da i vom Typ int

            // Typinferenz kann auch sinnvoll bei der Deklaration von
            // Objekten sein
            DateTime gbt = new DateTime(1990, 2, 22);
            // DateTime taucht in der Deklaration nur noch 1x auf
            var gbt1 = new DateTime(1990, 2, 22);


            var meineAdHocStruktur = new { X = 99.0, Y = 22 };

            //meineAdHocStruktur.X = 77.0;
                        
            process_Value(meineAdHocStruktur);
            process_Value2(meineAdHocStruktur);

            //meineAdHocStruktur.Z = 33;
            //meineAdHocStruktur = new { X = 99, Y = 22, Z = 33 };
            Assert.AreEqual(99, meineAdHocStruktur.X);

        }

        void process_Value(object aobj)
        {
            // Wie soll ich in den anonymen Typ casten
            aobj.ToString();

            //aobj.X = 99;
        }

        void process_Value2(dynamic aobj)
        {
            var x = aobj.X;
        }

        


        [TestMethod]
        public void _01_05_09_ZugriffsmodifikatorenTest()
        {
            // Konstanten verhalten sich wie static, sind also über den Name der Klasse erreichbar
            Debug.WriteLine(Basics._01_Grundbausteine._01_05_Variablen.PI);

            // Alle nicht statischen sind an ein Objekt gebunden
            Basics._01_Grundbausteine._01_05_Variablen EinObjekt = new Basics._01_Grundbausteine._01_05_Variablen();
                        
            Debug.WriteLine(EinObjekt.IchBinÖffentlich);
            Debug.WriteLine(EinObjekt.MwSt);

            //EinObjekt.IchBinPrivat = 99;

        }

        [TestMethod]
        public void _01_05_03_Variablen_StaticTest()
        {

            int id = Basics._01_Grundbausteine._01_05_Variablen.MakeID();
            Assert.AreEqual(0, id);

            id = Basics._01_Grundbausteine._01_05_Variablen.MakeID();
            Assert.AreEqual(1, id);

            id = Basics._01_Grundbausteine._01_05_Variablen.MakeID();
            Assert.AreEqual(2, id);



            id = 0;

            id = Basics._01_Grundbausteine._01_05_Variablen.MakeID_ohneStaticID();
            Assert.AreEqual(1, id);

            id = Basics._01_Grundbausteine._01_05_Variablen.MakeID_ohneStaticID();
            Assert.AreEqual(1, id);

            id = Basics._01_Grundbausteine._01_05_Variablen.MakeID_ohneStaticID();
            Assert.AreEqual(1, id);

            id = 0;

            id = Basics._01_Grundbausteine._01_05_Variablen.MakeID_mitStaticObjekt();
            Assert.AreEqual(1, id);

            id = Basics._01_Grundbausteine._01_05_Variablen.MakeID_mitStaticObjekt();
            Assert.AreEqual(2, id);

            id = Basics._01_Grundbausteine._01_05_Variablen.MakeID_mitStaticObjekt();
            Assert.AreEqual(3, id);
        }


        [TestMethod]
        public void _01_05_04_Variablen_GleitkommaTest()
        {

            try
            {
                // Gleitkommaliterale sind immer vom Typ Double: Zuweisung an float kann Datenverluste bedeuten
                //float einEinfachgenauer = 3.142;

                // deshalb: entweder in float konvertieren, und so den bewussten Datenverlust dokumentieren
                float einEinfachgenauer = (float)3.142;

                // oder ein explizites float- Literal nutzen
                float einEinfachgenauer2 = 3.142F;

                // Achtung: float in vielen Fällen zu ungenau
                float AbstandErdeRaketeInMeter = 29999998;
                for (int i = 0; i < 1000; i++)
                {
                    AbstandErdeRaketeInMeter += 1.0F;
                }

                Assert.AreEqual(3.0e7, AbstandErdeRaketeInMeter);



                // Rechnen an den Grenzen 
                double quotient = 1 / 0.0;
                Assert.IsTrue(double.IsPositiveInfinity(quotient));

                quotient += 10000000;

                Assert.IsTrue(double.IsPositiveInfinity(quotient));

                quotient /= 0.0;
                Assert.IsTrue(double.IsInfinity(quotient));

                quotient = -1 / 0.0;
                //Assert.IsTrue(double.IsPositiveInfinity(quotient));
                Assert.IsTrue(double.IsNegativeInfinity(quotient));

                quotient = 0.0 / 0.0;
                Assert.IsTrue(double.IsNaN(quotient));

                quotient += 99;
                                
                double quotient2 = 0.0 / 0.0;

                // ist gleichwertig zu quotient = quotient / quotient2;
                quotient /= quotient2;



            }
            catch (ArithmeticException ex)
            {
                Assert.IsTrue(false);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void _01_05_05_Variablen_DecimalTest()
        {
            decimal eineGrosseZahl = 12345678901234567890123456789m;

            eineGrosseZahl += 1;

            decimal zweite = eineGrosseZahl;
            eineGrosseZahl /= 2;

            Assert.AreEqual(eineGrosseZahl * 2, zweite);

            decimal dritte =  Math.Min(eineGrosseZahl, zweite);
            Assert.AreEqual(dritte, eineGrosseZahl);


            // Hier werden die Möglichkeiten der Mitgelieferten Sinusfunktion überschritten
            var x = Math.Sin((double)eineGrosseZahl);

            // Aber es gibt ja noch Reihenentwicklungen sin(x) = x - x^3/3! + x^5/5! - x^7/7! + ...
            // Siehe WocServer/mko.Algo.Analysis

            var y = 1.2345678901234567890123456789m;
            y += 1;


        }

        [TestMethod]
        public void _01_05_06_Variablen_NullableTest()
        {
            // Deklaration eines Nullable Typs
            Nullable<int> x = null;
            // Deklaration in vereinfachter C#- Syntax mittels ? Postfix
            int? y = null;            

            int z;
            
            //y.ToString();

            // Auslesen eines Wertes aus einem Nullable Typen, wobei im Falle eines null- Wertes
            // ein Standardwert ausgegeben wird

            int val = x.HasValue ? x.Value : 0;

            // Das ganze ist bereits durch GetValueOrDefault implementiert
            int u = x.GetValueOrDefault(0);
            
            // Der gleiche Vorgang in vereinfachter C# Syntax
            int v = x ?? 0;

            Assert.IsFalse(x.HasValue);


            // null zuweisen, um anzuzeigen, dass die Eigenschaft/der Wert nicht existieren
            x = 3000;

            u = x.GetValueOrDefault(99);

            v = x ?? 99;

            Assert.IsTrue(x.HasValue);
        }

        [TestMethod]
        public void _01_05_07_Variablen_Enums()
        {
            double gemessenerWert = 1.93;

            // Achtung Fehler: Centimeter muss klein geschrieben werden
            var inKm1 = Ctx.ConvertToKompliziert(gemessenerWert, "Kilometer");

            // Probleme mit der Groß/Kleinschreibung können bei Enum nicht auftreten
            var inKm = Ctx.ConvertTo(gemessenerWert, Ctx.LaengenEinheiten.km);
            var inCm = Ctx.ConvertTo(gemessenerWert, Ctx.LaengenEinheiten.cm);


        }

        [TestMethod]
        public void _01_05_07_Variablen_Konvertieren()
        {

            short sVal = short.MaxValue;

            // Implizite Konvertierung: kleinerer wird ohne Datenverlust in 
            // größeren Typ eingebettet
            int iVal = sVal;

            iVal = int.MaxValue;

            // Explizite Konvertierung: Datenverlust droht
            //sVal = iVal;
            sVal = (short)iVal;


            try
            {
                // Convert- Klasse

                string strPreis = "199,00";
                decimal decPreis = Convert.ToDecimal(strPreis);

                string strPreis2 = "199.00";
                decimal decPreis2 = Convert.ToDecimal(strPreis2);

                // Globalisierungskontext auf eine neue Kultur einstellen
                // 1) Alktuelle Kultur als Objekt abfragen
                var cult = System.Threading.Thread.CurrentThread.CurrentCulture;

                // 2) durch eine neue Kultur ersetzen
                var standardkultur = System.Threading.Thread.CurrentThread.CurrentCulture;
                try
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

                    string strPreis3 = "199.00";
                    decimal decPreis3 = Convert.ToDecimal(strPreis3);

                }
                finally
                {
                    // ursprüngliche Kultur wieder herstellen
                    System.Threading.Thread.CurrentThread.CurrentCulture = standardkultur;
                }

            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }


            // Typprüfung zur Laufzeit

            double a = 99;
            int b = 300;

            double res = Ctx.AddUntypisiert(a, b);

            try
            {
                // Kompiler kann den offensichtlichen Fehler (2. Parameter als String) nicht erkennen
                res = Ctx.AddUntypisiert(a, "Fr. 300");
            }
            catch (InvalidCastException ex)
            {
                // Die Laufzeitumgebung jedeoch entdeckt den Versuch, die strenge Typisierung zu umgehen
                Assert.IsTrue(true);
            }

            // Compiler überreden, einen String als Summanden zu aktzeptieren
            string c = "Fr. 300";
            object cObj = c;
            try
            {
                // Mittels Downcast aus einem String ein Double machen ?!
                // Kompiler kann den offensichtlichen Fehler  nicht erkennen
                // Laufzeit erkennt aber das Problem und quittiert es mit einer InvalidCastExcpetion
                double p2 = (double)cObj;
                
                res = Ctx.AddT(a, p2);
            }
            catch (InvalidCastException ex)
            {
                // Die Laufzeitumgebung jedeoch entdeckt den Versuch, die strenge Typisierung zu umgehen
                Assert.IsTrue(true);
                
            }


            // Der Compiler wählt hier double AddT(double a, double b)
            res = Ctx.AddT(99.0, 110.0);

            // Der Compiler wählt hier double AddT(int a, int b)
            res = Ctx.AddT(99, 110);

            // Hier meldet Compiler Fehler, das keine passende AddT gefunden werden kann,
            // die Strings addiert
            //res = Ctx.AddT("99", "110");


            Point p1 = new Point { x = 99, y = 22 };
            object pObj = p1;

            var p22 = pObj as Basics.Point;
            var p23 = pObj as Point;

        }

        class Point
        {
            public double x;
            public double y;
        }

        [TestMethod]
        public void _01_05_10_AlternativeZuBoxing_Funktionen_überladen()
        {

            double res = 0;
            
            // Universelle Addition mittels untypisierten Parametern und Object/Boxing
            Ctx.AddUntypisiert(3, 5.9);

            try
            {
                // Compiler merkt nicht, das eine Addition von Strings noch nicht implementiert ist
                Ctx.AddUntypisiert("3", "5.9");
            }
            catch (InvalidCastException)
            {
                Debug.WriteLine("String Add ist nicht implementiert");
            }

            // Alternativ und besser: streng typisiert mittels überladener AddT
            // Der Compiler wählt hier double AddT(double a, double b)
            res = Ctx.AddT(99.0, 110.0);

            // Der Compiler wählt hier double AddT(int a, int b)
            res = Ctx.AddT(99, 110);

            // Der Compiler wählt hier double AddT(short a, short b)
            res = Ctx.AddT((short)99, (short)110);

            // Compiler merkt sofort, das eine Addition von Strings noch nicht implementiert ist
            //res = Ctx.AddT("99", "110");           


        }

        [TestMethod]
        public void _01_05_08_Boxing_Unboxing()
        {

            // Boxing: 3.142 ist Double- Konstenante. Wenn üeber die Konstante
            // die Mehtode ToString aufgerufen wird, dann baut der Compiler um die
            // double Konstante eine Objektbox (automatisch)
            var numAsString = (3.142).ToString();
            
            object objBox = 3.142;

            Assert.AreEqual("3,142", objBox.ToString());

            // Auspacken des double- Wertes aus der Objektbox: Unboxing mittels
            // Konvertierungsoperator
            double val = (double)objBox;
            Assert.AreEqual(3.142, val);

        }








    }
}
