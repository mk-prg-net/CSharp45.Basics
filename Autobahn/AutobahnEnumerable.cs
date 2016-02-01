using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AB = Basics._04_Objektorientiert.Autobahn;

namespace Autobahn
{
    public class AutobahnEnumerable : IEnumerable<AB.Auto>
    {

        AB.Auto[] AlleFhzg = {
                                 new AB.Benzinauto("Ferrari", "F8"),
                                 new AB.Dieselauto("VW", "Passat"),
                             };


        public class AutobahnEnumerator : IEnumerator<AB.Auto>
        {
            private AB.Auto[] _AlleFhzg;
            private int index = -1;


            public AutobahnEnumerator(AB.Auto[] AlleFhzg)
            {
                _AlleFhzg = AlleFhzg;
            }


            public AB.Auto Current
            {
                get { return _AlleFhzg[index]; }
            }

            public void Dispose()
            {
                Debug.WriteLine("Enumerator wird beendet");
            }

            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (index + 1 < _AlleFhzg.Length)
                {
                    index++;
                    return true;
                }
                else
                    return false;
            }

            public void Reset()
            {
                index = -1;
            }
        }

        public IEnumerator<AB.Auto> GetEnumerator()
        {
            return new AutobahnEnumerator(AlleFhzg);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
