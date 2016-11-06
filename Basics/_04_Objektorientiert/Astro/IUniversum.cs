//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 18.9.2016
//
//  Projekt.......: Basics
//  Name..........: IUniversum.cs
//  Aufgabe/Fkt...: Struktur des Universums
//                  Implementiert das UnitOfWork- Pattern
//                  (http://martinfowler.com/eaaCatalog/unitOfWork.html)
//                  (http://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)
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
    public interface IUniversum
    {

        /// <summary>
        /// Erzeugt eine neue Galaxie im Universum (Klassenfabrik- Pattern)
        /// </summary>
        /// <param name="Name"></param>
        void CreateGalaxie(string Name);


        /// <summary>
        /// Erzeugt eine neue Galaxie im Universum (Klassenfabrik- Pattern)
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="strategie"></param>
        void CreateGalaxieWithStrategie(string Name, IStrategieBerechneMasseGalaxie strategie);


        /// <summary>
        /// Zugriff auf eine Galaxie
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        IGalaxie GetGalaxie(string Name);

        /// <summary>
        /// Liste aller Galaxieen
        /// </summary>
        IEnumerable<IGalaxie> Galaxien
        {
            get;
        }

        /// <summary>
        /// Klassenfabrik- Pattern
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Spektralklasse"></param>
        /// <param name="MasseInSonnenmassen"></param>
        void CreateStern(string name, ISpektralklasse Spektralklasse, double MasseInSonnenmassen, string NameHeimatgalaxie);

        /// <summary>
        /// Zugriff auf einen Stern im Universum
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        Stern GetStern(string Name);


        /// <summary>
        /// Liste aller Sterne im Universum
        /// </summary>
        IEnumerable<Stern> Sterne
        {
            get;
        }


        void CreatePlanet(string Name, double MasseInErdmassen, string NameHeimatstern);

        IPlanet GetPlanet(string Name);

        /// <summary>
        /// Liste aller Planeten
        /// </summary>
        IEnumerable<IPlanet> Planeten
        {
            get;
        }

    }
}
