using IngatlanEF.Models;
using IngatlanEF.Services;
using System;
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

namespace IngatlanEF.UgyintezoWindow
{
    /// <summary>
    /// Interaction logic for UgyintezoModositasWindow.xaml
    /// </summary>
    public partial class UgyintezoModositasWindow : Window
    {
        public UgyintezoModositasWindow()
        {
            InitializeComponent();
            List<Ugyintezo> ugyintezok = UgyintezoService.GetAllUgyintezo();
            dgrUgyMod.ItemsSource = ugyintezok;
        }

        private void btnMent_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnMegsem_Click(object sender, RoutedEventArgs e)
        {
            tbxNevModosit.Clear();
            tbxTelefonModosit.Clear();
            tbxEmailModosit.Clear();
        }
    }
}
