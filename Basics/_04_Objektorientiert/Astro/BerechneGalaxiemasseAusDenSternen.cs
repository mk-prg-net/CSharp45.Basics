//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 19.9.2016
//
//  Projekt.......: Basics
//  Name..........: BErechneGalaxiemasseAusDenSternen.cs
//  Aufgabe/Fkt...: Berechnet die Galaxiemasse als Summe der Sterne
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

namespace Basics._04_Objektorientiert.Astro
{
    public class BerechneGalaxiemasseAusDenSternen : IStrategieBerechneMasseGalaxie
    {
        public static IStrategieBerechneMasseGalaxie Instanz
        {
            get {
                if (_Instanz == null)
                {
                    _Instanz = new BerechneGalaxiemasseAusDenSternen();
                }
                return _Instanz;
            }
        }
        static BerechneGalaxiemasseAusDenSternen _Instanz; // = new BerechneGalaxiemasseAusDenSternen();


        public double Berechne_Masse_in_kg_von(IGalaxie Galaxie)
        {
            double Masse = Galaxie.Sterne.Sum(s => s.Masse_in_kg);
            return Masse;
        }
    }
}
