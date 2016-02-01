using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics
{
    public class Point
    {
        /// <summary>
        /// Klasse kann sehr wohl den Defaultkonstruktor überschreiben
        /// </summary>
        public Point()
        {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public Point(double X, double Y)
        {
            // this steht für das aktuelle Objekt. Über this.X wird auf das Feld X 
            // des aktuellen Objektes zugegriffen. Hingegen ist X der zugriff auf den Parameter X des aktuellen Konstruktors
            this.X = X;
            this.Y = Y;
        }

        // Die X und Y- Koordinaten werden über Felder
        // angesprochen. Problem: Der Zugriff auf den 
        // inneren Zustand und die Implementierung des 
        // Zustandes sind nicht voneineander getrennt
        public double X;
        public double Y;
    }
}
