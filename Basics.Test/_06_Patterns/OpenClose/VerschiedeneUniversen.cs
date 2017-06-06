using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Test._06_Patterns.OpenClose
{
    [TestClass]
    public class VerschiedeneUniversen
    {
        //
        

        [TestMethod]
        public void TestMethod1()
        {
            ErzeugeEinSonnensystem(Basics._04_Objektorientiert.Astro.inMem.Universum.Instance);

            // ErzeugeEinSonnensystem(Basics._04_Objektorientiert.Astro.inDB.Universum.Instance);

        }

        /// <summary>
        /// Demo Open Close. Ist gleichzeitig auch eine Demo für Method Injection (Spezialform 
        /// der Dependency INjection)
        /// </summary>
        /// <param name="meinUniversum"></param>
        void ErzeugeEinSonnensystem(Basics._04_Objektorientiert.Astro.IUniversum meinUniversum)
        {

            meinUniversum.CreateGalaxie("MeineGalaxie");
            meinUniversum.CreateStern("MeineSonne", Basics._04_Objektorientiert.Astro.Spektralklasse.A(), 1, "MeineGalaxie");
            meinUniversum.CreatePlanet("MeineErde", 1, "MeineSonne");


        }


    }
}
