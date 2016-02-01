using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

using Basics;

namespace Basics.Test.LISP
{
    [TestClass]
    public class _02_03_Linq_LSIP_Tests
    {
        void printListe(IEnumerable<int> liste)
        {
            foreach (int el in liste)
            {
                Debug.Write(el + ", ");
            }
        }

        [TestMethod]
        public void _02_03_01_LSIP_IntroTest()
        {
            int[] liste = { 2, 3, 5, 7, 11, 13 };

            // Zugriff auf einzelnes Listenelement mittels Indexer (<Indexnummer>)
            // (Beachte, dass die Indizes mit 0 beginnen !)
            var el4 = liste[3];
            Debug.WriteLine("4. Element in der Liste hat den Wert: " + el4);

            // Zuweisen eines neuen Wertes an ein Listenelement
            liste[3] = 37;
            //Debug.WriteLine("4. Element in der Liste hat nun den Wert: " + liste(3));

            // Durchlaufen aller Listenelemente
            //Debug.WriteLine("Alle Listenelemente");
            printListe(liste);

            // Liste erweitern
            var liste2 = liste.Concat(new int[] { 17, 19, 23, 29, 31 });
            Debug.WriteLine("");
            Debug.WriteLine("Alle Listenelemente nach Erweiterung");
            printListe(liste2);

            // In Liste2 steht keine Liste sondern ein "Abfrage", die das Ergebnis liefert
            // => Ändern sich die INhalte der "Quellen" der Abfrage, dann ändert sich 
            // auch das Abfrageergebnis
            Debug.WriteLine("");
            Debug.WriteLine("Alle Listenelemente nach Erweiterung und Änderung in der Quellliste");
            liste[0] = 47;
            printListe(liste2);

            // Fixieren der Resultate einer Abfrage gelingt mit der ToArray- Methode
            var liste2Fix = liste.Concat(new int[] { 17, 19, 23, 29, 31 }).ToArray();
            Debug.WriteLine("");
            Debug.WriteLine("Alle Listenelemente nach Erweiterung mit Fixierung");
            printListe(liste2Fix);

            liste[0] = 53;
            Debug.WriteLine("");
            Debug.WriteLine("Alle Listenelemente der fixierten Liste (nochmal)");
            printListe(liste2Fix);


            // Liste am Kopf erweitern
            var liste2_1 = new int[] { -5, -3, -2 }.Concat(liste2);
            Debug.WriteLine("");
            Debug.WriteLine("Vorne erweiterte Liste");
            printListe(liste2_1);


            // Kopf der Liste (ersten 3 Elemente) abschneiden
            var listeKopflos = liste2.Skip(3);

            Debug.WriteLine("");
            Debug.WriteLine("Liste ohne Kopf");
            printListe(listeKopflos);

            // Schwanz der Liste abschneiden
            var listeSchwanzlos = liste2.Take(3);
            Debug.WriteLine("");
            Debug.WriteLine("Liste ohne Schwanz");
            printListe(listeSchwanzlos);

            // Ein Stück aus der Mitte herausschneiden
            // Take(Skip(liste2, 3), 3)
            var Mittelstück = liste2.Skip(3).Take(3);
            Debug.WriteLine("");
            Debug.WriteLine("Mittelstück");
            printListe(Mittelstück);


            // Indexzugriffoperator als Spezialfall von Take und Skip
            // Zugriff auf das 5- te Element
            var el5 = liste2.ToArray()[5];
            var el5_ = liste2.Skip(5).Take(1).First();

            Assert.AreEqual(el5, el5_);



            var Mittelstück2 = liste2.Skip(12).Take(3);
            //Debug.WriteLine("");
            //Debug.WriteLine("Mittelstück");
            printListe(Mittelstück2);

            // Prüfen, ob Liste leer
            if (!liste2.Any())
            {
                Debug.WriteLine("Liste liste2 ist leer");
            }
            else
            {
                Debug.WriteLine("Liste liste2 ist nicht leer");
            }

            // Prüfen, ob Liste leer
            if (!Mittelstück2.Any())
            {
                Debug.WriteLine("Liste Mittelstück2 ist leer");
            }
            else
            {
                Debug.WriteLine("Liste Mittelstück2 ist nicht leer");
            }

            var umgedrehteListe = liste2_1.Reverse();

            var erstesElement = liste2_1.First();
            var letztesElement = liste2_1.Last();


        }


