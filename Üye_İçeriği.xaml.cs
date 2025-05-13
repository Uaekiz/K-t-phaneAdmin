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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KütüphaneAdmin
{
    /// <summary>
    /// Üye_İçeriği.xaml etkileşim mantığı
    /// </summary>
    public partial class Üye_İçeriği : Page
    {
        internal Üye_İçeriği(Üyeler üye)
        {
            InitializeComponent();
            ÜyeAdıText.Text = üye.GUyeAdi;
            ÜyeIDText.Text = üye.GUyeId.ToString(); // Varsayım: ÜyeID bir int
            KitapSayısıText.Text = üye.GAlinanKitap.ToString(); // Varsayım
            KitapListesi.ItemsSource = üye.GAlinanlar; // Varsayım: Kitaplar bir liste

        }
        private void Geri_Dön(object sender, RoutedEventArgs e)
        {
            Kutuphane.Geri_Dön(this);
        }
    }
}
