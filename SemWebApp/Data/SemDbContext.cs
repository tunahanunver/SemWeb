using Microsoft.EntityFrameworkCore;
using SemWebApp.Models;

namespace SemWebApp.Data
{
    public class SemDbContext : DbContext
    {
        public SemDbContext(DbContextOptions<SemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Abonelik> Abonelikler { get; set; }
        public DbSet<Odeme> Odemeler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Kullanici - Randevu ilişkisi
            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Kullanici)
                .WithMany(k => k.Randevular)
                .HasForeignKey(r => r.KullaniciId)
                .OnDelete(DeleteBehavior.Restrict);

            // Ders - Randevu ilişkisi
            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Ders)
                .WithMany(d => d.Randevular)
                .HasForeignKey(r => r.DersId)
                .OnDelete(DeleteBehavior.Restrict);

            // Kullanici - Abonelik ilişkisi
            modelBuilder.Entity<Abonelik>()
                .HasOne(a => a.Kullanici)
                .WithMany(k => k.Abonelikler)
                .HasForeignKey(a => a.KullaniciId)
                .OnDelete(DeleteBehavior.Restrict);

            // Abonelik - Odeme ilişkisi
            modelBuilder.Entity<Odeme>()
                .HasOne(o => o.Abonelik)
                .WithMany(a => a.Odemeler)
                .HasForeignKey(o => o.AbonelikId)
                .OnDelete(DeleteBehavior.Restrict);

            // Kullanici - Odeme ilişkisi
            modelBuilder.Entity<Odeme>()
                .HasOne(o => o.Kullanici)
                .WithMany(k => k.Odemeler)
                .HasForeignKey(o => o.KullaniciId)
                .OnDelete(DeleteBehavior.Restrict);

            // Decimal alan tanımlamaları
            modelBuilder.Entity<Abonelik>()
                .Property(a => a.Fiyat)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Odeme>()
                .Property(o => o.Miktar)
                .HasPrecision(10, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}