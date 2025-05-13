using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace KütüphaneAdmin
{
    internal class Kutuphane
    {
        public static List<Kitaplar> KitaplarListesi = new List<Kitaplar>();
        public static bool ÜyeSorgulama(int id, int[] kullanicilar)
        {
            foreach (var item in kullanicilar)
            {
                if (item == id)
                {
                    return true;
                }
            }
            return false;
        }
        public static void UyeEkleme(List<Üyeler> ÜyelerListesi, ref int[] kullanicilar)
        {
            Console.Clear();
            Console.WriteLine("Lütfen adınızı ve soyadınızı giriniz: ");
            string isim;
            while (true)
            {
                bool uygun = true;
                isim = Console.ReadLine().Trim();
                for (int i = 0; i < isim.Length; i++)
                {
                    if (char.IsDigit(isim[i]) || char.IsSymbol(isim[i]) || char.IsPunctuation(isim[i]) || (char.IsWhiteSpace(isim[i]) && char.IsWhiteSpace(isim[i + 1])))
                    {
                        uygun = false;
                        break;
                    }
                }
                if (uygun)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                }
            }
            int yeniId;
            while (true)
            {
                Random _id = new Random();
                yeniId = _id.Next(10000000, 99999999);
                bool varmi = true;
                foreach (var item in kullanicilar)
                {
                    if (item == yeniId)
                    {
                        varmi = false;
                        break;
                    }
                }
                if (varmi)
                {
                    break;
                }
            }

            Üyeler yeniüye = new Üyeler(isim, yeniId);
            StreamWriter sw = new StreamWriter("Üyeler.txt", true);
            sw.WriteLine(isim + ";" + yeniId + ";0;");
            ÜyelerListesi.Add(yeniüye);
            Array.Resize(ref kullanicilar, kullanicilar.Length + 1);
            kullanicilar[kullanicilar.Length - 1] = yeniId;
            sw.Close();
            Console.WriteLine($"Üye olma işleminiz başarıyla gerçekleşmiştir! ID'niz: {yeniId}");
        }
        public static int ÜyeSayfasi(Üyeler ü, List<Kitaplar> KitaplarListesi)
        {
            while (true)
            {
                Console.WriteLine("Hangi işlemi yapmak istersiniz?");
                Console.WriteLine("1 - Kütüphanedeki Kitaplar\n2 - Üye Bilgileri\n3 - Kitap Sorgulama\n0 - Çıkış");
                Console.Write("Lütfen yapmak istediğiniz işlemi giriniz: ");
                string _seçenek;
                int seçenek;
                while (true)
                {
                    _seçenek = Console.ReadLine();
                    if (int.TryParse(_seçenek, out seçenek))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                    }
                }
                Console.Clear();
                if (seçenek == 1)
                {
                    Kitaplar.Goster(KitaplarListesi);
                }

                if (seçenek == 2)
                {
                    Üyeler.ÜyeGöster(ü);
                }

                if (seçenek == 3)
                {
                    Kitaplar.KitapSorgulama(KitaplarListesi);
                }
                if (seçenek == 0)
                {
                    return 0;
                }
            }
        }
        public static void Kütüphane_Bilgi(List<Üyeler> ÜyelerListesi, List<Kitaplar> KitaplarListesi)
        {
            Console.WriteLine($"Küthüphanede {ÜyelerListesi.Count} üye, {KitaplarListesi.Count} kitap bulunmaktadır.");
        }
        public static void KitapYükleme(List<Kitaplar> kitap, string[] KBilgi)
        {
            Kitaplar k = new Kitaplar(KBilgi[0], KBilgi[1], int.Parse(KBilgi[2]), Convert.ToBoolean(KBilgi[3]));
            kitap.Add(k);

        }
        public static int KitapEkleme(List<Kitaplar> KitaplarListesi, int[] kitaplar)
        {
            while (true)
            {
                Console.WriteLine("Lütfen eklemek istediğiniz kitabın adını giriniz: ");
                string Kisim;
                while (true)
                {
                    bool uygun = true;
                    Kisim = Console.ReadLine().Trim();
                    for (int i = 0; i < Kisim.Length; i++)
                    {
                        if (char.IsWhiteSpace(Kisim[i]) && char.IsWhiteSpace(Kisim[i + 1]))
                        {
                            uygun = false;
                            break;
                        }
                    }
                    if (uygun)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                    }
                }

                Console.WriteLine("Lütfen yazarının adını giriniz: ");
                string Yisim;
                while (true)
                {
                    bool uygun = true;
                    Yisim = Console.ReadLine().Trim();
                    for (int i = 0; i < Yisim.Length; i++)
                    {
                        if (char.IsDigit(Yisim[i]) || char.IsSymbol(Yisim[i]) || char.IsPunctuation(Yisim[i]) || (char.IsWhiteSpace(Yisim[i]) && char.IsWhiteSpace(Yisim[i + 1])))
                        {
                            uygun = false;
                            break;
                        }
                    }
                    if (uygun)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                    }
                }
                int yeniIsbn;
                while (true)
                {
                    Random _isbn = new Random();
                    yeniIsbn = _isbn.Next(10000000, 99999999);
                    bool varmi = true;
                    foreach (var item in kitaplar)
                    {
                        if (item == yeniIsbn)
                        {
                            varmi = false;
                            break;
                        }
                    }
                    if (varmi)
                    {
                        break;
                    }
                }
                Kitaplar yenikitap = new Kitaplar(Kisim, Yisim, yeniIsbn, true);
                StreamWriter sw = new StreamWriter("Kitaplar.txt", true);
                sw.WriteLine(Kisim + ";" + Yisim + ";" + yeniIsbn + ";" + "true");
                KitaplarListesi.Add(yenikitap);
                sw.Close();

                Console.WriteLine("Kitap ekleme işlemi başarıyla gerçekleşmiştir!");
                Console.Write("Başka kitap eklemek istermisiniz? (e/h):");

                while (true)
                {
                    string seçim = Console.ReadLine().ToLower().Trim();
                    if (seçim.Length == 1 && seçim == "e")
                    {
                        break;
                    }
                    else if (seçim.Length == 1 && seçim == "h")
                    {
                        return 0;
                    }
                    else
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                    }
                }
            }
        }
        public static void Geri_Dön(Page currentpage)
        {
            if (currentpage.NavigationService != null && currentpage.NavigationService.CanGoBack)
            {
                currentpage.NavigationService.GoBack();
            }
        }
        
    }
    
}
