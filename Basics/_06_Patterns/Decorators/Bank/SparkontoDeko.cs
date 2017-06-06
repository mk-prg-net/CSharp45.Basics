//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 21.9.2016
//
//  Projekt.......: Basics
//  Name..........: SparkontoDeko.cs
//  Aufgabe/Fkt...: Demo Decorator- Pattern: Konto um Fähigkeit der 
//                  Verzinsung erweitern.
//
//
//
//
//<unit_environment>
//------------------------------------------------------------------
//  Zielmaschine..: PC 
//  Betriebssystem: Windows 7 mit .NET 4.5
//  Werkzeuge.....: Visual Studio 2013
//  Autor.........: Martin Korneffel (mko)
//  Version 1.0...: 
//
// </unit_environment>
//
//<unit_history>
//------------------------------------------------------------------
//
//  Version.......: 1.1
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 
//  Änderungen....: 
//
//</unit_history>
//</unit_header>        
        

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._06_Patterns.Decorators.Bank
{
    public class SparkontoDeko : IKonto
    {
        IKonto instance;

        public SparkontoDeko(IKonto instance)
        {
            this.instance = instance;
        }

        public double Guthaben
        {
            get
            {
                return instance.Guthaben;
            }
        }

        public void einzahlen(double betrag)
        {
            instance.einzahlen(betrag);
        }

        public void verzinse(int Laufzeit, double zins)
        {
            instance.einzahlen(Guthaben * zins * Laufzeit);

        }

        public void abheben(double betrag)
        {
            instance.abheben(betrag);
        }
    }
}
