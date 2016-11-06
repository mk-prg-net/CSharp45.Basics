//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 19.9.2016
//
//  Projekt.......: Basics
//  Name..........: GalaxieWithStrategie.cs
//  Aufgabe/Fkt...: Galaxie mit austauschbarer Berechnungsvorschrift für
//                  die Masse nach dem Strategie- Pattern
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
    public abstract class GalaxieWithStrategie : IGalaxie
    {
        //Func<IGalaxie, double> _StrategieBerechneMasse;
        IStrategieBerechneMasseGalaxie _StrategieBerechneMasse;

        // Alternativ zur Schnittstelle als Parameter 
        // public GalaxieWithStrategie(Func<IGalaxie, double> strategie)
        public GalaxieWithStrategie(IStrategieBerechneMasseGalaxie strategie)
        {
            _StrategieBerechneMasse = strategie;
        }

        public abstract IEnumerable<Stern> Sterne
        {
            get;
        }

        public abstract string Name
        {
            get;
        }

        /// <summary>
        /// Berechnung der Masse mittels einer austauschbaren Berechnungsvorschrift
        /// </summary>
        public double Masse_in_kg
        {
            get {
                //return _StrategieBerechneMasse(this); 
                return _StrategieBerechneMasse.Berechne_Masse_in_kg_von(this); 
            }
        }
    }
}
