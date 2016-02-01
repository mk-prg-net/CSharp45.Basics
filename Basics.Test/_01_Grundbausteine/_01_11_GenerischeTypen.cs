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

            // Einsatz eines selbstdefinierten, generischen Typs
            var breiteSchrank = new Ctx.MesswertLaengeDbl(70, Ctx.MesswertLaengeDbl.Units.cm);
            var AktGeschwindigkeitFerrari = new Ctx.Messwert<double, Velocity>(320.0, Velocity.kmh);
            var AktGeschwindigkeitBuggati = Ctx.Messwert.Create<double, Velocity>(300.0, Velocity.mph);
            var AktGeschwindigkeitPorsche = Ctx.Messwert.Create(300.0, Velocity.mph);


        }
    }
}
