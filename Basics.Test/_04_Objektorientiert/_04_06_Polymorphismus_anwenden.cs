using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Basics._04_Objektorientiert
{

    [TestClass]
    public class _04_Polymorphismus_anwenden
    {
        static void ProgressInfo(DMS.DirTree.DirTreeProgressInfo Info)
        {
            Debug.WriteLine("Anz.Verz: " + Info.DirCount + ", AnzDateien: " + Info.FileCount);
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Ein Objekt vom JpgCounter erzeugen
            var MyCounter = new JpegCounter();

            MyCounter.EventProgress += new DMS.DirTree.DGEventProgress(ProgressInfo);

            // das zu untersuchende Verzeichnis scannen
            MyCounter.scanDir(@"C:\Users\Schulung\Documents\Visual Studio 2012\Projects\Bildergalerie");

            // Ergebnis ausgeben
            Debug.WriteLine("Anz. JPG- Dateien = " + MyCounter.Count);

        }
    }
}
