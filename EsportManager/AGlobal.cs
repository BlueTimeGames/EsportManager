using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportManager
{
    public class GlobalAtributes
    {
        public static string DatabaseName { get; set; }
        public static string Date { get; set; }
        public static int IDTeam { get; set; }
    }

    public class GlobalMethodes
    {
        public static void GetBasicInfo()
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + GlobalAtributes.DatabaseName))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select id_team, date from info;", conn);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    GlobalAtributes.IDTeam = reader.GetInt32(0);
                    GlobalAtributes.Date = reader.GetString(1);
                }
               /* else
                {
                    throw 
                }*/
                reader.Close();
            }
        }

        public static int[] ParseDate(string date)
        {
            int[] parsed = new int[3];
            parsed[0] = int.Parse(date.Substring(0, 4));
            parsed[1] = int.Parse(date.Substring(5, 2));
            parsed[2] = int.Parse(date.Substring(8, 2));
            return parsed;
        }

        public static int[] ParseDate()
        {
            int[] parsed = new int[3];
            parsed[0] = int.Parse(GlobalAtributes.Date.Substring(0, 4));
            parsed[1] = int.Parse(GlobalAtributes.Date.Substring(5, 2));
            parsed[2] = int.Parse(GlobalAtributes.Date.Substring(8, 2));
            return parsed;
        }

        public static int CountAge(int[] birthDate)
        {
            DateTime small = new DateTime(birthDate[0], birthDate[1], birthDate[2]);
            DateTime big = new DateTime(int.Parse(GlobalAtributes.Date.Substring(0, 4)), int.Parse(GlobalAtributes.Date.Substring(5, 2)), int.Parse(GlobalAtributes.Date.Substring(8, 2)));
            int i = 0;
            while (big > small)
            {
                small = small.AddYears(1);
                i++;
            }
            return i;
        }

        public static string FormatDate()
        {
            return int.Parse(GlobalAtributes.Date.Substring(8, 2)) + ". " + int.Parse(GlobalAtributes.Date.Substring(5, 2)) + ". " + int.Parse(GlobalAtributes.Date.Substring(0, 4));
        }

        public static string FormatDate(string date)
        {
            return int.Parse(date.Substring(8, 2)) + ". " + int.Parse(date.Substring(5, 2)) + ". " + int.Parse(date.Substring(0, 4));
        }
    }
}
