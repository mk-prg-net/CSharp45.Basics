//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 21.9.2016
//
//  Projekt.......: Basics
//  Name..........: KontoMitProtokollDeko.cs
//  Aufgabe/Fkt...: Anwendung des Dekorator Patterns. Konto- Instanzen um Fähigkeit der 
//                  Protokollierung erweitern.
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
    public class KontoMitProtokollDeko : IKonto
    {
        IKonto instance;

        /// <summary>
        /// Open-Close Prinzip durch kapseln ders Protokolles in einer 
        /// Eigenschaft sicherstellen
        /// </summary>
        public IEnumerable<string> Protokoll
        {
            get
            {
                return _Protokoll;
            }
        }

        public List<string> _Protokoll = new List<string>();

        public KontoMitProtokollDeko(IKonto instance)
        {
            this.instance = instance;
        }

        public double Guthaben
        {
            get
            {
                return instance.Guthaben;
            }
        }

        public void einzahlen(double betrag)
        {
            instance.einzahlen(betrag);
            _Protokoll.Add("eingezahlt: " + betrag);
        }

        public void abheben(double betrag)
        {
            this.instance.abheben(betrag);
            _Protokoll.Add("abgehoben: " + betrag);
        }
    }
}
