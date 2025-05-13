using System.IO;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Admin admin;
        private int girişsayaç = 3;
        public MainWindow()
        {
            InitializeComponent();
            string AdminBilgiler; //Bu kısım sistem açıldığında adminin bilgilerini tekrar kontrol edip sisteme tanımlamak için
            StreamReader sra = new StreamReader("AdminBilgileri.txt");
            AdminBilgiler = sra.ReadLine();
            string[] ABilgi = AdminBilgiler.Split(";");
            admin = new Admin(ABilgi);
            sra.Close();
        }

        private void GirisYap_Click(object sender, RoutedEventArgs e)
        {
            string _id = IdTextBox.Text;
            int id;
            string şifre = PasswordTextBox.Password;
            if (int.TryParse(_id, out id) && admin.IdKontrol(id) && admin.SifreKontrol(şifre))
            {
                MainFrame.Navigate(new AdminSayfası());
            }
            else
            {
                girişsayaç--;
                IdTextBox.BorderBrush = Brushes.Red;
                IdTextBox.Background = Brushes.LightPink;
                PasswordTextBox.BorderBrush = Brushes.Red;
                PasswordTextBox.Background = Brushes.LightPink;
                IdTextBox.Clear();
                PasswordTextBox.Clear();
                if (girişsayaç==0)
                {
                    Application.Current.Shutdown();
                }
                MessageBox.Show("Hatalı giriş, tekrar deneyin!");
                IdTextBox.Clear();
            }
        }
    }
}