using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalReports_G5
{
    class LoadData
    {
        public static string gp_name, pilot_name, rteam,score, id;


        public static void FillDataInDict(List<string> lines, Dictionary<string,string> drivers, Dictionary<string, string> rteams, Dictionary<string, string> GPs)
        {

            string elementname, data;
            bool rightelement;
            foreach (string linea in lines)
            {
                elementname = GetElementName(linea);
                rightelement = Checkelement(elementname);

                if (rightelement)
                {
                    data = GetElementData(linea);
                    DataInDict(data, elementname, drivers, rteams, GPs);
                }
            }

        }

        public static string BrowseFile()
        {
            string rutaArchivo = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Seleccionar archivo";
            openFileDialog.Filter = "Archivos XML (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // El usuario ha seleccionado un archivo
                rutaArchivo = openFileDialog.FileName;
            }

            return rutaArchivo;
        }

        public static List<string> ReadFile(string filePath)
        {
            List<string> ListXML = new List<string>();

            if (File.Exists(filePath))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string linea;
                        while ((linea = sr.ReadLine()) != null)
                        {
                            ListXML.Add(linea);
                        }
                    }
                    // Hacer algo con el contenido del archivo
                    MessageBox.Show("Archivo " + filePath + " leído Correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer el archivo:\n" + ex.Message, "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El archivo no existe.", "Archivo no Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return ListXML;
        }

        public static string GetElementName(string xml)
        {
            int principio, final, espacio;
            string element;

            // Encontrar el principio del elemento
            principio = xml.IndexOf('<');
            if (principio == -1)
            {
                // XML inválido
                return null;
            }

            // Encontrar el final del elemento
            final = xml.IndexOf('>', principio);
            if (final == -1)
            {
                // XML inválido
                return null;
            }
            // Extraer el nombre del elemento
            element = xml.Substring(principio + 1, final - principio - 1);
            // Verificar Atributos
            espacio = element.IndexOf(' ');
            if (espacio != -1)
            {
                element = element.Substring(0, espacio - 1);
            }

            return element;
        }

        public static string GetElementData(string xmlLine)
        {
            {
                int start, end;
                string data;
                // Necesitamos conseguir la segunda aparición de el carácter >
                start = xmlLine.IndexOf('>') + 1;
                // Conseguimos la primera aparicion del caracter <
                end = xmlLine.LastIndexOf('<');
                // Creamos la substring de los datos, como in
                data = xmlLine.Substring(start, end - start);
                return data;
            }
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
                    GPs.Add(id, data);
            }
            else if (elementname == "Score")
            {
                score = data;
            }
            //Sabiendo que cada vez que el nombre cambie queremos guardar los puntos, iniciamos la funcion de guardar puntos en este if 
            else if (elementname == "Name")
            {
                pilot_name = data;
                id = DictionaryPoints.GetId(data);
                if (Distinct(drivers, data))
                    drivers.Add(id,data);
                PointsToDictionary(F1StatsXML.PointsRecord, gp_name, pilot_name, score);
            }
            else
            {
                id = DictionaryPoints.GetId(data);
                if (Distinct(rteams, data))
                    rteams.Add(id, data);
            }
        }

        public static void PointsToDictionary(Dictionary<string, string> Pointsrecord, string gp_name, string pilot_name, string score)
        {
            string id;
            //ID con formato GPNombre_NomApeApe
            id = DictionaryPoints.GetPointsId(gp_name, pilot_name);
            Pointsrecord.Add(id, score);
        }


        public static void WriteList(List<string> list)
        {
            foreach (string linea in list)
            {
                Console.WriteLine(linea);
            }

        }

        public static void WriteDictionary(Dictionary<string, string> dictionary)
        {
            foreach (KeyValuePair<string, string> element in dictionary)
            {
                Console.WriteLine("Key = {0}, Value = {1}",element.Key, element.Value);
            }
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
