using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

using Basics._01_Grundbausteine;

using P = Basics._01_Grundbausteine._01_01_Blockstruktur;

namespace Basics.Test._01_Grundbausteine
{
    [TestClass]
    public class _01_01_BloeckeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Aufruf statischer Member. Klassen als Container für Unterprogramme und Variablen klassischen, prozeduralen Sinne
            _01_01_Blockstruktur.EineStatischeVariable = _01_01_Blockstruktur.Sum(1, 2);

            P.EineStatischeVariable = P.Sum(99, 222);

            Debug.WriteLine(_01_01_Blockstruktur.EineStatischeVariable);


            // Das Unterprogramm geannte Unterprogramm ist kein statischer Memeber.
            // Um ihn aufzurufen, bedarf es einer Objektinstanz

            P obj = new P();
            obj.Unterprogramm();


        }
    }
}
