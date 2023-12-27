namespace OkulApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ogr = new Ogrenci();
            Console.WriteLine("Öğrenci Adı giriniz");
            ogr.Ad = Console.ReadLine();
            Console.WriteLine("Soyad giriniz");
            ogr.Soyad = Console.ReadLine();
            Console.WriteLine("Numara giriniz");
            ogr.Numara = Console.ReadLine();
        }
    }

    class Ogrenci
    {
        public int Ogrenciid { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public string Numara { get; set; }
    }
}
