using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public partial class PrimList : IList<long>
    {
        // Felder, die den BEreich definieren, aus dem die zu liefernden Primzahlen
        // stammen
        long _von;
        long _bis;

        List<long> _PN;

        // Konstruktor
        public PrimList(long von, long bis)
        {
            _von = von;
            _bis = bis;

            //_PN = new List<long>((int)Math.Min(_bis - _von, 10000) / 2);
            _PN = mko.Algo.NumberTheory.PrimeFactors.scan(von, bis).ToList();
        }


        public int IndexOf(long item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, long item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Indexer- Eigenschaft, der beim Abruf ein Indize übergeben wird
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public long this[int index]
        {
            get
            {
                if (index < 0 || index >= _PN.Count)
                    throw new IndexOutOfRangeException("PrimList hat nur " + _PN.Count + " Elemente");
                return _PN[index];
            }
            set
            {
                if (index < 0 || index >= _PN.Count)
                    throw new IndexOutOfRangeException("PrimList hat nur " + _PN.Count + " Elemente");

                _PN[index] = value;
            }
        }

        public void Add(long item)
        {
            _PN.Add(item);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(long item)
        {
            return _PN.Contains(item);
        }

        public void CopyTo(long[] array, int arrayIndex)
        {
            _PN.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _PN.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(long item)
        {
            return _PN.Remove(item);
        }

        public IEnumerator<long> GetEnumerator()
        {
            // Die ausführliche Form verwendet einen selbstdefinierten Enumerator ...
            return new PrimEnumerator(_PN.GetEnumerator());

            // ... aber man kann auch einen bereits existierenden verwenden.
            //return _PN.GetEnumerator();    
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
