using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormMitLogServer
{
    public partial class Form1 : WindowsTemplate.Form1
    {

        void Melder(string user, mko.Log.ILogInfo inf)
        {
            MessageBox.Show(inf.Message);
        }

        public Form1()
        {
            InitializeComponent();

            log.EventLog += (user, info) => tbxMeldung.Text = info.Message; 
            //log.EventLog += new mko.Log.LogServer.DGLogILogInfo(Melder);

            btnLbxLogTest.Click += btnLbxLogTest_Click;
        }

        void btnLbxLogTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hallo");
        }

        private void btnFireEvents_Click(object sender, EventArgs e)
        {
            log.Log(mko.Log.RC.CreateStatus("Hallo, es ist bereits " + DateTime.Now.ToLongTimeString()));
        }

        private void rbtMsgBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMsgBox.Checked)
            {
                log.EventLog += new mko.Log.LogServer.DGLogILogInfo(Melder);

            }
            else
            {
                log.EventLog -= new mko.Log.LogServer.DGLogILogInfo(Melder);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // char verarbeiten Unicode- Zeichen
            char c1, c2, c3, c4, c5, c6, c7;

            c1 = '\u041B';
            c2 = '\u042E';
            c3 = '\x0411';
            c4 = '\x041E';
            c5 = '\x0412';
            c6 = '\x042C';

            string str = "";

            str += c1.ToString() + c2.ToString() + c3.ToString() + c4.ToString() + c5.ToString() + c6.ToString();

            lblDasWichtigste.Text = str;


        }
    }
}
