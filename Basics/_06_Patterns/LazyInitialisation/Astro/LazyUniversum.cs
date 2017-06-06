//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 6.11.2016
//
//  Projekt.......: Basics
//  Name..........: LazyUniversum.cs
//  Aufgabe/Fkt...: Demo der Lazy Instantiation
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

using OAstro = Basics._04_Objektorientiert.Astro;

using System.Diagnostics;

namespace Basics._06_Patterns.LazyInitialisation.Astro
{
    public class LazyUniversum : OAstro.inMem.Universum
    {

        public LazyUniversum()
        {
            Instance.CreateGalaxie("Milchstrasse");
            Instance.CreateStern("Sonne", OAstro.Spektralklasse.G(), 1.0, "Milchstrasse");

            Beteigeuze = new Lazy<OAstro.Stern>(() =>
            {
                Instance.CreateStern("Beteigeuze", OAstro.Spektralklasse.M(), 3000.0, "Milchstrasse");
                return Instance.Sterne.First(r => r.Name == "Beteigeuze");
            });
        }

        /// <summary>
        /// Sonne wird beim erzeugen von Universum angelegt
        /// </summary>
        /// 
        //[Debuggable(DebuggableAttribute.DebuggingModes.Default)]        
        //[DebuggerStepThrough]
        public OAstro.Stern Sonne
        {
            get
            {
                return Instance.Sterne.First(r => r.Name == "Sonne");
            }
        }      
        
        

        /// <summary>
        /// Beteigeuze wird erst angelegt, wenn auf ihn zugegriffen wird.
        /// </summary>
        public Lazy<OAstro.Stern> Beteigeuze; 




    }
}
