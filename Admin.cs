using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace KütüphaneAdmin
{
    internal class Admin
    {
        public Admin(string[] a)
        {
            this.Sifre = a[0];
            this.AdminId = int.Parse(a[1]);
            this.GüvenlikSorusu = a[2];
            this.GüvenlikCevap = a[3];
        }
        private string? Sifre { get; set; }
        private int AdminId { get; set; }
        private string GüvenlikSorusu { get; set; }
        private string GüvenlikCevap { get; set; }

        public bool SifreKontrol(string girdi)
        {
            return girdi == Sifre;
        }
        public bool IdKontrol(int girdi)
        {
            return girdi == AdminId;
        }

        public int SifreDegis()
        {
            int sayac = 0;
            string? şifre1;
            while (true)
            {
                Console.Write("Lütfen ID'nizi giriniz: ");
                while (true)
                {
                    string? _id = Console.ReadLine();
                    int _Id;
                    if (int.TryParse(_id, out _Id) && IdKontrol(_Id))
                    {
                        break;
                    }
                    else
                    {
                        sayac++;
                        if (sayac == 2)
                        { return 1; }
                        Console.Write("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                    }
                }
                Console.Write("Lütfen şifrenizi giriniz: ");
                while (true)
                {
                    string? _şifre = Console.ReadLine();
                    if (_şifre == this.Sifre)
                    {
                        break;
                    }
                    else
                    {
                        sayac++;
                        if (sayac == 2)
                        { return 1; }
                        Console.Write("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                    }
                }
                Console.WriteLine($"Lütfen güvenlik sorusuna ilk harfi büyük olacak şekilde cevap veriniz.\n{this.GüvenlikSorusu}");
                while (true)
                {
                    string? _soru = Console.ReadLine();
                    if (_soru.Trim() == this.GüvenlikCevap)
                    {
                        break;
                    }
                    else
                    {
                        sayac++;
                        if (sayac == 2)
                        { return 1; }
                        Console.Write("Hatalı giriş! Lütfen tekrar deneyiniz: ");
                    }
                }
                while (true)
                {
                    string? şifre2;
                    Console.WriteLine("Lütfen yeni şifrenizi giriniz: ");
                    şifre1 = Console.ReadLine();
                    Console.WriteLine("Lütfen yeni şifrenizi tekrar giriniz: ");
                    şifre2 = Console.ReadLine();
                    if (şifre1 == şifre2)
                    {
                        string ADMİN = $"{şifre1};{this.AdminId};{this.GüvenlikSorusu};{this.GüvenlikCevap}";
                        this.Sifre = şifre1;
                        File.WriteAllText("AdminBilgileri.txt", ADMİN);
                        Console.WriteLine("Şifre değiştirme işlemi başarıyla gerçekleşmiştir!");
                        return 0;
                    }
                    else
                    {
                        Console.WriteLine("Girdiğiniz şifreler birbiriyle uyuşmamaktadır. Lütfen aynı şifreyi yazdığınızdan emin olunuz.");
                    }
                }
            }
        }

    }
}
