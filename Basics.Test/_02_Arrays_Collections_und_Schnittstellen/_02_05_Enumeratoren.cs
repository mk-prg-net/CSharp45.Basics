using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

using Ctx = Basics.Enumeratoren;


namespace Basics.Test._02_Arrays_Collections_und_Schnittstellen
{
    [TestClass]
    public class _02_05_Enumeratoren
    {
        [TestMethod]
        public void TestMethod1()
        {
            foreach (string op in Ctx.AllOperatorsAsString)
            {
                Debug.WriteLine(op);
            }

            int id = 0;
            var listeOps = Ctx.AllOperatorsAsString.Select(op => new { Id = id++, Op = op });


            foreach (int z in Ctx.IndexGenerator(5))
                Debug.WriteLine(z);

            // Tabelle aufbauen
            var eineListeVonZahlen = Ctx.IndexGenerator(99).ToArray();
            var einArrayMitBoolWertenFalse = Ctx.BoolFieldGenerator(false, 99).ToArray();


            var eineTabelle = Ctx.TableGenerator(eineListeVonZahlen, einArrayMitBoolWertenFalse).ToArray();

        }
    }
}
