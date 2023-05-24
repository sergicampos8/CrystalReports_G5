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
                            if (RTDrivers.Count == 1)
                            {
                                total_points_1 += driver_points;
                            }
                            else if (RTDrivers.Count == 2)
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
            query.Add(GetBestRt());

            return query;
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
            int max_point; string best_rt = ""; bool comprovar = false; 
            Dictionary<string,int> PointsRt = new Dictionary<string,int>();
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
                        best_rt = name;
                        comprovar = true;
                    }
            }

            best_rt += " " + (max_point).ToString();
            return best_rt;
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
            return Stats;
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
