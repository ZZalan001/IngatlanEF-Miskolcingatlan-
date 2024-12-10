using IngatlanEF.Models;
using IngatlanEF.Services;
using Mysqlx.Crud;
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
    /// Interaction logic for IngatlanModositWindow.xaml
    /// </summary>
    public partial class IngatlanModositWindow : Window
    {
        List<Ugyintezo> ugyintezoList = UgyintezoService.GetAllUgyintezo();
        List<Ingatlan> ingatlanok;
        public IngatlanModositWindow()
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

        private void btnMegsem_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            int ujAr = 0;
            int ujUgyi = 0;
            if (int.TryParse(tbxAr.Text, out ujAr) && int.TryParse(cbxUgyId.Text.Split(":")[0], out ujUgyi))
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
                IngatlanService.IngatlanUpdate(ujIngatlan);
                MessageBox.Show("Sikeres rögzítés");
            }
            CbxSelectFeltolt();
        }
    }
}
