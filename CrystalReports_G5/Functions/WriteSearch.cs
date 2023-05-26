using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalReports_G5
{
    class WriteSearch
    {
        // Esta función almacena la lista que le pasas en el archivo indicado
        public static string SaveListInFile(List<string> list, string browsefilePath)
        {
            try
            {
                // Si browsefilePath no tiene valor (quiere decir que es la primera vez que ejecutamos la función)
                if (String.IsNullOrEmpty(browsefilePath))
                {
                    // Creamos un browser para que el usuario indique donde guardar el archivoy su nombre
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    // El archivo será de tipo .txt y su nombre por defecto será query.txt
                    saveFileDialog.Filter = "Archivos TXT (*.txt)|*.txt";
                    saveFileDialog.Title = "Guardar archivo Txt";
                    saveFileDialog.FileName = "query.txt";

                    // En caso correcto
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {                
                        // Guardamos el path del archivo
                        browsefilePath = saveFileDialog.FileName;  

                        // Mostramos un mensaje de éxito
                        MessageBox.Show("La información se ha guardado en el archivo Txt.");
                    }
                    else
                    {
                        // En caso incorrecto mostramos un mensaje de error
                        MessageBox.Show("Ha cancelado la operación");
                    }
                }
                // Creamos el archivo y le insertamos la Lista
                File.WriteAllLines(browsefilePath, list);


            }
            // En caso erróneo
            catch (Exception ex)
            {
                // Mostramos el error indicado
                MessageBox.Show(ex.Message);

            }

            return browsefilePath;
        }


        // Función para juntar 2 Listas en una
        public static List<string> JoinLists(List<string> former_list, List<string> actual_list)
        {
            List<string> final_list = new List<string>();
            // Recorremos la primera lista y la añadimos linea por linea a la final
            foreach (string former_line in former_list)
            {
                final_list.Add(former_line);               
            }
            // Recorremos la segunda lista y la añadimos linea por linea a la final
            foreach (string actual_line in actual_list)
            {
                final_list.Add(actual_line);
            }
            return final_list;
        }
    }
}

