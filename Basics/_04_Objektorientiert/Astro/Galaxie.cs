//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.2.2016
//
//  Projekt.......: Basics
//  Name..........: Galaxie.cs
//  Aufgabe/Fkt...: Bildet eine Galaxie durch eine abstrakte Klasse ab.
//                  Die abstrakte Klasse stellt eine allgemeine Implementierung 
//                  einer Funktion zur Berechnug der Masse bereit.
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
    public abstract class Galaxie : IHimmelskörper, IGalaxie
    {
        public abstract string Name
        {
            get;
        }

        /// <summary>
        /// 1:n Beziehung zwischen Galaxie und Sterne:
        /// Verweist auf alle Sterne einer Galaxie
        /// </summary>
        public abstract IEnumerable<Stern> Sterne { get; }


        /// <summary>
        /// Masse_in_Kg als virtuelle Eigenschaft. Stellt eine Basisimlementierung zur Berechnung
        /// der Masse einer Galaxie als Summe der Massen ihrer Sterne bereit.
        /// Kann in abgeleiteten Klassen überschrieben (und damit präzisiert) werden.
        /// </summary>
        /// <returns></returns>
        public double Masse_in_kg
        {
            get
            {
                double Masse = 0.0;
                foreach (var stern in Sterne)
                {
                    Masse += stern.Masse_in_kg;
                    foreach (var planet in stern.Planetensystem)
                    {
                        Masse += planet.Masse_in_kg;
                    }
                }

                return Masse;
            }
        }


        public class NullGalaxie : Galaxie
        {

            public override string Name
            {
                get { return "NullGalaxie"; }
            }

            public override IEnumerable<Stern> Sterne
            {
                get { return new Stern.NullStern[]{}; }
            }
        }

        public static NullGalaxie Null
        {
            get
            {
                if (_Null == null)
                {
                    _Null = new NullGalaxie();
                }
                return _Null;
            }
        }
        static NullGalaxie _Null;
    }
}
