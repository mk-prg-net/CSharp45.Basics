using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._06_Patterns.Decorators.UserMgmt
{
    public class AdminLoggerDeco : AdminDeco
    {

        mko.Log.LogServer _logServer;
        

        public AdminLoggerDeco(AdminDeco admin, mko.Log.LogServer logSrv)
            : base(admin)
        {
            _logServer = logSrv;
        }


        public override void CreateNewUser(string UserName)
        {
            _logServer.Log(mko.Log.RC.CreateMsg(Name + " ruft CreateNewUser für " + UserName + " auf"));
            base.CreateNewUser(UserName);
        }

        public override void DeleteNewUser(string UserName)
        {
            _logServer.Log(mko.Log.RC.CreateMsg(Name + " ruft DeleteNewUser für " + UserName + " auf"));
            base.DeleteNewUser(UserName);
        }

    }
}
