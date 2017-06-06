using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._06_Patterns.Decorators.UserMgmt
{
    public class User
    {
        /// <summary>
        /// Name des Benutzers
        /// </summary>
        public virtual string Name { get; set; }

        public override string ToString()
        {
            return "User: " + Name;
        }

    }
}
