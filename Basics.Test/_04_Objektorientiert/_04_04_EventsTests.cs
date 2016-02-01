using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Basics._04_Objektorientiert;

namespace Basics._04_Objektorientiert
{
    [TestClass]
    public class _04_EventsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var FredVollgas = new Autobahn.Auto("Ferrari", "F4", 100);
            var RudiNormalo = new Autobahn.Auto("VW", "Passat", 103);
            var Susi = new Autobahn.Auto("Citroen", "Ente", 105);

            // Eventhandler registrieren
            FredVollgas.Hupen += new Autobahn.Auto.DGHupen(RudiNormalo.HöreHupe);
            FredVollgas.Hupen += new Autobahn.Auto.DGHupen(Susi.HöreHupe);

            // Events sind im Sinne des Aufrufes privat, bezüglich des Zugriffs öffentlich
            //FredVollgas.Hupen(99);


            // Ohne Schlüsselwort event wäre folgendes möglich
            // FredVollgas.Hupen(99);


            for (int i = 0; i < 1000; i++)
            {
                FredVollgas.fahre(100, 1);
                RudiNormalo.fahre(30, 1);
                Susi.fahre(20, 1);

                // Situation bewerten
                FredVollgas.SituationBewerten(RudiNormalo, Susi);
            }

        }
    }
}
