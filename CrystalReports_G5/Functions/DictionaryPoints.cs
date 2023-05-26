using System.IO;

namespace CrystalReports_G5
{
    
    class DictionaryPoints
    {
        // Función para crear un ID para cada GP
        public static string GetGpId(string gp)
        {
            //Inicializamos el string vacio
            string result = "";
            foreach (char c in gp)
            {
                //Quitamos los Espacios
                if (char.IsLetterOrDigit(c))
                {
                    //Añadimos el carácter al resultado
                    result += c;
                }
            }
            // El ID será el nombre del GP sin espacios
            return result;
        }


        //Función para crear un ID para el resto de elementos (Pilotos, Escuderias)
        public static string GetId(string pilot)
        {
            string[] words = pilot.Split(' '); 
            // Separar las palabras por espacio
            string result = "";

            for (int i = 0; i < words.Length; i++)
            {
                string p_id = "";

                if (words[i].Length >= 3)
                {
                    p_id = words[i].Substring(0, 3); 
                    // Tomar los primeros tres caracteres
                }
                else if (words[i].Length == 2)
                {
                    p_id = words[i].Substring(0, 2); 
                    // Tomar los primeros dos caracteres
                }
                else if (words[i].Length == 1)
                {
                    p_id = words[i].Substring(0, 1); 
                    // Tomar el primer caracter
                }

                //El resultado serán las 3 primeras letras de cada elemento de la cadena original en Mayúsculas
                result += p_id;

            }

            return result;
        }

        // Función para crear el ID final, Juntaremos todo el resto en tan solo uno para que este id tenga toda la información necesaria
        public static string GetPointsId(string gp_name, string pilot_name, string rteam_name)
        {
            //En primer lugar ponemos el GP a continuación la Escudería y finalmente el Piloto
            string id = GetGpId(gp_name) + "_" + GetId(rteam_name) + "_" + GetId(pilot_name);
            return id;
        }
    }
}
