using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._01_Grundbausteine
{
    public class _01_10_GenerischeTypen
    {
        public enum Farben { rot, grün, blau, cyan }

        public enum Varianten { basics, lux, hippster }

        /// <summary>
        /// Konkreter Datentyp für einen Längenmesswert
        /// </summary>
        public class MesswertLaengeDbl
        {
            public MesswertLaengeDbl(double Value, Units Unit)
            {
                _Value = Value;
                _Unit = Unit;
            }

            public double Value
            {
                get
                {
                    return _Value;
                }
            }
            private double _Value;

            public enum Units { mm, cm, dm, m, km }

            public Units Unit
            {
                get
                {
                    return _Unit;
                }
            }
            private Units _Unit;

        }

        /// <summary>
        /// Verallgemeinerung von MesswertLaengeDbl zu einer
        /// generischen Klasse für Messwerte
        /// </summary>
        public class Messwert<TValue, TUnits>
        {
            public Messwert(TValue Value, TUnits Unit)
            {
                _Value = Value;
                _Unit = Unit;
            }

            public TValue Value
            {
                get
                {
                    return _Value;
                }
            }
            private TValue _Value;

            public TUnits Unit
            {
                get
                {
                    return _Unit;
                }
            }
            private TUnits _Unit;

        }

        public class Messwert
        {
            /// <summary>
            /// Klassenfabrik: Gibt ein frisch erstelltes und konfiguriertes Messwertobjekt zurück
            /// </summary>
            /// <param name="Value"></param>
            /// <param name="Unit"></param>
            /// <returns></returns>
            public static Messwert<TValue1, TUnits1> Create<TValue1, TUnits1>(TValue1 Value, TUnits1 Unit)
            {
                return new Messwert<TValue1, TUnits1>(Value, Unit);
            }

        }


    }
}
