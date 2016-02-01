using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Basics.Test._03_StringsTest
{
    [TestClass]
    public class _03_02_CharTests
    {
        [TestMethod]
        public void _03_02_CharTest()
        {
            // char verarbeiten Unicode- Zeichen
            char c1, c2, c3, c4, c5, c6, c7;

            c1 = '\u041B';
            c2 = '\u042E';
            c3 = '\x0411';
            c4 = '\x041E';
            c5 = '\x0412';
            c6 = '\x042C';

            // Anwendung der Zeichenklassenprädikate
            if (char.IsLetter(c1))
                Debug.WriteLine(c1.ToString() + " ist ein Buchstabe");


            var str = "";

            str += c1.ToString() + c2.ToString() + c3.ToString() + c4.ToString() + c5.ToString() + c6.ToString();

            Debug.WriteLine(str);

        }
    }
}
