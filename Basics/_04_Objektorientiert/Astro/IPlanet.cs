using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro
{
    public interface IPlanet : IHimmelskörper
    {
        /// <summary>
        /// 1:n Beziehung:
        /// Verweis auf den Stern, der umkreist wird von diesem Planeten
        /// </summary>
        Stern Zentralstern { get; }

        /// <summary>
        /// Masse des Planeten, gemessen in Erdmassen
        /// </summary>
        double Masse_in_Erdmassen { get; }

    }
}
