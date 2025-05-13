using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KütüphaneAdmin
{
    internal class Kitaplar
    {
        public Kitaplar(string ad, string yazar, int isbn, bool var)
        {
            this.KitapAdi = ad;
            this.YazarAdi = yazar;
            this.ISBN = isbn;
            this.Bulunma = var;
        }
        private Kitaplar() { }
        private string KitapAdi { get; set; }
        private string YazarAdi { get; set; }
        private int ISBN { get; set; }
        private bool Bulunma { get; set; }

        public string GKitapAdi => KitapAdi;
        public string GYazarAdi => YazarAdi;
        public int GISBN => ISBN;
        public bool GBulunma => Bulunma;

        public static void Goster(List<Kitaplar> kitap)
        {
            Console.WriteLine($"{"İsim",-50}{"Yazar Adı",-40}{"ISBN",-10}{"Bulunma Durumu"}");
            for (int i = 0; i < 110; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
            foreach (var item in kitap)
            {
                Console.Write($"{item.KitapAdi,-50}  {item.YazarAdi,-40} {item.ISBN,-15}");
                if (item.Bulunma)
                {
                    Console.WriteLine("Kütüphanede\n");
                }
                else
                {
                    Console.WriteLine("Alınmış\n");
                }
            }
            Console.WriteLine("Ana menüye gitmek için bir tuşa basın...");
            Console.ReadKey();
        }
        public static void DurumDeğiştir(List<Kitaplar> KitaplarListesi, int[] KitapISBN, List<Üyeler> ÜyelerLİstesi, int[] ÜyeID)
        {
            Console.WriteLine("1 - Ödünç Verme\n2 - Ödünç İade\n Lütfen yapmak itediğiniz işlemi seçiniz: ");
            string _seçenek;
            int seçenek;
            while (true)
            {
                _seçenek = Console.ReadLine();
                if (int.TryParse(_seçenek, out seçenek) && seçenek <= 2 && seçenek >= 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                }
            }
            if (seçenek == 1)
            {
                Console.WriteLine("Lütfen kitabı alacak üyenin Id'sini giriniz: ");
                string _üyeID;
                int üyeID;
                Üyeler ü;
                while (true)
                {
                    _üyeID = Console.ReadLine();
                    if (int.TryParse(_üyeID, out üyeID))
                    {
                        if (Kutuphane.ÜyeSorgulama(üyeID, ÜyeID))
                        {
                            ü = Üyeler.ÜyeyeDön(ÜyelerLİstesi, üyeID);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                    }
                }

                Console.Write("Lütfen iade edilecek kitabın ISBN'ını giriniz: ");
                string _inputisbn;
                int isbn;
                while (true)
                {
                    _inputisbn = Console.ReadLine();
                    if (_inputisbn.Length == 9 && int.TryParse(_inputisbn, out isbn))
                    {
                        bool varmı = false;
                        foreach (var item in KitapISBN)
                        {
                            if (item == isbn)
                            {
                                varmı = true;
                                break;
                            }
                        }
                        if (varmı)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                    }
                }
                Kitaplar kitap = KitaplarListesi.Find(x => x.ISBN == isbn);
                List<string> üyeler = File.ReadAllLines("Üyeler.txt").ToList();
                for (int i = 0; i < üyeler.Count; i++)
                {
                    string[] üproperty = üyeler[i].Split(";");
                    if (int.Parse(üproperty[1]) == üyeID)
                    {
                        üproperty[3] = üproperty[3] + $",{kitap.KitapAdi}";
                        ü.ÜyeGüncelle(üproperty);
                        üyeler[i] = string.Join(";", üproperty);
                        break;
                    }
                }
                File.WriteAllLines("Üyeler.txt", üyeler);
                List<string> kitaplar = File.ReadAllLines("Kitaplar.txt").ToList();
                for (int i = 0; i < kitaplar.Count; i++)
                {
                    string[] kproperty = kitaplar[i].Split(";");
                    if (int.Parse(kproperty[2]) == kitap.ISBN)
                    {
                        kproperty[3] = "false";
                        kitap.Bulunma = false;
                        kitaplar[i] = string.Join(";", kproperty);
                        break;
                    }
                }
                File.WriteAllLines("Kitaplar.txt", kitaplar);
            }
            if (seçenek == 2)
            {
                Console.Write("Lütfen iade edilecek kitabın ISBN'ını giriniz: ");
                string _inputisbn;
                int isbn;
                while (true)
                {
                    _inputisbn = Console.ReadLine();
                    if (_inputisbn.Length == 9 && int.TryParse(_inputisbn, out isbn))
                    {
                        bool varmı = false;
                        foreach (var item in KitapISBN)
                        {
                            if (item == isbn)
                            {
                                varmı = true;
                                break;
                            }
                        }
                        if (varmı)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                    }
                }
                Kitaplar kitap = KitaplarListesi.Find(x => x.ISBN == isbn);
                List<string> kitaplar = File.ReadAllLines("Kitaplar.txt").ToList();
                for (int i = 0; i < kitaplar.Count; i++)
                {
                    string[] kproperty = kitaplar[i].Split(";");
                    if (int.Parse(kproperty[2]) == kitap.ISBN)
                    {
                        kproperty[3] = "true";
                        kitap.Bulunma = true;
                        kitaplar[i] = string.Join(";", kproperty);
                        break;
                    }
                }
                File.WriteAllLines("Kitaplar.txt", kitaplar);
            }
        }
        public static void KitapSorgulama(List<Kitaplar> KitaplarListesi)
        {
            List<Kitaplar> ArananKitap = new List<Kitaplar>();
            Console.Write("Lütfen aramak istediğiniz kitabın adını giriniz: ");
            string girdi = Console.ReadLine().Trim().ToLower();
            bool varmı = false;
            foreach (var item in KitaplarListesi)
            {
                if (item.KitapAdi.ToLower().Contains(girdi))
                {
                    ArananKitap.Add(item);

                }
            }
            if (ArananKitap.Count != 0)
            {
                varmı = true;
            }
            if (varmı)
            {
                Console.WriteLine($"{"İsim",-50}{"Yazar Adı",-40}{"Bulunma Durumu"}");
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();
                foreach (var item in ArananKitap)
                {
                    Console.Write($"{item.KitapAdi,-50}  {item.YazarAdi,-40}");
                    if (item.Bulunma)
                    {
                        Console.WriteLine("Kütüphanede\n");
                    }
                    else
                    {
                        Console.WriteLine("Alınmış\n");
                    }

                }
            }
            else
            {
                Console.WriteLine("Aradığınız kitap bulunamadı!");
            }

        }
        public static int KitapGüncelleme(List<Kitaplar> KitaplarListesi, int[] KitapISBN)
        {
            while (true)
            {
                Console.Write("Lütfen bilgilerini değiştirmek istediğiniz kitabın ISBN'ını giriniz: ");
                string _inputisbn;
                int isbn;
                while (true)
                {
                    _inputisbn = Console.ReadLine();
                    if (_inputisbn.Length == 9 && int.TryParse(_inputisbn, out isbn))
                    {
                        bool varmı = false;
                        foreach (var item in KitapISBN)
                        {
                            if (item == isbn)
                            {
                                varmı = true;
                                break;
                            }
                        }
                        if (varmı)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                    }
                }
                Kitaplar kitap = KitaplarListesi.Find(x => x.ISBN == isbn);

                Console.Write($"{kitap.KitapAdi}  {kitap.YazarAdi}  {kitap.ISBN}  ");
                if (kitap.Bulunma)
                {
                    Console.WriteLine("Kütüphanede");
                }
                else
                {
                    Console.WriteLine("Alınmış");
                }

                Console.WriteLine("Kitabın yazarını mı yoksa adını mı değiiştirmek istersiniz? ad(a)/yazar(y)");
                while (true)
                {
                    string seçim = Console.ReadLine().ToLower().Trim();
                    if (seçim.Length == 1 && seçim == "a")
                    {
                        Console.WriteLine("Lütfen kitabın yeni adını giriniz: ");
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
                        kitap.KitapAdi = Kisim;
                        List<string> satırlar = File.ReadAllLines("Kitaplar.txt").ToList();
                        for (int i = 0; i < satırlar.Count; i++)
                        {
                            string[] sütun = satırlar[i].Split(";");
                            if (sütun.Length > 0 && sütun[2] == _inputisbn)
                            {
                                sütun[0] = Kisim;
                                satırlar[i] = string.Join(";", sütun);
                                break;
                            }
                        }
                        File.WriteAllLines("Kitaplar.txt", satırlar);
                        Console.WriteLine("Kitap güncelleme işlemi başarıyla tamamlandı!");
                        break;

                    }
                    else if (seçim.Length == 1 && seçim == "y")
                    {
                        Console.WriteLine("Lütfen kitabın yeni yazarını giriniz: ");
                        string Yisim;
                        while (true)
                        {
                            bool uygun = true;
                            Yisim = Console.ReadLine().Trim();
                            for (int i = 0; i < Yisim.Length; i++)
                            {
                                if (char.IsWhiteSpace(Yisim[i]) && char.IsWhiteSpace(Yisim[i + 1]))
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
                        kitap.YazarAdi = Yisim;
                        List<string> satırlar = File.ReadAllLines("Kitaplar.txt").ToList();
                        for (int i = 0; i < satırlar.Count; i++)
                        {
                            string[] sütun = satırlar[i].Split(";");
                            if (sütun.Length > 0 && sütun[2] == _inputisbn)
                            {
                                sütun[1] = Yisim;
                                satırlar[i] = string.Join(";", sütun);
                                break;
                            }
                        }
                        File.WriteAllLines("Kitaplar.txt", satırlar);
                        Console.WriteLine("Kitap güncelleme işlemi başarıyla tamamlandı!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                    }
                }

                Console.Write("Başka kitap düzenlemek istermisiniz? (e/h):");

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
    }
}
