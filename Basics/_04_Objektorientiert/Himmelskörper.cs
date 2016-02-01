using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert
{
    // Da die Klasse eine abstrakte Methode enthält, muss sie als abstrakt 
    // gekennzeichnet werden.
    public abstract class Himmelskörper
    {
        public string Name
        {
            get;
            set;
        }

        // Eine allgemeine Berechnungsvorschrift für Massen existiert nicht.
        // Deshalb wird hier sinnloserweise 0 zurückgegeben, da ein
        // Funktionsrumpf bei virtuellen Funkltionen definiert werden muss
        public virtual double BerechneMasse()
        {
            return 0;
        }

        // Abstracte Methoden sind virtuelle Methoden, für die keine sinvolle 
        // implementierung in der Basisklasse existiert
        public abstract double BerechneMasseAbstract();

    }
}
