using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KütüphaneAdmin
{
    internal class Üyeler
    {
        public Üyeler(string ad, int id, int sayac, List<Kitaplar> kitap)
        {
            this.UyeAdi = ad;
            this.UyeId = id;
            this.AlinanKitap = sayac;
            this.Alinanlar = kitap;
        }

        public Üyeler(string ad, int id)
        {
            this.UyeAdi = ad;
            this.UyeId = id;
            this.AlinanKitap = 0;
            this.Alinanlar = new List<Kitaplar>();
        }
        public Üyeler() { }
        private string UyeAdi { get; set; }
        private int UyeId { get; set; }
        private List<Kitaplar> Alinanlar { get; set; }
        private int AlinanKitap { get; set; }

        public string GUyeAdi => UyeAdi;
        public int GUyeId => UyeId;
        public List<Kitaplar> GAlinanlar => Alinanlar;
        public int GAlinanKitap => AlinanKitap;

        public static void Goster(List<Üyeler> Üye)
        {
            Console.WriteLine("DEBUG: Goster() fonksiyonu çağrıldı."); // Debugging çıktısı
            Console.WriteLine($"{"İsim",-50}{"ID",-10}");
            for (int i = 0; i < 110; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
            foreach (var item in Üye)
            {
                Console.WriteLine($"{item.UyeAdi,-50}{item.UyeId,-10}\n");
            }
            Console.WriteLine("Ana menüye gitmek için bir tuşa basın...");
            Console.ReadKey();
        }
        public static void ÜyeYükleme(List<Üyeler> Üye, string[] UBilgi)
        {
            List<string> skitap;
            List<Kitaplar> kitaplar = new List<Kitaplar>();

            if (UBilgi.Length > 3 && !string.IsNullOrEmpty(UBilgi[3]))
            {
                skitap = new List<string>(UBilgi[3].Split(","));
                foreach (var item in Kutuphane.KitaplarListesi)
                {
                    foreach(var item2 in skitap)
                    {
                        if (item2.Equals(item.GKitapAdi))
                        {
                            Kitaplar k = item;
                            kitaplar.Add(item);
                        }
                    }
                }
                
            }

            Üyeler ü = new Üyeler(UBilgi[0], int.Parse(UBilgi[1]), int.Parse(UBilgi[2]), kitaplar);
            Üye.Add(ü);
        }

        public static Üyeler ÜyeyeDön(List<Üyeler> üye, int id)
        {
            return üye.Find(x => x.UyeId == id);
        }
        public static void ÜyeGöster(Üyeler ü)
        {
            Console.WriteLine($"{ü.UyeAdi} {ü.UyeId}\nAlınan Kitap Sayısı: {ü.AlinanKitap}\nALınan Kitaplar\n___________________");
            for (int i = 0; i < ü.Alinanlar.Count; i++)
            {
                Console.WriteLine(ü.Alinanlar[i]);
            }
            Console.WriteLine();
        }
        public Üyeler ÜyeGüncelle(string[] UBilgi)
        {
            this.AlinanKitap++;

            List<string> skitap = new List<string>();
            List<Kitaplar> kitaplar = new List<Kitaplar>();

            if (UBilgi.Length > 3 && !string.IsNullOrEmpty(UBilgi[3]))
            {
                skitap = new List<string>(UBilgi[3].Split(","));
                foreach (var item in Kutuphane.KitaplarListesi)
                {
                    foreach (var item2 in skitap)
                    {
                        if (item2.Equals(item.GKitapAdi))
                        {
                            Kitaplar k = item;
                            kitaplar.Add(item);
                        }
                    }
                }

            }
            this.Alinanlar = kitaplar;
            return this;
        }
        public static void ÜyeSorgulama(List<Üyeler> ÜyelerListesi)
        {
            List<Üyeler> ArananÜye = new List<Üyeler>();
            Console.Write("Lütfen aramak istediğiniz üyenin adını giriniz: ");
            string girdi = Console.ReadLine().Trim().ToLower();
            bool varmı = false;
            foreach (var item in ÜyelerListesi)
            {
                if (item.UyeAdi.ToLower().Contains(girdi))
                {
                    ArananÜye.Add(item);
                }
            }
            if (ArananÜye.Count != 0)
            {
                varmı = true;
            }
            if (varmı)
            {
                Console.WriteLine($"{"İsim",-50}{"ID",-10}");
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();
                foreach (var item in ArananÜye)
                {
                    Console.WriteLine($"{item.UyeAdi,-50}  {item.UyeId,-10}\n");
                }
            }
            else
            {
                Console.WriteLine("Aradığınız üye bulunamadı!");
            }
        }
    }
}
