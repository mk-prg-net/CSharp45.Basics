using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsTemplate
{
    public partial class Form1 : Form
    {

        protected mko.Log.LogServer log = new mko.Log.LogServer();
        mko.Log.WinFormListBoxLogHnd logHndLbx;

        public Form1()
        {
            InitializeComponent();
            logHndLbx = new mko.Log.WinFormListBoxLogHnd(lbxLog);
            log.registerLogHnd(logHndLbx);

        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLbxLogClear_Click(object sender, EventArgs e)
        {

        }

        private void btnLbxLogTest_Click(object sender, EventArgs e)
        {
            log.Log(mko.Log.RC.CreateMsg("Eine Testmeldung"));
        }
    }
}
