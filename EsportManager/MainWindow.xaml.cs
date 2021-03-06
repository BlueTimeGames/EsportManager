﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EsportManager
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            /*BitmapImage image = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/pictures/menu.jpg", UriKind.Absolute));
            Background.Source = image;*/
            
            
        }

        private void LoadGameClick(object sender, RoutedEventArgs e)
        {
            LoadGame win2 = new LoadGame();
            win2.MainWindow = this;
            win2.ShowDialog();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame win2 = new NewGame();
            win2.Mainwindow = this;
            win2.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void Facebook_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/Blue-Time-Games-100409108142240/");
        }

        private void Discord_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/mZZKkkW");
        }

        private void Twitter_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/BlueTimeGames");
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (BlackStar.Visibility == Visibility.Hidden)
            {
                Gunny.Visibility = Visibility.Visible;
                BlackStar.Visibility = Visibility.Visible;
                Peta.Visibility = Visibility.Visible;
            }
            else
            {
                Gunny.Visibility = Visibility.Hidden;
                BlackStar.Visibility = Visibility.Hidden;
                Peta.Visibility = Visibility.Hidden;
            }
            
        }
    }
}
