﻿using System;
using System.Collections.Generic;
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

namespace IngatlanEF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLoginClick(object sender, RoutedEventArgs e)
        {
            if (tbxJelszo.Text == MainWindow.jelszo)
            {
                MainWindow.logName = tbxFelhNev.Text;
                MainWindow.isLogged = true;
                MessageBox.Show("Sikeres belépés","Siker!",MessageBoxButton.OK,MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Hibás adatok!","Hiba",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void BtnMegcemClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}