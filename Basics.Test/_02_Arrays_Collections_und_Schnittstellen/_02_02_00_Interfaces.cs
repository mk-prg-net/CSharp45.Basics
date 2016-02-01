using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Test._02_Arrays_Collections_und_Schnittstellen
{
    [TestClass]
    public class _02_02_00_Interfaces
    {
        [TestMethod]
        public void TestMethod1()
        {
            var objIBasic = new Basics._02_Arrays_Collections_und_Schnittstellen.ImplementsIBasic();

            var objIDerived = new Basics._02_Arrays_Collections_und_Schnittstellen.ImplementsIDerived();


            Basics._02_Arrays_Collections_und_Schnittstellen.ProcessInterfaces.TransformID(objIDerived);
        }
    }
}
