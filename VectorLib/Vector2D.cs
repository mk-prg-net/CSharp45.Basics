using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorLib
{
    public struct Vector2D
    {
        public double X;
        public double Y;

        /// <summary>
        /// Defaultkonstruktoren sind bei struct vom System vodefiniert
        /// und dürfen nicht durch eignen ersetzt werden
        /// </summary>
        //public Vector2D()
        //{
        //    X = 0.1;
        //    Y = 0.1;
        //}

        public Vector2D(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Copy- Konstuktor
        /// </summary>
        /// <param name="Original"></param>
        public Vector2D(Vector2D Original)
        {
            X = Original.X;
            Y = Original.Y;
        }

        public double DEuklid
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }

        /// <summary>
        /// Vektoraddition
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector2D operator +(Vector2D a, Vector2D b)
        {
            int i = 0;
            Vector2D summe; //  = new Vector2D();
            summe.X = a.X + b.X;
            summe.Y = a.Y + b.Y;

            return summe;
        }

        /// <summary>
        /// Skalarprodukt aus zwei Vektoren
        /// </summary>
        /// <param name="aT"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double operator *(Vector2D aT, Vector2D b)
        {
            return aT.X * b.X + aT.Y * b.Y;
        }

        /// <summary>
        /// Konstante * Vektor
        /// </summary>
        /// <param name="faktor"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector2D operator *(double faktor, Vector2D b)
        {
            return new Vector2D(b.X * faktor, b.Y * faktor);
        }

    }
}
