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
    /// Interaction logic for PlayerDetail.xaml
    /// </summary>
    public partial class PlayerDetail : Window
    {
        Player player;
        Coach coach;
        string databaseName;
        int myTeam;
        int playerID;
        int reputation;
        int budget;
        string date;
        bool isPlayer;
        public PlayerDetail(string databaseNameI, int playerI, bool player)
        {
            databaseName = databaseNameI;
            playerID = playerI;
            isPlayer = player;
            InitializeComponent();
            if (isPlayer)
            {
                SetPlayerProperties();
            }
            else
            {
                playerID = 0 - playerI;
                SetCoachProperties();
            }
            
        }

        private void SetCoachProperties()
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {

                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select coach.name, coach.nick, coach.surname, team.logo, team.name, section.name, coach.salary, coach.contractEnd, coach.value, team.id_team, coach.training, section.id_section from coach join team on coach.id_team=team.id_team join section on section.id_section=coach.id_section where coach.id_coach=" + playerID + ";", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    coach = new Coach(playerID, reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(5), reader.GetInt32(6), reader.GetString(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetString(4));

                    byte[] data = (byte[])reader[3];
                    BitmapImage imageSource = new BitmapImage();
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        imageSource.BeginInit();
                        imageSource.StreamSource = ms;
                        imageSource.CacheOption = BitmapCacheOption.OnLoad;
                        imageSource.EndInit();
                    }
                    TeamLogo.Source = imageSource;
                }
                reader.Close();
                command = new SQLiteCommand("select info.id_team, team.reputation, team.budget, info.date from info join team on info.id_team=team.id_team;", conn);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    myTeam = reader.GetInt32(0);
                    reputation = reader.GetInt32(1);
                    budget = reader.GetInt32(2);
                    date = reader.GetString(3);
                }
                reader.Close();
                // zjištění akce která se bude s trenér po stisknutí tlačítka dít
                if (coach.IdTeam == 0)
                {
                    // trenér je volný
                    PlayerAction.Click += SignFreeCoach;
                    PlayerAction.Content = "Podepsat trenéra";
                }
                else if (coach.IdTeam == myTeam)
                {
                    // trenér je členem týmu
                    PlayerAction.Click += DropCoach;
                    PlayerAction.Content = "Propustit trenéra";
                    PlayerResign.Visibility = Visibility.Visible;
                }
                else
                {
                    // trenér je členem týmu
                    PlayerAction.Click += BuyCoach;
                    PlayerAction.Content = "Koupit trenéra";
                }
            }
            Name.Content = coach.Name + " '" + coach.Nick + "' " + coach.Surname;
            Team.Content = coach.TeamName;
            Section.Content = coach.SectionName;
            Position.Visibility = Visibility.Hidden;
            PositionLabel.Visibility = Visibility.Hidden;
            Contract.Content = coach.Salary + "$";
            ContractEnd.Content = coach.ContractEnd;
            Value.Content = coach.Value + "$";
            Age.Visibility = Visibility.Hidden;
            AgeLabel.Visibility = Visibility.Hidden;
            Contract.Margin =  new Thickness(Contract.Margin.Left, Contract.Margin.Top - 62, Contract.Margin.Right, Contract.Margin.Bottom);
            ContractEnd.Margin =  new Thickness(ContractEnd.Margin.Left, ContractEnd.Margin.Top - 62, ContractEnd.Margin.Right, ContractEnd.Margin.Bottom);
            Value.Margin =  new Thickness(Value.Margin.Left, Value.Margin.Top - 62, Value.Margin.Right, Value.Margin.Bottom);
            ContractLabel.Margin =  new Thickness(ContractLabel.Margin.Left, ContractLabel.Margin.Top - 62, ContractLabel.Margin.Right, ContractLabel.Margin.Bottom);
            ContractEndLabel.Margin =  new Thickness(ContractEndLabel.Margin.Left, ContractEndLabel.Margin.Top - 62, ContractEndLabel.Margin.Right, ContractEndLabel.Margin.Bottom);
            ValueLabel.Margin =  new Thickness(ValueLabel.Margin.Left, ValueLabel.Margin.Top - 62, ValueLabel.Margin.Right, ValueLabel.Margin.Bottom);
        }

        private void BuyCoach(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DropCoach(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SignFreeCoach(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SetPlayerProperties()
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {

                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select player.name, player.nick, player.surname, team.logo, team.name, section.name, position_type.name, player.salary, player.contractEnd, player.value, team.id_team, player.individualSkill, player.teamplaySkill, player.id_teamxsection, section.id_section, player.playerCoop, player.birth_date from player join teamxsection on player.id_teamxsection=teamxsection.id_teamxsection join team on teamxsection.id_team=team.id_team join section on section.id_section=player.id_section join position_type on player.id_position=id_position_in_game and section.id_section=position_type.id_section where player.id_player=" + playerID + ";", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    player = new Player(playerID, reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetString(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11), reader.GetInt32(12), reader.GetInt32(13), reader.GetInt32(14), reader.GetInt32(15));
                    player.Age = GlobalMethodes.CountAge(GlobalMethodes.ParseDate(reader.GetString(16)), GlobalMethodes.ParseDate("2020-01-01"));


                    byte[] data = (byte[])reader[3];
                    BitmapImage imageSource = new BitmapImage();
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        imageSource.BeginInit();
                        imageSource.StreamSource = ms;
                        imageSource.CacheOption = BitmapCacheOption.OnLoad;
                        imageSource.EndInit();
                    }
                    TeamLogo.Source = imageSource;

                }
                else
                {
                    reader.Close();
                    command = new SQLiteCommand("select player.name, player.nick, player.surname, section.name, position_type.name, player.salary, player.contractEnd, player.value, player.individualSkill, player.teamplaySkill, section.id_section, player.playerCoop, player.birth_date from player join section on section.id_section=player.id_section join position_type on player.id_position=id_position_in_game and section.id_section=position_type.id_section where player.id_player=" + playerID + ";", conn);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        player = new Player(playerID, reader.GetString(0), reader.GetString(1), reader.GetString(2), "Volný hráč", reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6), reader.GetInt32(7), 0, reader.GetInt32(8), reader.GetInt32(9), 0, reader.GetInt32(10), reader.GetInt32(11));
                        player.Age = GlobalMethodes.CountAge(GlobalMethodes.ParseDate(reader.GetString(12)), GlobalMethodes.ParseDate("2020-01-01"));
                    }
                }
                reader.Close();
                Name.Content = player.Name + " '" + player.Nick + "' " + player.Surname;
                Team.Content = player.TeamName;
                Section.Content = player.SectionName;
                Position.Content = player.PositionName;
                Contract.Content = player.Salary + "$";
                ContractEnd.Content = player.ContractEnd;
                Value.Content = player.Value + "$";
                Age.Content = player.Age;

                command = new SQLiteCommand("select info.id_team, team.reputation, team.budget, info.date from info join team on info.id_team=team.id_team;", conn);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    myTeam = reader.GetInt32(0);
                    reputation = reader.GetInt32(1);
                    budget = reader.GetInt32(2);
                    date = reader.GetString(3);
                }
                reader.Close();
                // zjištění akce která se bude s hráčem po stisknutí tlačítka dít
                if (player.IdTeam == 0)
                {
                    // hráč je volný
                    PlayerAction.Click += SignFreePlayer;
                    PlayerAction.Content = "Podepsat hráče";
                }
                else if (player.IdTeam == myTeam)
                {
                    // hráč je členem týmu
                    PlayerAction.Click += DropPlayer;
                    PlayerAction.Content = "Propustit hráče";
                    PlayerResign.Visibility = Visibility.Visible;
                    command = new SQLiteCommand("select count(*) from teamxsection where id_team=" + myTeam + ";", conn);
                    reader = command.ExecuteReader();
                    if (reader.Read() && reader.GetInt32(0) > 1)
                    {
                        PlayerMove.Visibility = Visibility.Visible;
                    }
                    reader.Close();
                }
                else
                {
                    // hráč je členem týmu
                    PlayerAction.Click += BuyPlayer;
                    PlayerAction.Content = "Koupit hráče";
                }

            }
        }

        private void BuyPlayer(object sender, RoutedEventArgs e)
        {
            int year = int.Parse(date.Substring(0, 4));
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select count(*) from '" + year + "match" + player.IdSection + "' where match_date=" + date + " and (id_teamxsection_home=" + player.IdTeamSection + " or id_teamxsection_away=" + player.IdTeamSection + ");", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.GetInt32(0)!=0)
                {
                    MessageBox.Show("Nelze koupit hráče. Hráč má v tento den zápas.", "Podpis smlouvy", MessageBoxButton.OK);
                    return;
                }
                reader.Close();
            }
            if ((player.IndiSkill + player.TeamSkill) / 2 < reputation - 10 || (player.IndiSkill + player.TeamSkill) / 2 > reputation + 10)
            {
                MessageBox.Show("Hráč nemá zájem hrát ve vašem týmu", "Podpis smlouvy", MessageBoxButton.OK);
            }
            else if (budget < player.Value * 1.5)
            {
                MessageBox.Show("Nemáte dostatek financí na podpis hráče.", "Podpis smlouvy", MessageBoxButton.OK);
            }
            else
            {
                int newSalary = 1000 + (int)(((reputation * (player.IndiSkill + player.TeamSkill) / 2) - 3600) * 1.02);
                MessageBoxResult result = MessageBox.Show("Chystáte se vykoupit hráče " + player.Nick + ". " + player.TeamName + " po Vás požaduje " + player.Value * 1.5 + "$. Jeho smlouva je na rok za " + newSalary + "$ měsíčně. Chcete smlouvu podepsat?", "Podpis smlouvy", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    year++;
                    player.ContractEnd = year.ToString() + player.ContractEnd.Remove(0, 4);
                    int playerValue = (newSalary * 100 / 3);
                    playerValue = playerValue / 100;
                    playerValue = playerValue * 100;
                    using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
                    {
                        conn.Open();
                        SQLiteCommand command = new SQLiteCommand("update player set id_teamxsection=" + myTeam + ", contractEnd='" + player.ContractEnd + "', value=" + playerValue + ", salary=" + newSalary + " where id_player=" + playerID + ";" +
                            " update team set budget=budget-" + player.Value*1.5 + " where id_team=" + myTeam + ";", conn);
                        command.ExecuteReader();
                    }
                    this.Close();
                }
            }
        }

        private void DropPlayer(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete propustit hráče " + player.Nick + "? Rozvázání smlouvy Vás bude stát " + player.Salary * 2 + "$.", "Rozvázání smlouvy", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (budget < player.Salary * 2)
                {
                    MessageBox.Show("Nemáte dostatek financí na propuštění hráče.", "Podpis smlouvy", MessageBoxButton.OK);
                }
                else
                {
                    using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
                    {
                        conn.Open();
                        SQLiteCommand command = new SQLiteCommand("update player set id_teamxsection=null, contractEnd='', value=0, salary=0 where id_player=" + playerID + ";" +
                            " update team set budget=budget-" + player.Salary*2 + " where id_team=" + myTeam + ";", conn);
                        command.ExecuteReader();
                    }
                    this.Close();
                }
            }
        }

        private void SignFreePlayer(object sender, RoutedEventArgs e)
        {
            if ((player.IndiSkill + player.TeamSkill) / 2 < reputation - 15 || (player.IndiSkill + player.TeamSkill) / 2 > reputation + 15)
            {
                MessageBox.Show("Hráč nemá zájem hrát ve vašem týmu", "Podpis smlouvy", MessageBoxButton.OK);
            }
            else if (budget < 0)
            {
                MessageBox.Show("Nemáte dostatek financí na podpis hráče.", "Podpis smlouvy", MessageBoxButton.OK);
            }
            else
            {
                int newSalary = 1000 + (int)(((reputation * (player.IndiSkill + player.TeamSkill) / 2) - 3600) * 1.02);
                MessageBoxResult result = MessageBox.Show("Chystáte se podepsat smlouvu s hráčem " + player.Nick + ". Jeho smlouva je na rok za " + newSalary + "$ měsíčně. Chcete smlouvu podepsat?", "Podpis smlouvy", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    int year = int.Parse(date.Substring(0,4));
                    year++;
                    player.ContractEnd = year.ToString() + date.Remove(0, 4);
                    int playerValue = (newSalary * 100 / 3);
                    playerValue = playerValue / 100;
                    playerValue = playerValue * 100;
                    using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
                    {
                        conn.Open();
                        SQLiteCommand command = new SQLiteCommand("update player set id_teamxsection=" + myTeam + ", contractEnd='" + player.ContractEnd + "', value=" + playerValue + ", salary=" + newSalary + " where id_player=" + playerID + ";", conn);
                        command.ExecuteReader();
                    }
                    this.Close();
                }
            }
        }

        private void MovePlayerToAnotherSection(object sender, RoutedEventArgs e)
        {
            int teamSecitonTo = 0;
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select id_teamxsection from teamxsection where id_team=" + myTeam + ";", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetInt32(0) == player.IdTeamSection)
                    {
                        reader.Read();
                        teamSecitonTo = reader.GetInt32(0);
                    } else
                    {
                        teamSecitonTo = reader.GetInt32(0);
                    }
                }
                reader.Close();
                command = new SQLiteCommand("update player set id_teamxsection=" + teamSecitonTo + " where id_player=" + player.IdPlayer + ";", conn);
                command.ExecuteReader();
            }
            this.Close();
        }

        private void ResignPlayer(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                if (player.PlayerCoop < 60)
                {
                    if (player.ContractEnd == date)
                    {
                        MessageBox.Show("Hráč je v týmu nespokojen. Dnes mu končí smlouva, a protože je nespokojen odchází.", "Podpis smlouvy", MessageBoxButton.OK);
                        SQLiteCommand command = new SQLiteCommand("update player set value = 0, salary = 0, id_teamxsection = NULL, contractEnd = '' where id_player = " + player.IdPlayer + ";", conn);
                        command.ExecuteReader();
                    }
                    else
                    {
                        MessageBox.Show("Hráč je v týmu nespokojen. Nemá zájem prodloužit smlouvu.", "Podpis smlouvy", MessageBoxButton.OK);
                    }
                } 
                else
                {
                    int newSalary = 1000 + (int)(((reputation * (player.IndiSkill + player.TeamSkill) / 2) - 3600) * 1.02);
                    MessageBoxResult result = MessageBox.Show("Chystáte se podepsat smlouvu s hráčem " + player.Nick + ". Jeho smlouva je na rok za " + newSalary + "$ měsíčně. Chcete smlouvu podepsat?", "Podpis smlouvy", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        int year = int.Parse(date.Substring(0, 4));
                        year++;
                        player.ContractEnd = year.ToString() + date.Remove(0, 4);
                        int playerValue = (newSalary * 100 / 3);
                        playerValue = playerValue / 100;
                        playerValue = playerValue * 100;
                        SQLiteCommand command = new SQLiteCommand("update player set contractEnd='" + player.ContractEnd + "', value=" + playerValue + ", salary=" + newSalary + ", playerCoop=70 where id_player=" + playerID + ";", conn);
                        command.ExecuteReader();
                        this.Close();
                    }
                }
            }
        }
    }
}
