using System;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

// Namespace für die Bibliothek mit den regulären Ausdrücken
using System.Text.RegularExpressions;

namespace Basics.Test._03_StringsTest
{
    [TestClass]
    public class _03_03_RegExTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                // (3*(5+2))*2
                // Ergebnis: 42
                // Darstellung in umgegehrt poln. Notation
                // ((3 (5 2)+)* 2)*

                string term = "((3 (5 2)+)* 2)*";

                // Demo reguläre Ausdrücke
                // Zählen aller Ziffer
                string term2 = "((3 (53 270)+)* 2,2)*";

                // alle Zahlen herausfiltern
                // \d: Klasse der Ziffernsymbole
                // + : Quantor: mind. 1x , sonst beliebig viele
                // * : Quantor: 0 bis beliebig viele
                // ? : Quantor: 0 bis mx. 1x
                MatchCollection matchColl = Regex.Matches(term2, @"\d+\,?\d*");

                foreach (var match in matchColl)
                {
                    Debug.WriteLine(match.ToString());
                }







                Debug.WriteLine(term);

                // Separation der Symbole
                term = Regex.Replace(term, @"\(", @" ( ");
                term = Regex.Replace(term, @"\)", @" ) ");

                Debug.WriteLine(term);
                // Achtung: TrimStart verandert nicht die Instanz, sondern gibt
                // den geänderten Wert der Instanz zurück
                term = term.TrimStart();

                string[] symbole = Regex.Split(term, @"\s+");

                foreach (string symbol in symbole)
                {
                    Debug.Write(symbol + ", ");
                }


                Stack<string> stack = new Stack<string>();

                // Einkellern aller Symbole bis zur ersten schließenden Klammer

                int akt_pos = 0;

                do
                {
                    // Einkellern bis zur schließenden Klammmer
                    while (symbole[akt_pos] != ")" && akt_pos < symbole.Length)
                    {
                        stack.Push(symbole[akt_pos]);
                        akt_pos++;
                    }

                    // Prüfen, ob kein Fehler im Ausdruck vorliegt
                    if (symbole.Length > 1 && akt_pos == symbole.Length)
                    {
                        throw new Exception("SyntaxError");
                    }

                    // Auswerten bis zur öffnenden Klammer

                    // Operationssymbol bestimmen
                    akt_pos++;
                    string OpSym = symbole[akt_pos];

                    switch (OpSym)
                    {
                        case "+":
                            Addiere(stack);
                            break;
                        case "*":
                            Multipliziere(stack);
                            break;
                        default: break;
                    }

                    akt_pos++;

                } while (akt_pos < symbole.Length);

                Debug.WriteLine("Ergebnis= " + stack.Peek());
                Assert.AreEqual(42, Convert.ToInt32(stack.Peek()));

            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }

        }

        static void Addiere(Stack<string> stack)
        {
            int summe = 0;

            while (stack.Peek() != "(")
            {
                int summand = Int32.Parse(stack.Pop());
                summe += summand;
            }

            // Öffnende Klammer durch Ergebnis der Addition ersetzen
            stack.Pop();
            stack.Push(summe.ToString());
        }

        static void Multipliziere(Stack<string> stack)
        {
            int produkt = 1;

            while (stack.Peek() != "(")
            {
                int faktor = Int32.Parse(stack.Pop());
                produkt *= faktor;
            }

            // Öffnende Klammer durch Ergebnis der Addition ersetzen
            stack.Pop();
            stack.Push(produkt.ToString());
        }

    }
}
