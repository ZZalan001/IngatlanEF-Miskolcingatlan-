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

namespace IngatlanEF.IngatlanWindow
{
    /// <summary>
    /// Interaction logic for IngatlanFelvetelWindow.xaml
    /// </summary>
    public partial class IngatlanFelvetelWindow : Window
    {
        public IngatlanFelvetelWindow()
        {
            InitializeComponent();
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            Ingatlan ujIngatlan = new()
            {
                Id = 0,
                Telepules = tbxTelepules.Text,
                Cím = tbxCim.Text,
                Ar = int.Parse(tbxAr.Text),
                Tipus = cbxTipus.Text,
                KepNev = tbxKepNev.Text,
                UgyintezoId = int.Parse(cbxUgyintezo.Text)
            };
            IngatlanService.IngatlanInsert(ujIngatlan);
            MessageBox.Show("Sikeres rögzítés");
        }
    }
}
