﻿using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EsportManager
{
    /// <summary>
    /// Interakční logika pro Training.xaml
    /// </summary>
    public partial class Training : Window
    {
        string databaseName;
        List<TeamSection> sections;
        List<string> trainingTypes;

        public Training(string databasename)
        {
            databaseName = databasename;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            trainingTypes = new List<string>
            {
                "Volno",
                "Individuální",
                "Analýza",
                "Cvičný zápas"
            };
            sections = new List<TeamSection>();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select id_teamxsection, section.id_section, section.name from info join teamxsection on teamxsection.id_team=info.id_team join section on section.id_section=teamxsection.id_section order by section.id_section", conn);
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
            }
            SectionsCB.Items.Clear();
            for (int i = 0; i < sections.Count; i++)
            {
                SectionsCB.Items.Add(sections.ElementAt(i).SectionName);
            }
            if (SectionsCB.Items.Count > 0)
            {
                SectionsCB.SelectedIndex = 0;
            }
        }

        private void SetAllComboboxes()
        {
            MondayMorningCB.ItemsSource = trainingTypes;
            MondayAfternoonCB.ItemsSource = trainingTypes;
            MondayEveningCB.ItemsSource = trainingTypes;
            TuesdayMorningCB.ItemsSource = trainingTypes;
            TuesdayAfternoonCB.ItemsSource = trainingTypes;
            TuesdayEveningCB.ItemsSource = trainingTypes;
            WednesdayMorningCB.ItemsSource = trainingTypes;
            WednesdayAfternoonCB.ItemsSource = trainingTypes;
            WednesdayEveningCB.ItemsSource = trainingTypes;
            ThursdayMorningCB.ItemsSource = trainingTypes;
            ThursdayAfternoonCB.ItemsSource = trainingTypes;
            ThursdayEveningCB.ItemsSource = trainingTypes;
            FridayMorningCB.ItemsSource = trainingTypes;
            FridayAfternoonCB.ItemsSource = trainingTypes;
            FridayEveningCB.ItemsSource = trainingTypes;
            SaturdayMorningCB.ItemsSource = trainingTypes;
            SaturdayAfternoonCB.ItemsSource = trainingTypes;
            SaturdayEveningCB.ItemsSource = trainingTypes;
            SundayMorningCB.ItemsSource = trainingTypes;
            SundayAfternoonCB.ItemsSource = trainingTypes;
            SundayEveningCB.ItemsSource = trainingTypes;
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select type from training where id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                MondayMorningCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                MondayAfternoonCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                MondayEveningCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                TuesdayMorningCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                TuesdayAfternoonCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                TuesdayEveningCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                WednesdayMorningCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                WednesdayAfternoonCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                WednesdayEveningCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                ThursdayMorningCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                ThursdayAfternoonCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                ThursdayEveningCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                FridayMorningCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                FridayAfternoonCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                FridayEveningCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                SaturdayMorningCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                SaturdayAfternoonCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                SaturdayEveningCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                SundayMorningCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                SundayAfternoonCB.SelectedIndex = reader.GetInt32(0);
                reader.Read();
                SundayEveningCB.SelectedIndex = reader.GetInt32(0);
                reader.Close();
            }
                
        }

        private void SetBackgrounds(ComboBox combo, Grid grid)
        {
            /*switch (combo.SelectedIndex)
            {
                case 0:
                    grid.Background = Brushes.LightGreen;
                    break;
                case 1:
                    grid.Background = Brushes.LightSalmon;
                    break;
                case 2:
                    grid.Background = Brushes.LightBlue;
                    break;
                case 3:
                    grid.Background = Brushes.LightYellow;
                    break;
                default:
                    grid.Background = Brushes.Transparent;
                    break;
            }*/
            
        }

        private void SaveTraining(object sender, RoutedEventArgs e)
        {
            string com = "";
            com += "update training set type=" + MondayMorningCB.SelectedIndex + " where day=1 and time_of_day=1 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + MondayAfternoonCB.SelectedIndex + " where day=1 and time_of_day=2 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + MondayEveningCB.SelectedIndex + " where day=1 and time_of_day=3 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + TuesdayMorningCB.SelectedIndex + " where day=2 and time_of_day=1 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + TuesdayAfternoonCB.SelectedIndex + " where day=2 and time_of_day=2 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + TuesdayEveningCB.SelectedIndex + " where day=2 and time_of_day=3 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + WednesdayMorningCB.SelectedIndex + " where day=3 and time_of_day=1 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + WednesdayAfternoonCB.SelectedIndex + " where day=3 and time_of_day=2 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + WednesdayEveningCB.SelectedIndex + " where day=3 and time_of_day=3 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + ThursdayMorningCB.SelectedIndex + " where day=4 and time_of_day=1 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + ThursdayAfternoonCB.SelectedIndex + " where day=4 and time_of_day=2 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + ThursdayEveningCB.SelectedIndex + " where day=4 and time_of_day=3 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + FridayMorningCB.SelectedIndex + " where day=5 and time_of_day=1 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + FridayAfternoonCB.SelectedIndex + " where day=5 and time_of_day=2 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + FridayEveningCB.SelectedIndex + " where day=5 and time_of_day=3 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + SaturdayMorningCB.SelectedIndex + " where day=6 and time_of_day=1 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + SaturdayAfternoonCB.SelectedIndex + " where day=6 and time_of_day=2 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + SaturdayEveningCB.SelectedIndex + " where day=6 and time_of_day=3 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + SundayMorningCB.SelectedIndex + " where day=7 and time_of_day=1 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + SundayAfternoonCB.SelectedIndex + " where day=7 and time_of_day=2 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            com += "update training set type=" + SundayEveningCB.SelectedIndex + " where day=7 and time_of_day=3 and id_teamxsection=" + sections.ElementAt(SectionsCB.SelectedIndex).ID + ";";
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand(com, conn);
                command.ExecuteReader();
            }
            this.Close();
        }

        private void TrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void MondayMorningTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a,b);
        }

        

        private void MondayEveningTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void MondayAfternoonTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void SundayAfternoonTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void SundayEveningTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void SundayMorningTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void SaturdayEveningTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void SaturdayAfternoonTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void SaturdayMorningTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void FridayEveningTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void FridayAfternoonTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void FridayMorningCBTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void ThursdayEveningTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void ThursdayAfternoonTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void ThursdayMorningTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void WednesdayEveningTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void WednesdayAfternoonTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void WednesdayMorningTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void TuesdayEveningTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void TuesdayAfternoonTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void TuesdayMorningTrainingChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox a = (ComboBox)e.Source;
            Grid b = (Grid)a.Parent;
            SetBackgrounds(a, b);
        }

        private void SectionsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetAllComboboxes();
        }
    }
}
