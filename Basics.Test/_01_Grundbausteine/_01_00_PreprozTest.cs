﻿// Eine Preprozessorkonstante deklarieren
//#define MeinePreProzKonstante
// #define DEBUG

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Basics.Test._01_Grundbausteine
{
    [TestClass]
    public class _01_00_PreprozTest
    {
        [TestMethod]
        public void _01_00_PreProzTest1()
        {
            // Zusätzliche Medien zur Aufzeichnung der Traceindfos definiert
            var txtList = new TextWriterTraceListener(@"Trace.txt");
            Debug.Listeners.Add(txtList);
            //Trace.Listeners.Add(txtList);

            //Debug.AutoFlush = true;
            //Trace.AutoFlush = true;

            // Traceswitch zur Steuerung der Informationsflut

            var ts = new System.Diagnostics.TraceSwitch("MySwitch", "...");
            //ts.Level = TraceLevel.Info;

            var ts2 = new System.Diagnostics.TraceSwitch("MySecoundSwitch", "...");

            Debug.WriteLine("Hallo Ausgabefenster");
            Trace.WriteLine("Hallo Ausgabefenster (Gruss von Trace)");


            Trace.WriteLineIf(ts.TraceError, "Eine Fehlermeldung");
            Trace.WriteLineIf(ts.TraceWarning, "Eine Warnung");
            Trace.WriteLineIf(ts.TraceInfo, "Eine Info");
            Trace.WriteLineIf(ts.TraceVerbose, "Eine audführliche Meldung");


            Trace.WriteLineIf(ts2.TraceError, "Eine Fehlermeldung 2");
            Trace.WriteLineIf(ts2.TraceWarning, "Eine Warnung 2");
            Trace.WriteLineIf(ts2.TraceInfo, "Eine Info 2");
            Trace.WriteLineIf(ts2.TraceVerbose, "Eine audführliche Meldung 2");


            // Auswerten der PreProzKonstante
#if(MeinePreProzKonstante)

            // Wenn die PreProzKonstante definiert ist, dann
            // wird dieser Block mitkompiliert

            Trace.WriteLine("MeinePreProzKonstante ist definiert");
#else
            Trace.WriteLine("MeinePreProzKonstante ist nicht definiert");

#endif

            // Arbeiten mit vordefinierten Preprozessorkonstanten
            // Die Debug- Konstante kann im Projekt in der Projektkonfiguration 
            // von Visual Studio eingestellt werden
#if(DEBUG)
            Debug.WriteLine("Bin im Debug- Zweig");
#elif(TRACE)
            Trace.WriteLine("Bin im nicht Debug- Zweig");
#endif

            // Die Aufrufe von Funktionen der Debug- Klasse werden nur dann kompiliert,
            // wenn in der Projektkonfiguration die Debug- Preprozessorkonstante gesetzt ist
            Debug.WriteLine("Diese Ausgabe erfolgt nur, wenn die PreProzKonstante DEBUG gesetzt ist");
            Trace.WriteLine("Diese Ausgabe erfolgt nur, wenn die PreProzKonstante TRACE gesetzt ist");

            Trace.WriteLine(mko.TraceHlp.FormatErrMsg("Basic.Test", "_01_00_PreProzTest1", "Eine Fehlermeldung"));
            Debug.WriteLine(mko.TraceHlp.FormatWarningMsg("Basic.Test", "_01_00_PreProzTest1", "Eine Warnung"));
            Debug.WriteLine(mko.TraceHlp.FormatInfoMsg("Basic.Test", "_01_00_PreProzTest1", "Eine Info"));

        }
    }
}
