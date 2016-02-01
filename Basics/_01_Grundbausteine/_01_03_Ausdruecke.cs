using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._01_Grundbausteine
{
    public class _01_03_Ausdruecke
    {        
        /// <summary>
        /// Pi aus einem Kettenbruch errechnen: https://de.wikipedia.org/wiki/Kreiszahl#Kettenbruchentwicklung 
        /// </summary>
        /// <returns></returns>
        public static double F_Pi_Kettenbruch() {

            return 3.0 + (1.0 / (7.0 + 1.0 / (15.0 + 1.0 / (1.0 + 1.0 / 292.0 + 1.0 / (1.0 + 1.0 / (1.0 + 1.0 / (1.0 + 1.0 / (2.0 + 1.0 / (1.0 + 1.0 / (3.0 + 1.0 / (1.0 + 1.0 / (14.0 + 1.0 / (2.0 + 1.0 / (1.0 + 1.0 / (1.0 + 1.0 / 2.0)))))))))))))));
        }


        public static void F_Mathemat_Funktionen()
        {

            var res = Math.Sin(Math.PI / 2);            

        }

        /// <summary>
        /// Grössten gemeinsamen Teiler zweier Ganzer Zahlen mittels Euklidischen Algorithmus berechnen
        /// Siehe https://de.wikipedia.org/wiki/Euklidischer_Algorithmus
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int GGT(int a, int b)
        {
            // Kombinierter Einstaz von ternären Operator und der Identität
            return b == 0 ? a : GGT(b, a % b);
        }


        public static int GGT2(int a, int b)
        {
            // Anstatt ternärer Operator der If- Block
            if (b == 0) return a; else return GGT2(b, a % b);

        }


        public static bool PrimTest(int z)
        {
            return PrimTestHlp(z, z - 1);
        }

        static bool PrimTestHlp(int z, int Teiler)
        {
            return z % Teiler == 0 ? (Teiler == 1 ? true : false) : PrimTestHlp(z, Teiler - 1);
        }
    }
}
