using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._06_Patterns.Decorators.UserMgmt
{
    public class Admin : User
    {
        public virtual void CreateNewUser(string UserName)
        {
            Debug.WriteLine("Neuer Benutzer " + UserName + " wurde von " + Name + " angelegt.");
        }

        public virtual void DeleteNewUser(string UserName)
        {
            Debug.WriteLine("Der Benutzer " + UserName + " wurde von " + Name + " gelöscht.");
        }
    }
}
