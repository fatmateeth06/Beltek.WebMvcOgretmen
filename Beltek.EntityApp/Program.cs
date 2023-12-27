using Microsoft.EntityFrameworkCore;

namespace Beltek.EntityApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var ogr = new Ogrenci();
            //ogr.Ad = "Ahmet";
            //ogr.Soyad = "Mehmet";
            //ogr.Numara = "234";




            //try
            //{
            //    using (var ctx = new OkulDbContext())
            //    {
            //        ctx.Ogrenciler.Add(ogr);
            //        int sonuc = ctx.SaveChanges();
            //        Console.WriteLine(sonuc > 0 ? "Ekleme Başarılı!" : "Ekleme Başarısız!");
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally
            //{
            //    if (ctx != null)
            //    {
            //        ctx.Dispose();
            //    }
            //}

            //***SİLME İŞLEMİ***
            //using (var ctx = new OkulDbContext())
            //{
            //    var ogr = ctx.Ogrenciler.Find(3);
            //    ctx.Ogrenciler.Remove(ogr);
            //   int sonuc = ctx.SaveChanges();
            //    Console.WriteLine(sonuc > 0 ? "Silme işlemi Başarılı": "Başarısız");
            //}

            //***Update İşlemi***

            //using (var ctx = new OkulDbContext())
            //{
            //    var ogr = ctx.Ogrenciler.Find(2);
            //    ogr.Numara = "789";
            //    ctx.Entry(ogr).State = EntityState.Modified;
            //    int sonuc = ctx.SaveChanges();
            //    Console.WriteLine(sonuc > 0 ? "Güncelleme başarılı" : "Başarısız");
            //}

            //***Select İşlemi***

            using (var ctx = new OkulDbContext())
            {
                List<Ogrenci> lst = ctx.Ogrenciler.ToList();
                foreach (var o in lst)
                {
                    Console.WriteLine($"{o.Ad}-{o.Soyad}-{o.Numara}");
                }
            }

        }
    }

    class Ogrenci
    {
        public int Ogrenciid { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public string Numara { get; set; }
    }
    class OkulDbContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=OkulDBEF;Integrated Security=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(20).IsRequired();//null olamaz olarak işaretler (IsRequired) kaldırırsak null olabilir demek.
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(38).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Numara).HasColumnType("varchar").HasMaxLength(15).IsRequired();//FluentApi
        }


    }


}
//ENTITY FRAMEWORK
//ORM TOOL:Object Relational Mapping