using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalReports_G5
{
    class ShowData
    {
        public static string id;
        public static List<string> query = new List<string>();


        public static List<string> DriversView(string pilot_name)
        {
            id = DictionaryPoints.GetId(pilot_name);

            query.Add("-------------------------------------------------");
            query.Add(pilot_name);
            query.Add("-------------------------------------------------");

            foreach (KeyValuePair<string, string> points in F1StatsXML.PointsRecord )
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
                            query.Add(gp_name.PadRight(25) + points_value);
                        }
                    }
                }
            }
            query.Add("-------------------------------------------------");
            return query;
        }

        public static void Add2Append(List<string> searchList, List<string> append)
        {

            foreach (string line in searchList)
            {
                append.Add(line);
            }
        }

        public static void RacingTeamView()
        {
            
        }
        public static void ListView()
        {
            
        }
        public static void Classic()
        {

        }

    }
}
