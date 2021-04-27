using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
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
    /// Interakční logika pro Window1.xaml
    /// </summary>
    public partial class NewGame : Window
    {
        public MainWindow Mainwindow { get; set; }
        List<TeamBasic> teamList = new List<TeamBasic>();
        MNation mNation;

        public NewGame()
        {
            mNation = new MNation();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            GetAllDatabasesToComboBox();
            CheckIfEnableStartButton();
        }

        private void GetAllDatabasesToComboBox()
        {
            string[] files = System.IO.Directory.GetFiles("./", "*.cem");
            for (int i = 0; i < files.Length; i++)
            {
                DatabaseComboBox.Items.Add(files[i].Substring(2, files[i].Length-6)); //za to dopsat aktuální datum + tým, za který se hraje
            }
        }

        private void CheckIfEnableStartButton()
        {
            if (TeamListLB.SelectedIndex == -1 || !CheckGameName())
            {
                StartButton.IsEnabled = false;
            }
            else
            {
                StartButton.IsEnabled = true;
            }
        }

        private bool CheckGameName()
        {
            if (GameNameTB.Text != "" && GameNameTB.Text.Length <= 10)
            {
                if (!CheckIfCharIsAlphabetic(GameNameTB.Text.ElementAt(0)))
                {
                    return false;
                }
                for (int i = 1; i < GameNameTB.Text.Count(); i++)
                {
                    if (!CheckIfCharIsAlphabeticOrNumeric(GameNameTB.Text.ElementAt(i)))
                    {
                        return false;
                    }
                }
                //existuje název?
                return !File.Exists(@".\games\" + GameNameTB.Text + ".gam" );
            }
            return false;
        }

        private bool CheckIfCharIsAlphabeticOrNumeric(char v)
        {
            return Char.IsLetterOrDigit(v);
        }

        private bool CheckIfCharIsAlphabetic(char v)
        {
            return Char.IsLetter(v);
        }

        private void GetAllNationsToComboBox()
        {
            teamList.Clear();
            mNation.Nations.Add(new ONation(0, "Všechny národnosti"));
            mNation.getAllResidentialNations();
            for (int i = 0; i < mNation.Nations.Count; i++)
            {
                NationsCB.Items.Add(mNation.Nations[i].Name);
            }
            NationsCB.SelectedIndex = 0;
        }



        private void AddTeamsToListBox()
        {
            teamList.Clear();
            TeamListLB.Items.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + DatabaseComboBox.SelectedItem + ".cem;"))
            {
                List<int> citiesList = new List<int>();
                SQLiteCommand command;
                conn.Open();
                if (NationsCB.SelectedIndex > 0) 
                { 
                    command = new SQLiteCommand("select id_team,team.name from team join city on team.id_city=city.id_city join nation on nation.id_nation=city.id_nation where team.name like '%" + TeamNameTW.Text + "%' and city.id_nation=" + mNation.Nations[NationsCB.SelectedIndex].IdNation + " order by team.name collate nocase;", conn);
                }
                else
                {
                    command = new SQLiteCommand("select id_team,name from team where name like '%" + TeamNameTW.Text + "%' order by name collate nocase", conn);
                }
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    teamList.Add(new TeamBasic(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();

                for (int i = 0; i < teamList.Count; i++)
                {
                    TeamListLB.Items.Add(teamList.ElementAt(i).Name);
                }
            }
            CheckIfEnableStartButton();
        }


        private void NationChangeComboBox(object sender, SelectionChangedEventArgs e)
        {
            AddTeamsToListBox();
        }

        private void TeamNameChangeTextView(object sender, TextChangedEventArgs e)
        {
            AddTeamsToListBox();
        }

        private void TeamListLBClickInto(object sender, SelectionChangedEventArgs e)
        {
            CheckIfEnableStartButton();
        }

        private void GameNameChange(object sender, TextChangedEventArgs e)
        {
            CheckIfEnableStartButton();
        }

        private void TeamListLB_MouseDown(object sender, MouseButtonEventArgs e)
        {
           // CheckIfEnableStartButton();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            File.Copy(@"./" + DatabaseComboBox.SelectedItem + ".cem", @"./games/" + GameNameTB.Text + ".gam");
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=./games/" + GameNameTB.Text + ".gam;"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("update info set id_team=" + teamList.ElementAt(TeamListLB.SelectedIndex).IdTeam + ", date='2019-01-01'", conn);
                command.ExecuteReader();
                command = new SQLiteCommand("select id_teamxsection from teamxsection join info on info.id_team=teamxsection.id_team", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                string com = "";
                while (reader.Read())
                {
                    for (int i = 1; i <= 7; i++)
                    {
                        for (int j = 1; j <= 3; j++)
                        {
                            com += "insert into training (day, time_of_day, type, id_teamxsection) values (" + i + "," + j + ",0," + reader.GetInt32(0) + ");";
                        }
                    }
                }
                reader.Close();
                command = new SQLiteCommand("select id_section from section", conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    com += "CREATE TABLE '2019match" + reader.GetInt32(0) + "' ('id_match'  INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,'id_teamxsection_home'  INTEGER NOT NULL,'id_teamxsection_away'  INTEGER NOT NULL,'home_score'    INTEGER,'away_score'    INTEGER,'match_date'    TEXT NOT NULL,'id_tournament' INTEGER NOT NULL,FOREIGN KEY('id_tournament') REFERENCES 'tournament'('id_tournament'),FOREIGN KEY('id_teamxsection_home') REFERENCES 'teamxsection'('id_teamxsection'),FOREIGN KEY('id_teamxsection_away') REFERENCES 'teamxsection'('id_teamxsection'));";
                    com += "CREATE TABLE '2019future_match" + reader.GetInt32(0) + "'('id_match'  INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,'id_home'   INTEGER NOT NULL,'id_away'   INTEGER NOT NULL,'type_home' INTEGER NOT NULL,'type_away' INTEGER NOT NULL,'date'  BLOB NOT NULL,'id_tournament' INTEGER NOT NULL,FOREIGN KEY('id_tournament') REFERENCES 'tournament'('id_tournament'));";
                }
                command = new SQLiteCommand(com, conn);
                command.ExecuteReader();
                MainGame win2 = new MainGame("./games/" + GameNameTB.Text + ".gam");
                Mainwindow.Close();
                this.Close();
                win2.ShowDialog();
            }
        }

        private void DatabaseChanged(object sender, SelectionChangedEventArgs e)
        {
            GlobalAtributes.DatabaseName = DatabaseComboBox.SelectedItem.ToString();
            GetAllNationsToComboBox();
            ComboBox c = (ComboBox)sender;
            if (c.SelectedIndex > -1)
            {
                TeamNameTW.IsEnabled = true;
                NationsCB.IsEnabled = true;
                TeamNameTW.Text = "";
                NationsCB.SelectedIndex = -1;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            Mainwindow.IsEnabled = true;
        }

        private void TeamListLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (StartButton.IsEnabled && TeamListLB.SelectedIndex > -1)
            {
                StartGame();
            }
        }
    }
}
