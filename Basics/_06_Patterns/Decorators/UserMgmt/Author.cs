using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._06_Patterns.Decorators.UserMgmt
{
    public class Author : User
    {
        public virtual void CreateNewDoc(string DocId, string title)
        {
            Debug.WriteLine("Neues Dokument " + title + " mit der ID " + DocId + " erstellt ");
        }

        public virtual void DeleteDoc(string DocId)
        {
            Debug.WriteLine("Dokument mit der ID " + DocId + " gelöscht");
        }
    }
}
