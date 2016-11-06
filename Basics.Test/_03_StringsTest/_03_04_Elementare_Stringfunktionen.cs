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
                string txt = "Anton1, Anton2, Berta, Cäsar";

                int anzDigits = 0;
                int anzLetter = 0;
                int anzWhitespace = 0;
                int anzPunct = 0;

                //Strings sind spezielle Formen von Arrays
                for (int i = 0; i < txt.Length; i++)
                {
                    char c = txt[i];

                    if (char.IsDigit(c))
                    {
                        anzDigits++;
                    }
                    else if (char.IsLetter(c))
                    {
                        anzLetter++;
                    }
                    else if (char.IsWhiteSpace(c))
                    {
                        anzWhitespace++;
                    }
                    else if (char.IsPunctuation(c))
                    {
                        anzPunct++;
                    }

                }

                Assert.AreEqual(2, anzDigits);
                Assert.AreEqual(txt.Length, anzDigits + anzLetter + anzPunct + anzWhitespace);
            }

            {
                string txt = "Anton, Berta, Cäsar";
                string txt2 = "";

                foreach (char c in txt)
                {
                    // Sehr ineffizient, da jedes Anfügen an txt2 ein neuerstellen des Strings
                    // durch die Laufzeitumgebung bedeutet.
                    txt2 += c;
                }

                Assert.AreEqual(txt, txt2);

                // Effziente Stringkonkatentation mittels StringBuilder

                var bld = new System.Text.StringBuilder();
                foreach (char c in txt)
                {
                    // deutlich effizienter !
                    bld.Append(c);
                }

                string txt3 = bld.ToString();
                
            }


            {
                string txt = "Anton, Berta, Cäsar";
                var substr1 = txt.Substring(7, 5);
                Debug.WriteLine(substr1);
                Assert.AreEqual("Berta", substr1);

                var substr2 = txt.Substring(7);
                Debug.WriteLine(substr2);
                Assert.AreEqual("Berta, Cäsar", substr2);
            }

            {
                string txt = "Anton, Berta, Cäsar";

                // IndexOf ermittelt den Index, ab dem ein Substring beginnt
                // Mittels Insert kann ein String ab einem Index um einen Substring erweitert werden
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

                // Array hat genauso viele Einträge wie namen[]
                string[] namen_norm = new string[namen.Length];

                for (int i = 0; i < namen.Length; i++)
                {
                    // Entfernen aller führenden und nachfolgenden Leerzeichen
                    namen_norm[i] = namen[i].Trim();
                }

                // Splitten, gesteuert durch zwei Arten von Split- Symbolen
                string[] namen2 = txt.Split(' ', ',');
                Assert.AreEqual(12, namen2.Length);

                string[] namen3 = txt.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                Assert.AreEqual(4, namen3.Length);

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
