using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportManager
{
    class OCity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ONation Nation { get; set; }

        public OCity (int id, string name, int idNation, string nation)
        {
            ID = id;
            Name = name;
            Nation = new ONation(idNation, nation);
        }
    }

    class MCity
    {
        public List<OCity> Cities { get; set; }

        public MCity() 
        { 
            Cities = new List<OCity>(); 
        }

        public void getAllCities()
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + GlobalAtributes.DatabaseName + ".gam;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("select * from v_city;", conn);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cities.Add(new OCity(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                }
                reader.Close();
            }
        }

        public void findCity(int id)
        {

        }
    }
}
