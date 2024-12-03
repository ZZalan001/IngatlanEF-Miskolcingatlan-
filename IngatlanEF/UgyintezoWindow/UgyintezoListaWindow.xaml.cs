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
    /// Interaction logic for UgyintezoListaWindow.xaml
    /// </summary>
    public partial class UgyintezoListaWindow : Window
    {
        public UgyintezoListaWindow()
        {
            InitializeComponent();
            List<Ugyintezo> ugyintezok = UgyintezoService.GetAllUgyintezo();
            dgrUgyintezok.ItemsSource = ugyintezok;
        }

        private void BtnBezar(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
