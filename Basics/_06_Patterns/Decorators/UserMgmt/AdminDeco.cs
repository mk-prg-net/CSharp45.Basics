//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 23.3.2016
//
//  Projekt.......: Basics
//  Name..........: AdminDeco.cs
//  Aufgabe/Fkt...: Dekoration eines Users mit den Fähigkeiten eines Administrators.
//                  
//
//
//
//
//<unit_environment>
//------------------------------------------------------------------
//  Zielmaschine..: PC 
//  Betriebssystem: Windows 7 mit .NET 4.5
//  Werkzeuge.....: Visual Studio 2013
//  Autor.........: Martin Korneffel (mko)
//  Version 1.0...: 
//
// </unit_environment>
//
//<unit_history>
//------------------------------------------------------------------
//
//  Version.......: 1.1
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 
//  Änderungen....: 
//
//</unit_history>
//</unit_header>        
        
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._06_Patterns.Decorators.UserMgmt
{
    public class AdminDeco : User, IAdminDeco
    {
        User _user;

        public AdminDeco(User user)
        {
            _user = user;
        }

        public override string Name
        {
            get
            {
                return _user.Name;
            }
            set
            {
                _user.Name = value;
            }
        }

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
