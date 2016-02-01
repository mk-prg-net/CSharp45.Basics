using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics
{
    /// <summary>
    /// Aus ArrayGenerisch wird jetzt der generische Typ ArrayGenerisch2, indem 
    /// der Datentyp für das interne Array zu einem Typparameter gemacht wird.
    /// </summary>
    public class ArrayGenerisch<T>
    {
        T[] _array;

        public ArrayGenerisch(int AnzElemente)
        {
            _array = new T[AnzElemente];
        }

        /// <summary>
        /// Indexer: Eine Eigenschaft, die über den INdexzugriffsoperator
        /// [ix] angesprochen wird
        /// </summary>
        /// <param name="ix"></param>
        /// <returns></returns>
        public T this[int ix] {

            get
            {
                return _array[ix];
            }

            set
            {
                _array[ix] = value;
            }
        }

        
        public int Length
        {
            get
            {
                return _array.Length;
            }
        }

    }
}
