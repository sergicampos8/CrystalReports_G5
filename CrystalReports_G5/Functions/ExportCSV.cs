using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CrystalReports_G5
{
    class ExportCSV
    {
        // Función que permite guardar el xml en csv filtrando los datos
        public static void GuardarInformacionCSV(List<string> lines, bool loaded)
        {
            // Declaración de variables
            string csvFilePath;
            List<string> filteredLines = new List<string>();
            string gpName = "", position = "", name = "", team = "", score = "";

            //Control de errores, comprobación de que hay un archivo cargado
            if (loaded)
            {
                // Control de errores, intentamos leer las lineas de la lista para filtrar los datos
                try
                {
                    // Para cada linea de la lista con los datos mmiramos si contiene los filtros que necesitamos
                    foreach (string line in lines)
                    {
                        if (line.Contains("<GPName>"))
                        {
                            // Llamamos a la funcion GetElementData para extraer la informacion de dentro de los tags
                            gpName = LoadData.GetElementData(line);
                        }
                        else if (line.Contains("<Standings"))
                        {
                            // Llamamos a la funcion GetPosition para extraer la informacion de los atributos
                            position = GetPosition(line);
                        }
                        else if (line.Contains("<Name>"))
                        {
                            // Llamamos a la funcion GetElementData para extraer la informacion de dentro de los tags
                            name = LoadData.GetElementData(line);
                        }
                        else if (line.Contains("<RacingTeam>"))
                        {
                            // Llamamos a la funcion GetElementData para extraer la informacion de dentro de los tags
                            team = LoadData.GetElementData(line);
                        }
                        else if (line.Contains("<Score>"))
                        {
                            // Llamamos a la funcion GetElementData para extraer la informacion de dentro de los tags
                            score = LoadData.GetElementData(line);
                        }
                        // Si todos los datos están rellenados, añadimos la linea csvLine a la lista del CSV
                        if (!string.IsNullOrEmpty(gpName) && !string.IsNullOrEmpty(position) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(team) && !string.IsNullOrEmpty(score))
                        {
                            // Añadiendo la informacion a la lista del archivo CSV
                            string csvLine = $"{gpName};{position};{name};{team};{score}";
                            filteredLines.Add(csvLine);
                            //Volvemos a poner vacias las variables
                            position = name = team = score = "";
                        }
                    }
                    //Añadiendo la cabecera a la posición 0 de la lista
                    filteredLines.Insert(0, "GP;Position;Driver;Team;Points");

                    // SaveFileDialog para añadir un browse filtrado solo por archivos .csv y con nombre predeterminado para seleccionar donde queremos guardar el archivo
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
                    saveFileDialog.Title = "Guardar archivo CSV";
                    saveFileDialog.FileName = "datos.csv";

                    //Si apretan el botón de Aceptar se guarda el archivo y se escriben todas las lineas de la lista
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        csvFilePath = saveFileDialog.FileName;

                        File.WriteAllLines(csvFilePath, filteredLines);

                        MessageBox.Show("La información se ha guardado en el archivo CSV.");
                    }
                    //Si clican Cancelar salta un mensaje en un Box
                    else
                    {
                        MessageBox.Show("Ha cancelado la operación");
                    }
                }
                //Si hay cualquier error en la lectura de la lista o está corrupta salta el mensaje de base del sistema de porque no se puede procesar
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                MessageBox.Show("No hay ningún archivo cargado");
            }
        }
        // Funcion para extraer el atributo posición
        static string GetPosition(string line)
        {
            //Declaración del indice inicial a partir de las comillas iniciales del numero
            int startIndex = line.IndexOf(" position=\"") + 11;
            //Declaración del indice final
            int endIndex = line.IndexOf('"', startIndex);
            //Sacando la información de dentro del atributo
            string position = line.Substring(startIndex, endIndex - startIndex);
            return position;
        }
    }
}
