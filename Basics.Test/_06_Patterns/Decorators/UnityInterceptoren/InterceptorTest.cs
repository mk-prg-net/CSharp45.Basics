﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

using Bank = Basics._06_Patterns.Decorators.Bank;
using Intercept = Basics._06_Patterns.Decorators.UnityInterceptoren;

namespace Basics.Test._06_Patterns.Decorators.UnityInterceptoren
{
    [TestClass]
    public class InterceptorTest
    {
        UnityContainer ioc;

        [TestInitialize]
        public void TestInit()
        {
            ioc = new UnityContainer();

            // Interception- Erweiterung registrieren (Die Klassenfabriken 
            // erzeugen nun Proxies)
            ioc.AddNewExtension<Interception>();

            // Klassenfabriken konfigurieren
            ioc.RegisterType<Bank.IKonto, Bank.Konto>
                (
                    new InjectionConstructor(),

                    // Interceptor Chain einleiten
                    new Interceptor<InterfaceInterceptor>(),

                    // definieren der Inteceptoren
                    new InterceptionBehavior<Intercept.LoggingInterceptor>()
                );
        }


        [TestMethod]
        public void TestMethod1()
        {

            var DonaldsKonto = ioc.Resolve<Bank.IKonto>();

            DonaldsKonto.einzahlen(1000);
            DonaldsKonto.einzahlen(200);

            var aktGuthaben = DonaldsKonto.Guthaben;
            Assert.AreEqual(1200.0, aktGuthaben);

            DonaldsKonto.abheben(430);
            Assert.AreEqual(770.0, aktGuthaben);

        }
    }
}
