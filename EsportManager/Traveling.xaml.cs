using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EsportManager
{
    /// <summary>
    /// Interaction logic for Traveling.xaml
    /// </summary>
    public partial class Traveling : Window
    {
        MCity mCity;
        string databaseName;
        int teamId;
        int teamHomeCity;
        List<TeamSection> sections;
        public Traveling(string databaseNameI, int teamIdI)
        {
            databaseName = databaseNameI;
            teamId = teamIdI;
            sections = new List<TeamSection>();
            mCity = new MCity();
            InitializeComponent();
            SetComboBoxes();
            
        }

        private void SetComboBoxes()
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select teamxsection.id_teamxsection, section.id_section, name from section join teamxsection on teamxsection.id_section=section.id_section where id_team=" + teamId + " order by section.id_section;", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                int sectionBefore = -1;
                while (reader.Read())
                {
                    if (sectionBefore == reader.GetInt32(1))
                    {
                        //je to B tým
                        sections.Add(new TeamSection(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2) + " B"));
                    }
                    else
                    {
                        //je to A tým
                        sections.Add(new TeamSection(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2)));
                    }

                    sectionBefore = reader.GetInt32(1);
                }
                reader.Close();

                mCity.getAllCities();
            }
            for (int i = 0; i < sections.Count; i++)
            {
                SectionsCB.Items.Add(sections.ElementAt(i).SectionName);
            }
            for (int i = 0; i < mCity.Cities.Count; i++)
            {
                CitiesCB.Items.Add(mCity.Cities[i].Name);
            }
            SectionsCB.SelectedIndex = 0;
            CitiesCB.SelectedIndex = 0;
        }

        private void SectionChange(object sender, SelectionChangedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select teamxsection.id_city, team.id_city from teamxsection join team on team.id_team=teamxsection.id_team where id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    teamHomeCity = reader.GetInt32(1);
                    GetHome.IsEnabled = !(reader.GetInt32(0) == reader.GetInt32(1));
                }
                reader.Close();
            }
        }

        private void CityChange(object sender, SelectionChangedEventArgs e)
        {
            Move.IsEnabled = !(mCity.Cities[CitiesCB.SelectedIndex].ID == teamHomeCity);
        }

        private void MovePlayers(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Vážně chcete přesunout tým do " + mCity.Cities[CitiesCB.SelectedIndex].Name + ". Cesta stojí 5000$ a každý den mimo gaming house stojí 1000$.", "Chystáte se přesunout tým.", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("update teamxsection set id_city=" + mCity.Cities[CitiesCB.SelectedIndex].ID + " where id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";", conn);
                command.ExecuteReader();
                command = new SQLiteCommand("update team set budget=budget-5000 where id_team=" + teamId + ";", conn);
                command.ExecuteReader();
            }
            this.Close();
        }

        private void MovePlayersHome(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Vážně chcete přesunout tým do domovského města? Cesta stojí 5000$.", "Chystáte se přesunout tým.", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("update teamxsection set id_city=" + teamHomeCity + " where id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";", conn);
                command.ExecuteReader();
                command = new SQLiteCommand("update team set budget=budget-5000 where id_team=" + teamId + ";", conn);
                command.ExecuteReader();
            }
            this.Close();
        }
    }
}
