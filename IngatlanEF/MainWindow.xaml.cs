﻿using IngatlanEF.IngatlanWindow;
using IngatlanEF.UgyintezoWindow;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IngatlanEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string jelszo = "Ananasz";
        public static bool isLogged = false;
        public static string logName = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogInOut(object sender, RoutedEventArgs e)
        {
            if (isLogged)
            {
                lblBejelentkezve.Content = "Bejelentkezve:";
                isLogged = false;
                mnuBelepes.Header = "Bejelentkezés";
            }
            else
            {
                //megnyitok egy új ablakot, ott bekérem a jelszót és a felhasználónevet
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                
                //ha az helyes, akkor
                //aktiválom a két másik menüpontot
                mnuIngatlanok.IsEnabled = true;
                mnuUgyintezok.IsEnabled = true;
                //kiíratom a felhasználó nevét
                lblBejelentkezve.Content = $"Bejelentkezve: {logName}";
                mnuBelepes.Header = "Kijelentkezés";
                //igazra állítom, hogy buzi aki olvassa
                
            }
        }

        private void IngatlanokListaja(object sender, RoutedEventArgs e)
        {
            IngatlanListaWindow ingatlanListaWindow = new IngatlanListaWindow();
            ingatlanListaWindow.ShowDialog();
        }

        private void UgyintezokListaja(object sender, RoutedEventArgs e)
        {
            UgyintezoListaWindow ugyintezoListaWindow = new UgyintezoListaWindow();
            ugyintezoListaWindow.ShowDialog();
        }

        private void UgyintezokFelvetele(object sender, RoutedEventArgs e)
        {
            UgyintezoFelvetelWindow ugyintezoFelvetelWindow = new UgyintezoFelvetelWindow();
            ugyintezoFelvetelWindow.ShowDialog();
        }

        private void UgyintezokModositas(object sender, RoutedEventArgs e)
        {
            UgyintezoModositasWindow ugyintezoModositasWindow = new UgyintezoModositasWindow();
            ugyintezoModositasWindow.ShowDialog();
        }

        private void UgyintezokTorlese(object sender, RoutedEventArgs e)
        {
            UgyintezoTorlesWindow ugyintezoTorlesWindow = new UgyintezoTorlesWindow();
            ugyintezoTorlesWindow.ShowDialog();
        }

        private void IngatlanokFelvetel(object sender, RoutedEventArgs e)
        {

        }

        private void IngatlanokModositasa(object sender, RoutedEventArgs e)
        {

        }

        private void IngatlanokTorlese(object sender, RoutedEventArgs e)
        {

        }
    }
}