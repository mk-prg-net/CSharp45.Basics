using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Typalias
using Ctx = Basics._01_Grundbausteine._01_10_GenerischeTypen;

namespace Basics.Test._01_Grundbausteine
{
    [TestClass]
    public class _01_11_GenerischeTypen
    {
        enum Velocity { kmh, meter_per_sec, mph}

        [TestMethod]
        public void TupelTests()
        {
            // Tupel zur Abbildung von Austattungsvarianten
            var variante1 = new Tuple<Ctx.Farben, Ctx.Varianten>(Ctx.Farben.blau, Ctx.Varianten.hippster);
            var variante2 = new Tuple<Ctx.Farben, Ctx.Varianten>(Ctx.Farben.grün, Ctx.Varianten.basics);

            // Tupel zur Abbildung von x, y - Koordinaten
            var P1 = new Tuple<double, double>(3.14, 2.72);
            var P2 = new Tuple<double, double>(0, 1);


            // Vereinfachte erstellung mittels Klassenfabrik
            var variante3 = Tuple.Create<Ctx.Farben, Ctx.Varianten>(Ctx.Farben.grün, Ctx.Varianten.lux);

            // Feature vom Compiler: bei generischen Funktionen kann der Compiler die Typparameterliste
            // (<...>) aus den Typen der eingesetzten Werte der Parameterliste bestimmen
            var variante4 = Tuple.Create(Ctx.Farben.cyan, Ctx.Varianten.lux);

            var XYCoordinate = Tuple.Create(2.0, 3.6);

            // Einsatz eines selbstdefinierten, generischen Typs
            var breiteSchrank = new Ctx.MesswertLaengeDbl(70, Ctx.MesswertLaengeDbl.Units.cm);
            var AktGeschwindigkeitFerrari = new Ctx.Messwert<double, Velocity>(320.0, Velocity.kmh);

            var AktVSatellit = Ctx.Messwert<double, Velocity>.Create1(20000, Velocity.kmh);

            var AktGeschwindigkeitBuggati = Ctx.Messwert.Create<double, Velocity>(300.0, Velocity.mph);

            // via Typinferenz füllt der Compiler nun automatisch die Typparameterliste aus
            var AktGeschwindigkeitPorsche = Ctx.Messwert.Create(300.0, Velocity.mph);

            Assert.IsTrue(Ctx.IsGreater<Ctx.Messwert<double, Velocity>, double, Velocity>(AktGeschwindigkeitBuggati, AktGeschwindigkeitPorsche));

            //Ctx.IsGreater<Ctx.Messwert<Ctx.MeinTuple, Velocity>, Ctx.MeinTuple, Velocity>(Ctx.Messwert.Create(Ctx.MeinTuple.Create(1.0, 3.0), Velocity.kmh), Ctx.Messwert.Create(Ctx.MeinTuple.Create(2.0, 2.0), Velocity.kmh));


            var FarbtonObereEcke = Ctx.Messwert.Create(128, Ctx.Farben.cyan);






        }
    }
}
