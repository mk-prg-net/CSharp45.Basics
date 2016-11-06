using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ctx = Basics._01_Grundbausteine._01_07_Unterprogramme_und_Funktionen;

namespace Basics.Test._01_Grundbausteine
{
    [TestClass]
    public class _01_07_Unterprogramme_und_FunktionenTests
    {
        [TestMethod]
        public void _01_07_Unterprogramme_und_FunktionenTest()
        {

            var l = Ctx.Length(Ctx.CreatePoint(2, 9));

            var p2 = Ctx.CreatePoint();
            Assert.AreEqual(99.0, p2.X);
            Assert.AreEqual(99.0, p2.Y);

            // Variante 1: Punktobj wird in Getpoint erzeugt
            l = Ctx.Length(Ctx.GetPoint(1));

            // Variante 2: Punktobj wird im Rufer erzeugt
            Point pp = new Point();

            l = Ctx.Length(Ctx.GetPoint(1, pp));

            // In C++ könnte der pp jetz sauber entsorgt werden
            //delete pp



            Basics.Point a = new Point() { X = 10, Y = 20 };
            Basics.Point b = new Point() { X = -5, Y = 3 };

            Basics.Point c = Ctx.Add(a, b);
            Assert.IsTrue(Ctx.Equal(c, new Point() {X= 5, Y= 23}, 0.01));


            Point posFlugzeug = Ctx.PolarToCartesian(Math.Sqrt(2) * 1000, Math.PI / 4.0);
            Assert.IsTrue(Math.Abs(posFlugzeug.X - posFlugzeug.Y) < 0.01);
            Assert.AreEqual(1000.0, posFlugzeug.Y, 0.01);


            double r = Math.Sqrt(2) * 1000;
            double phi = Math.PI / 4.0;

            // Unterprogramm mit out- Parameter
            double abstand, hoehe;
            Ctx.PolarToCartesian(r, phi, out abstand, out hoehe);

            // Unterprogramm mit ref- Parameter: lokale Variablen im Hauptprogramm müssen vor
            // dem Aufruf initialisiert werden
            // Folgende Zeile führt zu einem Fehler, da hohehe2 nicht initialisiert wurde
            //double abstand2 = 0, hoehe2; 
            double abstand2 = 0, hoehe2 = 0; 
            Ctx.PolarToCartesianWithRef(r, phi, ref abstand2, ref hoehe2);

            Point pFlugzeug = new Point();

            Ctx.PolarToCartesianWithImplicitRef(r, phi, pFlugzeug);

            


            // Benannte Parameter           
            Ctx.PolarToCartesianWithImplicitRef(phi_in_rad: 1.4,  p: pFlugzeug, r: Math.Sqrt(2));

            var FerrariVonFredVollgas = Ctx.CreateAuto(
                    EntfernungVomStart:  110,
                    vStartInKmh:300,
                    Markenname: "Ferrari",
                    Modell: "F8"                    
                );
            
            var RudiNormalosPassat = Ctx.CreateAuto(
                EntfernungVomStart: 115,        
                Markenname: "VW",
                Modell: "Passat"
            );


            // Defaultparameter

            var P1 = Ctx.CreatePoint();
            var P2 = Ctx.CreatePoint(100);
            var P3 = Ctx.CreatePoint(100, 100);

            // Kombination von benannten Parametern und Defaultwerten
            var P4 = Ctx.CreatePoint(y: 100);


            // Parameterarray: variadische Funktionen

            double[] liste = {1, 2, 3, 4, 5, 6};
            double summe = Ctx.Sum(liste);


            // Der Compiler wandelt, bedingt durch das Schlüsselwort params,
            // folgende Zeile um in:
            // summe = Ctx.Sum(new double[] {1, 2, 3, 4, 5, 6});
            summe = Ctx.Sum(1, 2, 3, 4, 5, 6);
            summe = Ctx.Sum(1, 2, 3);
            Assert.AreEqual(6, summe);

            double mulSum = Ctx.MulSum(2);
            mulSum = Ctx.MulSum(2, 1);
            mulSum = Ctx.MulSum(2, 1, 2, 3);
            Assert.AreEqual(12, mulSum);

        }
    }
}
