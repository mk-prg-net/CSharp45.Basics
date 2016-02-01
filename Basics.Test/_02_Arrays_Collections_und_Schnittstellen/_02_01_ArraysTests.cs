using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Basics.Test._02_Arrays_und_Collections
{
    [TestClass]
    public class _02_01_ArraysTests
    {

        [TestMethod]
        public void _02_01_01_ArraysIntroTests()
        {
            int[] a = new int[4];
            a[0] = 99;
            a[1] = 4711;

            // Initialisieren mittels Copy
            Array.Copy(new int[] { 88, 33, 44, 14 }, a, a.Length);

            // Zwei Varianten, Arrays zu kopieren
            // 1. Array.Copy: Vorteil: unterschiedliche lange Arrays können kopiert werden
            int[] b = new int[8];
            Array.Copy(a, b, Math.Min(a.Length, b.Length));

            // 2. Clonen: Vorteil: sehr simpel
            int[] c = (int[])a.Clone();


            // Ein 1d Array, das durch eine Liste initialisiert wird
            int[] primzahlen = { 2, 3, 5, 7, 11, 13 };

            Assert.AreEqual(2, primzahlen[0]);
            Assert.AreEqual(13, primzahlen[5]);

            int summePrim = 0;
            for (int i = 0; i < primzahlen.Length; i++)
                summePrim += primzahlen[i];

            // Schleife, die alle Elemente in einem Array besucht
            summePrim = 0;
            foreach (int p in primzahlen)
                summePrim += p;

            // Kopieren und Clonen
            int[] prim2 = primzahlen;

            summePrim = 0;
            foreach (int p in prim2)
                summePrim += p;

            prim2[1] = 53;

            // Beide zeigen auf dasselbe Array !
            Assert.AreEqual(primzahlen[1], prim2[1]);

            // Clonen
            int[] primClone = (int[])primzahlen.Clone();
            primClone[1] = 99;

            Assert.AreNotEqual(primzahlen[1], primClone[1]);            

            // Wert einer Iterationsvariable p in einer foreach- Schleife darf nicht verändert werden
            //foreach (int p in primzahlen)
            //    p++;

            // Ein 2d Array mit 3 Zeilen und 2 Spalten
            double[,] stDiagramm = new double[3, 2];
            //double[][] stDiagramm2 = new double[3][2];

            // 1. Spalte = Zeit, 2. Spalte = zurückgelegter Weg
            stDiagramm[0, 0] = 1; stDiagramm[0, 1] = 0.5;
            stDiagramm[1, 0] = 2; stDiagramm[1, 1] = 1.0;
            stDiagramm[2, 0] = 3; stDiagramm[2, 1] = 1.5;


            // Anzahl der Dimensionen von stDiagramm: 2
            Assert.AreEqual(2, stDiagramm.Rank);

            Assert.AreEqual(3, stDiagramm.GetLength(0));
            Assert.AreEqual(2, stDiagramm.GetLength(1));

            double[,] vtDiagramm = new double[2, 2];


            for (int i = 0; i < vtDiagramm.GetUpperBound(0) + 1; i++)
            {
                vtDiagramm[i, 0] = stDiagramm[i, 0];
                vtDiagramm[i, 1] = (stDiagramm[i + 1, 1] - stDiagramm[i, 1]) / (stDiagramm[i + 1, 0] - stDiagramm[i, 0]);
            }

            // 2D- Array mit Initialisierungsliste anlegen
            double[,] vt2 = {
                                {1.0, 2.0},
                                {2.0, 3.9},
                                {3.0, 4.8}
                            };
            Assert.AreEqual(vt2.GetUpperBound(0), 2);
            Assert.AreEqual(vt2.GetUpperBound(1), 1);
            Assert.AreEqual(vt2.Rank, 2);
            Assert.AreEqual(vt2.Length, 6);
        }

        [TestMethod]
        public void _02_01_02_ArraysSortTest()
        {
            try
            {
                // Sortieren eingebauter Datentypen

                int[] primz = { 19, 2, 41, 37, 17, 19, 13, 5, 7, 3, 11 };
                Array.Sort(primz);


                string[] planeten = { "Merkur", "Venus", "Erde", "Mars", "Jupiter", "Saturn" };
                Array.Sort(planeten);

                // Absteigend sortieren
                Array.Reverse(planeten);



                // Preisliste anlegen
                PriceDbl[] Preisliste = {
                                     new PriceDbl(5.99, CurrencySymbols.SFr),
                                     new PriceDbl(3.49, CurrencySymbols.SFr),
                                     new PriceDbl(1.99, CurrencySymbols.USD),
                                     new PriceDbl(0.99, CurrencySymbols.EUR),
                                     new PriceDbl(4.49, CurrencySymbols.EUR)
                                 };

                // Preisliste sortierbar, da Preis die IComparable- Schnittstelle implementiert
                Array.Sort(Preisliste);

                // Alternative zum Zwang IComparable zu impelemntieren ist LINQ
                PriceDbl[] Preisliste2 = {
                                     new PriceDbl(5.99, CurrencySymbols.SFr),
                                     new PriceDbl(3.49, CurrencySymbols.SFr),
                                     new PriceDbl(1.99, CurrencySymbols.USD),
                                     new PriceDbl(0.99, CurrencySymbols.EUR),
                                     new PriceDbl(4.49, CurrencySymbols.EUR)
                                 };
                var PreiseSortiert = Preisliste2.OrderBy(r => r.ToUSD()).ToArray();


                //var Preisliste_sortiert = Preisliste.OrderBy(preis => preis.GetEuro() * 100 + preis.GetCent());
                //var Preisliste_sortiert_desc = Preisliste.OrderByDescending(preis => preis.GetEuro() * 100 + preis.GetCent());

                //var Preisliste_gefiltert_und_sortiert = Preisliste.Where(preis => preis.GetEuro() >= 1 && preis.GetEuro() < 5)
                //                                                  .OrderBy(preis => preis.GetEuro() * 100 + preis.GetCent());

                //foreach (var preis in Preisliste_gefiltert_und_sortiert)
                //{
                //    Debug.WriteLine(preis.ToString());
                //}

                //Preisliste[0].SetPreis(2.99);

                //Debug.WriteLine("Gefilterte Preisliste, nachdem die ursprüngliche Quelle geändert wurde");
                //foreach (var preis in Preisliste_gefiltert_und_sortiert)
                //{
                //    Debug.WriteLine(preis.ToString());
                //}




                //var Preisliste_in_Dollar_gefiltert_und_sortiert = Preisliste.Where(preis => preis.GetEuro() >= 1 && preis.GetEuro() < 5)
                //                                  .OrderBy(preis => preis.GetEuro() * 100 + preis.GetCent())                                                  
                //                                  .Select(preis => (((double)preis.GetEuro() * 100 + preis.GetCent())/100.0) * 1.37)
                //                                  .ToArray();




                //---------------------------------------------------------------------
                // Alternative zum Erweitern sortierender Objekte mit IComparable:
                // IComparer

                PointWithProperties[] Punkte = {
                                                   new PointWithProperties(3, 5),
                                                   new PointWithProperties(1,2),
                                                   new PointWithProperties(4,4),
                                                   new PointWithProperties(2,2),
                                                   new PointWithProperties(3,2),
                                                   new PointWithProperties(-2,-8)
                                               };

                System.Array.Sort(Punkte, new PointVergleicher());

            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }


        }
    }
}
