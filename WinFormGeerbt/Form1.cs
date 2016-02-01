using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormGeerbt
{
    public partial class Form1 : WindowsTemplate.Form1
    {

        Datensatz[] Mitarbeiter = {
                                      new Datensatz(){ Id = 1, Alter = 99, Name= "Methusalem"},
                                      new Datensatz(){ Id = 2, Alter = 19, Name= "Blondi"},
                                      new Datensatz(){ Id = 3, Alter = 39, Name= "Chef"},
                                  };


        List<Datensatz> Mitarbeiterliste = new List<Datensatz>();

        public Form1()
        {
            InitializeComponent();

            Mitarbeiterliste.AddRange(Mitarbeiter);
            DatensatzBindingSource.DataSource = Mitarbeiterliste;
        }

        private void btnTesteEingaben_Click(object sender, EventArgs e)
        {
            foreach (var m in Mitarbeiterliste)
            {
                log.Log(mko.Log.RC.CreateMsg(m.Id + ", " + m.Name + ", " + m.Alter));
            }
        }

        //private void DatensatzBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        //{
        //    try{
        //        if (e.NewObject != null)
        //        {
        //            var ds = (Datensatz)e.NewObject;
        //            ds.Id = -1;
        //            ds.Alter = 0;
        //            Mitarbeiterliste.Add(ds);
        //        }

        //    }catch(Exception ex) {
        //        log.Log(mko.Log.RC.CreateError("In Bindingsource.AddingNew: " +  mko.ExceptionHelper.FlattenExceptionMessages(ex)));
        //    }
        //}

        //private void DatensatzBindingSource_CurrentItemChanged(object sender, EventArgs e)
        //{
        //    var bs = (BindingSource)sender;
            
        //}
    }
}
