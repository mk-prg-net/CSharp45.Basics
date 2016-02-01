using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics
{
    public class PointWithProperties
    {
        /// <summary>
        /// Defaultkonstruktor (leere PArameterliste!)
        /// </summary>
        public PointWithProperties() {}

        /// <summary>
        /// Spezifischer Konstruktor
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public PointWithProperties(double X, double Y)
        {
            // Namenskonflikt zwischen Eigenschafts- und Parametername wird gelöst,
            // indem die Eigenschaft mittels this- Zeiger von dem PArameter unterschieden wird

            // Die Zuweisung an die Eigenschaft X wird vom Compiler übersetzt in eine 
            // Aufruf des setters: this.X = X; -> this.X.set(X);
            this.X = X;
            this.Y = Y;
        }


        // Implementierung des internen Zustandes
        double _X;
        double _Y;

        // Zugriffsschicht auf den internen Zustand

        /// <summary>
        /// X- Koordinate
        /// </summary>
        public double X
        {
            // Kompiler formt aus get-> double get() ...
            get
            {
                return _X;
            }

            set
            {
                // value ist der implizit der set- MEthode übergeben PArameter
                // void set(double value) ...
                _X = value;
            }
        }

        /// <summary>
        /// X- Koordinate
        /// </summary>
        public double Y
        {
            // Kompiler formt aus get-> double get() ...
            get
            {
                return _Y;
            }

            set
            {
                // value ist der implizit der set- MEthode übergeben PArameter
                // void set(double value) ...
                _Y = value;
            }
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ") dEuklid= " + Math.Round(Math.Sqrt(X*X + Y*Y), 2);
        }
    }
}
