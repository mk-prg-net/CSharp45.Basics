//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 23.3.2016
//
//  Projekt.......: basics
//  Name..........: AuthorDeco.cs
//  Aufgabe/Fkt...: Dekoration eines Users mit den Fähigkeiten eines Authors
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
    public class AuthorDeco : User
    {
        User _user;

        public AuthorDeco(User user)
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


        public virtual void CreateNewDoc(string DocId, string title)
        {
            Debug.WriteLine("Neues Dokument " + title + " mit der ID " + DocId + " wurde von " + Name + " erstellt ");
        }

        public virtual void DeleteDoc(string DocId)
        {
            Debug.WriteLine("Dokument mit der ID " + DocId + " wurde von " + Name + " gelöscht");
        }



    }
}
