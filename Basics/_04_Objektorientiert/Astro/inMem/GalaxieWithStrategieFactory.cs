//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 9.11.2016
//
//  Projekt.......: Basics
//  Name..........: GalaxieWithStrategieFactory.cs
//  Aufgabe/Fkt...: Klassenfabrik für inMem.GalaxieWithStrategie.cs
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

namespace Basics._04_Objektorientiert.Astro.inMem
{
    /// <summary>
    /// Erzeugt eine inMem.GalaxieWithStrategie
    /// </summary>
    public class GalaxieWithStrategieFactory : IGalaxieWithStrategieFactory
    {
        public Astro.GalaxieWithStrategie Create(string Name, IStrategieBerechneMasseGalaxie Strategie)
        {
            return new GalaxieWithStrategie(Name, Strategie);
        }
        
    }
}
