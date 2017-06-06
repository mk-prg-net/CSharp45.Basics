using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert
{
    /// <summary>
    /// StoppUhr als versiegelte Klasse (sealed). Keine weiteren Ableitungen sind 
    /// möglich
    /// </summary>
    public sealed class StoppUhr
    {

        // Innerer Zustand: hier werden Informationen im Objekt gespeichert
        long _TicksBeimStart;

        long _TicksBeimStopp;

        // Konstruktoren bzw. Initialisierungsroutinen
        public StoppUhr()
        {
            Reset();
        }

        // Methoden oder Nachrichten, die ein Objekt empfangen kann, und auf die es reagiert

        /// <summary>
        /// Zeitmessvorgang starten
        /// </summary>
        public void Start()
        {
            Reset();
        }

        /// <summary>
        /// ... beenden
        /// </summary>
        public void Stopp()
        {
            _TicksBeimStopp = DateTime.Now.Ticks;

            if (ZeitInMsEigenschaft >= ZeitLimitInMs)
            {
                // Ereignis feuern, was alle Benachrichtigt in der Umgebung, dass das 
                // Zeitlimit gerissen wurde

                if (ZeitlimitUeberschrittenEvent != null)
                {
                    //Eventhandler wurden registriert-> Event wird gefeuert
                    ZeitlimitUeberschrittenEvent.Invoke(ZeitLimitInMs, ZeitInMsEigenschaft);
                }


            }
        }

        /// <summary>
        /// Das Event wird gefeuert, wenn ein Zeitlimit überschritten wurde.
        /// Dabei werden alle Objekt benachrichtigt, die hier vorhher einen Eventhandler
        /// registriert hatten. Eventhandler sind nichts weiter als Methoden von Objekten.
        /// In diesem Fall Methoden, die zwei Parameter entgegennehmen der Art
        /// void Eventhandler(double ZeitlimitInMs, double ZeitInMs);
        /// Rückgabewert und Parameterliste sind durch den Typen Action<double, double> 
        /// definiert.
        /// Objekte vom Typ Action<...> sind "Kisten", die Einsprungadressen von
        /// Methoden aufnehmen
        /// </summary>
        public event Action<double, double> ZeitlimitUeberschrittenEvent;

        /// <summary>
        /// Inneren Zustand in einen Grundzustand versetzen (für eine neue Zeitmeassung vorbereiten)
        /// </summary>
        public void Reset()
        {
            _TicksBeimStart = DateTime.Now.Ticks;
            _TicksBeimStopp = _TicksBeimStart;
        }

        // Hier werden Nachrichten eingesetzt, um den inneren Zustand abzurufen

        public double ZeitInMs()
        {
            return new TimeSpan(_TicksBeimStopp - _TicksBeimStart).TotalMilliseconds;
        }

        public double ZeitInSec()
        {
            return new TimeSpan(_TicksBeimStopp - _TicksBeimStart).TotalSeconds;
        }

        // Alternativer Zugriff auf den inneren Zustand über Eigenschaften 

        public double ZeitInMsEigenschaft
        {
            // Getter dient zum Abruf der Informationen einer Eigenschaft
            get
            {
                return ZeitInMs();
            }

            // Setter dient zum Setzen neuer Informationen in einer Eigenschaft
            // Compiler wandelt set{ ... } um in void set(double value) {...}
            set
            {
                _TicksBeimStart = 0;
                _TicksBeimStopp = (long)(value * 1.0e4);
            }
        }

        // Neue Eigenschaft, die auf einen trivial implementierten inneren Zustand zugreift
        // altmodisch und unsauber implementiert
        //public string Name;

        // modern als Eigenschaft
        public string Name
        {
            // Compiler wandelt get{ ... } um in string get() {...}
            get
            {
                return _Name;
            }

            // Setter dient zum Setzen neuer Informationen in einer Eigenschaft
            // Compiler wandelt set{ ... } um in void set(double value) {...}
            set
            {
                _Name = value;
            }
        }

        string _Name;

        // Wenn der innere Zustand nur eine Variable ist, dann gehts auch einfacher
        public string Name2 { get; set; }

        //string _Name2;

        int _einWert;
        public int NurLesbar
        {
            get
            {
                return _einWert;
            }
        }


        public int NurSchreibbar
        {
            set
            {
                _einWert = value;
            }
        }



        // Events: Ein Ereignis, das beim Überschreiten eines Zeitlimits gefeuert wird
        // Innerer Zustand speichert ein Zeitlimit
        long _Zeitlimit_in_Ticks;

        // Alternativer Zugriff auf den inneren Zustand über Eigenschaften 
        public double ZeitLimitInMs
        {
            // Getter dient zum Abruf der Informationen einer Eigenschaft
            get
            {
                return _Zeitlimit_in_Ticks * 1e-4;
            }

            // Setter dient zum Setzen neuer Informationen in einer Eigenschaft
            // Compiler wandelt set{ ... } um in void set(double value) {...}
            set
            {
                _Zeitlimit_in_Ticks = (long)(value * 1e4);
            }
        }



    }
}
