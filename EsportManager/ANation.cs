using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportManager
{
    class ONation
    {
        public int IdNation { get; set; }
        public string Name { get; set; }

        public ONation(int id_nation, String name)
        {
            IdNation = id_nation;
            Name = name;
        }
        
    }

    class MNation
    {
        public List<ONation> Nations { get; set; }
        public List<ONation> ResidentalNations { get; set; }

        public MNation() 
        { 
            Nations = new List<ONation>(); 
            ResidentalNations = new List<ONation>(); 
        }

        public void getAllNations() 
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + GlobalAtributes.DatabaseName + ".cem;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("select * from v_nation;", conn);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Nations.Add(new ONation(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();
            }
        }

        public void getAllResidentialNations()
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + GlobalAtributes.DatabaseName + ".cem;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("select * from v_nationresidential;", conn);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ResidentalNations.Add(new ONation(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();
            }
        }
    }
}
