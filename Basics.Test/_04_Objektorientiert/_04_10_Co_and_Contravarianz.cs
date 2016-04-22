using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

using ctx = Basics._04_Objektorientiert.Astro;


namespace Basics.Test._04_Objektorientiert
{
    [TestClass]
    public class _04_10_Co_and_Contravarianz
    {

        [ClassInitialize]
        public void ClassInit(TestContext ctx)
        {
            mko.Newton.Init.Do();
        }



        double AddMassesInList(List<ctx.Himmelskörper> listCBs)
        {
            return listCBs.Sum(r => r.Masse_in_kg);
        }


        double AddMasses(IEnumerable<ctx.Himmelskörper> itCBs)
        {
            return itCBs.Sum(r => r.Masse_in_kg);
        }


        [TestMethod]
        public void TestCovariant()
        {
            var stars = new List<ctx.Stern>();
            stars.AddRange(new ctx.Stern[] {
                new ctx.Stern()

        });
            var galactica = new List<ctx.Galaxie>();

            galactica.Add(new ctx.Galaxie())

        }
    }
}
