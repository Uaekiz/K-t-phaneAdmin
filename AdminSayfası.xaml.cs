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
    /// AdminSayfası.xaml etkileşim mantığı
    /// </summary>
    public partial class AdminSayfası : Page
    {
        public AdminSayfası()
        {
            InitializeComponent();
            string KitapBilgileri;//Burada dosyadaki kitapları sisteme taratıyoruz
            int[] KitapISBN = new int[0];
            StreamReader srk = new StreamReader("Kitaplar.txt");
            while ((KitapBilgileri = srk.ReadLine()) != null)
            {
                string[] KBilgi = KitapBilgileri.Split(";");
                Kutuphane.KitapYükleme(Kutuphane.KitaplarListesi, KBilgi);
                Array.Resize(ref KitapISBN, KitapISBN.Length + 1);
                KitapISBN[KitapISBN.Length - 1] = int.Parse(KBilgi[2]);
            }
            srk.Close();
        }
        private void Kitap_Göster(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Kitap_Görüntüleme());
        }
        private void Üyeler_Göster(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Üye_Görüntüleme());
        }
    }
}
