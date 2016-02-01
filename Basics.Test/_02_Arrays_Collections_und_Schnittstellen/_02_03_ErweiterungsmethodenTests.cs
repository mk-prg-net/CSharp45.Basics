using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Basics;
using Basics.Test._02_Arrays_Collections_und_Schnittstellen;

namespace Basics.Test._02_Arrays_Collections_und_Schnittstellen
{
    // Versigelte Klassen können nicht als Basisklassen herhalten, um sie durch
    // vererbung zu erweitern
    public sealed class Schlachtschiff
    {
        public string Name { get; set; }
        public int AnzLeben { get; set; }
        public int Feuerkraft { get; set; }
    }


    // Moderne Lösung: Erweiterungsmethoden für versiegelte Klassen
    public static class SchlachtschiffExtensions
    {
        public static void schiesstAuf(this Schlachtschiff feuernde, Schlachtschiff befeuerte)
        {
            befeuerte.AnzLeben -= feuernde.Feuerkraft;
        }
    }


    [TestClass]
    public class _02_03_ErweiterungsmethodenTests
    {
        // Klassische Lösung, einen Vorgegebene Klasse um Funktionen zu erweitern
        static void schiessen(Schlachtschiff feuernde, Schlachtschiff befeuerte)
        {
            befeuerte.AnzLeben -= feuernde.Feuerkraft;
        }      


        [TestMethod]
        public void _02_03_ErweiterungsmethodenTest()
        {
            long l1 = 13;

            // Klassisch
            Assert.IsTrue(LongExtensions.IsOdd(l1));
            
            // Dank Erweiterungsmethode syntaktisch möglich
            Assert.IsTrue(l1.IsOdd());
            Assert.IsFalse(l1.IsEven());            
            Assert.IsTrue(l1.IsPrime());

            var bismarck = new Schlachtschiff() { AnzLeben = 100, Feuerkraft = 10 };
            var hood = new Schlachtschiff() { AnzLeben = 70, Feuerkraft = 10 };

            schiessen(bismarck, hood);

            bismarck.schiesstAuf(hood);

            // Kompiler übersetzt den vorausgegangenen Ausdruck in folgenden
            SchlachtschiffExtensions.schiesstAuf(bismarck, hood);

        }
    }
}
