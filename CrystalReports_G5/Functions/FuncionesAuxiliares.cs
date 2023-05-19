using System;
using System.Collections.Generic;
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
    }
}
