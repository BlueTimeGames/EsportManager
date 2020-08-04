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
        public int Salary { get; set; }
        public int Value { get; set; }
        public string SectionName { get; set; }
        public string Nick { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContractEnd { get; set; }
        public string TeamName { get; set; }

        public Coach()
        { 
        }

        public Coach(int id, string name, string nick, string surname, string sectionName, int salary, string contractEnd, int value, int idTeam, int training, string teamName)
        {
            IdCoach = id;
            Name = name;
            Nick = nick;
            Surname = surname;
            Value = value;
            Training = training;
            Salary = salary;
            ContractEnd = contractEnd;
            IdTeam = idTeam;
            SectionName = sectionName;
            TeamName = teamName;
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
