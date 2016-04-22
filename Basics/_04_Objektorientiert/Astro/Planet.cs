using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro
{
    public abstract class Planet : Himmelskörper
    {
        /// <summary>
        /// 1:n Beziehung:
        /// Verweis auf den Stern, der umkreist wird von diesem Planeten
        /// </summary>
        public abstract Stern Zentralstern { get; }

        /// <summary>
        /// 1:n Beziehung zwischen Planet und seinen Monden:
        /// Liste der Monde, die diesen Planeten umkreisen
        /// </summary>
        public abstract IEnumerable<Mond> Monde { get; }
    }
}
