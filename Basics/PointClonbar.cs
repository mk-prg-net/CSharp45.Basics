using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public class PointClonbar : ICloneable
    {
        public PointClonbar()
        {
            X = 0;
            Y = 0;
        }


        public PointClonbar(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }


        public double X;
        public double Y;

        public object Clone()
        {
            // Ein neues Objekt
            return new PointClonbar(X, Y);
        }
    }
}
