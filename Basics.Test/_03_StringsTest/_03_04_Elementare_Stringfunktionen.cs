using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;

namespace Basics.Test._03_StringsTest
{
    [TestClass]
    public class _03_04_Elementare_Stringfunktionen
    {
        [TestMethod]
        public void _03_StringTest_Elementare_Stringfunktionen()
        {
            {
                string txt = "Anton, Berta, Cäsar";
                Debug.WriteLine(txt.Substring(8, 5));
                Debug.WriteLine(txt.Substring(8));
            }

            {
                string txt = "Anton, Berta, Cäsar";
                txt = txt.Insert(txt.IndexOf("Berta"), "Aladin, ");
                Debug.WriteLine(txt);
            }

            {
                // Splitten
                string txt = "Anton,Berta,Cäsar";
                string[] namen = txt.Split(',');
            }

            {
                // Splitten
                string txt = "  Anton Adelbert  , Berta,Cäsar   ";
                string[] namen = txt.Split(',');

                // Mittels Linq die Schleife vermeiden
                var allesGetrimmt = namen.Select(n => n.Trim());
                var allesGetrimmtArray = namen.Select(n => n.Trim()).ToArray();

                // namen = namen.Select(n => n.Trim()).ToArray();

                for (int i = 0; i < namen.Length; i++)
                {
                    namen[i] = namen[i].Trim();
                }


                
                
            }
        }
    }
}
