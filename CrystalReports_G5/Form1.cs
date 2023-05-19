using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalReports_G5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {

        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Seleccionar archivo";
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // El usuario ha seleccionado un archivo
                string rutaArchivo = openFileDialog.FileName;
                // Obtener solo el nombre del archivo sin la ruta
                string nombreArchivo = Path.GetFileName(rutaArchivo);
                // Asignar el nombre del archivo al control TextBox
                FileBox.Text = nombreArchivo;
            }
        }

        private void FileBox_TextChanged(object sender, EventArgs e)
        {
            // No es necesario agregar código aquí para este ejemplo
        }
    }
}
