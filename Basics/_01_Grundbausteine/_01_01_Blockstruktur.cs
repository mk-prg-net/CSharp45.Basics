using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Namensraumblock
namespace Basics._01_Grundbausteine
{    

    // Klassenblock
    public class _01_01_Blockstruktur
    {
        // Statische Member verhalten sich wie klassiche gloabel Variablen oder 
        // Unterprogramme

        public static int EineStatischeVariable = 0;

        public static int Sum(int a, int b) { return a + b; }


        // Unterprogrammblock
        public void Unterprogramm()
        {
            // Schleifenblock
            while (true)
            {
                // Bedingter Anweisungsblock
                if (true)
                {
                    // Anonymer Block 1
                    {
                        int x = 99;

                        // Anonymer Block 2
                        {
                            // In C/C++ zulässig, in C# nicht
                            //int x = 199;
                            int x1 = 199;
                            // Im Innersten_angelangt
                        }

                        // Eine weitere Nebenrechnung
                        {
                            // x1 wird hier neu angelegt
                            int x1 = 299;
                        }
                        // in diesem übergeordneten Block existiert x1 nicht
                        // x1 = 22;

                        // Eine weitere Nebenrechnung
                        {
                            // x1 wird hier neu angelegt
                            int x1 = 399;
                        }

                        // y existiert hier nicht mehr- bereits vom Stack geräumt
                    }
                    // x existiert hier nicht mehr- bereits vom Stack geräumt
                }                
            }
        }
    }
}
