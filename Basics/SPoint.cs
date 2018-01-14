using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public struct SPoint
    {
        // Achtung: Strukturen dürfen den eingebauten Defaultkonstruktor nicht überschreiben
        //public SPoint()
        //{
        //    X = 0;
        //    Y = 0;
        //}

        /// <summary>
        /// Konstrutor mit 2 Parametern. 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public SPoint(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
            this.Description = "Hallo";
            Description2 = "Welt";
        }

        public double X; // { get; set; }
        public double Y; // { get; set; }

        public string Description;
        public string Description2 { get; set; }
    }
}
