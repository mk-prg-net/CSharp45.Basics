using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

using System.Linq;

using Basics._04_Objektorientiert;
using Basics._04_Objektorientiert.Astro.inMem;

namespace Basics._04_Objektorientiert
{
    [TestClass]
    public class _04_PolymorphismusTests
    {
        //[ClassInitialize]
        //public void ClassInit()
        //{
        //    mko.Newton.Init.Do();
        //}


        [TestMethod]
        public void Autobahntest()
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
