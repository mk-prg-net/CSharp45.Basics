using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Basics._04_Objektorientiert.Autobahn
{
    /// <summary>
    /// Abstrakte Klasse
    /// </summary>
    public abstract class LKW : Auto
    {
        /// <summary>
        /// Allgemeine Methode zum betanken eines Fahrzeuges
        /// </summary>
        /// <param name="mengeInLiter"></param>
        /// <returns></returns>
        public abstract double tankenPolymorphAbstract(double mengeInLiter);

    }

    public class Gastanker : LKW
    {
        public override double tankenPolymorphAbstract(double mengeInLiter)
        {
            Debug.WriteLine("Tanke " + mengeInLiter + " GAS");

            return mengeInLiter;
        }
    }
}
