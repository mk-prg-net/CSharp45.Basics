using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Basics.Test._01_Grundbausteine
{
    [TestClass]
    public class _01_09_DateTimeTests
    {
        [TestMethod]
        public void _01_09_DateTime_Lebenszeit()
        {
            var gbt = new DateTime(1968, 6, 7);
            var gbtUtc = new DateTimeOffset(gbt, new TimeSpan(1, 0, 0));
            var jetzt = DateTime.Now;
            var jetztUtc = DateTime.UtcNow;

            // Wieviel Tage Lebe isch schon
            long ticksVerstricheneLebenszeit = jetzt.Ticks - gbt.Ticks;
            var zeitspanne = new TimeSpan(ticksVerstricheneLebenszeit);
            double tageVerstricheneLebenszeit = zeitspanne.TotalDays;

            Debug.WriteLine("Ich lebe schon " + 
                tageVerstricheneLebenszeit.ToString("N2"));

            var Faelligkeitsdatum = jetzt.AddMonths(1);
            Debug.WriteLine("Die Rechnung wird fällig am: " + 
                Faelligkeitsdatum.ToShortDateString() + " " + 
                Faelligkeitsdatum.ToShortTimeString());
        }
    }
}
