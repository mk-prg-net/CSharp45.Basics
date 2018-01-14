using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Basics._06_Patterns.Decorators.Bank;

namespace Basics.Test
{
    [TestClass]
    public class DekoTest
    {
        [TestMethod]
        public void DekoTest1()
        {
            var DonaldsKonto = new Konto();

            DonaldsKonto.einzahlen(100);
            DonaldsKonto.einzahlen(50);
            Assert.AreEqual(DonaldsKonto.Guthaben, 150.0);


            // Donald unter Beobachtung:
            var DonaldObserver = new KontoMitProtokollDeko(DonaldsKonto);
            DonaldObserver.einzahlen(100);

            // Donals Konto verzinsen lassen
            var DonaldsSparkonto = new SparkontoDeko(DonaldObserver);
            DonaldsSparkonto.einzahlen(10);

            DonaldsSparkonto.verzinse(1, 0.10);
            Assert.AreEqual(DonaldsKonto.Guthaben, 176.0);



            var Drucker = new Protokolldrucker();

            Drucker.drucke(DonaldObserver);
            // Drucker.drucke(DonaldsSparkonto);


        }
    }
}
