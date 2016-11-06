using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Basics._04_Objektorientiert.Astro;
using System.Diagnostics;


// Damit die Erweitrungsmethoden von Unity bereitstehen, müssen wir den Namespace hier einbinden
using Microsoft.Practices.Unity;

namespace DependencyInjectionDemo
{
    class Program
    {

        const string IDMilchstrasse = "Milchstrasse";

        static void Main(string[] args)
        {
            //var Universum = new Basics._04_Objektorientiert.Astro.inMem.Universum();
            var Universum = Basics._04_Objektorientiert.Astro.inMem.Universum.Instance;

            // Manuell durchgeführte Dependency Injection: Poor Man DI
            IStrategieBerechneMasseGalaxie Berechnungsvorschrift = new BerechneGalaxiemasseAusDenSternen();

            // Create Kommando
            Universum.CreateGalaxieWithStrategie(IDMilchstrasse, Berechnungsvorschrift);

            // Afragen der soeben erzeugten Galaxie
            var Milchstrasse = Universum.GetGalaxie(IDMilchstrasse);

            Universum.CreateStern("Sonne", Spektralklasse.G(), 1, IDMilchstrasse);
            Universum.CreateStern("Bellatrix", Spektralklasse.A(), 50, IDMilchstrasse);
            Universum.CreateStern("Beteigeuze", Spektralklasse.M(), 1, IDMilchstrasse);

            var Sterne = Milchstrasse.Sterne;

            var Sonne = Universum.GetStern("Sonne");
            Debug.Assert(Sonne.Masse_in_Sonnenmassen == 1 && Sonne.Heimatgalaxie == Milchstrasse);

            var masse = Milchstrasse.Masse_in_kg;


            // Anlegen des Ioc Containers (Unity)
            var IoC = new Microsoft.Practices.Unity.UnityContainer();

            // Definieren aller Schnittstellen und der Klassen, deren Instanzen zur Laufzeit die Schnittstellen implementieren sollen
            IoC.RegisterType<IStrategieBerechneMasseGalaxie, BerechneGalaxiemasseAusDenSternenUndPlaneten>();


            Universum.CreateGalaxieWithStrategie("Andromeda", IoC.Resolve<IStrategieBerechneMasseGalaxie>());

            Universum.CreateStern("SonneA", Spektralklasse.G(), 1, "Andromeda");
            Universum.CreatePlanet("Superkugel", 10000, "SonneA");

            double masseAndromeda = Universum.GetGalaxie("Andromeda").Masse_in_kg;


        }
    }
}
