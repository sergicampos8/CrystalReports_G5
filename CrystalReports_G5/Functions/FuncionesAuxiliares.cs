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
                    MessageBox.Show( "Archivo " + filePath + " leído Correctamente");
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
    }
}
