using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Basics._04_Objektorientiert.Autobahn
{
    public class Benzinauto : Auto
    {
        /// <summary>
        /// Konstruktoren einer Abgeleiteten Klasse müssen einen Konstruktor der Basisklasse in der sog. 
        /// Initialisierungsliste ( nach dem Doppelpunkt) aufrufen
        /// </summary>
        /// <param name="Marke"></param>
        /// <param name="Modell"></param>
        public Benzinauto(string Marke, string Modell) : base(Marke, Modell) { }

        /// <summary>
        /// Allgemeine Methode zum betanken eines Fahrzeuges
        /// </summary>
        /// <param name="mengeInLiter"></param>
        /// <returns></returns>
        public new double tanken(double mengeInLiter)
        {
            Debug.WriteLine("Benzinauto" + Marke + " " + Modell + " wurde betankt mit " + mengeInLiter + " Liter Benzin");
            return mengeInLiter;
        }

        public override double tankenPolymorph(double mengeInLiter)
        {
            return tanken(mengeInLiter);
        }

        //public override double tankenPolymorphAbstract(double mengeInLiter)
        //{
        //    Debug.Write("Abstrakte Mehode/ ");
        //    tanken(mengeInLiter);
        //    return mengeInLiter;
        //}

        public TimeSpan parken(DateTime von, DateTime bis, string ort)
        {
            throw new System.NotImplementedException();
        }

        public void überholen(Auto überholter)
        {
            throw new System.NotImplementedException();
        }

    }
}
