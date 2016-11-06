using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Objektorientiert.Astro
{
    public interface IGalaxie : IHimmelskörper
    {
        IEnumerable<Stern> Sterne { get; }
    }
}
