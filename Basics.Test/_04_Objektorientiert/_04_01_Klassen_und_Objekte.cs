using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

using Basics._04_Objektorientiert;
using Basics._04_Objektorientiert.Autobahn;

namespace Basics.Test._04_Objektorientiert
{
    [TestClass]
    public class _04_01_Klassen_und_Objekte
    {
        void MeinEventhandler(double Zeitlimit, double verstricheneZeitInMs)
        {
            Debug.WriteLine("Zeitlimit: " + Zeitlimit.ToString("N1") + ", verstrichene Zeit: " + verstricheneZeitInMs.ToString("N1"));
        }


        void MeinAndererEventhandler(double Zeitlimit, double verstricheneZeitInMs)
        {
            Debug.WriteLine("Anderer Eventhandler:  Zeitlimit: " + Zeitlimit.ToString("N1") + ", verstrichene Zeit: " + verstricheneZeitInMs.ToString("N1"));
        }

        [TestMethod]
        public void TestMethod1()
        {

            StoppUhr meineStoppuhr = new StoppUhr();

            // Zugriff auf den inneren Zustand durch schreiben in eine Eigenschaft
            meineStoppuhr.ZeitInMsEigenschaft = 1000;


            // Lesen des inneren Zustandes durch lesen einer eigenschaft
            double gestoppteZeit = meineStoppuhr.ZeitInMsEigenschaft;

            // Events austesten
            meineStoppuhr.ZeitLimitInMs = 1000;

            // Eventhandler registrieren
            meineStoppuhr.ZeitlimitUeberschrittenEvent += MeinEventhandler;

            // wg. dem Schlüsselwort event kann der Delegate nicht m,ehr über die Objektinstanz direkt aufgeufen werden
            //meineStoppuhr.ZeitlimitUeberschrittenEvent(1, 2);

            meineStoppuhr.Start();

            System.Threading.Thread.Sleep(2000);

            meineStoppuhr.Stopp();

            // Eventhandler wieder abkoppeln
            meineStoppuhr.ZeitlimitUeberschrittenEvent -= MeinEventhandler;
            // anderen ankoppeln
            meineStoppuhr.ZeitlimitUeberschrittenEvent += MeinAndererEventhandler;

            meineStoppuhr.Start();

            System.Threading.Thread.Sleep(2000);

            meineStoppuhr.Stopp();


            // Beide Eventhandler ankoppeln
            meineStoppuhr.ZeitlimitUeberschrittenEvent += MeinEventhandler;

            meineStoppuhr.Start();

            System.Threading.Thread.Sleep(2000);

            meineStoppuhr.Stopp();



            Wasserhahn kleinerHahn = new Wasserhahn(25.4),
            Absperrhahn = new Wasserhahn(50.8);


            kleinerHahn.öffnen(50.0);
            Absperrhahn.öffnen(100.0);



            kleinerHahn.öffnen(20);
            Absperrhahn.öffnen(100);

            Console.WriteLine("Öffnung kleiner Hahn in %: {0:N1}", kleinerHahn.ÖffnungInPromille / 10);

            kleinerHahn.ÖffnungInPromille = 333;

            Console.WriteLine("Öffnung kleiner Hahn in %: {0:N1}", kleinerHahn.ÖffnungInPromille / 10);

            // Zugriff auf statische Methoden
            Console.WriteLine("Durchfluss: {0:N3}", Wasserhahn.DurchflussInCm3ProSekunde(kleinerHahn, 10));

            // Arbeiten mit der Klasse Auto

            // Objekte konstuieren oder synonym Instanzen instanziieren

            Auto FredVollgas = new Auto("Ferrari", "Testarossa");
            

            // nur lesbare Eigenschaft kann nicht gesetzt werden
            //FredVollgas.VolleFahrzeugbezeichnung = "Porsche/Carrera";
            Debug.WriteLine(FredVollgas.VolleFahrzeugbezeichnung);

            // Eine Eigenschaft mit intelligenten Gettern und Settern

            // Compiler wandelt Zuweisung um in FredVollgas.EntfernungVonStuttgartInKm.set(100);
            FredVollgas.EntfernungVonStuttgartInKm = 100;



            // Anlegen von SusiSchleicher mit dem 2. Konstruktor (startet bei 50km)
            Auto SusiSchleicher = new Auto("VW", "Käfer", 50, 10);


            Auto AntonNormalo = new Auto("VW", "Golf", 10, 120);

            // Neu ab .NET 3.5 Objektinitialisierer: Dynamisch einen Konstruktor der Wahl schaffen
            Auto RudiHandwerker = new Auto("Audi", "A6", 25);


            Auto[] fahrsteifen = new Auto[] {
                new Auto("Fiat", "Stilo", 99),
                new Auto("Dacia", "Logan", 200),
                new Auto("VW", "Golf", 150)
            };


            Console.WriteLine("Der Wagen von Fred Vollgas iste ein " + FredVollgas.Marke + " Modell " + FredVollgas.Modell);
            // Marke ist eine nur lesbare Eigenschaft
            //SusiSchleicher.Marke = "Ferrari";

            // Fahren und Position über den Rückgabewert der Methode bestimmen
            double pos = FredVollgas.fahre(50, 5);

            Console.WriteLine("Aktuelle Position von Fred Vollgas: {0:N3}", FredVollgas.EntfernungVonStuttgartInKm);

            double[] v = { 20, 30, 10, 40, 50, 60, 30, 10 };
            double[] t = { 40, 20, 30, 5, 3, 7, 10, 15 };

            // Simulation: Vorankommen auf dem hat umkämpften linken Fahrstreifen
            for (int i = 0; i < v.Length; i++)
            {
                FredVollgas.fahre(v[i], t[i]);
                Console.WriteLine("Aktuelle Position von Fred Vollgas: {0:N3}", FredVollgas.EntfernungVonStuttgartInKm);
            }

        }

      
    }
}
