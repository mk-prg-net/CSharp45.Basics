//<unit_header>
//----------------------------------------------------------------
// Copyright 2016 Martin Korneffel
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.2.2016
//
//  Projekt.......: Basics
//  Name..........: IHimmelskörper.cs
//  Aufgabe/Fkt...: Grundstruktur aller Himmelskörper, dargestellt durch eine Schnittstelle
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
    
    public interface IHimmelskörper
    {

        /// <summary>
        /// Name des Himmelskörpers
        /// </summary>
        string Name
        {
            get;
        }        
        
        /// <summary>
        /// Masse des Himmelskörpers in kg
        /// </summary>
        double Masse_in_kg {
            get;
        }

    }
}
