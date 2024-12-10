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
        List<Ugyintezo> ugyintezoList = UgyintezoService.GetAllUgyintezo();
        public IngatlanFelvetelWindow()
        {
            InitializeComponent();
            cbxTipus.ItemsSource = MainWindow.tipusok;
            foreach (Ugyintezo ugyintezo in ugyintezoList)
            {
                cbxUgyintezo.Items.Add($"{ugyintezo.Id}: {ugyintezo.Nev}");
            }
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            int ujAr = 0;
            int ujUgyi = 0;
            if (int.TryParse(tbxAr.Text, out ujAr) && int.TryParse(cbxUgyintezo.Text, out ujUgyi))
            {
                Ingatlan ujIngatlan = new()
                {
                    Id = 0,
                    Telepules = tbxTelepules.Text,
                    Cím = tbxCim.Text,
                    Ar = ujAr,
                    Tipus = cbxTipus.Text,
                    KepNev = tbxKepNev.Text,
                    UgyintezoId = ujUgyi
                };
                IngatlanService.IngatlanInsert(ujIngatlan);
                MessageBox.Show("Sikeres rögzítés");
                tbxAr.Text = "";
                tbxCim.Text = "";
                tbxKepNev.Text = "";
                tbxTelepules.Text = "";
                cbxTipus.SelectedItem = "Beosztás alatt";
                cbxUgyintezo.Text = "";
            }
            else
            {
                MessageBox.Show("Nem megfelelő ár vagy nincs kiválasztott ügyintéző!");
            }
        }

        private void btnMegsem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
