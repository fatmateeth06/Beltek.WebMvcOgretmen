namespace Beltek.WebMvc.Models
{
    public class Ogrenci
    {

        public Ogrenci()
        {
                    
        }


        public Ogrenci(int ogrenciid, string ad, string soyad,string numara,string bolum)//parametreleri sağına yazdık
        {
            this.Ogrenciid = ogrenciid;
            this.Ad = ad;
            this.Soyad = soyad;
            this.Numara = numara;
            this.Bolum = bolum;
        }

        public Ogrenci(int ogrenciid, string ad, string soyad)
        {
            this.Ogrenciid = ogrenciid;
            this.Ad = ad;
            this.Soyad = soyad;
          
        }

        public string Bolum { get; set; }

        public int Ogrenciid { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Numara { get; set; }



        public override string ToString()
        {
            return $"Adı:{this.Ad} Soyadı:{this.Soyad} Id:{this.Ogrenciid}";
        }
    }
}
