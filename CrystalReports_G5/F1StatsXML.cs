using System;
using System.Collections;
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
        static FuncionesAuxiliares funcionesAuxiliares = new FuncionesAuxiliares();
        static ArrayList ArrayDrivers = new ArrayList();
        static ArrayList ArrayRTeams = new ArrayList();
        static ArrayList ArrayGP = new ArrayList();
        public F1StatsXML()
        {
            InitializeComponent();


   
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            ArrayList lines = new ArrayList();
            string filePath = FileBox.Text.Trim();
            lines = funcionesAuxiliares.ReadFile(filePath);
            funcionesAuxiliares.FillArraylists(lines);
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            string rutaArchivo = funcionesAuxiliares.BrowseFile();
            FileBox.Text = rutaArchivo;

        }

        private void FileBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TypeEmployeeMultiBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
