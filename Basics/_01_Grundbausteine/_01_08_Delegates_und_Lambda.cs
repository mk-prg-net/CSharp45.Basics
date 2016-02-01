using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._01_Grundbausteine
{
    public class _01_08_Delegates_und_Lambda
    {
        /// <summary>
        /// Addition von zwei Zahlen
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Multiplikation von zwei Zahlen
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Mul(double a, double b) { return a * b; }
        // (double a, double b) => { return a * b; } zum Mul passender Lambdaausdruck        

        /// <summary>
        /// Ein Delegate von System.Delegate ableiten, der zu den Mul und Add- MEthoden passt
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public delegate double DGBinOp(double a, double b);


        // 
        /// <summary>
        /// Delegates einsetzen, um Rückrufmethoden an Unterprogramme zu übergeben.
        /// Callback Designpattern (op ist der Callback).
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="op"></param>
        /// <returns></returns>
        public static double Calculator(double a, double b, Func<double, double, double> op)
        {
            return op.Invoke(a, b);
        }


        /// <summary>
        /// Verallgemeinerte Akkumulation.
        /// Operationen der Art r = binOp(oN, binOp(oN-1, .... binOp(o0, Init))...)) werden berechnet
        /// Wenn binOp = (a, b) => a+b, dann ist Akku die Summenbildung über alle Operanden.
        /// Wenn binOp = (a, b) => a*b, dann ist Akku die Produktbildung über alle Operanden.
        /// </summary>
        /// <param name="InitVal">Startwert</param>
        /// <param name="binOp">binäre Operation, mit der alle Operanden aufakkumuliert werden</param>
        /// <param name="Operands">Liste der Operanden</param>
        /// <returns></returns>
        public static double Akku(double InitVal, Func<double, double, double> binOp, params double[] Operands) {
            double res = InitVal;
            foreach(double operand in Operands) {
                res = binOp(res, operand);
            }
            return res;
        }




    }
}
