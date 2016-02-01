using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Basics;
using System.Diagnostics;


namespace Basics.Test._02_Arrays_Collections_und_Schnittstellen
{
    [TestClass]
    public class _02_02_CollectionsTests
    {
        [TestMethod]
        public void _02_02_CollectionsGrundlagenTest()
        {
            try
            {

                // Ein Primlist- Objekt erzeugen
                var Von1bis1000 = new PrimSet(1, 1000);

                var enumerator1 = Von1bis1000.GetEnumerator();
                var enumerator2 = Von1bis1000.GetEnumerator();

                // Mit dem ersten vorlaufen
                enumerator1.MoveNext();
                enumerator1.MoveNext();
                enumerator1.MoveNext();

                Debug.WriteLine(enumerator1.Current);

                // Mit dem zweiten einen Schritt nach vorn
                enumerator2.MoveNext();
                Debug.WriteLine(enumerator2.Current);


                // manuell über die IEnumerable- Schnittstelle das Objekt steuern

                var Enum1_1000 = Von1bis1000.GetEnumerator();

                Enum1_1000.Reset();
                if (Enum1_1000.MoveNext())
                {
                    //1. Primzahl: 
                    long p1 =  Enum1_1000.Current;
                    if (Enum1_1000.MoveNext())
                    {
                        // 2. Primzahl:
                        long p2 = Enum1_1000.Current;
                    }
                }


                // Mittels forEach- Schleife alle Primzahlen aus dem definierten Bereich auslesen
                long pSumme = 0;
                foreach (long p in Von1bis1000)
                {
                    pSumme += p;
                }
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }

            try
            {
                var PL1bis1000 = new PrimList(1, 1000);

                int halbeanz = PL1bis1000.Count / 2;

                // Indexer austesten
                // Primzahl in der Mitte: 
                long pMitte =  PL1bis1000[halbeanz];

                PL1bis1000[halbeanz] = 17;

                // Auch forEach funktioniert
                int i = 0;
                long pSumme = 0;
                foreach (long p in PL1bis1000)
                {
                    pSumme +=  p;                    
                }


                for (int ii = 0; ii < PL1bis1000.Count; ii++)
                    Debug.WriteLine(PL1bis1000[ii]);

            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }

        }

