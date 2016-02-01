using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._01_Grundbausteine
{
    public class _01_04_Operatoren
    {
        // Logische Basisfunktionen (analog Grundrechenarten in der Arithmetik): log. UND, log. ODER, log. NICHT
        //
        // AND  | true  | false
        //------+-------+-------
        // true | true  | false
        // false| false | false
        //
        // OR   | true  | false
        //------+-------+-------
        // true | true  | true 
        // false| true  | false
        //
        // NOT  |              
        //------+-------        
        // true | false        
        // false| true      


        public static string In_Dualzahl_konvertieren_mit_Bitops(uint Zahl)
        {
            uint Bitmaske = 0x80000000u;
            //uint Bitmaske = 0xFFFFFFFFu;
            string dual = "";

            for (int i = 0; i < 32; i++)
            {
                // 2) Höchste Bitstelle überprüfen auf 0 oder 1
                if ((Zahl & Bitmaske) != 0)
                {
                    // 2.a) Höchste Bitstelle ist 1-> ein L ausgeben
                    dual += "L";
                }
                else
                {
                    // 2.b) sonst ein O ausgeben
                    dual += "O";
                }

                // 3) Schiebe um ein Bit nach links (Richtung niederwertiger Bits -> Littel Endian !)
                Zahl <<= 1;

                // Weiter bei 2, solange nicht alle Bits verarbeitet wurden
            }

            return dual;

        }

        public static bool Logische_Operatoren_in_Aussagen()
        {
            // Fakten
            bool Ich_gucke_ARD = false;
            bool Ich_habe_ein_Fernsehgerät = true;
            bool Ich_habe_schon_GEZahlt = false;
            bool Ich_habe_Langeweile = true;

            // Regeln

            // Implikation (siehe https://de.wikipedia.org/wiki/Logische_Verkn%C3%BCpfung)
            bool Mich_besucht_der_Gerichtsvollzieher = Ich_habe_ein_Fernsehgerät && !Ich_habe_schon_GEZahlt;

            // Logisches ODER
            bool Ich_gucke_fern = Ich_habe_schon_GEZahlt || Ich_habe_Langeweile;

            return Mich_besucht_der_Gerichtsvollzieher && Ich_gucke_fern;

        }

        public static bool Zeichenkettenoperatoren()
        {
            // Zeichenkettenwerte haben den Datentyp string
            string A = "1";
            string B = "2";

            var C = A + B;


            int iA = 1;
            int iB = 2;

            var iC = iA + iB;


            return true;

        }



        public static bool Gepruefte_Festkommaoperatoren()
        {
            try
            {
                int x = int.MaxValue;
                checked
                {
                    x++;
                }
                return false;
            }
            catch (OverflowException ex)
            {
                return true;
            }
        }

        public static bool Ungepruefte_Festkommaoperatoren()
        {
            try
            {
                int x = int.MaxValue;
                uint y = uint.MaxValue;
                unchecked
                {
                    x++;
                    y++;
                }
                return true;
            }
            catch (OverflowException ex)
            {
                return false;
            }
        }


        /// <summary>
        /// Codiert in einen Integer den Euro- und Centanteil eines Preises
        /// </summary>
        /// <param name="euro"></param>
        /// <param name="cent"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Preis(int euro, int cent)
        {
            //Return euro * 100 + cent
            int p = 0;
            p = euro * 100 + cent;
            return p;
        }

        /// <summary>
        /// Dekodiert aus einem Integer den Euroanteil eines Preises
        /// </summary>
        /// <param name="preis"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int PreisEuroAnteil(int preis)
        {
            return preis / 100;
        }

        /// <summary>
        /// Dekodiert aus einem INteger den Centanteil eines Preises
        /// </summary>
        /// <param name="preis"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int PreisCentAnteil(int preis)
        {
            // \ ist die INtegerdivision (keine NAchkommastellen) 
            // / ist die Gleitkommadivision (Ergebnis ist ein double)
            return preis - preis / 100 * 100;
        }




    }
}
