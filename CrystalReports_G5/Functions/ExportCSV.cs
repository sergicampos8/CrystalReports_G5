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

            string gpName = "", position = "", name = "", team = "", score = "";

            foreach (string line in lines)
            {
                if (line.Contains("<GPName>"))
                {
                    gpName = LoadData.GetElementData(line);
                }
                else if (line.Contains("<Standings"))
                {
                    position = GetPosition(line);
                }
                else if (line.Contains("<Name>"))
                {
                    name = LoadData.GetElementData(line);
                }
                else if (line.Contains("<RacingTeam>"))
                {
                    team = LoadData.GetElementData(line);
                }
                else if (line.Contains("<Score>"))
                {
                    score = LoadData.GetElementData(line);
                }

                if (!string.IsNullOrEmpty(gpName) && !string.IsNullOrEmpty(position) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(team) && !string.IsNullOrEmpty(score))
                {
                    string csvLine = $"{gpName};{position};{name};{team};{score}";
                    filteredLines.Add(csvLine);
                    position = name = team = score = "";
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

                MessageBox.Show("La información se ha guardado en el archivo CSV.");
            }
            else
            {
                MessageBox.Show("Ha cancelado la operación");
            }
        }

        static string GetPosition(string line)
        {
            int startIndex = line.IndexOf(" position=\"") + 11;
            int endIndex = line.IndexOf('"', startIndex);
            string position = line.Substring(startIndex, endIndex - startIndex);
            return position;
        }
    }
}
