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
    /// Interaction logic for IngatlanTorlesWindow.xaml
    /// </summary>
    public partial class IngatlanTorlesWindow : Window
    {
        List<Ugyintezo> ugyintezoList = UgyintezoService.GetAllUgyintezo();
        List<Ingatlan> ingatlanok;
        public IngatlanTorlesWindow()
        {
            InitializeComponent();
            CbxSelectFeltolt();
            cbxSelect.SelectedIndex = 0;
            cbxTipus.ItemsSource = MainWindow.tipusok;
            foreach (Ugyintezo ugyintezo in ugyintezoList)
            {
                cbxUgyId.Items.Add($"{ugyintezo.Id}: {ugyintezo.Nev}");
            }
        }

        private void CbxSelectFeltolt()
        {
            ingatlanok = IngatlanService.GetAllIngatlan();
            dgrIngatlanAdatok.ItemsSource = ingatlanok;
            cbxSelect.Items.Clear();
            foreach (Ingatlan ingatlan in ingatlanok)
            {
                cbxSelect.Items.Add($"{ingatlan.Id}: {ingatlan.Telepules}, {ingatlan.Cím}");
            }
            dgrIngatlanAdatok.Items.Refresh();
        }

        private void cbxSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //kiválasztott ingatlan megkeresése
            if (cbxSelect.SelectedIndex >= 0)
            {


                Ingatlan kivalasztott = ingatlanok.FirstOrDefault(i => i.Id == int.Parse(cbxSelect.SelectedItem.ToString().Split(":")[0]));
                //adatok megjelenítése a vezérlőn
                if (kivalasztott != null)
                {
                    tbxTelepules.Text = kivalasztott.Telepules;
                    tbxCim.Text = kivalasztott.Cím;
                    tbxAr.Text = kivalasztott.Ar.ToString();
                    tbxKepNev.Text = kivalasztott.KepNev;
                    cbxTipus.SelectedItem = MainWindow.tipusok.Contains(kivalasztott.Tipus) ? kivalasztott.Tipus : "Besorolás alatt";
                    cbxUgyId.SelectedItem = $"{kivalasztott.UgyintezoId}: {ugyintezoList.FirstOrDefault(u => u.Id == kivalasztott.UgyintezoId).Nev}";
                }
                else
                {
                    MessageBox.Show("Nincs kiválasztott elem!");
                }
            }
        }

        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMegsem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
