using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Basics.Test._05_Multithreading
{
    [TestClass]
    public class _05_01_ThreadsMitDelegatesTests
    {

        delegate IEnumerable<long> DGps(long start, long end);

        [TestMethod]
        public void _05_01_ThreadsMit2DelegatesTest()
        {
            Basics._04_Objektorientiert.StoppUhr st = new Basics._04_Objektorientiert.StoppUhr();

            st.Start();

            const long ende = 10000000;

            DGps dgPrimscan = new DGps(mko.Algo.NumberTheory.PrimeFactors.scan);


            var ares1 = dgPrimscan.BeginInvoke(1, ende / 2, null, null);
            var ares2 = dgPrimscan.BeginInvoke(ende/2 +1, ende , null, null);

            while (!ares1.IsCompleted && !ares2.IsCompleted)
            {
                Debug.Write(".");
                System.Threading.Thread.Sleep(200);
            }


            // Ergebnisse abrufen
            var lst1 = dgPrimscan.EndInvoke(ares1);
            var lst2 = dgPrimscan.EndInvoke(ares2);

            st.Stopp();

            Debug.WriteLine("Anz gefundener Primzahlen: " + (lst1.Count() + lst2.Count()) + " Zeit: " + st.ZeitInMs());


        }

        [TestMethod]
        public void _05_01_ThreadsMit4DelegatesTest()
        {
            const long ende = 10000000;

            Basics._04_Objektorientiert.StoppUhr st = new Basics._04_Objektorientiert.StoppUhr();

            st.Start();


            DGps dgPrimscan = new DGps(mko.Algo.NumberTheory.PrimeFactors.scan);


            var ares1 = dgPrimscan.BeginInvoke(1, ende / 4, null, null);
            var ares2 = dgPrimscan.BeginInvoke(ende / 4 + 1, ende/2, null, null);
            var ares3 = dgPrimscan.BeginInvoke(ende / 2 + 1, (3*ende)/4, null, null);
            var ares4 = dgPrimscan.BeginInvoke((3 * ende) / 4 + 1, ende, null, null);

            // Warten, solange bis fertig
            //ares1.AsyncWaitHandle.WaitOne();

            while (!ares1.IsCompleted && !ares2.IsCompleted && !ares3.IsCompleted && !ares4.IsCompleted)
            {
                Debug.Write(".");
                System.Threading.Thread.Sleep(200);
            }

            // Ergebnisse abrufen
            var lst1 = dgPrimscan.EndInvoke(ares1);
            var lst2 = dgPrimscan.EndInvoke(ares2);
            var lst3 = dgPrimscan.EndInvoke(ares3);
            var lst4 = dgPrimscan.EndInvoke(ares4);

            st.Stopp();


            Debug.WriteLine("Anz gefundener Primzahlen: " + (lst1.Count() + lst2.Count() + lst3.Count() + lst4.Count()) + " Zeit: " + st.ZeitInMs());


        }


        [TestMethod]
        public void _05_01_ThreadsMitParallelForEachTest()
        {
            const long ende = 10000000;

            Basics._04_Objektorientiert.StoppUhr st = new Basics._04_Objektorientiert.StoppUhr();

            st.Start();

            var results =  mko.Algo.NumberTheory.PrimeFactors.scanParallelWithParalleForEach(1, ende, null);


            st.Stopp();
            int anzPrim = 0;
            foreach(var part in results) {
                anzPrim += part.Count();
            }
            

            Debug.WriteLine("Anz gefundener Primzahlen: " + anzPrim +  " Zeit: " + st.ZeitInMs());
        }



        [TestMethod]        
        public async void _05_01_AsyncAwait()
        {
            IEnumerable<long> primlist = null;

            // hier wird ein Thread mit der Aufgabe gestartet, und nach dem Start kehrt die Funktion unmittelbar 
            // zu Aufrufer zurück
            await System.Threading.Tasks.Task.Run(() => primlist = mko.Algo.NumberTheory.PrimeFactors.scan(1, 10000000));

            // Dieser Teil wird ers nach vollständiger bearbeitung dr im Thread gestarteten Aufgabe abgearbeitet
            Debug.WriteLine("#Primzahlen: " + primlist.Count());
        }
    }




}
