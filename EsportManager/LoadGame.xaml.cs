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
    /// Interakční logika pro LoadGame.xaml
    /// </summary>
    public partial class LoadGame : Window
    {
        public MainWindow MainWindow { get; set; }
        string[] files;
        public LoadGame()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            InitializeComponent();
            LoadGames();
            LoadGameButton.IsEnabled = false;
        }
        

        private void LoadGames()
        {
            files = System.IO.Directory.GetFiles("./games/", "*.gam");
            for (int i = 0; i < files.Length; i++)
            {
                using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=./" + files.ElementAt(i) + ";"))
                {
                    conn.Open();
                    SQLiteCommand command = new SQLiteCommand("select team.name, date from info join team on team.id_team=info.id_team", conn);
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        GamesLB.Items.Add((files[i].Remove(files[i].Length - 4)).Substring(8) + ", " + reader.GetString(0) + ", " + reader.GetString(1)); //za to dopsat aktuální datum + tým, za který se hraje
                    }
                    conn.Close();
                }
            }
        }

        private void LoadGameClick(object sender, RoutedEventArgs e)
        {
            MainGame win2 = new MainGame("./games/" + (files[GamesLB.SelectedIndex].Remove(files[GamesLB.SelectedIndex].Length - 4)).Substring(8) + ".gam");
            MainWindow.Close();
            this.Close();
            win2.ShowDialog();
        }

        private void GameChange(object sender, SelectionChangedEventArgs e)
        {
            if (GamesLB.SelectedIndex == -1)
            {
                LoadGameButton.IsEnabled = false;
            }
            else
            {
                LoadGameButton.IsEnabled = true;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void GamesDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (GamesLB.SelectedIndex != -1)
            {
                MainGame win2 = new MainGame("./games/" + (files[GamesLB.SelectedIndex].Remove(files[GamesLB.SelectedIndex].Length - 4)).Substring(8) + ".gam");
                MainWindow.Close();
                this.Close();
                win2.ShowDialog();
            }
        }
    }
}
