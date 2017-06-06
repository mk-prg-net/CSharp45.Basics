//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.11.2016
//
//  Projekt.......: Basics
//  Name..........: UniversumWithDI.cs
//  Aufgabe/Fkt...: Universum, dessen Abhängigkeiten (Galaxieen, Sterne, Planeten)
//                  über Dependency- Injection (DI) aufgelöst werden.
//                  Das Universum mit seinen Create- Methoden ist aus 
//                  softwaretechnischer Sicht die Implementierung eines 
//                  des UnitOfWork- Patterns
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
    public class UniversumWithDI : IUniversum
    {

        ISternClassFactory _SternFactory;
        IGalaxieFactory _GalaxieFactory;
        IGalaxieWithStrategieFactory _GalaxieWithStrategieFactory;
        IPlanetFactory _PlanetFactory;

        /// <summary>
        /// Konstruktor mit DI:
        /// Über die Parameter werden Klassenfabriken injeziert, die neue
        /// Galaxieen, Sterne und Planeten erzeugen.
        /// </summary>
        /// <param name="SternFactory"></param>
        /// <param name="GalaxieFactory"></param>
        /// <param name="GalaxieWithStrategieFactory"></param>
        /// <param name="PlanetFactory"></param>
        public UniversumWithDI(ISternClassFactory SternFactory,
                               IGalaxieFactory GalaxieFactory,
                               IGalaxieWithStrategieFactory GalaxieWithStrategieFactory,
                               IPlanetFactory PlanetFactory)
        {

            // Klassenfabriken für Himmelskörper
            _SternFactory = SternFactory;
            _GalaxieFactory = GalaxieFactory;
            _GalaxieWithStrategieFactory = GalaxieWithStrategieFactory;
            _PlanetFactory = PlanetFactory;
        }

        public IEnumerable<Astro.Stern> Sterne
        {
            get
            {
                return _Sterne;
            }
        }
        List<Astro.Stern> _Sterne = new List<Astro.Stern>();

        public IEnumerable<Astro.IGalaxie> Galaxien
        {
            get
            {
                return _Galaxien;
            }
        }
        List<IGalaxie> _Galaxien = new List<IGalaxie>();


        public IEnumerable<IPlanet> Planeten
        {
            get
            {
                return _Planeten;
            }
        }
        List<IPlanet> _Planeten = new List<IPlanet>();

        /// <summary>
        ///  Klassenfabrik für Galaxien implementieren
        /// </summary>
        /// <param name="Name"></param>
        public void CreateGalaxie(string Name)
        {
            if (!_Galaxien.Any(g => g.Name == Name))
            {

                _Galaxien.Add(_GalaxieFactory.Create(Name));
            }
            else
            {
                throw new System.Exception("Galaxie mit dem Namen " + Name + " existiert bereits");
            }
        }

        /// <summary>
        ///  Klassenfabrik für GalaxienMitStrategie implementieren
        /// </summary>
        /// <param name="Name"></param>
        public void CreateGalaxieWithStrategie(string Name, IStrategieBerechneMasseGalaxie strategie)
        {
            if (!_Galaxien.Any(g => g.Name == Name))
            {

                _Galaxien.Add(_GalaxieWithStrategieFactory.Create(Name, strategie));
            }
            else
            {
                throw new System.Exception("GalaxieMitStrategie mit dem Namen " + Name + " existiert bereits");
            }
        }



        /// <summary>
        /// Klassenfabrik für Sterne implementieren.
        /// Schlägt dabei nach der Heimatgalaxi nach, und gibt Referenz auf diese zurück.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Spektralklasse"></param>
        /// <param name="MasseInSonnenmassen"></param>
        /// <param name="NameHeimatgalaxie"></param>
        public void CreateStern(string Name, ISpektralklasse Spektralklasse, double MasseInSonnenmassen, string NameHeimatgalaxie)
        {
            if (!_Sterne.Any(s => s.Name == Name))
            {
                if (_Galaxien.Any(g => g.Name == NameHeimatgalaxie))
                {
                    var stern = _SternFactory.Create(Name, Spektralklasse, MasseInSonnenmassen, _Galaxien.Single(g => g.Name == NameHeimatgalaxie));
                    _Sterne.Add(stern);
                }
                else
                {
                    throw new Exception("Die Galaxie " + NameHeimatgalaxie + ", in welcher der neue Stern " + Name + " angelegt werden sollte, existiert nicht");
                }
            }
            else
            {
                throw new System.Exception("Stern mit dem Namen " + Name + " existiert bereits");
            }
        }

        public void CreatePlanet(string Name, double MasseInErdmassen, string NameHeimatstern)
        {
            if (!_Planeten.Any(p => p.Name == Name))
            {
                if (_Sterne.Any(s => s.Name == NameHeimatstern))
                {
                    var planet =  _PlanetFactory.Create(Name, MasseInErdmassen, _Sterne.Single(s => s.Name == NameHeimatstern));
                    _Planeten.Add(planet);
                }
                else
                {
                    throw new Exception("Der Heimatstern " + NameHeimatstern + " existiert nicht");
                }
            }
            else
            {
                throw new Exception("Der Planet " + Name + " existiert bereits");
            }
        }


        public Astro.IGalaxie GetGalaxie(string Name)
        {
            return _Galaxien.Single(g => g.Name == Name);
        }

        public Astro.Stern GetStern(string Name)
        {
            return _Sterne.Single(g => g.Name == Name);
        }

        public IPlanet GetPlanet(string Name)
        {
            return _Planeten.Single(p => p.Name == Name);
        }
    }
}
