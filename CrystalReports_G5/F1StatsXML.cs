﻿using System;
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
        List<string> appendlist = new List<string>();

        List<string> lines = new List<string>();
        public static Dictionary<string, string> PointsRecord = new Dictionary<string, string>();
        public static Dictionary<string, string> Drivers = new Dictionary<string, string>();
        public static Dictionary<string, string> RTeams = new Dictionary<string, string>();
        public static Dictionary<string, string> GPs = new Dictionary<string, string>();
        bool loaded = false;
        string SaveFilePath;
         
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
            //Seleccionamos el Path indicado en la FileBox
            string filePath = FileBox.Text.Trim();

            //Cargamos el archivo y lo guardamos en Diccionarios y devolvemos una lista con el XML completo
            lines = LoadData.Load(filePath, PointsRecord, Drivers, RTeams, GPs, lines);
            //Verificamos si el archivo ha sido cargado correctamente.
            loaded = lines.Count() >= 1;            
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
            ExportCSV.GuardarInformacionCSV(lines, loaded);
            
        }

        // Event handler para el evento "Click" del botón "searchbutton"
        private void searchbutton_Click(object sender, EventArgs e)
        {
            //Verificamos si se ha cargado un archivo   
            if (loaded)
            {
                //Guardamos las selecciones en variables
                string selection1 = (string)TypeEmployeeMultiBox.SelectedItem;
                string selection2 = (string)NameMultiBox.SelectedItem;

                //verificamos si se han hecho selecciones en los 2 MultiBox
                if (selection1 != null && selection2 != null)
                {
                    //Seleccionamos lo que debemos sacar por pantalla en función de las selecciones
                    searchList = ShowData.SelectView(selection1, selection2, searchList);

                    //Mostramos en la textBox el resultado
                    ShowData.WriteTextBox(searchList, QueryTextBox);
                    //Lo guadamos en el archivo indicado
                    SaveFilePath = WriteSearch.SaveListInFile(searchList, SaveFilePath);
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
            //Verificamos si se ha cargado un archivo   
            if (loaded)
            {
                //Guardamos las selecciones en variables
                string selection1 = (string)TypeEmployeeMultiBox.SelectedItem;
                string selection2 = (string)NameMultiBox.SelectedItem;

                //verificamos si se han hecho selecciones en los 2 MultiBox
                if (selection1 != null && selection2 != null)
                {
                    // Se obtienen los resultados de búsqueda según las selecciones realizadas
                    appendlist = ShowData.SelectView(selection1, selection2, appendlist);
                    searchList = WriteSearch.JoinLists(searchList, appendlist);

                    // Se escriben los resultados de búsqueda en el cuadro de texto "QueryTextBox"
                    // Se guardan en el archivo indicado
                    ShowData.WriteTextBox(searchList, QueryTextBox);
                    SaveFilePath = WriteSearch.SaveListInFile(searchList, SaveFilePath);

                }
            }
        }

        private void statisticsbutton_Click(object sender, EventArgs e)
        {
            //Verificamos si se ha cargado un archivo   
            if (loaded)
            {
                // Limpiamos la lista
                searchList.Clear();
                // Le añadimos las Estadisticas
                searchList = ShowData.ViewStatistics();

                // La imprimimos por la TextBox y la guardamos en el archivo indicado
                ShowData.WriteTextBox(searchList, QueryTextBox);
                SaveFilePath = WriteSearch.SaveListInFile(searchList, SaveFilePath);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

