using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._02_Arrays_Collections_und_Schnittstellen
{
    // IDerived baut auf den Forderungen der Schnittstelle IBasic auf
    // und erweitert diese :<=> Schnittstellenvererbung
    public interface IDerived : IBasic
    {
        int ID2 { get; }
    }
}
