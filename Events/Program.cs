using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static mko.Log.LogServer log = new mko.Log.LogServer();

        static void Melder1(string userid, mko.Log.ILogInfo info)
        {
            Debug.WriteLine("info1: " + info.LogType + ": " + info.Message);
        }

        static void Melder2(string userid, mko.Log.ILogInfo info)
        {
            Debug.WriteLine("info2: " + info.LogType + ": " + info.Message);
        }


        static void Main(string[] args)
        {

            log.EventLog += new mko.Log.LogServer.DGLogILogInfo(Melder1);

            log.Log(mko.Log.RC.CreateStatus("Prog gestartet"));
            log.Log(mko.Log.RC.CreateError("ein Fehler"));

            //log.EventLog("ich", mko.Log.RC.CreateError("Hallo"));

            log.EventLog += new mko.Log.LogServer.DGLogILogInfo(Melder2);


            log.Log(mko.Log.RC.CreateStatus("Prog läuft"));

            log.Log(mko.Log.RC.CreateError("ein Fehler2"));

            log.EventLog -= new mko.Log.LogServer.DGLogILogInfo(Melder2);

            log.Log(mko.Log.RC.CreateStatus("Prog läuft"));



        }
    }
}
