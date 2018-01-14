using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

using Basics._04_Objektorientiert.Autobahn;

namespace Basics.Test._04_Objektorientiert
{
    [TestClass]
    public class _04_02_Konstruktion_Destruktion
    {
        class C
        {
            Object x;
            public static int anz_instanzen;
            public static double pi;

            static C()
            {
                anz_instanzen = 1;
                pi = Basics._01_Grundbausteine._01_03_Ausdruecke.F_Pi_Kettenbruch();
            }
        }


        [TestMethod]
        public void TestMethod1()
        {
            // Statische Konstruktoren
            var mein_pi = C.pi;
            var dein_pi = C.pi;
            var meine_instanzen = C.anz_instanzen;

            // Objektkonstruktion
            Auto HugosSchrottkiste = new Auto();

            HugosSchrottkiste.EntfernungVonStuttgartInKm = 200;

            HugosSchrottkiste.Dispose();

            // Um die explizit implementierte Dispose- Methode aus IDisposable aufzurufen, muß zuvor ein Schnittstellenzeiger gezogen werden
            IDisposable ptrIDsp = HugosSchrottkiste;
            ptrIDsp.Dispose();

            ((IDisposable)HugosSchrottkiste).Dispose();

            {
                IDisposable dptr = HugosSchrottkiste;
                dptr.Dispose();
            }

            var Goldpfeil = new Auto();

            //...
            {
                IDisposable dptr = Goldpfeil;
                dptr.Dispose();
            }

            // Simmulation von 'Scope' in C++
            using (var Silberpfeil = new Auto("Mercedes", "Rennauto"))
            {
                Debug.WriteLine(Silberpfeil.Marke);

            } // Hier wird automatisch Dispose aufgerufen

            // Im unsing- Block können nur Objekte instanziiert werden, deren Klasse
            // IDisposable implementieren
            //using (var Zentrum = new Point(1, 2))
            //{

            //}

            try
            {
                var Silberpfeil2 = new Auto("Mercedes", "Rennauto2");
                //using(var heute = DateTime.Now)
                using (var fredVollgas = new Auto("Ferrari", "Testarossa"))
                using (var KunoTunichtGut = new Auto("Alpha", "Romeo"))
                {
                    Debug.WriteLine(Silberpfeil2.Marke);
                    // Plötzlich passiert ein Fehler
                    throw new Exception();
                    Debug.WriteLine("Nach dem Fehler");
                }
                // Überschreiten der using- Blockgrenze fürht automat. zum Aufruf von 
                // Dispose
                ((IDisposable)Silberpfeil2).Dispose();
            }
            catch (Exception)
            {
                Debug.WriteLine("Fehler aus using- Block wurde behandelt");
            }






            // Die bessere Lösung wäre wohl nur explizite Implementierung zuzulassen, wobei der Zugriff auf die Schnittstellenelemente 
            // von c# unterstützt wird wie folgt
            // HugosSchrottkiste.IDisposable.Dispose();


            for (int k = 0; k < 100; k++)
            {
                Auto FredVollgas = new Auto("Ferrari", "Nr " + k, 0, 80);

                do
                {
                    double[] v = { 20, 30, 10, 40, 50, 60, 30, 10 };
                    double[] t = { 40, 20, 30, 5, 3, 7, 10, 15 };

                    // Simulation: Vorankommen auf dem hat umkämpften linken Fahrstreifen
                    for (int i = 0; i < v.Length; i++)
                    {
                        FredVollgas.fahre(v[i], t[i]);
                        //Debug.WriteLine("Aktuelle Position von Fred Vollgas: {0:N3}", FredVollgas.EntfernungVonStuttgartInKm);
                    }
                } while (FredVollgas.EntfernungVonStuttgartInKm < 50.0);
            }

            for (int k = 0; k < 100; k++)
            {
                Auto FredVollgas = new Auto("VW", "Nr " + k, 0, 80);
                using (Auto FredVollgas2 = new Auto("VW-using", "Nr " + k, 0, 80))
                {
                    do
                    {
                        double[] v = { 20, 30, 10, 40, 50, 60, 30, 10 };
                        double[] t = { 40, 20, 30, 5, 3, 7, 10, 15 };

                        if (k == 50)
                            goto Sprungmarke;

                        // Simulation: Vorankommen auf dem hat umkämpften linken Fahrstreifen
                        for (int i = 0; i < v.Length; i++)
                        {
                            FredVollgas2.fahre(v[i], t[i]);
                            //Debug.WriteLine("Aktuelle Position von Fred Vollgas: {0:N3}", FredVollgas2.EntfernungVonStuttgartInKm);
                        }
                    } while (FredVollgas2.EntfernungVonStuttgartInKm < 50.0);

                } // Ende using- Block
                //Einen "Schnittstellenzeiger ziehen", um auf die explizit definierte Dispose- Methode zuzugreifen
                //IDisposable dsp = FredVollgas;
                //dsp.Dispose();
            }
            Sprungmarke:;
        }
    }
}
