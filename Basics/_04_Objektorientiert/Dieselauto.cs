using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Basics._04_Objektorientiert.Autobahn
{
    public class Dieselauto : Auto, IComparable, IDisposable
    {
        /// <summary>
        /// Konstruktoren einer Abgeleiteten Klasse müssen einen Konstruktor der Basisklasse in der sog. 
        /// Initialisierungsliste ( nach dem Doppelpunkt) aufrufen
        /// </summary>
        /// <param name="Marke"></param>
        /// <param name="Modell"></param>
        public Dieselauto(string Marke, string Modell)
            : base(Marke, Modell, 100)
        {
            // Zugirff auf Member in der Basisklasse, falls...
            Debug.WriteLine(base.VolleFahrzeugbezeichnung);

            // ... in der abgeleiteten Klasse der Member überdeckt wurde
            Debug.WriteLine(this.VolleFahrzeugbezeichnung);

        }

        public override string ToString()
        {
            return VolleFahrzeugbezeichnung;
        }

        // Mittels new wird dokumentiert, dass das Überschreiben von VolleFahrzeugbezeichnung
        // aus der Basisklasse beabsichtigt war.
        public new string VolleFahrzeugbezeichnung
        {
            get
            {
                return "Diesel: " + base.VolleFahrzeugbezeichnung;
            }
        }

        /// <summary>
        /// Spezielle Methode zum betanken eines Dieselfahrzeuges. Diese überdeckt die Implementierung aus der Basisklasse. Das Schlüsselwort new dokumentiert dies
        /// </summary>
        /// <param name="mengeInLiter"></param>
        /// <returns></returns>
        public new double tanken(double mengeInLiter)
        {
            Debug.WriteLine("Dieselauto" + Marke + " " + Modell + " wurde betankt mit " + mengeInLiter + " Liter Diesel");
            return mengeInLiter;
        }

        public override double tankenPolymorph(double mengeInLiter)
        {
            Debug.WriteLine("Dieselauto" + Marke + " " + Modell + " wurde polymorph betankt mit " + mengeInLiter + " Liter Diesel");
            return mengeInLiter;
        }

        //public override double tankenPolymorphAbstract(double mengeInLiter)
        //{
        //    Debug.Write("Abstrakte Mehode/ ");
        //    tanken(mengeInLiter);
        //    return mengeInLiter;
        //}

        //public override string ToString()
        //{
        //    return Marke + " " + Modell;
        //}



        public void Dispose()
        {
            //IDisposable ptrDsp = (IDisposable)(Auto)this;
            //ptrDsp.Dispose();


            System.Diagnostics.Debug.WriteLine(Marke + " Dieselauto: " + Modell + " wird nach " + EntfernungVonStuttgartInKm + "km mit Dispose verschrottet");

        }



        public int CompareTo(object obj)
        {
            var anderesAuto = (Dieselauto)obj;
            if (anderesAuto.EntfernungVonStuttgartInKm > this.EntfernungVonStuttgartInKm)
                return -1;
            else if (anderesAuto.EntfernungVonStuttgartInKm < this.EntfernungVonStuttgartInKm)
                return 1;
            else
                return 0;
        }
    }
}
