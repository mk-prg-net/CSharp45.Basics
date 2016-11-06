using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._01_Grundbausteine
{
    public class _01_07_Unterprogramme_und_Funktionen
    {

        public static Point GetPoint(int PointNumber)
        {
            var p = new Point();
            // Hier erfolgt fiktiv ein Datenbankzugriff, der zur Nummer den zugehörigen Punkt holt
            // ...
            p.X = PointNumber;
            p.Y = PointNumber * 100;
            return p;
        }

        public static Point GetPoint(int PointNumber, Point p)
        {            
            // Hier erfolgt fiktiv ein Datenbasnkzugriff, der zur Nummer den zugehörigen Punkt holt
            // ...
            p.X = PointNumber;
            p.Y = PointNumber * 100;
            return p;
        }

        // Demo von Defaultparametern
        // Die folgende Funktion entspricht dem Desingpattern einer Klassenfabrik
        public static Point CreatePoint(double x = 99, double y = 99)
        {            
            //Point p = new Point();
            //p.X = 9;
            //p.Y = 11;
            //return p;
            return new Point(x, y);
        }

        /// <summary>
        /// Berechnet den Abstand vom Nullpunkt
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static double Length(Point a)
        {
            return Math.Sqrt(a.X*a.X + a.Y*a.Y);
        }

        /// <summary>
        /// Prüft zwei Punkte auf Identität
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="delta">maximal, durch Unschärfe bedingter Abstand für zwei identische Punkte</param>
        /// <returns></returns>
        public static bool Equal(Point a, Point b, double delta)
        {
            Point diff = new Point() { X = a.X - b.X, Y =  a.Y - b.Y };

            return delta > Length(diff);

        }

        /// <summary>
        /// Addition von zwei Punkten, realisiert als Funktion
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point Add(Point a, Point b)
        {
            return new Point() { X = a.X + b.X, Y = a.Y + b.Y };
        }

        /// <summary>
        /// Umrechnung, als Funktion implementiert, wodurch der Aufruf zu einem Ausdruck wird
        /// </summary>
        /// <param name="r"></param>
        /// <param name="phi_in_rad"></param>
        /// <returns></returns>
        public static Point PolarToCartesian(double r, double phi_in_rad)
        {
            return new Point() { X = r * Math.Sin(phi_in_rad), Y = r * Math.Cos(phi_in_rad) };
        }

        /// <summary>
        /// Alternative Umrechung von Polar- in Kartesischsche Koordinaten - realisiert als Unterprogramm
        /// </summary>
        /// <param name="r"></param>
        /// <param name="phi_in_rad"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void PolarToCartesian(double r, double phi_in_rad, out double x, out double y)
        {
            x = r * Math.Sin(phi_in_rad);
            y = r * Math.Cos(phi_in_rad);

            // Änderungen von eingabeparametern im Unterprogramm haben keine auswirkung auf die Werte im Rufer
            r = 0;
            phi_in_rad = 0;
        }

        // ref ist abgeschwächte Form von out: Zuweisungen an ref- Parameter im Funktuionsblock
        // nicht zwingend erforderlich
        public static void PolarToCartesianWithRef(double r, double phi_in_rad, ref double x, ref double y)
        {
            x = r * Math.Sin(phi_in_rad);
            y = r * Math.Cos(phi_in_rad);
        }

        /// <summary>
        /// Demo: Referenztypen werden immer als "ref" übergeben
        /// </summary>
        /// <param name="r"></param>
        /// <param name="phi_in_rad"></param>
        /// <param name="p"></param>
        public static void PolarToCartesianWithImplicitRef(double r, double phi_in_rad, Point p)
        {
            p.X = r * Math.Sin(phi_in_rad);
            p.Y = r * Math.Cos(phi_in_rad);
        }


        /// <summary>
        /// Demo Paramarray
        /// </summary>
        /// <param name="summanden"></param>
        /// <returns></returns>
        public static double Sum(params double[] summanden)
        {
            double _sum = 0;

            foreach (double s in summanden)
            {
                _sum += s;
            }

            return _sum;
        }

        /// <summary>
        /// Vor dem Param- Array dürfen noch weitere Paramter stehen. Hier factor.
        /// </summary>
        /// <param name="factor"></param>
        /// <param name="summanden"></param>
        /// <returns></returns>
        public static double MulSum(double factor,  params double[] summanden)
        {
            double _sum = 0;

            foreach (double s in summanden)
            {
                _sum += s;
            }

            return factor *_sum;
        }


        /// <summary>
        /// Klassenfabrik für Autos
        /// </summary>
        /// <param name="Markenname"></param>
        /// <param name="Modell">Modellbezeichung für das Fahrzeug</param>
        /// <param name="EntfernungVomStart">Entfernung von Stuttgart in km</param>
        /// <param name="vStartInKmh"></param>
        /// <returns></returns>
        public static _04_Objektorientiert.Autobahn.Auto CreateAuto(
            string Markenname, 
            string Modell, 
            double EntfernungVomStart = 0, 
            double vStartInKmh = 0)
        {
            return new _04_Objektorientiert.Autobahn.Auto(Markenname, Modell, EntfernungVomStart, vStartInKmh);
        }


    }
}
