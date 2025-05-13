using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KütüphaneAdmin
{
    /// <summary>
    /// Kitap_Görüntüleme.xaml etkileşim mantığı
    /// </summary>
    public partial class Kitap_Görüntüleme : Page
    {
        public Kitap_Görüntüleme()
        {
            InitializeComponent();
            
            KitapTablosu.ItemsSource = Kutuphane.KitaplarListesi;
        }
        private void Geri_Dön(object sender, RoutedEventArgs e)
        {
            Kutuphane.Geri_Dön(this);
        }
        private void KArama(object sender, RoutedEventArgs e) {
            string aranan=Kitap_Arama.Text.Trim().ToLower();
            List<Kitaplar> ArananKitap = new List<Kitaplar>();
            if (string.IsNullOrEmpty(aranan))
            {
                KitapTablosu.ItemsSource = Kutuphane.KitaplarListesi;
            }

            else
            {
                foreach (var item in Kutuphane.KitaplarListesi)
                {
                    if (item.GKitapAdi.ToLower().Contains(aranan) || item.GYazarAdi.ToLower().Contains(aranan) || item.GISBN.Equals(aranan))
                    {
                        ArananKitap.Add(item);
                    }
                }
                KitapTablosu.ItemsSource = ArananKitap;
            }

        }

        private void KitapTablosu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (KitapTablosu.SelectedItem is Kitaplar seçilenkitap )
            {
                Kitap_İçeriği kitapgöster = new Kitap_İçeriği(seçilenkitap);
                this.NavigationService.Navigate(kitapgöster);
            }
        }
    }
}
