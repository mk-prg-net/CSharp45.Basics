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
        }

        public double X;
        public double Y;
    }
}
