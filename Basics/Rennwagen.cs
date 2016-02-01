using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics
{
    public class Rennwagen : Basics._04_Objektorientiert.Autobahn.Benzinauto
    {
        public Rennwagen() : base("Auto Union", "1") { }
        public void Überholen(_04_Objektorientiert.Autobahn.Auto anderenRennwagen)
        {
            throw new System.NotImplementedException();
        }
    }
}
