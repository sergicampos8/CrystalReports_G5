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
            if (elementname == "GPName" || elementname == "Name" || elementname == "RacingTeam")
            {
                check = true;
            }

            return check;
        }

        public static void FillDataInLists(List<string> lines, List<string> drivers, List<string> rteams, List<string> GPs)
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
                    DataInList(data, elementname, drivers, rteams, GPs);
                }
            }
        }

        public static void DataInList(string data, string elementname, List<string> drivers, List<string> rteams, List<string> GPs)
        {
            if (elementname == "GPName")
            {
                if(Distinct(GPs, data))
                    GPs.Add(data);
            }
            else if (elementname == "Name")
            {
                if (Distinct(drivers, data))
                    drivers.Add(data);
            }
            else
            {
                if (Distinct(rteams, data))
                    rteams.Add(data);
            }

        }

        public static void WriteList(List<string> list)
        {
            foreach (string linea in list)
            {
                Console.WriteLine(linea);
            }

        }

        public static bool Distinct(List<string> list, string data)
        {
            bool check = true;
            foreach (string linea in list)
            {
                if (data == linea)
                {
                    check = false;
                }
            }
            return check;
        }
    }
}
