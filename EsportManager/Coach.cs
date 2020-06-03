using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportManager
{
    class Coach
    {
        public int IdCoach { get; set; }
        public int IdTeam { get; set; }
        public int Training { get; set; }
        public int IdSection { get; set; }
        public string SectionName { get; set; }
        public string Nick { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Coach()
        { 
        }

        public Coach(string section, string nick, string name, string surname, int id_coach)
        {
            SectionName = section;
            Nick = nick;
            Name = name;
            Surname = surname;
            IdCoach = id_coach;
        }
    }
}
