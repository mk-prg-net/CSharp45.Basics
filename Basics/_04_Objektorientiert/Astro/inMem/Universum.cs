using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro.inMem
{
    public class Universum : IUniversum
    {
        /// <summary>
        /// Das Universum als Singleton
        /// </summary>
        public static IUniversum Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Universum();
                }
                return _Instance;
            }
        }
        static Universum _Instance;

        public IEnumerable<Astro.Stern> Sterne
        {
            get
            {
                return _Sterne;
            }
        }
        List<Stern> _Sterne = new List<Stern>();

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

                _Galaxien.Add(new Galaxie(Name));
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

                _Galaxien.Add(new GalaxieWithStrategie(Name, strategie));
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
                    var stern = new Stern(Name, Spektralklasse, MasseInSonnenmassen, _Galaxien.Single(g => g.Name == NameHeimatgalaxie));
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
                if (_Sterne.Any(s => s.Name == NameHeimatstern)) {
                    var planet = new Planet(Name, MasseInErdmassen, _Sterne.Single(s => s.Name == NameHeimatstern));
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
            throw new NotImplementedException();
        }
    }
}
