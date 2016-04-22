using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

using Basics._04_Objektorientiert;

namespace Basics._04_Objektorientiert
{
    [TestClass]
    public class _04_PolymorphismusTests
    {
        [ClassInitialize]
        public void ClassInit(TestContext ctx)
        {
            mko.Newton.Init.Do();
        }

        [TestMethod]
        public void HimmeslkoerperTest()
        {
            Stern Sonne = new Stern(1.0);
            Stern Beteigeuze = new Stern(100);

            Galaxie Milchstrasse = new Galaxie(new Stern[] { Sonne, Beteigeuze });

            // Upcast (Cast in den Typ der Basisklasse) ist implizit möglich
            Himmelskörper h = Sonne;

            // Downcast muss immer mit expliziter Typkonvertierung erfolgen
            Stern einStern = (Stern)h;

            // Demo Polymorphismus
            Himmelskörper[] Katalog = { Sonne, Beteigeuze, Milchstrasse };


            foreach (var himmelkoerper in Katalog)
            {
                Debug.WriteLine(himmelkoerper.BerechneMasseInKg());
            }

        }


        [TestMethod]
        public void TestMethod1()
        {
            Autobahn.Benzinauto FredVollgas = new Autobahn.Benzinauto("Ferrari", "F4");
            Autobahn.Dieselauto RudiNormalo = new Autobahn.Dieselauto("VW", "Passat TDI");
            //Autobahn.Auto allgAuto = new Autobahn.Auto();

            Debug.WriteLine(RudiNormalo.VolleFahrzeugbezeichnung);

            Autobahn.Auto RudiNormaloAlsBasisklasse = RudiNormalo;
            Debug.WriteLine(RudiNormaloAlsBasisklasse.VolleFahrzeugbezeichnung);


            string txt = FredVollgas.ToString();
            txt = RudiNormalo.ToString();

            //allgAuto.tankenPolymorph(100);

            // as Cast fürht bei Typinkompatibilität zur Rückgabe eines null- Wertes
            Autobahn.Auto RudiNormaloAlsAuto = RudiNormalo; // as Autobahn.Auto;
            RudiNormalo.tanken(20);
            RudiNormaloAlsBasisklasse.tanken(20);
            FredVollgas.tanken(30);

            RudiNormaloAlsAuto.tanken(30);

            RudiNormaloAlsAuto.tankenPolymorph(40);

            RudiNormalo.tankenPolymorph(45);

            ((IDisposable)RudiNormaloAlsAuto).Dispose();

            RudiNormalo.Dispose();

            FredVollgas.tanken(100);
            RudiNormalo.tanken(50);

            Autobahn.Auto einAuto = FredVollgas;
            einAuto.tanken(33);
            einAuto.tankenPolymorph(33);

            einAuto = RudiNormalo;
            einAuto.tanken(22);
            einAuto.tankenPolymorph(22);

            Autobahn.Auto[] flotte = { FredVollgas, RudiNormalo };

            for (int i = 0; i < flotte.Length; i++)
            {
                Debug.WriteLine("Auftanken für " + flotte[i].ToString() + " beginnt");
                flotte[i].tanken(10);
                flotte[i].tankenPolymorph(15);

            }

            //LKW abstrakterLKW = new LKW();

            Autobahn.LKW abstrakterGastanker = new Autobahn.Gastanker();

            abstrakterGastanker.tankenPolymorphAbstract(100);

            // Rückgriff auf Defaultimplementierung in Basisklasse Auto
            abstrakterGastanker.tankenPolymorph(200);
        }
    }
}
