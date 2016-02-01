using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public partial class PrimList
    {
        // Enumerator- Klasse
        public class PrimEnumerator : IEnumerator<long>
        {

            IEnumerator<long> _PN;
            

            // Konstruktor
            public PrimEnumerator(IEnumerator<long> PN)
            {
                _PN = PN;
            }

            public long Current
            {
                get { return _PN.Current; }
            }

            public void Dispose()
            {
                // Hier könnte man externe Resourcen freigeben
            }

            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                return _PN.MoveNext();
            }

            public void Reset()
            {                
                _PN.Reset();
            }
        }

    }
}
