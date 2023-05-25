using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CrystalReports_G5
{
    class LoadData
    {
        public static string gp_name, pilot_name, score, rteam_name,id;

        public static List<string> Load(string filepath, Dictionary<string, string> PointsRecord, Dictionary<string, string> drivers, Dictionary<string, string> rteams, Dictionary<string, string> GPs, List<string> lines)
        {
            PointsRecord.Clear();
            drivers.Clear();
            rteams.Clear();
            GPs.Clear();

            bool loaded = false;

            if(File.Exists(filepath))
            {
                try
                {
                    lines = ReadFile(filepath);
                    FillDataInDict(lines, drivers, rteams, GPs);
                    MessageBox.Show("Archivo " + filepath + " leído correctamente");
                    loaded = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer el archivo:\n" + ex.Message, "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show("El Archivo seleccionado no existe\n", "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lines;

        }

        public static void FillDataInDict(List<string> lines, Dictionary<string, string> drivers, Dictionary<string, string> rteams, Dictionary<string, string> GPs)
        {
            foreach (string linea in lines)
            {
                string elementname = GetElementName(linea);
                if (Checkelement(elementname))
                {
                    string data = GetElementData(linea);
                    DataInDict(data, elementname, drivers, rteams, GPs);
                }
            }
        }

        public static string BrowseFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Seleccionar archivo",
                Filter = "Archivos XML (*.xml)|*.xml"
            };

            return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : "";
        }

        public static List<string> ReadFile(string filePath)
        {
            List<string> ListXML = new List<string>();

            ListXML = File.ReadAllLines(filePath).ToList();
            
            return ListXML;
        }


        public static string GetElementName(string xml)
        {
            int principio = xml.IndexOf('<');
            int final = xml.IndexOf('>', principio);

            if (principio == -1 || final == -1)
            {
                // XML inválido
                return null;
            }

            string element = xml.Substring(principio + 1, final - principio - 1);
            int espacio = element.IndexOf(' ');

            if (espacio != -1)
            {
                element = element.Substring(0, espacio);
            }

            return element;
        }

        public static string GetElementData(string xmlLine)
        {
            int start = xmlLine.IndexOf('>') + 1;
            int end = xmlLine.LastIndexOf('<');

            if (start >= 0 && end >= 0 && end > start)
            {
                return xmlLine.Substring(start, end - start);
            }

            return null;
        }

        public static bool Checkelement(string elementname)
        {
            bool check = false;
            if (elementname == "GPName" || elementname == "Name" || elementname == "RacingTeam" || elementname == "Score")
            {
                check = true;
            }

            return check;
        }

        public static void DataInDict(string data, string elementname, Dictionary<string, string> drivers, Dictionary<string, string> rteams, Dictionary<string, string> GPs)
        {
            if (elementname == "GPName")
            {
                gp_name = data;
                id = DictionaryPoints.GetGpId(data);
                if (Distinct(GPs, data))
                {
                    GPs.Add(id, data);
                }
            }
            else if (elementname == "Score")
            {
                score = data;
            }
            else if (elementname == "Name")
            {
                pilot_name = data;
                id = DictionaryPoints.GetId(data);
                if (Distinct(drivers, data))
                {
                    drivers.Add(id, data);
                }
            }
            else
            {
                rteam_name = data;
                id = DictionaryPoints.GetId(data);
                if (Distinct(rteams, data))
                {
                    rteams.Add(id, data);
                }
                PointsToDictionary(F1StatsXML.PointsRecord, gp_name, pilot_name, score, rteam_name);
            }
        }


        public static void PointsToDictionary(Dictionary<string, string> Pointsrecord, string gp_name, string pilot_name, string score, string rteam_name)
        {
            string id;
            //ID con formato GPNombre_NomApeApe
            id = DictionaryPoints.GetPointsId(gp_name, pilot_name, rteam_name);
            Pointsrecord.Add(id, score);
        }

        public static bool Distinct(Dictionary<string, string> list, string data)
        {
            bool check = true;
            foreach (string value in list.Values)
            {
                if (data == value)
                {
                    check = false;
                }
            }
            return check;
        }

       
    }
}
