using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Test._04_Objektorientiert
{
    [TestClass]
    public class _04_09_OperatorueberladungTests
    {
        [TestMethod]
        public void _04_OperatorueberladungTest()
        {
            var a = new Romzahl("MDCLXVI");
            var b = new Romzahl("XIII");

            // Explizite Wandlung mit Konvertierungsoperator
            long MDCLXVI = (long)a;
            Assert.AreEqual(MDCLXVI, 1666);

            // Aufruf des selbstdefinierten Additionsoperators für Romzahlen
            var RomSumme = a + b;
            long LongSumme = (long)RomSumme;
            Assert.AreEqual(LongSumme, 1679);

        }
    }
}
