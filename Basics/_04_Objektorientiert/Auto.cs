using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Basics._04_Objektorientiert.Autobahn
{
    public class Auto : IDisposable
    {
        // Events

        // 1) Delegate für Hupsignal definieren

        public delegate void DGHupen(int ANzHupsignale);


        // 2) Mittels Delegate einen Member deklarieren, an dem andere 
        // Verkehrsteilnehmer ihre HupeHören Eventhandler registrieren können

        public event DGHupen Hupen;


        // 3) Methode zum Auslösden des Events bereitstellen
        protected void HupsignalAuslösen(int AnzHupsignale)
        {
            if (Hupen != null)
                Hupen(AnzHupsignale);
        }


        // 4) Reaktion auf Hupsignal

        public void HöreHupe(int AnzHupsignal)
        {
            if (AnzHupsignal < 3)
                Debug.WriteLine(Marke + @"\" + Modell + @"Enternung: " + EntfernungVonStuttgartInKm + " Grummel ....");
            else
                Debug.WriteLine(Marke + @"\" + Modell + @"Enternung: " + EntfernungVonStuttgartInKm + " Hilfe !!!");
        }


        public void SituationBewerten(params Auto[] andereVerkehrsteilnehmer)
        {
            bool bitteHupen = false;
            foreach (var Teilnehmer in andereVerkehrsteilnehmer)
            {
                double Abstand = Teilnehmer.EntfernungVonStuttgartInKm - EntfernungVonStuttgartInKm;
                if (Abstand < 0.05 && Abstand > 0.0)
                    bitteHupen = true;
            }

            if (bitteHupen)
                HupsignalAuslösen(3);

        }


        // Nur lesbare Eigenschaften Marke und Modell
        string _Marke;
        public string Marke
        {
            // string get() {...; return...;}
            get
            {
                return _Marke;
            }
        }

        string _Modell;
        public string Modell
        {
            get
            {
                return _Modell;
            }
        }

        /// <summary>
        ///  Bsp. einer nur lesbaren Eigenschaft
        /// </summary>
        public string VolleFahrzeugbezeichnung
        {
            get
            {
                return Marke + "/" + Modell;
            }

            private set
            {
            }
        }


        // Liste der Konstruktoren

#if(DEBUG)
        void MeldeGeburt(string Marke, string Modell)
        {
            Debug.WriteLine("Geburt Marke: " + Marke + " Modell: " + Modell);
        }
#endif

        /// <summary>
        /// Default- Konstruktor. Wird z.B. vom Objektinitialisierer new Auto(){....} benötigt
        /// </summary>
        public Auto()
        {
            _Marke = "unbekannt";
            _Modell = "unbekannt";

#if(DEBUG)
            MeldeGeburt(_Marke, _Modell);
#endif
        }

        /// <summary>
        /// Konstruktoren
        /// </summary>
        /// <param name="Marke">Automarke</param>
        /// <param name="Modell">Modell der Marke</param>
        /// 
        public Auto(string Marke, string Modell)
        {
            _Marke = Marke;
            _Modell = Modell;

#if(DEBUG)
            MeldeGeburt(_Marke, _Modell);
#endif
        }

        /// <summary>
        /// Konstruktor 2
        /// </summary>
        /// <param name="Marke"></param>
        /// <param name="Modell"></param>
        /// <param name="EntfernungVonStuttgartInKm">Startpunkt des Autos, gemessen von Stuttgart aus</param>
        public Auto(string Marke, string Modell, double EntfernungVonStuttgartInKm)
        {
            _Marke = Marke;
            _Modell = Modell;
            this.EntfernungVonStuttgartInKm = EntfernungVonStuttgartInKm;

#if(DEBUG)
            MeldeGeburt(_Marke, _Modell);
#endif
        }

        public Auto(string Marke, string Modell, double EntfernungVonStuttgartInKm, double vStart)
        {
            _Marke = Marke;
            _Modell = Modell;
            this.EntfernungVonStuttgartInKm = EntfernungVonStuttgartInKm;
#if(DEBUG)
            MeldeGeburt(_Marke, _Modell);
#endif
        }

        // Destruktor: Wird Aufgerufen, wenn das Objekt durch den Garbage Collector im Speicher gelöscht wird
        ~Auto()
        {
            System.Diagnostics.Debug.WriteLine(Marke + " Modell: " + Modell + " wird nach " + EntfernungVonStuttgartInKm + "km verschrottet");
        }

        double _EntfernungVonStuttgartInKm;
        public double EntfernungVonStuttgartInKm
        {
            get
            {
                return _EntfernungVonStuttgartInKm;
            }

            // void set(double value) { .... }
            set
            {
                _EntfernungVonStuttgartInKm = value;
            }
        }


        public double fahre(double vInMProSek, double fahrzeitInSek)
        {
            _EntfernungVonStuttgartInKm += (vInMProSek * fahrzeitInSek) / 1000.0;
            return _EntfernungVonStuttgartInKm;
        }


        /// <summary>
        /// Allgemeine Methode zum betanken eines Fahrzeuges
        /// </summary>
        /// <param name="mengeInLiter"></param>
        /// <returns></returns>
        public double tanken(double mengeInLiter)
        {
            Debug.WriteLine(Marke + " " + Modell + " wurde betankt mit " + mengeInLiter + " Liter Treibstoff");
            return mengeInLiter;
        }

        // Polymorphe Methode werden in der Basisklasse mit virtual gekennzeichnet
        public virtual double tankenPolymorph(double mengeInLiter)
        {
            Debug.WriteLine(Marke + " " + Modell + " wurde betankt mit " + mengeInLiter + " Liter Treibstoff");
            return mengeInLiter;
        }


        // Implementierung der Dispose- Methode
        public void Dispose()
        {
            Debug.WriteLine("Das ursprüngliche Auto- Dispose");
        }

        // public void Dispose()     // implizit implementiert
        void IDisposable.Dispose()  // explizit implementiert
        {
            System.Diagnostics.Debug.WriteLine(Marke + " Modell: " + Modell + " wird nach " + EntfernungVonStuttgartInKm + "km mit Dispose verschrottet");

            // Explizit den Aufruf des Dstruktors durch den Garbage Collector abschalten (um eine doppelte Ressourcenfreigabe zu verhindern)
            GC.SuppressFinalize(this);

        }

        // Primitive Eigenschaft 
        public int Schadensfreiheitklasse
        {
            get
            {
                return _Schadensfreiheitklasse;
            }
            set
            {
                _Schadensfreiheitklasse = value;
            }
        }
        int _Schadensfreiheitklasse;

        //
        public int SchadensfreiheitklasseSimpel { get; set; }

    }
}
