using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Test._06_Patterns.Singleton
{
    [TestClass]
    public class Singleton
    {
        [TestMethod]
        public void Singleton_PriceDbl()
        {
            //var singlePrice = new Basics.PriceDbl(1, CurrencySymbols.USD, 1.10, 1.12);

            //var rate = singlePrice.ExchangeRateToUSD_InstanceMethod(Basics.CurrencySymbols.SFr);

        }

        [TestMethod]
        public void Singleton_Lazy_Universum()
        {
            var myUniverse = new Basics._06_Patterns.LazyInitialisation.Astro.LazyUniversum();


            var mySun = myUniverse.Sonne;

            Assert.IsFalse(myUniverse.Beteigeuze.IsValueCreated);
            var myBeta = myUniverse.Beteigeuze;
            var m = myUniverse.Beteigeuze.Value.Masse_in_kg;
            Assert.IsTrue(myUniverse.Beteigeuze.IsValueCreated);

            var myBeta2 = myUniverse.Beteigeuze;

            
            Assert.AreEqual(myBeta.Value, myBeta2.Value);

        }

    }
}
