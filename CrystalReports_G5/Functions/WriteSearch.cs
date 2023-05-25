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
        public static string SaveListInFile(List<string> list, string browsefilePath)
        {
            try
            {
                if (String.IsNullOrEmpty(browsefilePath))
                {

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Archivos TXT (*.txt)|*.txt";
                    saveFileDialog.Title = "Guardar archivo Txt";
                    saveFileDialog.FileName = "query.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                    
                        browsefilePath = saveFileDialog.FileName;                  
                        File.WriteAllLines(browsefilePath, list);

                        MessageBox.Show("La información se ha guardado en el archivo Txt.");
                    }
                    else
                    {
                        MessageBox.Show("Ha cancelado la operación");
                    }
                }
                else
                {
                    File.WriteAllLines(browsefilePath, list);
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return browsefilePath;
        }



        public static List<string> JoinLists(List<string> former_list, List<string> actual_list)
        {
            List<string> final_list = new List<string>();
            foreach (string former_line in former_list)
            {
                final_list.Add(former_line);               
            }
            foreach (string actual_line in actual_list)
            {
                final_list.Add(actual_line);
            }
            return final_list;
        }
    }
}