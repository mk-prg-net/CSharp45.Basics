using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ctx = Basics._01_Grundbausteine._01_08_Delegates_und_Lambda;

namespace Basics.Test._01_Grundbausteine
{
    [TestClass]
    public class _01_08_Delegates_und_LambdaTests
    {
        Func<double, double, double> myFunc;

        [TestMethod]
        public void _01_08_01_DelegatesTest()
        {
            // Delegate anlegen und Einsprungadresse ablegen
            Ctx.DGBinOp dgOp = new Ctx.DGBinOp(Ctx.Add);

            // Die Einsprungadresse über die Delegate- Variable aufrufen
            var res = dgOp.Invoke(3, 9);

            // Weitere Einsprungadresse ablegen
            dgOp += Ctx.Mul;

            // Nun werden beide Funktionen aufgerufen. Was ist das Ergebnis ?
            res = dgOp.Invoke(3, 9);


            // Nun nehmen wir eine wieder weg
            dgOp -= Ctx.Add;            

            // Jetzt wird nur noch Mul ausgeführt
            res = dgOp.Invoke(3, 9);


            // Einsprungadresse in Add- Funktion bestimmt und in einer
            // Delegate- Variable gespeichert
            var myDg = new Func<double, double, double>(Ctx.Add);            

            // Kurzschreibweise, entsprich myDg.Invoke(3, 6);
            res = myDg(3, 6);
            Assert.AreEqual(9, res);

            // Ein Delegate kann n Einsprungadressen aufnehmen
            myDg += Ctx.Mul;

            // Eine etwas sinnlose Anwendung von Delegates
            res = myDg(3, 6);
            Assert.AreEqual(18, res);

            // Einen Einsprungpunkt aus der Liste entfernen
            myDg -= Ctx.Mul;

            res = myDg(3, 6);
            Assert.AreEqual(9, res);

            // Compiler macht aus nachfolgender Zeile res = Ctx.Calculator(2, 7, new Func<double, double, double>(Ctx.Add));
            res = Ctx.Calculator(2, 7, Ctx.Add);
            Assert.AreEqual(9, res);

            res = Ctx.Calculator(2, 7, Ctx.Mul);
            Assert.AreEqual(14, res);

            // Berechnung der Summe 1 + 2 + 3 + ...
            res = Ctx.Akku(0.0, Ctx.Add, 1, 2, 3, 4, 5, 6);
            Assert.AreEqual(21, res);

            // Berechnung des Produktes 1 * 2 * 3 * ... = N!
            res = Ctx.Akku(1.0, Ctx.Mul, 1, 2, 3, 4, 5, 6);
            Assert.AreEqual(720, res);
        }

        [TestMethod]
        public void _01_08_02_LambdaTest()
        {
            double res = 0;

            // Lambdaausdruck als Sprachmittel, um inline Funktionen/Unterprogramme zu definieren

            res = Ctx.Calculator(2, 7, Ctx.Add);

            // Ausführlicher Lambdaausdruck (anonyme Funktion)
            res = Ctx.Calculator(2, 7, (double a, double b) => { var summe = a + b; return 5 * summe; });

            // Durch Typinferenz kann auf die Typen der Parameter verzichtet werden
            res = Ctx.Calculator(2, 7, (a, b) => { var summe = a + b; return 5 * summe; });

            // Zusammenfassen der beiden Anweisungen im Rumpf der Lambdafunktion zu einem Ausdruck
            res = Ctx.Calculator(2, 7, (a, b) => { return 5 * (a + b); });

            // Wenn der Rumpf nur noch aus einem Ausdruck besteht, dann können die {...} Blockklammern
            // weggelassen werden. Auch return kann entfallen- es erfolgt implizit.
            res = Ctx.Calculator(2, 7, (a, b) => 5 * (a + b));
            Assert.AreEqual(45, res);

            res = Ctx.Akku(0, (a, b) => a + b, 2, 3, 4, 5, 6, 7);

            res = Ctx.Akku(1, (a, b) => a * b, 2, 3, 4, 5, 6, 7);


            res = Ctx.Akku(1, (a, b) => 5*(a + b), 2, 3, 4, 5, 6, 7);


        }



    }
}
