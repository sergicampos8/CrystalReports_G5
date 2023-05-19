using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalReports_G5.Functions
{
    class FuncionesAuxiliares
    {

        public string BrowseFile()
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

        public ArrayList ReadFile(string filePath)
        {
            ArrayList ArrayListXML = new ArrayList();

            if (File.Exists(filePath))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string linea;
                        while ((linea = sr.ReadLine()) != null)
                        {
                            ArrayListXML.Add(linea);
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


            // Imprimir las líneas del archivo
            //Console.WriteLine("Contenido del archivo:");
            //foreach (string linea in ArrayListXML)
            //{
            //    Console.WriteLine(linea);
            //}

            return ArrayListXML;
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

        public static bool Checkelement (string elementname)
        {
            bool check = false;
            if(elementname == "GPName" || elementname == "Name" || elementname == "RacingTeam")
            { 
                check = true;
            }

            return check;
        }

        public void FillDataInArraylists(ArrayList lines)
        {
            string elementname, data;
            bool rightelement;
            foreach (string linea in lines)
            {
                elementname = GetElementName(linea);
                rightelement = Checkelement(elementname);

                if(rightelement)
                
                    data = GetElementData(linea);
                    PutDataInArrayList(linea, elementname);
                    Console.WriteLine(linea);

                }
            }
        }

        public void PutDataInArrayList(string word, string type)
        {

            ArrayList extra = new ArrayList();
            bool repeticio;

            repeticio = false;
               


            foreach(string line in extra)
            {
                if (word.Equals(line))
                {
                    repeticio = true;
                    Console.WriteLine(line);
                }

            }

        if (!repeticio)
        {
            if (type.Equals("GPName"))
            {
                ArrayGP = extra;
            }
            else if (type.Equals("Name"))
            {
                ArrayDrivers = extra;
            }
            else
            {
                ArrayRTeams = extra;
            }

        }

        public ArrayList ReturnCorrectList(string type, ArrayList ArrayDrivers, ArrayList ArrayRTeams, ArrayList ArrayGP)
        {
            ArrayList extra = new ArrayList;
            if (type.Equals("GPName"))
            {
                extra = ArrayGP;
            }
            else if (type.Equals("Name"))
            {
                extra = ArrayDrivers;
            }
            else
            {
                extra = ArrayRTeams;
            }
            return extra;

        }             
    }
}
