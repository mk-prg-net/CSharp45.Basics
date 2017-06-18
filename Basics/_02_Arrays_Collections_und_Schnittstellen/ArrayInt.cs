using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics
{
    public class ArrayInt : IEnumerable<int>
    {
        int[] _array;

        public ArrayInt(int AnzElemente)
        {
            _array = new int[AnzElemente];
        }

        /// <summary>
        /// Indexer: Eine Eigenschaft, die über den INdexzugriffsoperator
        /// [ix] angesprochen wird
        /// </summary>
        /// <param name="ix"></param>
        /// <returns></returns>
        public int this[int ix] {

            get
            {
                return _array[ix];
            }

            // value ist versteckter Parameter des Setters
            // void set(int value) {...}
            set
            {
                _array[ix] = value;
            }
        }

        // Eine gewöhnliche, nur lesbare Eigenschaft
        public int Length
        {
            get
            {
                return _array.Length;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new Enumerator(_array);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class Enumerator : IEnumerator<int>
        {
            // Konstuktor
            public Enumerator(int[] array)
            {
                _array = array;
            }

            int ix = -1;
            int[] _array;

            public int Current
            {
                get { return _array[ix]; }
            }

            public void Dispose()
            {
                //throw new NotImplementedException();
            }

            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                ix++;
                return ix < _array.Length;
            }

            public void Reset()
            {
                ix = -1;
            }
        }
    }
}
