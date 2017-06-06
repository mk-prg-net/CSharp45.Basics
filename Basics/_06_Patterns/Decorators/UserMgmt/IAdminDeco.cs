using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._06_Patterns.Decorators.UserMgmt
{
    public interface IAdminDeco
    {
        string Name
        {
            get;
            set;
        }

        void CreateNewUser(string UserName);

        void DeleteNewUser(string UserName);

    }
}
