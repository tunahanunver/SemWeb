using Microsoft.EntityFrameworkCore;
using SemWeb.Models;

namespace SemWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Abonelik> Abonelikler { get; set; }
        public DbSet<Odeme> Odemeler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}