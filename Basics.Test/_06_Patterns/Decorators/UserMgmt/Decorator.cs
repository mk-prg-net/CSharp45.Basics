using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using Basics._06_Patterns.Decorators.UserMgmt;


namespace Basics.Test
{
    [TestClass]
    public class Decorator
    {
        List<mko.Log.ILogInfo> logs = new List<mko.Log.ILogInfo>();

        [TestInitialize]
        public void Init()
        {
            logs.Clear();
        }

        [TestMethod]
        public void UserDecoTest()
        {
            var Anton = new User();
            Anton.Name = "Anton";

            // Erweiterungmethode (C# dekoriert Klassen !)
            // Kompiler baut folgende Zeile um in:
            // UserExt.Log(Anton, "frisch angelegt");
            // Achtung: der Namensraum, in dem UserExt sich befindet, muss mittels using
            // global eingebunden werden.
            Anton.Log("frisch angelegt");

            // Anton als Admin
            var AntonAsAdmin = new AdminDeco(Anton);
            AntonAsAdmin.CreateNewUser("Berta");

            ErzeugeBenutzerkonten(AntonAsAdmin, "Frida", "Leon", "Hugo");

            Anton.Log("Neuen Benutzer Berta angelegt");
            
            // Anton als Author
            var AntonAsAuthor = new AuthorDeco(Anton);
            AntonAsAuthor.CreateNewDoc("X99", "Designpatterns- Leitfaden");

            User[] AlleUser = { AntonAsAdmin, AntonAsAuthor };


            Anton.Log("Neues Dokument X99 angelegt");


            var logServer = new mko.Log.LogServer();
            logServer.EventLog +=logServer_EventLog;


            var AntonAsLoggingAdmin = new AdminLoggerDeco(AntonAsAdmin, logServer);

            var Berta = new User();
            var BertaAdminDeco = new AdminDeco(Berta);
            Berta.Name = "Berta";

            var BertaAdminDecoWithLogger = new AdminLoggerDeco(BertaAdminDeco, logServer);
            ErzeugeBenutzerkonten(BertaAdminDeco, "Sindbad");
            ErzeugeBenutzerkonten(BertaAdminDecoWithLogger, "Laura", "Fridolin");


            AntonAsLoggingAdmin.CreateNewUser("Cäsar");

            AntonAsLoggingAdmin.DeleteNewUser("Cäsar");

            Assert.AreEqual(2, logs.Count, "Es wurden zwei Logeinträge erwartet");           

        }

        void ErzeugeBenutzerkonten(AdminDeco administrator, params string[] newUserNames)
        {

            foreach (var userName in newUserNames)
            {
                administrator.CreateNewUser(userName);
            }

        }

        void logServer_EventLog(string userId, mko.Log.ILogInfo info)
        {
            logs.Add(info);
        }
    }
}
