using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalReports_G5
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports frm = new Reports();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {

        }
    }
}
