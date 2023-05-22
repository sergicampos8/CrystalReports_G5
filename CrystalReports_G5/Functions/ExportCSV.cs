using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CrystalReports_G5
{
    class ExportCSV
    {
        public static void GuardarInformacionCSV(List<string> lines)
        {
            string csvFilePath;
            List<string> filteredLines = new List<string>();
            bool startRecording = false;

            foreach (string line in lines)
            {
                if (line.Contains("<Results>"))
                {
                    startRecording = true;
                }
                else if (line.Contains("</Results>"))
                {
                    startRecording = false;
                }
                else if (startRecording)
                {
                    filteredLines.Add(line);
                }
            }

            filteredLines.Insert(0, "GP;Position;Driver;Team;Points");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
            saveFileDialog.Title = "Guardar archivo CSV";
            saveFileDialog.FileName = "datos.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                csvFilePath = saveFileDialog.FileName;

                using (StreamWriter file = new StreamWriter(csvFilePath))
                {
                    foreach (string line in filteredLines)
                    {
                        file.WriteLine(line);
                    }
                }

                Console.WriteLine("Archivo CSV creado con éxito.");
            }
            else
            {
                Console.WriteLine("Operación cancelada por el usuario.");
            }

            csvFilePath = "datos.csv";
            using (StreamWriter file = new StreamWriter(csvFilePath))
            {
                foreach (string line in filteredLines)
                {
                    file.WriteLine(line);
                }
            }
        }
    }
}
