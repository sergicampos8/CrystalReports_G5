using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace CrystalReports_G5
{
    public partial class F1StatsXML : Form
    {
        //Declaración de diccionarios, Listas y booleano para control de errores
        List<string> searchList = new List<string>();
        List<string> lines = new List<string>();
        public static Dictionary<string, string> PointsRecord = new Dictionary<string, string>();
        public static Dictionary<string, string> Drivers = new Dictionary<string, string>();
        public static Dictionary<string, string> RTeams = new Dictionary<string, string>();
        public static Dictionary<string, string> GPs = new Dictionary<string, string>();
        bool loaded = false;

        public F1StatsXML()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Event handler para el evento "Click" del botón "LoadButton"
        private void LoadButton_Click(object sender, EventArgs e)
        {
            // Se limpian los diccionarios y listas existentes
            PointsRecord.Clear();
            Drivers.Clear();
            RTeams.Clear();
            GPs.Clear();

            // Se obtiene la ruta del archivo especificada en el campo de texto "FileBox"
            string filePath = FileBox.Text.Trim();

            // Se leen las líneas del archivo y se almacenan en la lista "lines"
            lines = LoadData.ReadFile(filePath);

            // Se llena la información en los diccionarios "Drivers", "RTeams" y "GPs"
            LoadData.FillDataInDict(lines, Drivers, RTeams, GPs);

            // Se actualiza el indicador "loaded" según la cantidad de líneas leídas
            loaded = lines.Count > 0;
        }

        // Event handler para el evento "Click" del botón "ButtonBrowse"
        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            // Se invoca la función "BrowseFile" de la clase "LoadData" para seleccionar un archivo y se actualiza el campo de texto "FileBox" con la ruta del archivo seleccionado
            string rutaArchivo = LoadData.BrowseFile();
            FileBox.Text = rutaArchivo;
        }

        private void FileBox_TextChanged(object sender, EventArgs e)
        {

        }

        // Event handler para el evento "SelectedIndexChanged" del ListBox "TypeEmployeeMultiBox"
        private void TypeEmployeeMultiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se deselecciona cualquier elemento seleccionado en el ListBox "NameMultiBox"
            NameMultiBox.SelectedIndex = -1;

            // Se obtiene la selección actual del ListBox "TypeEmployeeMultiBox"
            string seleccion = (string)TypeEmployeeMultiBox.SelectedItem;

            // Se actualiza el contenido del ListBox "NameMultiBox" según la selección realizada en "TypeEmployeeMultiBox"
            ShowData.UpdateNameMultiBox(seleccion, NameMultiBox, GPs, Drivers, RTeams);
        }

        private void NameMultiBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LabelFile_Click(object sender, EventArgs e)
        {

        }

        // Event handler para el evento "Click" del botón "SaveAsCSVbutton"
        private void SaveAsCSVbutton_Click(object sender, EventArgs e)
        {
            // Si hay datos cargados, se invoca la función "GuardarInformacionCSV" de la clase "ExportCSV" para guardar la información en formato CSV
            if (loaded)
            {
                ExportCSV.GuardarInformacionCSV(lines);
            }
        }

        // Event handler para el evento "Click" del botón "searchbutton"
        private void searchbutton_Click(object sender, EventArgs e)
        {
            // Si hay datos cargados y se han seleccionado valores en los ListBox "TypeEmployeeMultiBox" y "NameMultiBox"
            if (loaded)
            {
                string selection1 = (string)TypeEmployeeMultiBox.SelectedItem;
                string selection2 = (string)NameMultiBox.SelectedItem;

                if (selection1 != null && selection2 != null)
                {
                    // Se limpia la lista de búsqueda y se obtienen los resultados de búsqueda según las selecciones realizadas
                    searchList.Clear();
                    searchList = ShowData.SelectView(selection1, selection2);

                    // Se escriben los resultados de búsqueda en el cuadro de texto "QueryTextBox"
                    ShowData.WriteTextBox(searchList, QueryTextBox);
                }
            }
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void F1StatsXML_Load(object sender, EventArgs e)
        {

        }

        // Event handler para el evento "Click" del botón "appendbutton"
        private void appendbutton_Click(object sender, EventArgs e)
        {
            // Si hay datos cargados y se han seleccionado valores en los ListBox "TypeEmployeeMultiBox" y "NameMultiBox"
            if (loaded)
            {
                string selection1 = (string)TypeEmployeeMultiBox.SelectedItem;
                string selection2 = (string)NameMultiBox.SelectedItem;

                if (selection1 != null && selection2 != null)
                {
                    // Se obtienen los resultados de búsqueda según las selecciones realizadas
                    searchList = ShowData.SelectView(selection1, selection2);

                    // Se escriben los resultados de búsqueda en el cuadro de texto "QueryTextBox"
                    ShowData.WriteTextBox(searchList, QueryTextBox);
                }
            }
        }
    }
}

