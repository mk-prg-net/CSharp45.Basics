using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ctx = Basics._01_Grundbausteine._01_03_Ausdruecke;

namespace Basics.Test._01_Grundbausteine
{
    [TestClass]
    public class _01_03_AusdrueckeTests
    {
        [TestMethod]
        public void _01_03_01_AusdrueckeTests_Funktionen()
        {
            // Aufruf einer Funktion, die Pi liefert
            double pi_k = Ctx.F_Pi_Kettenbruch();
            Assert.IsTrue(3.141 < pi_k && pi_k < 3.142);


            // Aufruf einer Funktion, die den größten gemeinsamen Teiler aus zwei ganzen Zahlen berechnet
            int ggt = Ctx.GGT(41 * 17 * 13 * 11, 19 * 13 * 7 * 5 * 3);
            Assert.AreEqual(13, ggt);

            bool istPrim = Ctx.PrimTest(7);
            Assert.IsTrue(istPrim);

            istPrim = Ctx.PrimTest(41*13);
            Assert.IsFalse(istPrim);
            
        }

    }
}
