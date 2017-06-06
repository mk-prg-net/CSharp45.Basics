using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._06_Patterns.Decorators.Bank
{
    public class Protokolldrucker
    {
        public void  drucke(KontoMitProtokollDeko konto){
            foreach(var eintrag in konto.Protokoll){
                Debug.WriteLine(eintrag);
            }
        }
    }
}
