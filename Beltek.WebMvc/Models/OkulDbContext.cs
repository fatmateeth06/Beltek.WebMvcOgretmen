using Microsoft.EntityFrameworkCore;

namespace Beltek.WebMvc.Models
{
    public class OkulDbContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }

        public DbSet<Ogretmen> Ogretmenler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=OkulDBMVCDeneme;Integrated Security=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Numara).HasColumnType("varchar").HasMaxLength(15).IsRequired();//FluentApi
            modelBuilder.Entity<Ogrenci>().Property(o => o.Bolum).HasColumnType("varchar").HasMaxLength(30).IsRequired();//isrequired null olmasın demek


            modelBuilder.Entity<Ogretmen>().ToTable("tblOgretmenler");
            modelBuilder.Entity<Ogretmen>().Property(t => t.TcKimlik).HasColumnType("varchar").HasMaxLength(11).IsRequired();
            modelBuilder.Entity<Ogretmen>().HasKey(t => t.TcKimlik);
            modelBuilder.Entity<Ogretmen>().Property(t => t.Ad).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Ogretmen>().Property(t => t.Soyad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogretmen>().Property(t => t.Alan).HasColumnType("varchar").HasMaxLength(15).IsRequired();//FluentApi

        }
    }
}
