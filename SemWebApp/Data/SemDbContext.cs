﻿using Microsoft.EntityFrameworkCore;
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
            base.OnModelCreating(modelBuilder);
        }
    }
}