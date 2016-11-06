using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._01_Grundbausteine
{
    // Variablen, Funktionen und Unterprogramme müssen immer in einem Klassenblock eingeschlossen sein
    // int x = 99;


    public class DemoZugriffsmodifikatoren
    {
        public void Zugriff()
        {

            // Zugriff auf statische Member erfordern kein Objekt. Sie sind direkt der Klasse untergeordnet
            _01_05_Variablen.id_static = 99;

            // Alle nichtstatischen Member sind an Objekte der Klasse gebunden
            _01_05_Variablen EinObjekt = new _01_05_Variablen();

            // Interne Member sind innerhalb des Projektes überall sichbar
            Debug.WriteLine(EinObjekt.IchBinIntern);

            // Öffentliche sind überall sichbar
            Debug.WriteLine(EinObjekt.IchBinÖffentlich);

            // Private sind nur innerhalb der Klasse sichtbar
            //Debug.WriteLine(EinObjekt.IchBinPrivat);

        }
    }

    public class _01_05_Variablen
    {
        public const double PI = 3.142;
        public readonly double MwSt;

        public static int id_static = 0;

        private int IchBinPrivat = 1;
        protected int IchBinGeschützt = 2;
        internal int IchBinIntern = 3;
        public int IchBinÖffentlich = 4;

        // Initialisierungsroutiene (= Konstruktor) der Klasse
        public _01_05_Variablen()
        {
            // Auch innerhalb eines Konstruktors ist ein schreiben in Konstanten verboten
            // PI = 99;

            // Innerhalb eines Konstruktors kann einem Readonly ein Wert zugewiesen werden
            MwSt = 0.19;

        }

        public void UmgangMitKonstanten()
        {
            // Konstanten sind unveränderlich. Dies stellt der Compiler sicher
            //PI = 99;

            // Auch Readonlys si9nd unveränderlich !
            //MwSt = 99;

            IchBinPrivat = 99;
        }



        public static int MakeID()
        {
            return id_static++;
        }

        internal int id_nonstatic = 0;

        public static int MakeID_ohneStaticID()
        {
            _01_05_Variablen EinObjekt = new _01_05_Variablen();
            return ++EinObjekt.id_nonstatic;
        }

        static _01_05_Variablen MeinStatischesObjekt = new _01_05_Variablen();

        public static int MakeID_mitStaticObjekt()
        {
            return ++MeinStatischesObjekt.id_nonstatic;
        }

        /// <summary>
        /// Motivation für Enums: Definieren einer Zieleinheit als String- 
        /// Nachteile: Ressourcenverschwendung, unsicher
        /// </summary>
        /// <param name="MesswertInMeter"></param>
        /// <param name="ZielEinheit"></param>
        /// <returns></returns>
        public static double ConvertToKompliziert(double MesswertInMeter, string ZielEinheit)
        {

            // Resistent gegen Groß/Kleinschreibung
            if (ZielEinheit.ToLower() == "cm")
            {
                return 100.0 * MesswertInMeter;
            }

            if (ZielEinheit == "dm")
            {
                return 10.0 * MesswertInMeter;
            }

            if (ZielEinheit == "km")
            {
                return 0.001 * MesswertInMeter;
            }

            if (ZielEinheit == "m")
            {
                return 1.0 * MesswertInMeter;
            }

            if (ZielEinheit == "mm")
            {
                return 1000.0 * MesswertInMeter;
            }

            return -1.0;
        }

        /// <summary>
        /// Enum für Längeneinheiten = Untertyp von int
        /// </summary>
        public enum LaengenEinheiten
        {
            mm = 1,
            cm = 2,
            dm = 3,
            m = 4,
            km = 5
        }

        /// <summary>
        /// Verbesserung: Zieleinheit als Enum. Schon Ressourcen und ist sicher !
        /// </summary>
        /// <param name="MesswertInMeter"></param>
        /// <param name="ZielEinheit"></param>
        /// <returns></returns>
        public static double ConvertTo(double MesswertInMeter, LaengenEinheiten ZielEinheit)
        {
            //if (ZielEinheit == cm)
            double zielwert = 0.0;
            if (ZielEinheit == LaengenEinheiten.cm)
            {
                zielwert = 100.0 * MesswertInMeter;
            }
            else if (ZielEinheit == LaengenEinheiten.dm)
            {
                zielwert = 10.0 * MesswertInMeter;
            }
            else
            {
                zielwert = -1.0;
            }

            //if (ZielEinheit == LaengenEinheiten.km)
            //{
            //    return 0.001 * MesswertInMeter;
            //}

            //if (ZielEinheit == LaengenEinheiten.m)
            //{
            //    return 1.0 * MesswertInMeter;
            //}

            //if (ZielEinheit == LaengenEinheiten.mm)
            //{
            //    return 1000.0 * MesswertInMeter;
            //}

            return zielwert;
        }

        public static double ConvertTo2(double MesswertInMeter, LaengenEinheiten ZielEinheit)
        {
            switch (ZielEinheit)
            {

                case LaengenEinheiten.cm:
                    return 100.0 * MesswertInMeter;

                case LaengenEinheiten.dm:

                    return 10.0 * MesswertInMeter;


                //if (ZielEinheit == LaengenEinheiten.km)
                //{
                //    return 0.001 * MesswertInMeter;
                //}

                //if (ZielEinheit == LaengenEinheiten.m)
                //{
                //    return 1.0 * MesswertInMeter;
                //}

                //if (ZielEinheit == LaengenEinheiten.mm)
                //{
                //    return 1000.0 * MesswertInMeter;
                //}
                default:
                    {
                        return -1.0;
                    }
            }


        }


        /// <summary>
        /// Funktion dient zur Demo der Typprüfung zur Laufzeit
        /// </summary>
        /// <param name="a">Erster Summand</param>
        /// <param name="b">Zweiter Summand</param>
        /// <returns></returns>
        public static double AddUntypisiert(object a, object b)
        {
            // Achtung: a und b werden als Objektboxen übergeben.
            // Wenn b ein integer war, und nun als integerobjektbox übergeben wurde,
            // dann ist dafür kein (double) Konvertierungsop. definiert
            // => Unboxing durchführen in             

            // Ohne Downcast läuft nichts
            // return a + b;
            //return (double)a + (double)b;
            return Unboxing(a) + Unboxing(b);
        }

        public static double Unboxing(object box)
        {
            // Kann man auch mit Convert.ToDouble(box) realisieren

            if (box is int)
                return (double)(int)box;
            // gleich in Double wandeln geht nicht !!
            //return (double)box;
            else if (box is short)
                return (double)(short)box;
            if (box is double)
                return (double)box;
            else
                throw new InvalidCastException();

        }

        // Überladene Funktionen lösen das Problem besser
        public static double AddT(double a, double b)
        {
            return a + b;
        }

        public static double AddT(int a, int b)
        {
            return a + b;
        }

        public static double AddT(short a, short b)
        {
            return a + b;
        }
    }
}
