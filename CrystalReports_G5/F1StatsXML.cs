using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace CrystalReports_G5
{
    public partial class F1StatsXML : Form
    {
        List<string> searchList = new List<string>();
        List<string> lines = new List<string>();
        public static Dictionary<string, string> PointsRecord = new Dictionary<string, string>();
        public static Dictionary<string, string> Drivers = new Dictionary<string, string>();
        public static Dictionary<string, string> RTeams = new Dictionary<string, string>();
        public static Dictionary<string, string> GPs = new Dictionary<string, string>();
        bool loaded = false;
        bool statistics = false;
         
        public F1StatsXML()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            PointsRecord.Clear();
            Drivers.Clear();
            RTeams.Clear();
            GPs.Clear();

            string filePath = FileBox.Text.Trim();
            lines = LoadData.ReadFile(filePath);
            LoadData.FillDataInDict(lines, Drivers, RTeams, GPs);
            loaded = lines.Count > 0;
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
            NameMultiBox.SelectedIndex = -1;
            string seleccion = (string) TypeEmployeeMultiBox.SelectedItem;
            ShowData.UpdateNameMultiBox(seleccion, NameMultiBox, GPs, Drivers, RTeams);
        }

        private void NameMultiBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LabelFile_Click(object sender, EventArgs e)
        {

        }

        private void SaveAsCSVbutton_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                ExportCSV.GuardarInformacionCSV(lines);
            }
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            
            if (loaded)
            {
                string selection1 = (string)TypeEmployeeMultiBox.SelectedItem;
                string selection2 = (string)NameMultiBox.SelectedItem;

                if (selection1 != null && selection2 != null)
                {
                    searchList.Clear();
                    QueryTextBox.Text = "";
                    searchList = ShowData.SelectView(selection1, selection2);

                    ShowData.WriteTextBox(searchList, QueryTextBox);
                    statistics = false;
                }
            }
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void F1StatsXML_Load(object sender, EventArgs e)
        {

        }

        private void appendbutton_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                
                if (!statistics)
                {
                    QueryTextBox.Text = "";
                }

                string selection1 = (string)TypeEmployeeMultiBox.SelectedItem;
                string selection2 = (string)NameMultiBox.SelectedItem;

                if (selection1 != null && selection2 != null)
                {
                    searchList = ShowData.SelectView(selection1, selection2);
                    ShowData.WriteTextBox(searchList, QueryTextBox);
                    
                }
            }
        }

        private void statisticsbutton_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                searchList.Clear();
                QueryTextBox.Text = "";
                searchList = ShowData.ViewStatistics();
                ShowData.WriteTextBox(searchList, QueryTextBox);
                statistics = true;
            }                      
        }
    }
}


