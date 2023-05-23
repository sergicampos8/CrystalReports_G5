using System.IO;

namespace CrystalReports_G5
{
    class DictionaryPoints
    {
        public static string GetGpId(string gp)
        {
            string result = "";
            foreach (char c in gp)
            {
                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }
            }
            return result;
        }

        public static string GetId(string pilot)
        {
            string[] words = pilot.Split(' '); // Separar las palabras por espacio
            string result = "";

            for (int i = 0; i < words.Length; i++)
            {
                string p_id = "";

                if (words[i].Length >= 3)
                {
                    p_id = words[i].Substring(0, 3); // Tomar los primeros tres caracteres
                }
                else if (words[i].Length == 2)
                {
                    p_id = words[i].Substring(0, 2); // Tomar los primeros dos caracteres
                }
                else if (words[i].Length == 1)
                {
                    p_id = words[i].Substring(0, 1); // Tomar el primer caracter
                }

                result += p_id;

            }

            return result;
        }

        public static string GetPointsId(string gp_name, string pilot_name, string rteam_name)
        {
            string id = GetGpId(gp_name) + "_" + GetId(rteam_name) + "_" + GetId(pilot_name);
            return id;
        }
    }
}
