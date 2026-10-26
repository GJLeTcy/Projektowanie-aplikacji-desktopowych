using Elektro_Bud.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Elektro_Bud
{
    public partial class MainWindow : Window
    {
        // To dla DataGrid żeby pokazywał liste produktów
        ObservableCollection<Produkt> listaProduktow = new ObservableCollection<Produkt>();
        int kolejneId = 1;

        public MainWindow()
        {
            InitializeComponent();
            DodajPrzykladoweDane();
            dgProdukty.ItemsSource = listaProduktow; // Podłączam listę do tabeli
        }

        private void DodajPrzykladoweDane()
        {
            listaProduktow.Add(new Produkt(kolejneId++, "Kabel YDYp 3x2,5", "Kable i przewody", 15, 189.99, "ElPar"));
            listaProduktow.Add(new Produkt(kolejneId++, "Żarówka LED 10W", "Oświetlenie", 120, 12.50, "【entity-Philips¦canonical_name=Philips】"));
            listaProduktow.Add(new Produkt(kolejneId++, "Gniazdko podwójne", "Gniazdka i wyłączniki", 45, 24.90, "OSPEL"));
        }

        private void buttonDodajClick(object sender, RoutedEventArgs e)
        {
            if (txtNazwa.Text == "")
            {
                MessageBox.Show("Podaj nazwę!");
                return;
            }

            int ilosc;
            if (int.TryParse(txtIlosc.Text, out ilosc) == false)
            {
                MessageBox.Show("Ilość musi być liczbą!");
                return;
            }

            double cena;
            if (double.TryParse(txtCena.Text, out cena) == false)
            {
                MessageBox.Show("Cena musi być liczbą!");
                return;
            }

            string kategoria = (cmbKategoria.SelectedItem as ComboBoxItem).Content.ToString();

            Produkt nowy = new Produkt(kolejneId++, txtNazwa.Text, kategoria, ilosc, cena, txtDostawca.Text);
            listaProduktow.Add(nowy);
            WyczyscPola();
        }

        private void buttonUsunClick(object sender, RoutedEventArgs e)
        {
            if (dgProdukty.SelectedItem == null)
            {
                MessageBox.Show("Zaznacz produkt do usunięcia!");
                return;
            }

            Produkt doUsuniecia = dgProdukty.SelectedItem as Produkt;
            listaProduktow.Remove(doUsuniecia);
            WyczyscPola();
        }

        private void buttonEdytujClick(object sender, RoutedEventArgs e)
        {
            if (dgProdukty.SelectedItem == null) return;

            Produkt zaznaczony = dgProdukty.SelectedItem as Produkt;
            zaznaczony.Nazwa = txtNazwa.Text;
            zaznaczony.Ilosc = int.Parse(txtIlosc.Text);
            zaznaczony.Cena = double.Parse(txtCena.Text);
            zaznaczony.Dostawca = txtDostawca.Text;

            dgProdukty.Items.Refresh();
        }

        private void dgProdukty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProdukty.SelectedItem == null) return;

            Produkt p = dgProdukty.SelectedItem as Produkt;
            txtNazwa.Text = p.Nazwa;
            txtIlosc.Text = p.Ilosc.ToString();
            txtCena.Text = p.Cena.ToString();
            txtDostawca.Text = p.Dostawca;
        }

        private void buttonWyczyscClick(object sender, RoutedEventArgs e)
        {
            WyczyscPola();
        }

        private void WyczyscPola()
        {
            txtNazwa.Text = "";
            txtIlosc.Text = "";
            txtCena.Text = "";
            txtDostawca.Text = "";
            txtBlad.Text = "";
            cmbKategoria.SelectedIndex = -1;
            dgProdukty.SelectedItem = null;
        }
    }
}
