using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._06_Patterns.Decorators.UserMgmt
{
    public static class UserExt
    {
        public static System.Collections.ObjectModel.ObservableCollection<string> Logfile = new System.Collections.ObjectModel.ObservableCollection<string>();

        public static void Log(this User user, string LogMessage)
        {
            UserExt.Logfile.Add(string.Format("{0,8:s}: ({1}) {2}", DateTime.Now, user, LogMessage));       
        }

    }
}
