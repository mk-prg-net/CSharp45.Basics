using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._02_Arrays_Collections_und_Schnittstellen
{
    public class ProcessInterfaces
    {
        public static int TransformID(IBasic obj) {
            return obj.ID * 10;
        }

        public static int TransformID2(IDerived obj)
        {
            return obj.ID * obj.ID2;
        }

    }
}
