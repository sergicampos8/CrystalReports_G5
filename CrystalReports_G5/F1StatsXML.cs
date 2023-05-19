using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalReports_G5.Functions;

namespace CrystalReports_G5
{
    public partial class F1StatsXML : Form
    {
        public F1StatsXML()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {

        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            FuncionesAuxiliares funcionesAuxiliares = new FuncionesAuxiliares();
            string rutaArchivo = funcionesAuxiliares.BrowseFile();
            FileBox.Text = rutaArchivo;

        }

        private void FileBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
