using System.IO;

namespace CrystalReports_G5
{
    class DictionaryPoints
    {
        private static string GetGpId(string input)
        {
            string result = "";
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }
            }
            return result;
        }

        public static string GetPilotId(string input)
        {
            string[] words = input.Split(' '); // Separar las palabras por espacio
            string result = "";

            for (int i = 0; i < words.Length; i++)
            {
                string firstCharacters = "";

                if (words[i].Length >= 3)
                {
                    firstCharacters = words[i].Substring(0, 3); // Tomar los primeros tres caracteres
                }
                else if (words[i].Length == 2)
                {
                    firstCharacters = words[i].Substring(0, 2); // Tomar los primeros dos caracteres
                }
                else if (words[i].Length == 1)
                {
                    firstCharacters = words[i].Substring(0, 1); // Tomar el primer caracter
                }

                firstCharacters = char.ToUpper(firstCharacters[0]) + firstCharacters.Substring(1); // Convertir el primer carácter a mayúscula

                result += firstCharacters;

                if (i < words.Length - 1)
                {
                    result += ""; // Agregar espacio como separador, excepto para la última palabra
                }
            }

            return result;
        }

        private static string GetPointsId(string gp_name, string pilot_name)
        {
            string id = GetGpId(gp_name) + "_" + GetPilotId(pilot_name);
            return id;
        }
    }
}
