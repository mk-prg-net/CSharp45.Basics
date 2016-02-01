using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics
{
    public class PointVergleicher : IComparer<PointWithProperties> 
    {
        int IComparer<PointWithProperties>.Compare(PointWithProperties a, PointWithProperties b)
        {
            // Vergleich erfolgt über den euklidischen Abstand der Punkte vom Ursprung
            double dEuklid_a = Math.Sqrt(a.X * a.X + a.Y * a.Y);
            double dEuklid_b = Math.Sqrt(b.X * b.X + b.Y * b.Y);

            if (dEuklid_a < dEuklid_b)
                return -1;
            else if (dEuklid_a > dEuklid_b)
                return 1;
            else
                return 0;
        }

    }
}
