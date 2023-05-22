﻿using System.IO;

namespace CrystalReports_G5
{
    class DictionaryPoints
    {
        private static string GetGpId(string gp)
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

        public static string GetPilotId(string pilot)
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

                //firstCharacters = char.ToUpper(firstCharacters[0]) + firstCharacters.Substring(1); // Convertir el primer carácter a mayúscula

                result += p_id;

                //if (i < words.Length - 1)
                //{
                //    result += ""; // Agregar espacio como separador, excepto para la última palabra
                //}
            }

            return result;
        }

        public static string GetPointsId(string gp_name, string pilot_name)
        {
            string id = GetGpId(gp_name) + "_" + GetPilotId(pilot_name);
            return id;
        }
    }
}
