using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CrystalReports_G5
{
    class ShowData
    {
        //Declaramos la variable publica id que utilizaran la gran mayoria de funciones
        public static string id;

        //Funcion destinada a devolver una lista que tenga la búsqueda de los datos de un piloto
        public static List<string> DriversView(string pilot_name)
        {
            //Conseguimos la id de el piloto
            id = DictionaryPoints.GetId(pilot_name);
            
            //Declaración de nueva list en la que pondremos el estilo y el nombre del piloto
            List<string> query = new List<string>();

            query.Add("--------------------------------------------------------------------------------------------------");
            query.Add(pilot_name);
            query.Add("--------------------------------------------------------------------------------------------------");

            //Entraremos en cada linia de nuestro diccionario de puntos ya que el id contiene los datos de GP, Escuderia y Piloto
            foreach (KeyValuePair<string, string> points in F1StatsXML.PointsRecord)
            {
                string points_value = points.Value;
                string points_id = points.Key;

                //Si la id de los puntos contiene la id de nuestro piloto entraremos a otro bucle
                if (points_id.Contains(id))
                {
                    //Entramos en el diccionario de GPs donde buscaremos coincidir su id con la id de nuestra puntuación
                    foreach (KeyValuePair<string, string> gp in F1StatsXML.GPs)
                    {
                        string gp_id = gp.Key;
                        string gp_name = gp.Value;
                        //En caso de que el id de la puntuación contenga la del gp guardaremos en la lista el nombre de Gp y su puntuación respectiva
                        if (points_id.Contains(gp_id))
                        {
                            query.Add($"{gp_name,-25}{points_value}");
                        }
                    }
                }
            }

            query.Add("--------------------------------------------------------------------------------------------------");

            return query;
        }

        // Función destinada a devolver una lista que contenga los datos de un Racing Team (Equipo de Carreras)
        public static List<string> RacingTeamView(string rt_name)
        {
            // Obtener el ID del Racing Team utilizando el nombre proporcionado
            string id = DictionaryPoints.GetId(rt_name);

            // Lista para almacenar los nombres de los pilotos del Racing Team
            List<string> RTDrivers = new List<string>();

            // Lista para almacenar los datos de búsqueda resultantes
            List<string> query = new List<string>();

            // Variables para almacenar los puntos totales de los dos pilotos del Racing Team
            int t_points_1 = 0;
            int t_points_2 = 0;

            // Agregar una línea separadora inicial a la lista de consulta
            query.Add("--------------------------------------------------------------------------------------------------");

            // Agregar el nombre del Racing Team a la lista de consulta
            query.Add(rt_name);

            // Agregar una línea separadora adicional a la lista de consulta
            query.Add("--------------------------------------------------------------------------------------------------");

            // Recorrer todos los registros de puntos
            foreach (KeyValuePair<string, string> points in F1StatsXML.PointsRecord)
            {
                string points_value = points.Value;
                string points_id = points.Key;

                // Verificar si el ID del Racing Team está presente en el registro de puntos
                if (points_id.Contains(id))
                {
                    // Recorrer todos los pilotos registrados
                    foreach (KeyValuePair<string, string> driver in F1StatsXML.Drivers)
                    {
                        string driver_id = driver.Key;
                        string driver_name = driver.Value;

                        // Verificar si el ID del piloto está presente en el registro de puntos
                        if (points_id.Contains(driver_id))
                        {
                            // Agregar el nombre del piloto a la lista de pilotos del Racing Team
                            RTDrivers.Add(driver_name);

                            // Obtener los puntos del piloto
                            int driver_points = int.Parse(points_value);

                            // Actualizar los puntos totales según el piloto
                            if (RTDrivers[0] == driver_name)
                            {
                                t_points_1 += driver_points;
                            }
                            else if (RTDrivers[1] == driver_name)
                            {
                                t_points_2 += driver_points;
                            }
                        }
                    }
                }
            }

            // Agregar los nombres de los pilotos y sus respectivos puntos a la lista de consulta, ordenándolos por puntos de mayor a menor
            if (t_points_1 > t_points_2)
            {
                query.Add($"{RTDrivers[0],-20}{t_points_1}");
                query.Add($"{RTDrivers[1],-20}{t_points_2}");
            }
            else
            {
                query.Add($"{RTDrivers[1],-20}{t_points_2}");
                query.Add($"{RTDrivers[0],-20}{t_points_1}");
            }

            // Agregar una línea separadora final a la lista de consulta
            query.Add("--------------------------------------------------------------------------------------------------");

            // Devolver la lista de consulta
            return query;
        }


        // Esta Función devuelve la información de un GP
        public static List<string> GPView(string GP_name)
        {
            int position = 0;
            id = DictionaryPoints.GetGpId(GP_name); // Obtiene el ID del Gran Premio

            List<string> query = new List<string>();

            query.Add("--------------------------------------------------------------------------------------------------");
            query.Add(GP_name); // Agrega el nombre del Gran Premio a la lista
            query.Add("--------------------------------------------------------------------------------------------------");

            foreach (KeyValuePair<string, string> points in F1StatsXML.PointsRecord)
            {
                string points_value = points.Value;
                string points_id = points.Key;

                if (points_id.Contains(id)) // Verifica si el ID del Gran Premio está presente en el ID de los puntos
                {
                    foreach (KeyValuePair<string, string> driver in F1StatsXML.Drivers)
                    {
                        string driver_id = driver.Key;
                        string driver_name = driver.Value;
                        if (points_id.Contains(driver_id)) // Verifica si el ID del piloto está presente en el ID de los puntos
                        {
                            position++;
                            query.Add(Convert.ToString(position).PadRight(10) + points_value.PadRight(15) + driver_name);
                            // Agrega la posición, los puntos y el nombre del piloto a la lista
                        }
                    }
                }
            }
            query.Add("--------------------------------------------------------------------------------------------------");

            return query; // Devuelve la lista de resultados
        }

        // Esta función devuelve las estadisticas generales de la F1
        public static List<string> ViewStatistics()
        {
            List<string> Stats = new List<string>();
            Stats.Add("--------------------------------------------------------------------------------------------------");
            Stats.Add("Statistics");
            Stats.Add("--------------------------------------------------------------------------------------------------");
            Stats.Add(GetBestRt()); // Obtiene la mejor puntuación del equipo de carreras
            Stats.Add(GetBestDriver()); // Obtiene la mejor puntuación del piloto
            Stats.Add(GetBestDriverWins()); // Obtiene el piloto con más victorias
            Stats.Add("--------------------------------------------------------------------------------------------------");

            return Stats; // Devuelve la lista de estadísticas
        }

        //Función destinada a conseguir el piloto en la primera posición de cada GP
        public static string GetGpFirstPlace(string id)
        {
            string first_driver = "";

            foreach (KeyValuePair<string, string> points in F1StatsXML.PointsRecord)
            {
                string points_value = points.Value;
                string points_id = points.Key;

                if (points_id.Contains(id)) // Verifica si el ID del punto contiene el ID del GP especificado
                {
                    foreach (KeyValuePair<string, string> driver in F1StatsXML.Drivers)
                    {
                        string driver_id = driver.Key;
                        string driver_name = driver.Value;
                        if (points_id.Contains(driver_id) && points_value == "25")
                        {
                            // Verifica si el ID del punto contiene el ID del piloto y si el valor de los puntos es 25
                            first_driver = driver_name; // Asigna el nombre del piloto a first_driver
                        }
                    }
                }
            }

            return first_driver; // Devuelve el nombre del piloto en la primera posición del GP
        }

        // Esta función devuelve el nombre del piloto con más carreras ganadas y el número de carreras ganadas
        public static string GetBestDriverWins()
        {
            int n_wins = 0;
            string wins_driver = "", driver_n = "";
            List<string> GpFirst = new List<string>();

            foreach (KeyValuePair<string, string> gp in F1StatsXML.GPs)
            {
                string gp_id = gp.Key;
                string gp_name = gp.Value;
                GpFirst.Add(GetGpFirstPlace(gp_id));
                // Obtiene el piloto en la primera posición de cada GP y lo agrega a la lista GpFirst
            }

            foreach (KeyValuePair<string, string> driver in F1StatsXML.Drivers)
            {
                int count = 0;
                string driver_id = driver.Key;
                string driver_name = driver.Value;
                foreach (string fdriver in GpFirst)
                {
                    if (fdriver == driver_name)
                    {
                        count++;
                        // Cuenta cuántas veces el piloto está en la primera posición de algún GP
                    }
                }
                if (count > n_wins)
                {
                    n_wins = count;
                    driver_n = driver_name;
                    // Actualiza el número máximo de victorias y el nombre del piloto correspondiente
                }
            }

            wins_driver = "Driver with most races won (" + (n_wins).ToString() + "): " + driver_n;
            // Crea una cadena de texto con el piloto que tiene más victorias
            return wins_driver; // Devuelve la cadena de texto
        }


        public static int GetDriverPoints(string id)
        {
            int d_points = 0;

            foreach (KeyValuePair<string, string> points in F1StatsXML.PointsRecord)
            {
                string points_value = points.Value;
                string points_id = points.Key;

                if (points_id.Contains(id)) // Verifica si el ID del punto contiene el ID del piloto especificado
                {
                    foreach (KeyValuePair<string, string> gp in F1StatsXML.GPs)
                    {
                        string gp_id = gp.Key;
                        string gp_name = gp.Value;
                        if (points_id.Contains(gp_id)) // Verifica si el ID del punto contiene el ID del GP actual
                        {
                            d_points += int.Parse(points_value);
                            // Suma el valor de los puntos (convertido a entero) al total de puntos del piloto
                        }
                    }
                }
            }
            return d_points; // Devuelve el total de puntos del piloto
        }


        public static string GetBestDriver()
        {
            int max_point;
            string best_driver = "", driver_n = "";
            bool comprovar = false;
            Dictionary<string, int> PointsD = new Dictionary<string, int>();

            // Recorre la lista de pilotos y agrega sus nombres y puntos al diccionario PointsD
            foreach (KeyValuePair<string, string> driver in F1StatsXML.Drivers)
            {
                string driver_id = driver.Key;
                string driver_name = driver.Value;
                PointsD.Add(driver_name, GetDriverPoints(driver_id));
            }

            // Obtiene el valor máximo de puntos del diccionario PointsD
            max_point = PointsD.Values.Max();

            // Busca el nombre del piloto con la cantidad máxima de puntos
            while (!comprovar)
            {
                foreach (KeyValuePair<string, int> pointd in PointsD)
                {
                    string name = pointd.Key;
                    int points = pointd.Value;
                    if (max_point == points)
                    {
                        driver_n = name;
                        comprovar = true;
                    }
                }
            }

            best_driver = "Best Driver (" + (max_point).ToString() + "): " + driver_n;
            return best_driver; // Devuelve el nombre del piloto con más puntos
        }

        public static int GetRtPoints(string id)
        {
            int points_p1 = 0,
                points_p2 = 0,
                total_points;
            List<string> RTDrivers = new List<string>();

            // Recorre la lista de puntos y busca aquellos que corresponden al ID del equipo de carreras (RT)
            foreach (KeyValuePair<string, string> points in F1StatsXML.PointsRecord)
            {
                string points_value = points.Value;
                string points_id = points.Key;

                if (points_id.Contains(id))
                {
                    // Busca los pilotos asociados a los puntos y los agrega a la lista RTDrivers
                    foreach (KeyValuePair<string, string> driver in F1StatsXML.Drivers)
                    {
                        string driver_id = driver.Key;
                        string driver_name = driver.Value;
                        if (points_id.Contains(driver_id))
                        {
                            if (RTDrivers.Count < 2)
                            {
                                RTDrivers.Add(driver_name);
                            }
                            if (RTDrivers[0] == driver_name)
                            {
                                points_p1 += int.Parse(points_value); // Suma los puntos al piloto 1 del equipo
                            }
                            else
                            {
                                points_p2 += int.Parse(points_value); // Suma los puntos al piloto 2 del equipo
                            }
                        }
                    }
                }
            }

            total_points = points_p1 + points_p2; // Calcula el total de puntos del equipo sumando los puntos de ambos pilotos
            return total_points; // Devuelve el total de puntos del equipo de carreras (RT)
        }


        public static string GetBestRt()
        {
            int max_point;
            string best_rt = "",
                rt = "";
            bool comprovar = false;
            Dictionary<string, int> PointsRt = new Dictionary<string, int>();

            // Recorre la lista de equipos de carreras (RT) y obtiene los puntos de cada equipo llamando a la función GetRtPoints
            foreach (KeyValuePair<string, string> rteam in F1StatsXML.RTeams)
            {
                string rteam_id = rteam.Key;
                string rteam_name = rteam.Value;
                PointsRt.Add(rteam_name, GetRtPoints(rteam_id));
            }

            max_point = PointsRt.Values.Max(); // Obtiene la máxima cantidad de puntos entre todos los equipos

            while (!comprovar)
            {
                foreach (KeyValuePair<string, int> pointrt in PointsRt)
                {
                    string name = pointrt.Key;
                    int points = pointrt.Value;
                    if (max_point == points)
                    {
                        rt = name;
                        comprovar = true;
                    }
                }
            }

            best_rt = "Best Racing (" + (max_point).ToString() + "): " + rt; // Construye la cadena de texto con el nombre y los puntos del mejor equipo de carreras
            return best_rt; // Devuelve la cadena de texto con la información del mejor equipo de carreras (RT)
        }


        public static List<string> SelectView(string selection1, string selection2, List<string> list)
        {
            list.Clear();

            if (selection1 == "Grand Prix")
            {
                list = ShowData.GPView(selection2); // Llama a la función ShowData.GPView con el segundo parámetro de selección y asigna el resultado a la lista
            }
            else if (selection1 == "Pilot")
            {
                list = ShowData.DriversView(selection2); // Llama a la función ShowData.DriversView con el segundo parámetro de selección y asigna el resultado a la lista
            }
            else
            {
                list = ShowData.RacingTeamView(selection2); // Llama a la función ShowData.RacingTeamView con el segundo parámetro de selección y asigna el resultado a la lista
            }

            return list; // Devuelve la lista actualizada según la selección realizada
        }


        public static void WriteTextBox(List<string> searchList, TextBox textBox)
        {
            textBox.Text = ""; // Limpia el contenido actual del TextBox

            foreach (string line in searchList)
            {
                textBox.Text += line + Environment.NewLine; // Agrega cada línea de la lista al TextBox, separadas por una nueva línea
            }
        }



        public static void UpdateNameMultiBox(string selection, ComboBox NameMultibox, Dictionary<string, string> GPs, Dictionary<string, string> Drivers, Dictionary<string, string> RTeams)
        {
            NameMultibox.SelectedIndex = -1; // Desactiva la selección actual en el ComboBox
            NameMultibox.Items.Clear(); // Limpia los elementos actuales del ComboBox

            if (selection == "Grand Prix")
            {
                NameMultibox.Items.AddRange(GPs.Values.ToArray()); // Agrega los valores de los Grand Prix al ComboBox
            }
            else if (selection == "Pilot")
            {
                NameMultibox.Items.AddRange(Drivers.Values.ToArray()); // Agrega los valores de los Pilotos al ComboBox
            }
            else
            {
                NameMultibox.Items.AddRange(RTeams.Values.ToArray()); // Agrega los valores de los Racing Teams al ComboBox
            }
        }
    }
}
