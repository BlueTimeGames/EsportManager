﻿using System;
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
    /// Interakční logika pro TournamentInfo.xaml
    /// </summary>
    public partial class TournamentInfoGroup : Window
    {
        class MatchDataGrid
        {
            public BitmapImage homeTeam { get; set; }
            public BitmapImage awayTeam { get; set; }
            public string score { get; set; }
            public MatchDataGrid(BitmapImage h, BitmapImage a, string s)
            {
                homeTeam = h;
                awayTeam = a;
                score = s;
            }
        }
        TournamentStandings standings = null;
        TournamentBracket bracket = null;
        List<MatchDataGrid> playedMatches = new List<MatchDataGrid>();
        string databaseName;
        int tournament;
        int year;
        int idSection;
        int system;
        bool openNextForm;
        public TournamentInfoGroup(string databaseNameI, int tournamentI, bool openNextFormI)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            databaseName = databaseNameI;
            tournament = tournamentI;
            openNextForm = openNextFormI;
            InitializeComponent();
            SetTournamentProperties();
            SetPlayedMatches();
            CreateStandings();
            SetIncomingMatches();
        }

        private void SetIncomingMatches()
        {
            int counter = 0;
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select ta.logo, tb.logo, m.id_teamxsection_home, m.id_teamxsection_away, m.id_match from '" + year + "match" + idSection + "' m join teamxsection a on a.id_teamxsection = m.id_teamxsection_home join teamxsection b on b.id_teamxsection = m.id_teamxsection_away join team ta on ta.id_team = a.id_team join team tb on tb.id_team = b.id_team where id_tournament=" + tournament + " and home_score is null limit 7;", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    byte[] data = (byte[])reader[0];
                    BitmapImage imageSource1 = new BitmapImage();
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        imageSource1.BeginInit();
                        imageSource1.StreamSource = ms;
                        imageSource1.CacheOption = BitmapCacheOption.OnLoad;
                        imageSource1.EndInit();
                    }

                    data = (byte[])reader[1];
                    BitmapImage imageSource2 = new BitmapImage();
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        imageSource2.BeginInit();
                        imageSource2.StreamSource = ms;
                        imageSource2.CacheOption = BitmapCacheOption.OnLoad;
                        imageSource2.EndInit();
                    }
                    Image i = new Image();
                    i.Width = 30;
                    i.Height = 30;
                    i.SnapsToDevicePixels = true;
                    i.Source = imageSource1;
                    i.HorizontalAlignment = HorizontalAlignment.Left;
                    i.VerticalAlignment = VerticalAlignment.Top;
                    i.Margin = new Thickness(10, 10 + (counter * 50), 0, 0);
                    MatchesIncoming.Children.Add(i);
                    Image i2 = new Image();
                    i2.Width = 30;
                    i2.Height = 30;
                    i2.HorizontalAlignment = HorizontalAlignment.Left;
                    i2.VerticalAlignment = VerticalAlignment.Top;
                    i2.Margin = new Thickness(90, 10 + (counter * 50), 0, 0);
                    i2.Source = imageSource2;
                    MatchesIncoming.Children.Add(i2);
                    Label sc = new Label();
                    sc.Content =  "-";
                    sc.HorizontalAlignment = HorizontalAlignment.Center;
                    sc.VerticalAlignment = VerticalAlignment.Top;
                    sc.FontSize = 13;
                    sc.Width = 40;
                    sc.Margin = new Thickness(0, 20 + (counter * 50), 0, 0);
                    sc.HorizontalContentAlignment = HorizontalAlignment.Center;
                    MatchesIncoming.Children.Add(sc);

                    counter++;
                }
            }
        }

        private void CreateStandings()
        {
            if (standings != null)
            {
                //standings.CreateStandings();
                Standings.ItemsSource = standings.standings;
            } 
            else
            {
                Standings.Visibility = Visibility.Hidden;
                if (system == 3 || system == 4)
                {
                    DrawBracket();
                }
            }
           
        }

        private void DrawBracket()
        {
            if (bracket.allMatches.Count > 0)
            {

            
            string[] roundsNames = new string[5] { "1. kolo", "Osmifinále", "Čtvrtfinále", "Semifinále", "Finále" };
            List<int> drawnObjects = new List<int>();
            for (int i = 0; i < bracket.allMatches.Last().Round; i++)
            {
                Label l = new Label();
                l.Content = roundsNames[5 - bracket.allMatches.Last().Round + i];
                l.HorizontalAlignment = HorizontalAlignment.Left;
                l.VerticalAlignment = VerticalAlignment.Top;
                l.FontSize = 14;
                l.Width = 100;
                l.Margin = new Thickness(20 + (i * 120), 50, 0, 0);
                l.HorizontalContentAlignment = HorizontalAlignment.Center;
                MainGrid.Children.Add(l);
            }
            int lastMatchRound = 0;
            int counter = 0;
            for (int i = 0; i < bracket.allMatches.Count; i++)
            {
                if (lastMatchRound!= bracket.allMatches.ElementAt(i).Round)
                {
                    counter = 0;
                }
                Label home = new Label();
                if (bracket.allMatches.ElementAt(i).HomeTeam != null)
                {
                    home.Content = bracket.allMatches.ElementAt(i).HomeTeam.TeamName;
                }
                else
                {
                    home.Content = "TBD";
                }
                home.HorizontalAlignment = HorizontalAlignment.Left;
                home.VerticalAlignment = VerticalAlignment.Top;
                home.FontSize = 13;
                home.Width = 100;
                home.Margin = new Thickness(20 + ((bracket.allMatches.ElementAt(i).Round-1) * 120), 70 + (counter * 80), 0, 0);
                home.HorizontalContentAlignment = HorizontalAlignment.Center;
                MainGrid.Children.Add(home);
                Label away = new Label();
                if (bracket.allMatches.ElementAt(i).AwayTeam != null)
                {
                    away.Content = bracket.allMatches.ElementAt(i).AwayTeam.TeamName;
                } else
                {
                    away.Content = "TBD";
                }
                away.HorizontalAlignment = HorizontalAlignment.Left;
                away.VerticalAlignment = VerticalAlignment.Top;
                away.FontSize = 13;
                away.Width = 100;
                away.Margin = new Thickness(20 + ((bracket.allMatches.ElementAt(i).Round - 1) * 120), 100 + (counter * 80), 0, 0);
                away.HorizontalContentAlignment = HorizontalAlignment.Center;
                MainGrid.Children.Add(away);
                lastMatchRound = bracket.allMatches.ElementAt(i).Round;
                counter++;
            }
            }
        }

        private void SetPlayedMatches()
        {
            int counter = 0;
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select ta.logo, tb.logo, m.id_teamxsection_home, m.id_teamxsection_away, m.id_match, m.home_score, m.away_score from '" + year + "match" + idSection +"' m join teamxsection a on a.id_teamxsection = m.id_teamxsection_home join teamxsection b on b.id_teamxsection = m.id_teamxsection_away join team ta on ta.id_team = a.id_team join team tb on tb.id_team = b.id_team where id_tournament=" + tournament + " and home_score not null order by m.match_date;", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // výpočet pro tabulku
                    /*if (standings != null)
                    {
                        standings.SetPlayedMatch(reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(5), reader.GetInt32(6));
                    }*/
                    
                    // vizuální stránka
                    if (counter < 7)
                    {
                        byte[] data = (byte[])reader[0];
                        BitmapImage imageSource1 = new BitmapImage();
                        using (MemoryStream ms = new MemoryStream(data))
                        {
                            imageSource1.BeginInit();
                            imageSource1.StreamSource = ms;
                            imageSource1.CacheOption = BitmapCacheOption.OnLoad;
                            imageSource1.EndInit();
                        }   
                        data = (byte[])reader[1];
                        BitmapImage imageSource2 = new BitmapImage();
                        using (MemoryStream ms = new MemoryStream(data))
                        {
                            imageSource2.BeginInit();
                            imageSource2.StreamSource = ms;
                            imageSource2.CacheOption = BitmapCacheOption.OnLoad;
                            imageSource2.EndInit();
                        }
                        Image i = new Image();
                        i.Width = 30;
                        i.Height = 30;
                        i.SnapsToDevicePixels = true;
                        i.Source = imageSource1;
                        i.HorizontalAlignment = HorizontalAlignment.Left;
                        i.VerticalAlignment = VerticalAlignment.Top;
                        i.Margin = new Thickness(10, 10+(counter*50), 0, 0);
                        MatchesPlayed.Children.Add(i);
                        Image i2 = new Image();
                        i2.Width = 30;
                        i2.Height = 30;
                        i2.HorizontalAlignment = HorizontalAlignment.Left;
                        i2.VerticalAlignment = VerticalAlignment.Top;
                        i2.Margin = new Thickness(90, 10 + (counter * 50), 0, 0);
                        i2.Source = imageSource2;
                        MatchesPlayed.Children.Add(i2);
                        Label sc = new Label();
                        sc.Content = reader.GetInt32(5) + " - " + reader.GetInt32(6);
                        sc.HorizontalAlignment = HorizontalAlignment.Center;
                        sc.VerticalAlignment = VerticalAlignment.Top;
                        sc.FontSize = 13;
                        sc.Width = 40;
                        sc.Margin = new Thickness(0, 20 + (counter * 50), 0, 0);
                        sc.HorizontalContentAlignment = HorizontalAlignment.Center;
                        MatchesPlayed.Children.Add(sc);
                    }
                    counter++;
                }
                reader.Close();
            }
        }

        private void SetTournamentProperties()
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select date from info;", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                year = int.Parse(reader.GetString(0).Substring(0, 4));
                reader.Close();
                command = new SQLiteCommand("select name,id_section,prize_pool,pp_teams,pp_dividing,system,drawn from tournament where id_tournament=" + tournament + ";", conn);
                reader = command.ExecuteReader();
                reader.Read();
                TournamentName.Content = reader.GetString(0);
                idSection = reader.GetInt32(1);
                system = reader.GetInt32(5);
                bool drawn = reader.GetInt32(6) == 1;
                if (system == 1 || system == 2 || system == 6)
                {
                    standings = new TournamentStandings(databaseName, tournament, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), system, idSection);
                } else if (system == 3 || system == 4)
                {
                    bracket = new TournamentBracket(databaseName, tournament, drawn, system, idSection);
                }
                reader.Close();
            }
        }

        private void ShowTeamDetail(object sender, MouseButtonEventArgs e)
        {
            DataGrid d = (DataGrid)sender;
            if (d.SelectedIndex > -1 && openNextForm)
            {
                TeamDetail win2 = new TeamDetail(databaseName, standings.standings.ElementAt(d.SelectedIndex).IdTeam);
                win2.ShowDialog();
            }
        }
    }
}
