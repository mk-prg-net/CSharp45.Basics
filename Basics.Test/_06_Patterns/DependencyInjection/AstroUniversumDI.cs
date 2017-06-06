using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity;
using Astro = Basics._04_Objektorientiert.Astro;

using System.Linq;

namespace Basics.Test._06_Patterns.DependencyInjection
{
    [TestClass]
    public class AstroUniversumDI
    {

        Microsoft.Practices.Unity.UnityContainer IoC;

        [TestInitialize]
        public void TestInit()
        {
            IoC = new Microsoft.Practices.Unity.UnityContainer();

            // Registrieren der Klassen, mit welchen Schnittstellen und abstrakte Methoden 
            // aufzulösen sind
            IoC.RegisterType<Astro.IGalaxieFactory, Astro.inMem.GalaxieFactory>();
            IoC.RegisterType<Astro.IGalaxieWithStrategieFactory, Astro.inMem.GalaxieWithStrategieFactory>();
            IoC.RegisterType<Astro.ISternClassFactory, Astro.inMem.SternFactory>();
            IoC.RegisterType<Astro.IPlanetFactory, Astro.inMem.PlanetFactory>();

            IoC.RegisterType<Astro.IUniversum, Astro.inMem.UniversumWithDI>();

        }

        [TestMethod]
        public void DI_Test()
        {
            // Mittels IoC- Container wird MyUniverse erstellt. Dazu muss der 
            // IoC den Konstruktor Astro.inMem.UniversumWithDI(ISternClassFactory SternFactory,
            //                                                 IGalaxieFactory GalaxieFactory,
            //                                                 IGalaxieWithStrategieFactory GalaxieWithStrategieFactory,
            //                                                 IPlanetFactory PlanetFactory)
            // aufrufen und die Parameterliste mit INstanzen der benötigten Klassenbibliotheken 
            // füllen. Dies führt der IoC seblständig durch, indem er seine Liste registrierter
            // Schnittstellen und zugehöriger Klassen analysiert.
            var MyUniverse = IoC.Resolve<Astro.IUniversum>();

            MyUniverse.CreateGalaxie("Milchstrasse");
            MyUniverse.CreateStern("Sonne", Astro.Spektralklasse.G(), 1, "Milchstrasse");
            MyUniverse.CreatePlanet("Jupiter", 320, "Sonne");

            var Milkyway = MyUniverse.GetGalaxie("Milchstrasse");
            Assert.AreEqual("Sonne", Milkyway.Sterne.First().Name);


        }
    }
}
