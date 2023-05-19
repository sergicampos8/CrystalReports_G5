using System;
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

        public void ReadFile(string filePath)
        {

            if (File.Exists(filePath))
            {
                try
                {
                    string content = File.ReadAllText(filePath);
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
        }
    }
}
