using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

using System.Linq;

using Basics._04_Objektorientiert;
using Basics._04_Objektorientiert.Astro.inMem;


namespace Basics._04_Objektorientiert
{
    [TestClass]
    public class _04_Astro
    {
        [TestMethod]
        public void GalaxieTest()
        {
            mko.Newton.Init.Do();

            Universum.Instance.CreateGalaxie("Milchstrasse");

            // Zugriff auf die Milchstrasse
            var Milchstrasse = Universum.Instance.GetGalaxie("Milchstrasse");

            Universum.Instance.CreateStern("Sonne", Astro.Spektralklasse.G(), 1.0, "Milchstrasse");
            // Zugriff auf die Sonne
            Astro.Stern Sonne = Universum.Instance.GetStern("Sonne");

            Universum.Instance.CreatePlanet("Merkur", 0.0553, "Sonne");
            Universum.Instance.CreatePlanet("Venus", 0.815, "Sonne");
            Universum.Instance.CreatePlanet("Erde", 1, "Sonne");
            Universum.Instance.CreatePlanet("Mars", 0.1074, "Sonne");
            Universum.Instance.CreatePlanet("Jupiter", 318, "Sonne");
            Universum.Instance.CreatePlanet("Saturn", 95, "Sonne");
            Universum.Instance.CreatePlanet("Uranus", 15, "Sonne");
            Universum.Instance.CreatePlanet("Neptun", 17, "Sonne");


            Universum.Instance.CreateStern("Beteigeuze", Astro.Spektralklasse.M(), 3000.0, "Milchstrasse");

            // Upcast (Cast in den Typ der Basisklasse) ist implizit möglich
            Astro.IHimmelskörper h = Sonne;

            // Downcast muss immer mit expliziter Typkonvertierung erfolgen
            Stern einStern = (Stern)h;

            // Demo Polymorphismus
            var MasseMilchstrasse = Milchstrasse.Masse_in_kg / mko.Newton.Mass.MassOfSun.Value;
            var MasseMilchstrasse2 = Milchstrasse.Sterne.Sum(r => r.Masse_in_Sonnenmassen) + Sonne.Planetensystem.Sum(p => p.Masse_in_kg) / mko.Newton.Mass.MassOfSun.Value;

            Assert.AreEqual(Math.Round(MasseMilchstrasse, 6), Math.Round(MasseMilchstrasse2, 6));


        }


        [TestMethod]
        public void GalaxieMitStrategieTest()
        {
            mko.Newton.Init.Do();

            // Strategie: die Palnetenmassen bei der Berechnung vernachlässigen
            Universum.Instance.CreateGalaxieWithStrategie("Milchstrasse", Astro.BerechneGalaxiemasseAusDenSternen.Instanz);

            // Zugriff auf die Milchstrasse
            var Milchstrasse = Universum.Instance.GetGalaxie("Milchstrasse");

            Universum.Instance.CreateStern("Sonne", Astro.Spektralklasse.G(), 1.0, "Milchstrasse");
            // Zugriff auf die Sonne
            Astro.Stern Sonne = Universum.Instance.GetStern("Sonne");

            Universum.Instance.CreatePlanet("Merkur", 0.0553, "Sonne");
            Universum.Instance.CreatePlanet("Venus", 0.815, "Sonne");
            Universum.Instance.CreatePlanet("Erde", 1, "Sonne");
            Universum.Instance.CreatePlanet("Mars", 0.1074, "Sonne");
            Universum.Instance.CreatePlanet("Jupiter", 318, "Sonne");
            Universum.Instance.CreatePlanet("Saturn", 95, "Sonne");
            Universum.Instance.CreatePlanet("Uranus", 15, "Sonne");
            Universum.Instance.CreatePlanet("Neptun", 17, "Sonne");


            Universum.Instance.CreateStern("Beteigeuze", Astro.Spektralklasse.M(), 3000.0, "Milchstrasse");            

            // Demo Polymorphismus
            var MasseMilchstrasse = Milchstrasse.Masse_in_kg / mko.Newton.Mass.MassOfSun.Value;
            var MasseMilchstrasse2 = Milchstrasse.Sterne.Sum(r => r.Masse_in_Sonnenmassen);

            Assert.AreEqual(Math.Round(MasseMilchstrasse, 6), Math.Round(MasseMilchstrasse2, 6));


        }

    }
}
