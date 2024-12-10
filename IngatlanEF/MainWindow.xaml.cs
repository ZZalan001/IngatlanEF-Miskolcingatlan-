using IngatlanEF.IngatlanWindow;
using IngatlanEF.Models;
using IngatlanEF.UgyintezoWindow;
using Microsoft.Win32;
using System.IO;
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
        public const string jelszo = "a";
        public static bool isLogged = false;
        public static string logName = "";
        public static string[] tipusok = { "Lakóház", "Palota", "Építési telek","Raktárépület","Besorolás alatt" };
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
                menuExport.IsEnabled = true;
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
            IngatlanFelvetelWindow ingatlanFelvetelWindow = new IngatlanFelvetelWindow();
            ingatlanFelvetelWindow.ShowDialog();
        }

        private void IngatlanokModositasa(object sender, RoutedEventArgs e)
        {
            IngatlanModositWindow ingatlanModositWindow = new IngatlanModositWindow();
            ingatlanModositWindow.ShowDialog();
        }

        private void IngatlanokTorlese(object sender, RoutedEventArgs e)
        {
            IngatlanTorlesWindow ingatlanTorlesWindow = new IngatlanTorlesWindow();
            ingatlanTorlesWindow.ShowDialog();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                FileName = "export.txt",
                DefaultExt = "*.txt",
                Filter = "txt|*.txt"
            };
            if (sfd.ShowDialog() == true)
            {
                if (File.Exists(sfd.FileName))
                {
                    MessageBoxResult result =  MessageBox.Show("A fájl már létezik, felülírja?","Figyelmeztetés!",MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    
                    if(result == MessageBoxResult.Yes)
                    {

                        //using (var context = new MiskolcingatlanContext())
                        //{
                        //    try
                        //    {
                        //        List<Ingatlan> ingatlanok = context.Ingatlans.ToList();
                        //        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        //        {
                        //            foreach (Ingatlan ingatlan in ingatlanok)
                        //            {
                        //                sw.WriteLine($"{ingatlan.Telepules}, {ingatlan.Cím}\n" + $"{ingatlan.Ar}");
                        //            }
                        //            sw.Close();
                        //        }
                        //    }
                        //    catch
                        //    {

                        //    }
                        //}
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott állomány");
            }
        }
    }
}