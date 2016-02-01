using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Autobahn.Test
{
    [TestClass]
    public class AutobahnTests
    {
        [TestMethod]
        public void Autobahn_EnumerableTest()
        {

            var A8 = new Autobahn.AutobahnEnumerable();

            foreach (var fhzg in A8)
            {
                Assert.IsInstanceOfType(fhzg ,typeof(Basics._04_Objektorientiert.Autobahn.Auto));

                Debug.WriteLine(fhzg.VolleFahrzeugbezeichnung);
            }
        }
    }
}
