using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimScanMultithreaded
{
    class Program
    {
        static void Main(string[] args)
        {
            //ScanSerial();

            ScanDouble();

        }


        static void ScanSerial()
        {
            var res = mko.Algo.NumberTheory.PrimeFactors.scan(1, 10000000);

        }

        static void ScanDouble()
        {
            // Delegates anlegen
            var dg1 = new Func<long, long, IEnumerable<long>>(mko.Algo.NumberTheory.PrimeFactors.scan);
            var dg2 = new Func<long, long, IEnumerable<long>>(mko.Algo.NumberTheory.PrimeFactors.scan);
            var dg3 = new Func<long, long, IEnumerable<long>>(mko.Algo.NumberTheory.PrimeFactors.scan);
            var dg4 = new Func<long, long, IEnumerable<long>>(mko.Algo.NumberTheory.PrimeFactors.scan);


            // Methoden asynchron mittels Delegates starten
            var ares1=  dg1.BeginInvoke(1, 2500000, null, null);
            var ares2=  dg2.BeginInvoke(2500001, 5000000, null, null);
            var ares3 = dg3.BeginInvoke(5000001, 75000000, null, null);
            var ares4 = dg4.BeginInvoke(7500001, 10000000, null, null);

            while (!ares1.IsCompleted && !ares2.IsCompleted && !ares3.IsCompleted && !ares4.IsCompleted)
            {
                Debug.Write(".");
                System.Threading.Thread.Sleep(200);
            }

            //ares1.AsyncWaitHandle.WaitOne();

            var res1 = dg1.EndInvoke(ares1);
            var res2 = dg2.EndInvoke(ares2);

        }
    }
}
