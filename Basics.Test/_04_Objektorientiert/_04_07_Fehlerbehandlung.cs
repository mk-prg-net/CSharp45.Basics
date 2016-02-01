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
            System.IO.FileStream fs = new System.IO.FileStream(@"C:\Fantasie.txt", System.IO.FileMode.Open);
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

        }
    }
}
