using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalReports_G5
{
    class ShowData
    {
        public static string id;
        public static List<string> query = new List<string>();


        public static List<string> DriversView(string pilot_name)
        {
            id = DictionaryPoints.GetId(pilot_name);

            query.Add("--------------------------------------------------------------------------------------------------");
            query.Add(pilot_name);
            query.Add("--------------------------------------------------------------------------------------------------");

            foreach (KeyValuePair<string, string> points in F1StatsXML.PointsRecord)
            {
                string points_value = points.Value;
                string points_id = points.Key;

                if (points_id.Contains(id))
                {
                    foreach (KeyValuePair<string, string> gp in F1StatsXML.GPs)
                    {
                        string gp_id = gp.Key;
                        string gp_name = gp.Value;
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

        public static List<string> RacingTeamView(string rt_name)
        {
            id = DictionaryPoints.GetId(rt_name);
            List<string> RTDrivers = new List<string>();

            int total_points_1 = 0;
            int total_points_2 = 0;

            query.Add("--------------------------------------------------------------------------------------------------");
            query.Add(rt_name);
            query.Add("--------------------------------------------------------------------------------------------------");

            foreach (KeyValuePair<string, string> points in F1StatsXML.PointsRecord)
            {
                string points_value = points.Value;
                string points_id = points.Key;

                if (points_id.Contains(id))
                {
                    foreach (KeyValuePair<string, string> driver in F1StatsXML.Drivers)
                    {
                        string driver_id = driver.Key;
                        string driver_name = driver.Value;

                        if (points_id.Contains(driver_id))
                        {
                            RTDrivers.Add(driver_name);

                            int driver_points = int.Parse(points_value);
                            if (RTDrivers[0] == driver_name)
                            {
                                total_points_1 += driver_points;
                            }
                            else if (RTDrivers[1] == driver_name)
                            {
                                total_points_2 += driver_points;
                            }
                        }
                    }
                }
            }

            query.Add($"{RTDrivers[0],-20}{total_points_1}");
            query.Add($"{RTDrivers[1],-20}{total_points_2}");
            query.Add("--------------------------------------------------------------------------------------------------");
            return query;
        }

        public static List<string> GPView(string GP_name)
        {
            int position = 0;
            id = DictionaryPoints.GetGpId(GP_name);

            query.Add("--------------------------------------------------------------------------------------------------");
            query.Add(GP_name);
            query.Add("--------------------------------------------------------------------------------------------------");

            foreach (KeyValuePair<string, string> points in F1StatsXML.PointsRecord)
            {
                string points_value = points.Value;
                string points_id = points.Key;

                if (points_id.Contains(id))
                {
                    foreach (KeyValuePair<string, string> driver in F1StatsXML.Drivers)
                    {
                        string driver_id = driver.Key;
                        string driver_name = driver.Value;
                        if (points_id.Contains(driver_id))
                        {
                            position++;
                            query.Add(Convert.ToString(position).PadRight(10) + points_value.PadRight(15) + driver_name);
                        }
                    }
                }
            }
            query.Add("--------------------------------------------------------------------------------------------------");
            
            return query;
        }

        public static List<string> ViewStatistics()
        {
            List<string> Stats = new List<string>();
            Stats.Add("--------------------------------------------------------------------------------------------------");
            Stats.Add("Statistics");
            Stats.Add("--------------------------------------------------------------------------------------------------");
            Stats.Add((GetBestRt()));
            Stats.Add(GetBestDriver());
            Stats.Add(GetBestDriverWins());
            Stats.Add("--------------------------------------------------------------------------------------------------");

            return Stats;
        }

        public static string GetGpFirstPlace(string id)
        {
            string first_driver = "";

            foreach (KeyValuePair<string, string> points in F1StatsXML.PointsRecord)
            {
                string points_value = points.Value;
                string points_id = points.Key;

                if (points_id.Contains(id))
                {
                    foreach (KeyValuePair<string, string> driver in F1StatsXML.Drivers)
                    {
                        string driver_id = driver.Key;
                        string driver_name = driver.Value;
                        if (points_id.Contains(driver_id) && points_value == "25")
                        {
                            first_driver = driver_name;
                        }
                    }
                }
            }

            return first_driver;
        }

        public static string GetBestDriverWins()
        {
            
            int n_wins = 0; string wins_driver = "", driver_n = ""; 
            List<string> GpFirst = new List<string>();

            foreach (KeyValuePair<string, string> gp in F1StatsXML.GPs)
            {
                string gp_id = gp.Key;
                string gp_name = gp.Value;
                GpFirst.Add(GetGpFirstPlace(gp_id));
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
                    }
                }
                if (count > n_wins)
                {
                    n_wins = count;
                    driver_n = driver_name;
                }
            }
                

            wins_driver = "Driver with most races won (" + (n_wins).ToString() + "): " + driver_n; 
            return wins_driver;
        }

        public static int GetDriverPoints(string id)
        {
            int d_points = 0;

            foreach (KeyValuePair<string, string> points in F1StatsXML.PointsRecord)
            {
                string points_value = points.Value;
                string points_id = points.Key;

                if (points_id.Contains(id))
                {
                    foreach (KeyValuePair<string, string> gp in F1StatsXML.GPs)
                    {
                        string gp_id = gp.Key;
                        string gp_name = gp.Value;
                        if (points_id.Contains(gp_id))
                        {
                            d_points += int.Parse(points_value); 
                        }
                    }
                }
            }
            return d_points;
        }

        public static string GetBestDriver()
        {
            int max_point; string best_driver = "",
                                    driver_n = ""; bool comprovar = false;
            Dictionary<string, int> PointsD = new Dictionary<string, int>();

            foreach (KeyValuePair<string, string> driver in F1StatsXML.Drivers)
            {
                string driver_id = driver.Key;
                string driver_name = driver.Value;
                PointsD.Add(driver_name, GetDriverPoints(driver_id));
            }
            max_point = PointsD.Values.Max();

            while (!comprovar)
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

            best_driver = "Best Driver (" + (max_point).ToString() + "): " + driver_n;
            return best_driver;
        }

        public static int GetRtPoints(string id)
        {
            int points_p1 = 0,
                points_p2 = 0,
                total_points;
            List<string> RTDrivers = new List<string>();


            foreach (KeyValuePair<string, string> points in F1StatsXML.PointsRecord)
            {

                string points_value = points.Value;
                string points_id = points.Key;

                if (points_id.Contains(id))
                {
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
                                points_p1 += int.Parse(points_value);
                            }
                            else
                            {
                                points_p2 += int.Parse(points_value);
                            }
                        }
                    }
                }
            }
            total_points = points_p1 + points_p2;
            return total_points;
        }

        public static string GetBestRt()
        {
            int max_point; string best_rt = "",
                                  rt = ""; bool comprovar = false;
            Dictionary<string, int> PointsRt = new Dictionary<string, int>();

            foreach (KeyValuePair<string, string> rteam in F1StatsXML.RTeams)
            {
                string rteam_id = rteam.Key;
                string rteam_name = rteam.Value;
                PointsRt.Add(rteam_name, GetRtPoints(rteam_id));
            }
            max_point = PointsRt.Values.Max();

            while (!comprovar)
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

            best_rt = "Best Racing (" + (max_point).ToString() + "): " + rt;
            return best_rt;
        }

        public static List<string> SelectView(string selection1, string selection2)
        {
            List<string> QList = new List<string>();

            if (selection1 == "Grand Prix")            
            {
                QList = ShowData.GPView(selection2);
            }
            else if (selection1 == "Pilot")
            {
                QList = ShowData.DriversView(selection2);
            }
            else
            {
                QList = ShowData.RacingTeamView(selection2);
            }

            return QList;
        }

        public static void WriteTextBox(List<string> searchList, TextBox textBox)
        {

            textBox.Text = "";

            // Append each line from searchList to the textbox
            foreach (string line in searchList)
            {
                textBox.Text += line + Environment.NewLine;
            }
        }

        public static void UpdateNameMultiBox(string selection, ComboBox NameMultibox, Dictionary<string, string> GPs, Dictionary<string, string> Drivers, Dictionary<string, string> RTeams)
        {
            NameMultibox.SelectedIndex = -1;
            NameMultibox.Items.Clear();

            if (selection == "Grand Prix")
            {
                NameMultibox.Items.AddRange(GPs.Values.ToArray());
            }
            else if (selection == "Pilot")
            {
                NameMultibox.Items.AddRange(Drivers.Values.ToArray());
            }
            else
            {
                NameMultibox.Items.AddRange(RTeams.Values.ToArray());
            }
        }
    }
}
