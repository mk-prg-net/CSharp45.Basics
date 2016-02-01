using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._02_Arrays_Collections_und_Schnittstellen
{
    public class ImplementsIDerived : IDerived
    {
        int _ID = 1;

        public int ID
        {
            get { return _ID; }
        }

        int _ID2 = 99;
        public int ID2
        {
            get { throw new NotImplementedException(); }
        }
    }
}
