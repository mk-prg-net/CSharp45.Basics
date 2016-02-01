using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ctx = Basics._03_Strings._03_01_TryParse;

namespace Basics.Test._03_StringsTest
{
    [TestClass]
    public class _03_01_TryParseTests
    {
        [TestMethod]
        public void _03_01_TryParseTest()
        {
            var wert = Ctx.ReadDouble("1234,567");
            Assert.AreEqual(1.234567e3, wert);

            wert = Ctx.ReadDouble("1,234567e3");
            Assert.AreEqual(1.234567e3, wert);

            wert = Ctx.ReadDouble_ch("1234.567");
            Assert.AreEqual(1.234567e3, wert);

            wert = Ctx.ReadDouble_ch("1.234567e3");
            Assert.AreEqual(1.234567e3, wert);

            wert = Ctx.ReadDouble_ch("1'234.567");
            Assert.AreEqual(1.234567e3, wert);


            // Gesamten Kulturkontext temporär umschalten

            var bak = System.Threading.Thread.CurrentThread.CurrentCulture;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de-CH");

            wert = Ctx.ReadDouble("Fr. 1'234.567");
            Assert.AreEqual(1.234567e3, wert);

            string strWert = wert.ToString("C");
            Assert.AreEqual("Fr. 1'234.57", strWert);

            strWert = wert.ToString("N");
            Assert.AreEqual("Fr. 1'234.57", strWert);

            System.Threading.Thread.CurrentThread.CurrentCulture = bak;

        }
    }
}
