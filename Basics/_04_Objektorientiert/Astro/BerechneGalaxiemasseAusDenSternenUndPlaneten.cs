//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 19.19.2016
//
//  Projekt.......: Basics
//  Name..........: BerechnenGalaxiemasseAusDenSternenundPlaneten.cs
//  Aufgabe/Fkt...: 
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
    public class BerechneGalaxiemasseAusDenSternenUndPlaneten : IStrategieBerechneMasseGalaxie
    {

        public static IStrategieBerechneMasseGalaxie Instanz
        {
            get
            {
                if (_Instanz == null)
                {
                    _Instanz = new BerechneGalaxiemasseAusDenSternenUndPlaneten();
                }
                return _Instanz;
            }
        }
        static BerechneGalaxiemasseAusDenSternenUndPlaneten _Instanz;


        public double Berechne_Masse_in_kg_von(IGalaxie Galaxie)
        {
            double Masse = Galaxie.Sterne.Sum(s => s.Masse_in_kg + s.Planetensystem.Sum(p => p.Masse_in_kg));
            return Masse;
        }
    }
}
