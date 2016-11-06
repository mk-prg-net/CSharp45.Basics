using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Basics._01_Grundbausteine.Universum.Andromeda.Spiralarme.Sterne.Neutronensterne;
//using Basics._01_Grundbausteine.Universum.Milchstrasse.Spiralarme.Sterne.Neutronensterne;


// Aliasbezeichner für einen langen Namenspfad
using Milcharm = Basics._01_Grundbausteine.Universum.Milchstrasse.Spiralarme;

// Aliasbezeichner für einen Datentyp
using Milchkern = Basics._01_Grundbausteine.Universum.Milchstrasse.Galaxiekern.Schwarzes_Loch;

//using Basics._01_Grundbausteine.Universum.Milchstrasse.Galaxiekern;
using Basics._01_Grundbausteine.Universum.Andromeda.Galaxiekern;

// Aliasbezeichner für Namensraum
using Milchkerne = Basics._01_Grundbausteine.Universum.Milchstrasse.Galaxiekern;

namespace Basics.Test
//namespace Basics._01_Grundbausteine.Universum.Andromeda.Spiralarme
{
    [TestClass]
    public class _01_02_Namespaces
    {
        [TestMethod]
        public void _01_02_NamespacesTest()
        {
            // Zugriff über voll qualifizierten Namen
            var blackHole = new Basics._01_Grundbausteine.Universum.Andromeda.Galaxiekern.Schwarzes_Loch();

            var blackHole2 = new Basics._01_Grundbausteine.Universum.Milchstrasse.Galaxiekern.Schwarzes_Loch();

            var blackhole2_1 = new Schwarzes_Loch();
            var blackhole2_2 = new Milchkerne.Schwarzes_Loch();

            // Zugriff über kurzen Aliasnamen für Datentyp
            var blackHole3 = new Milchkern();
            Assert.IsInstanceOfType(blackHole3, typeof(Basics._01_Grundbausteine.Universum.Milchstrasse.Galaxiekern.Schwarzes_Loch));

            // Zugriff über kurzen Aliasnamen für Namensraum
            var sonne = new Milcharm.Sterne.Sonnenähnliche();
            Assert.IsInstanceOfType(sonne, typeof(Basics._01_Grundbausteine.Universum.Milchstrasse.Spiralarme.Sterne.Sonnenähnliche));

            if (sonne is Basics._01_Grundbausteine.Universum.Milchstrasse.Spiralarme.Sterne.Sonnenähnliche)
            {
                Assert.IsTrue(true);
            }

            Type typSonne = sonne.GetType();
            Type typSonnenähnlich = typeof(Basics._01_Grundbausteine.Universum.Milchstrasse.Spiralarme.Sterne.Sonnenähnliche);

            if(Object.ReferenceEquals(typSonne, typSonnenähnlich)) {
                Assert.IsTrue(true);
            }

            // Das typSonne und typSonnenähnlich Referenztypen sind, ist
            // folgender Vergleich auf Identität gleichwertig mit Objekt.ReferenceEquals
            if (typSonne == typSonnenähnlich)
            {
                Assert.IsTrue(true);
            }

            // Zugriff über using
            var supermagnet = new Magnetare();
            Assert.IsInstanceOfType(supermagnet, typeof(Basics._01_Grundbausteine.Universum.Andromeda.Spiralarme.Sterne.Neutronensterne.Magnetare));

            var supermagnet2 = new Basics._01_Grundbausteine.Universum.Milchstrasse.Spiralarme.Sterne.Neutronensterne.Magnetare();

            var puls = new Pulsare();

            var milchPuls = new Milcharm.Sterne.Neutronensterne.Pulsare();
        }
    }
}
