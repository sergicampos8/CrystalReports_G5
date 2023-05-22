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

            foreach (string line in lines)
            {
                if (line.Contains("<GPInfo>"))
                {
                    filteredLines.Add(GetValue(line, "<GPName>"));
                    filteredLines.Add(GetValue(line, "<Position>"));
                    filteredLines.Add(GetValue(line, "<Driver>"));
                    filteredLines.Add(GetValue(line, "<Team>"));
                    filteredLines.Add(GetValue(line, "<Points>"));
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

                File.WriteAllLines(csvFilePath, filteredLines);

                Console.WriteLine("Archivo CSV creado con éxito.");
            }
            else
            {
                Console.WriteLine("Operación cancelada por el usuario.");
            }
        }

        static string GetValue(string line, string tag)
        {
            int startIndex = line.IndexOf(tag) + tag.Length;
            int endIndex = line.IndexOf("</", startIndex);
            return line.Substring(startIndex, endIndex - startIndex);
        }

    }
}
