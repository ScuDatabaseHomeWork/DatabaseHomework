using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeritbaniDeneme.Database.Entities;
using VeritbaniDeneme.Database.Mapping;

namespace VeritbaniDeneme.Database.Context
{
    public class VeritabaniOdevContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database = VeritabaniOdev;integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoktorMap());
            modelBuilder.ApplyConfiguration(new HastaMap());
            modelBuilder.ApplyConfiguration(new PersonelMap());
            modelBuilder.ApplyConfiguration(new PoliklinikMap());
            modelBuilder.ApplyConfiguration(new RandevuMap());
            modelBuilder.ApplyConfiguration(new RollerMap());
        }

        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Rol> Roller { get; set; }

    }
}