        IEnumerable<long> QueryAlleDurch3tlb = new long[] { 3, 5, 9, 12, 15, 19 }.Where(z => z % 3 == 0);

        IEnumerable<long> FilterAlleDurch3tlb(IEnumerable<long> src)
        {
            return src.Where(z => z % 3 == 0);
        }

        [TestMethod]
        public void _02_03_02_Linq_IntroTest()
        {

            // 
            long[] listeA = { 3, 5, 9, 12, 15, 19 };
            long[] listeB = { 13, 15, 19, 25, 39, 45 };

            // Listen zu einer großen Zusammenfassen (mit Duplikate)
            var alle = listeA.Concat(listeB);

            // ... ohne Duplikate
            var alleOhneDuplikate = listeA.Union(listeB);

            // Schnittmenge
            var Schnittmenge = listeA.Intersect(listeB);
            
            Assert.AreEqual(alle.Count() - Schnittmenge.Count(), alleOhneDuplikate.Count());

            // Alle Elemente zählen
            int anzAlle = alle.Count();

            // Zählen aller durch 3 teilbaren in listeA
            int anzHabenTeiler3 = alle.Count(z => z % 3 == 0);            

            // Filtern der Listen mittels Where - Algo
            var habenTeiler3 = alle.Where(z => z % 3 == 0);
            var habenTeiler5 = alle.Where(z => z % 5 == 0);


            var habenTeiler3_1 = FilterAlleDurch3tlb(alle);
            habenTeiler3_1 = FilterAlleDurch3tlb(new long[]{33, 55, 77, 99, 66});

            var AllePrimzahlen = alleOhneDuplikate.Where(z => z.IsPrime()).OrderBy(z => z);


            // Linq mit komplexeren Daten
            Preis[] Preisliste = {
                                     new Preis(5,99),
                                     new Preis(3,49),
                                     new Preis(1,29),
                                     new Preis(1,99),
                                     new Preis(3,21),
                                     new Preis(0,99),
                                     new Preis(4,49)
                                 };

            int x = 99;
            Func<Preis, int> dgBerechnePreis = preis => preis.GetEuro() * 100 + preis.GetCent();

            var Preisliste_sortiert = Preisliste.OrderBy(dgBerechnePreis);
            var Preisliste_sortiert_desc = Preisliste.OrderByDescending(preis => preis.GetEuro() * 100 + preis.GetCent());

            var Preisliste_gefiltert_und_sortiert = Preisliste.Where(preis => preis.GetEuro() > 1 && preis.GetEuro() < 5)
                                                              .OrderBy(preis => preis.GetEuro() * 100 + preis.GetCent())
                                                              .ToArray();
            // Sortieren nach mehreren Eigenschaften/Kriterien
            var Preisliste_sortiert_nach_euro_und_cent = Preisliste.OrderBy(preis => preis.GetEuro())
                                                                   .ThenBy(preis => preis.GetCent())
                                                                   .ToArray();

            var Preisliste_sortiert_nach_euro_und_cent2 = Preisliste.OrderBy(preis => preis.GetEuro())
                                                                    .ThenByDescending(preis => preis.GetCent())
                                                                    .ToArray();



            var Preisliste_in_Dollar_gefiltert_und_sortiert = Preisliste.Where(preis => preis.GetEuro() > 1 && preis.GetEuro() < 5)
                                              .OrderBy(dgBerechnePreis)
                                              .Select(preis => (((double)preis.GetEuro() * 100 + preis.GetCent()) / 100.0) * 1.32)
                                              .ToArray();


        }
    }
}
