﻿//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 21.9.2016
//
//  Projekt.......: Basics
//  Name..........: Konto.cs
//  Aufgabe/Fkt...: Triviale Implementierung der IKonto- Schnittstelle
//                  
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
    public class Konto : IKonto
    {

        public double Guthaben { get; set; }

        public void einzahlen(double betrag)
        {
            Guthaben += betrag;
        }

        public void abheben(double betrag)
        {
            Guthaben -= betrag;
        }
    }
}
