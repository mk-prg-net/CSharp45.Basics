//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 19.9.2016
//
//  Projekt.......: Basics.cs
//  Name..........: IBerechneMasseGalaxie.cs
//  Aufgabe/Fkt...: Schnittstelle für Berechnungsvorschrift der Masse von 
//                  Galaxien (Strategie- Pattern)
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

namespace Basics._04_Objektorientiert.Astro
{
    public interface IStrategieBerechneMasseGalaxie
    {
        /// <summary>
        /// Berechnet die Masse einer Galaxie z.B. aus der Summe ihrer Komponenten
        /// </summary>
        /// <param name="Galaxie"></param>
        /// <returns></returns>
        double Berechne_Masse_in_kg_von(IGalaxie Galaxie);
    }
}