        [TestMethod]
        public void _02_02_CollectionsGenerischTest()
        {
            var meinArray = new ArrayInt(5);

            // Compiler wandelt folgende Zeile um in
            // meinArray.this[0].set(2)
            meinArray[0] = 2;
            meinArray[1] = 3;
            meinArray[2] = 5;
            meinArray[3] = 7;
            meinArray[4] = 11;

            int a = meinArray[3];

            for (int i = 0; i < meinArray.Length; i++)
            {
                meinArray[i] = i * 10;
            }

            // Dank IEnumarable können wir auf dem selbsdefinierten Array mittels 
            // einer foreach- Schleife iterieren

            foreach (int elem in meinArray)
            {
                Debug.WriteLine(elem);
            }

            int sum = 0;
            for (int i = 0; i < meinArray.Length; i++)
                // Compiler wandelt folgende Zeile um in
                // meinArray.this[i].get()
                sum += meinArray[i];

            // jetzt den generischen Typ nutzen
            var PreislisteGen = new ArrayGenerisch<Preis>(3);

            PreislisteGen[0] = new Preis(4, 99);
            PreislisteGen[1] = new Preis(1, 99);
            PreislisteGen[2] = new Preis(2, 29);

            var p1 = PreislisteGen[1];           


            var A8 = new ArrayGenerisch<Basics._04_Objektorientiert.Autobahn.Auto>(3);

            //A8[0].tanken(100);

            var deinArray = new ArrayGenerisch<double>(3);

            deinArray[0] = 3.14;
            deinArray[1] = 2.72;
            deinArray[2] = 9.81;

            // deinArray ist streng typisiert
            //deinArray[2] = "Hallo";

            double dblSum = 0;
            for (int i = 0; i < deinArray.Length; i++)
                dblSum += deinArray[i];


            // Vorgefertigte generische Collections einsetzen

            // 1) List- ein dynamischer Ersatz für Arrays
            var Preisliste = new List<Preis>(10);

            FüllePreisliste(Preisliste);

            // Compiler wandelt folgenden Aufruf um in
            // Preisliste.this[3].get()
            var preis3 = Preisliste[3];
            Assert.AreEqual(8, preis3.GetEuro());
            Assert.AreEqual(8, Preisliste[3].GetEuro());

            // Einen Preis aus der Liste entfernen
            Preisliste.RemoveAt(0); // 1. Element entfernen
            Preisliste.RemoveAt(Preisliste.Count - 1); // letztes Element entfernen
            Preisliste.RemoveRange(1, 2);

            FüllePreisliste(Preisliste);

            // Linked List
            var AktuellePreise = new LinkedList<string>();
            foreach (var p in Preisliste)
            {
                AktuellePreise.AddLast(p.ToString());
            }

            foreach (var el in AktuellePreise)
            {
                Debug.WriteLine(el);
            }

            // Iterieren über die LinkedList vorwärts
            LinkedListNode<string> actNode = null;
            for (actNode = AktuellePreise.First; actNode != null; actNode = actNode.Next)
            {
                Debug.WriteLine("preis: " + actNode.Value);

            }

            // Iterieren über die LinkedList rückwärts
            for (actNode = AktuellePreise.Last; actNode != null; actNode = actNode.Previous)
            {
                Debug.WriteLine("preis: " + actNode.Value);

            }

            foreach (var p in AktuellePreise)
            {
                // Current greift auf Value vom Node zu
                Debug.WriteLine("preis: " + p);
            }


            // 2 PReise entfernen
            Preisliste.Remove(new Preis(12, 45));

            // den 3. Preis entfernen
            Preisliste.RemoveAt(3);

            
            AktuellePreise.Clear();
            foreach (var p in Preisliste)
            {
                AktuellePreise.AddLast(p.ToString());
            }

            // Telefonbuch
            var telBuch = new Dictionary<string, int>();

            telBuch.Add("Anton", 4711);

            // neuer Eintrag hinzugefügt, da noch nicht unter dem Schlüssel vorhanden
            // Folgeder Indexeraufruf entspricht telbuch.Add("Berta", 6969);
            telBuch["Berta"] = 6969;

            // Eintrag geändert
            telBuch["Berta"] = 7766;

            telBuch["Cäsar"] = 3344;

            // Iterieren durch Dictionary 1
            var telBuchListe = new LinkedList<string>();
            foreach (var k in telBuch.Keys)
            {
                telBuchListe.AddLast(k + ": " + telBuch[k]);
            }

            // Iterieren durch Dictionary 2
            telBuchListe.Clear();
            foreach (KeyValuePair<string, int> pair in telBuch)
            {
                telBuchListe.AddLast(pair.Key + ": " + pair.Value);
            }

            // Queue

            var Warteschlange = new Queue<Tuple<int, string>>();


            // Aufträge in Warteschlange einstellen
            Warteschlange.Enqueue(new Tuple<int, string>(99, "Abwaschen"));
            Warteschlange.Enqueue(new Tuple<int, string>(77, "Abtrocknen"));
            Warteschlange.Enqueue(new Tuple<int, string>(66, "Wegräumen"));

            // Jobverarbeitung schaltet sich ein
            var Auftragsprotokoll = new LinkedList<string>();
            var Auftrag = Warteschlange.Dequeue();
            Auftragsprotokoll.AddLast("Führe aus: " + Auftrag.Item2);

            Warteschlange.Enqueue(new Tuple<int, string>(55, "Zumachen"));

            // Nachschauen, ohne zu entnehmen
            var erstes = Warteschlange.Peek();

            // Da die Queue IEnumerable implementiert, können alle aktuellen
            // Einträge mittels foreach- Schleife besucht werden
            foreach (var job in Warteschlange)
            {
                Debug.WriteLine(job.Item2);
            }

            var alleJobsDieMitABeginnen = Warteschlange.Where(r => r.Item2.StartsWith("A")).ToArray();

            Auftrag = Warteschlange.Dequeue();
            Auftragsprotokoll.AddLast("Führe aus: " + Auftrag.Item2);

            // Alle restlichen verarbeiten
            while (Warteschlange.Count > 0)
            {
                Auftrag = Warteschlange.Dequeue();
                Auftragsprotokoll.AddLast("Führe aus: " + Auftrag.Item2);
            }

        }

        /// <summary>
        /// Entstanden durch automatische Methodenextraktion
        /// </summary>
        /// <param name="Preisliste"></param>
        private static void FüllePreisliste(List<Preis> Preisliste)
        {
            Preisliste.Add(new Preis(3, 99));
            Preisliste.Add(new Preis(1, 49));

            Preisliste.AddRange(new Preis[] {
                new Preis(12, 45),
                new Preis(8, 20),
                new Preis(15, 99)
            });
        }

    }
}
