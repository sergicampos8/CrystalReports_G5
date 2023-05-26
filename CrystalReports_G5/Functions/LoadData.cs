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

        // Esta función realizará todo el proceso de lectura y almacenamiento del archivo XML entrante
        public static List<string> Load(string filepath, Dictionary<string, string> PointsRecord, Dictionary<string, string> drivers, Dictionary<string, string> rteams, Dictionary<string, string> GPs, List<string> lines)
        {
            // Limpiamos los Diccionarios y la lista
            PointsRecord.Clear();
            drivers.Clear();
            rteams.Clear();
            GPs.Clear();

            // Verificamos la existencia del archivo
            if(File.Exists(filepath))
            {
                // Intentamos leer el archivo XML
                try
                {
                    // Lo añadimos a la Lista lines
                    lines = ReadFile(filepath);
                    // A través de lines insertamos la información en los diccionarios indicados
                    FillDataInDict(lines, drivers, rteams, GPs);
                    // En caso correcto mostramos un mensaje de éxito
                    MessageBox.Show("Archivo " + filepath + " leído correctamente");
                }
                catch (Exception ex)
                {
                    // En caso de error en cualquier punto mostramos el mensaje de Error indicado
                    MessageBox.Show("Error al leer el archivo:\n" + ex.Message, "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                // Si no se encuentra el archivo mostramos un mensaje de error
                MessageBox.Show("El Archivo seleccionado no existe\n", "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Devolvemos la Lista con el archivo XML integro
            return lines;

        }


        // Esta función almacena toda la información en diccionarios gracias a una Lista
        public static void FillDataInDict(List<string> lines, Dictionary<string, string> drivers, Dictionary<string, string> rteams, Dictionary<string, string> GPs)
        {
            // Recorremos la Lista
            foreach (string linea in lines)
            {
                string elementname, data;

                // Obtenemos el elemento
                elementname = GetElementName(linea);

                // Verificamos si el elemento es uno de los que nos interesa
                if (Checkelement(elementname))
                {
                    // Extraemos la información dentro de ese elemento
                    data = GetElementData(linea);

                    // Añadimos esta infomación al Diccionario indicado
                    DataInDict(data, elementname, drivers, rteams, GPs);
                }
            }
        }

        // Esta función nos abrirá un Browser que nos permitirá seleccionar el archivo XML que queramos leer
        public static string BrowseFile()
        {
            // Creamos el browser
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                // Le ponemos Un título y filtramos para que solo se puedan seleccionar archivos XML
                Title = "Seleccionar archivo",
                Filter = "Archivos XML (*.xml)|*.xml"
            };

            // En caso correcto devolvemos el archivo indicado si no lo devolvemos vacío
            return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : "";
        }


        // Esta función leerá el archivo XML y lo meterá en una Lista<string>
        public static List<string> ReadFile(string filePath)
        {
            List<string> ListXML = new List<string>();       
            ListXML = File.ReadAllLines(filePath).ToList();
            
            return ListXML;
        }


        // Esta función obtendrá el elemento de una línea
        public static string GetElementName(string xml)
        {
            int principio, final, espacio;
            string element;

            // Buscamos la apertura y el cierre del primer elemento
            principio = xml.IndexOf('<');
            final = xml.IndexOf('>', principio);

            // Si son nulos, el XML no es correcto
            if (principio == -1 || final == -1)
            {
                // XML inválido
                return null;
            }

            // Extraemos el contenido de los <>
            element = xml.Substring(principio + 1, final - principio - 1);

            // Buscamos si hay un atributo gracias al espacio
            espacio = element.IndexOf(' ');

            // En caso de haber un elemento, lo eliminamos
            if (espacio != -1)
            {
                element = element.Substring(0, espacio);
            }

            return element;
        }

        // Esta función extrae la información dentro del elemento de la linea insertada
        public static string GetElementData(string xmlLine)
        {
            int principio, final; string resultado;

            // Buscamos el inicio del contenido del elemento
            principio = xmlLine.IndexOf('>') + 1;
            // Buscamos el final del contenido del elemento (comenzando desde el final de la string)
            final = xmlLine.LastIndexOf('<');

            // En caso correcto devolvemos un subtring
            if (principio >= 0 && final >= 0 && final > principio)
            {
                resultado = xmlLine.Substring(principio, (final - principio));
                return resultado;
            }

            // En caso incorrecto devolvemos nulo
            return null;
        }


        // Esta función verifica si el elemento seleccionado es uno de los que buscamos en caso afirmativo devuelve true
        public static bool Checkelement(string elementname)
        {
            bool check = false;
            // Aquí indicamos qué elementos nos interesan
            if (elementname == "GPName" || elementname == "Name" || elementname == "RacingTeam" || elementname == "Score")
            {
                check = true;
            }

            return check;
        }


        // Esta función alamacena la información en los diccionarios en función del nombre del elemento
        public static void DataInDict(string data, string elementname, Dictionary<string, string> drivers, Dictionary<string, string> rteams, Dictionary<string, string> GPs)
        {
            // Verificamos el nombre del elemento
            if (elementname == "GPName")
            {
                // Guardamos la información en una variable auxiliar
                gp_name = data;
                // obtenemos su ID
                id = DictionaryPoints.GetGpId(data);
                // Verficamos si ya ha sido añadido al diccionario
                if (Distinct(GPs, data))
                {
                    // Añadimos el id in la información al diccionario
                    GPs.Add(id, data);
                }
            }
            else if (elementname == "Score")
            {
                // Guardamos la información en una variable auxiliar
                score = data;
            }
            else if (elementname == "Name")
            {
                // Guardamos la información en una variable auxiliar
                pilot_name = data;
                // obtenemos su ID
                id = DictionaryPoints.GetId(data);

                // Verficamos si ya ha sido añadido al diccionario
                if (Distinct(drivers, data))
                {
                    // Añadimos el id in la información al diccionario
                    drivers.Add(id, data);
                }
            }
            else
            {
                // Guardamos la información en una variable auxiliar
                rteam_name = data;
                // obtenemos su ID
                id = DictionaryPoints.GetId(data);
                // Verficamos si ya ha sido añadido al diccionario
                if (Distinct(rteams, data))
                {
                    // Añadimos el id in la información al diccionario
                    rteams.Add(id, data);
                }

                // Al ser RTeams la última información que aparece en el XML podemos añadir ya la información al diccionario de puntos
                PointsToDictionary(F1StatsXML.PointsRecord, gp_name, pilot_name, score, rteam_name);
            }
        }

        // Esta función añade una línea al diccionario de puntos
        public static void PointsToDictionary(Dictionary<string, string> Pointsrecord, string gp_name, string pilot_name, string score, string rteam_name)
        {
            string id;
            // ID con formato GPNombre_RTNombre_PilotoNomApeApe
            id = DictionaryPoints.GetPointsId(gp_name, pilot_name, rteam_name);
            // Añadimos el id in la información al diccionario
            Pointsrecord.Add(id, score);
        }

        // Esta función verifica si la información que le pasas ya está añadida a la lista que le pasas
        public static bool Distinct(Dictionary<string, string> list, string data)
        {
            bool check = true;
            // Recorremos la lista
            foreach (string value in list.Values)
            {
                // si la linea es igual a la data, está repetida
                if (data == value)
                {
                    check = false;
                }
            }
            return check;
        }   
    }
}
