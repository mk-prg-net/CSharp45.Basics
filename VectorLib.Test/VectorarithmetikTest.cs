using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VectorLib.Test
{
    [TestClass]
    public class VectorarithmetikTest
    {
        [TestMethod]
        public void VectorarithmetikTest_NewDeleteVector()
        {
            Vector2D v1 = new Vector2D();
            Assert.AreEqual(0.0, v1.X);
            Assert.AreEqual(0.0, v1.Y);

            v1.X = 99; v1.Y = -99;

            Vector2D v2 = v1;
            Assert.AreEqual(99.0, v2.X);
            Assert.AreEqual(-99.0, v2.Y);

            Vector2D v3 = new Vector2D(v1);
            Assert.AreEqual(99.0, v3.X);
            Assert.AreEqual(-99.0, v3.Y);

            Vector2D v4 = new Vector2D(99.0, -99.0);
            Assert.AreEqual(99.0, v4.X);
            Assert.AreEqual(-99.0, v4.Y);
        }

        [TestMethod]
        public void VectorarithmetikTest_Operators()
        {
            var v1 = new Vector2D(1, 1);
            var v2 = new Vector2D(-2, -3);

            var v3 = v1 + v2;
            var skalarProd = v1 * v2;
            var Streckung = 3 * v1;

            var res = v1 * v2 * (v1 + v2);

        }
    }
}
