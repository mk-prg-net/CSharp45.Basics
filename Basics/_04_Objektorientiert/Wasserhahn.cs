using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert
{
    public class Wasserhahn
    {
        public static double DurchflussInCm3ProSekunde(Wasserhahn hahn, double Wasserdruck)
        {
            return hahn.Rohrdurchmesser * Wasserdruck;
        }

        // Initialisierung durch Konstruktoren (werden durch den new- Operator aufgerufen)
        // Konstruktor hat den Namen der Klasse und hat keinen Rückgabewert
        public Wasserhahn(double Rohrdurchmesser)
        {
            // Durch this wird das Element der Klasse vom gleichnamigen Parameter unterschieden
            this.Rohrdurchmesser = Rohrdurchmesser;
        }

        // Öffnung des Wasserhahnes (Startwert stets 0)
        double öffnungInProzent;

        // Vereinfachte Deklaration einer Eigenschaft, deren getter und setter nur lesen/schrreiben ohne Transformation
        public double Rohrdurchmesser { get; set; }

        // Zugriff auf den Öffnungsgrad über eine Eigenschaft steuern
        public double ÖffnungInPromille
        {
            // Kompiler formt folgenden Kopf um in
            // doubel get() {....}
            get
            {
                return öffnungInProzent * 10.0;
            }

            // Kompiler formt folgenden Kopf um in
            // void set(double value) {....}
            set
            {
                öffnungInProzent = value / 10.0;
            }
        }


        // Methoden
        public double öffnen(double vergrößerungInProzent)
        {
            öffnungInProzent += vergrößerungInProzent;
            if (öffnungInProzent > 100.0)
                öffnungInProzent = 100.0;

            return öffnungInProzent;
        }

        public double schließen(double vergrößerungInProzent)
        {
            öffnungInProzent -= vergrößerungInProzent;
            if (öffnungInProzent < 0.0)
                öffnungInProzent = 0.0;

            return öffnungInProzent;
        }

    }
}
