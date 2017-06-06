//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 9.11.2016
//
//  Projekt.......: basics
//  Name..........: PlanetFactory.cs
//  Aufgabe/Fkt...: Klassenfabrik für inMem.Planet
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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro.inMem
{
    public class PlanetFactory : IPlanetFactory
    {

        public PlanetFactory()
        {
            Debug.WriteLine("Die Planetenfabrik wird angelegt.");
        }

        public IPlanet Create(string Name, double Masse_in_Erdmassen, Astro.Stern Zentralstern)
        {
            return new Planet(Name, Masse_in_Erdmassen, Zentralstern);
        }
    }
}
