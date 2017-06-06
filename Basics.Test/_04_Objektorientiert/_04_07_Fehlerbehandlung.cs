using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Diagnostics;

namespace Basics.Test._04_Objektorientiert
{
    [TestClass]
    public class _04_07_Fehlerbehandlung
    {
        static void up1()
        {
            try
            {
                Debug.WriteLine("UP1: Vor dem ersten Fehler.");
                //throw new Exception("Erster Fehler aus UP1");
                up2();
                Debug.WriteLine("UP1: Nach dem ersten Fehler.");
            }
            catch (Exception ex)
            {
                throw new Exception("CATCH Handler aus UP1", ex);

                // Fehlerobjekt erneut werfen
                //throw;
            }
            finally
            {
                Debug.WriteLine("Finally aus UP1");
            }
        }

        static void up2()
        {
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(@"C:\Fantasie.txt", System.IO.FileMode.Open);
            }
            catch (Exception ex)
            {
                throw new Exception(mko.TraceHlp.FormatErrMsg("Test Fehlerbehandlung", "up2"), ex);
            }
        }

        static void ThrowIfvon_gt_bis(double von, double bis)
        {
            if(von > bis)
            {
                throw new Exception(mko.TraceHlp.FormatErrMsg("TestEx", "up3", "von ist größer als bis !"));
            }
        }

        static void ThrowIfvon_lt_1(double von)
        {
            if (von <= 1)
            {
                throw new Exception(mko.TraceHlp.FormatErrMsg("TextEx", "up3", "von ist kleiner 1"));
            }
        }


        static void up3(double von, double bis)
        {
            if (von <= bis)
            {
                if (von > 1)
                {
                    double laenge = bis - von;
                } else
                {
                    throw new Exception(mko.TraceHlp.FormatErrMsg("TextEx", "up3", "von ist kleiner 1"));
                }
            }
            else
            {
                throw new Exception(mko.TraceHlp.FormatErrMsg("TestEx", "up3", "von ist größer als bis !"));

            }
        }

        static void up31(double von, double bis)
        {
            // Vorbedingungen des Programmes
            ThrowIfvon_gt_bis(von, bis);
            ThrowIfvon_lt_1(von);

            double laenge = bis - von;

        }

        static void up32(double von, double bis)
        {
            // Vorbedingungen des Programmes
            mko.TraceHlp.ThrowArgExIfNot(von <= bis, "von ist größer als bis");
            mko.TraceHlp.ThrowArgExIfNot(von > 1, "von ist kleiner als 1");

            double laenge = bis - von;

        }


        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                up2();
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Debug.WriteLine("FileNotFoundException: " + ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Debug.WriteLine("Finally aus Main");
            }

            //Achtung: Abgeleitete Fehler müssen vor den Fehlern der Basisikalsse analysiert werden
            //try
            //{
            //    up2();
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //}
            //catch (System.IO.FileNotFoundException ex)
            //{
            //    Debug.WriteLine("FileNotFoundException: " + ex.Message);
            //}
            //finally
            //{
            //    Debug.WriteLine("Finally aus Main");
            //}

            try
            {
                Debug.WriteLine("HP1: Vor dem ersten Fehler.");
                up1();
                Debug.WriteLine("HP1: Nach dem ersten Fehler.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Debug.WriteLine("Ursrünglicher Fehler: " + ex.InnerException.Message);

                }

                Debug.WriteLine(mko.ExceptionHelper.FlattenExceptionMessages(ex));
            }


            try
            {
                up32(2, 1);
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
    }
}
