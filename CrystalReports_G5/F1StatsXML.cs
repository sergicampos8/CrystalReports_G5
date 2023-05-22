using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CrystalReports_G5
{
    public partial class F1StatsXML : Form
    {
        List<string> ListDrivers = new List<string>();
        List<string> ListRTeams = new List<string>();
        List<string> ListGP = new List<string>();
        List<string> lines = new List<string>();
        public static Dictionary<string, string> PointsRecord = new Dictionary<string,string>();


        public F1StatsXML()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            string filePath = FileBox.Text.Trim();
            lines = LoadData.ReadFile(filePath);
            LoadData.FillDataInLists(lines, ListDrivers, ListRTeams, ListGP);
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            string rutaArchivo = LoadData.BrowseFile();
            FileBox.Text = rutaArchivo;

        }

        private void FileBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TypeEmployeeMultiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = (string) TypeEmployeeMultiBox.SelectedItem;

            NameMultiBox.Items.Clear();  // Limpia los elementos existentes en el segundo ListBox
            if(seleccion == "Grand Prix")
            {
                NameMultiBox.Items.AddRange(ListGP.ToArray());
            }
            else if (seleccion == "Pilot")
            {
                NameMultiBox.Items.AddRange(ListDrivers.ToArray());
            }
            else
            {
                NameMultiBox.Items.AddRange(ListRTeams.ToArray());
            }
        }

        private void NameMultiBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LabelFile_Click(object sender, EventArgs e)
        {

        }

        private void SaveAsCSVbutton_Click(object sender, EventArgs e)
        {
            ExportCSV.GuardarInformacionCSV(lines);
        }
    }


}


