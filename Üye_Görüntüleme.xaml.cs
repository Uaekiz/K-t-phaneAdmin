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
    /// Üye_Görüntüleme.xaml etkileşim mantığı
    /// </summary>
    public partial class Üye_Görüntüleme : Page
    {
        List<Üyeler> ÜyelerListesi;
        public Üye_Görüntüleme()
        {
            InitializeComponent();
            string ÜyeBilgileri;
            int[] KullaniciID = new int[0];
            ÜyelerListesi = new List<Üyeler>();
            StreamReader sru = new StreamReader("Üyeler.txt");
            while ((ÜyeBilgileri = sru.ReadLine()) != null)
            {
                string[] Ubilgi = ÜyeBilgileri.Split(";");
                Üyeler.ÜyeYükleme(ÜyelerListesi, Ubilgi);
                Array.Resize(ref KullaniciID, KullaniciID.Length + 1);
                KullaniciID[KullaniciID.Length - 1] = int.Parse(Ubilgi[1]);
            }
            sru.Close();
            ÜyeTablosu.ItemsSource=ÜyelerListesi;

        }

        private void Geri_Dön(object sender, RoutedEventArgs e)
        {
            Kutuphane.Geri_Dön(this);
        }

        private void UArama(object sender, RoutedEventArgs e)
        {
            string aranan = Üye_Arama.Text.Trim().ToLower();
            List<Üyeler> ArananÜye = new List<Üyeler>();
            if (string.IsNullOrEmpty(aranan))
            {
                ÜyeTablosu.ItemsSource = ÜyelerListesi;
            }

            else
            {
                foreach (var item in ÜyelerListesi)
                {
                    if (item.GUyeAdi.ToLower().Contains(aranan) || item.GUyeId.Equals(aranan))
                    {
                        ArananÜye.Add(item);
                    }
                }
                ÜyeTablosu.ItemsSource = ArananÜye;
            }

        }

        private void ÜyeTablosu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ÜyeTablosu.SelectedItem is Üyeler seçilenüye)
            {
                Üye_İçeriği üyegöster = new Üye_İçeriği(seçilenüye);
                this.NavigationService.Navigate(üyegöster);

            }
        }
    }
}
