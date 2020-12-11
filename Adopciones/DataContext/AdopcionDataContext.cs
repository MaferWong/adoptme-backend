using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Adopciones.Models;

namespace Adopciones.DataContext
{
    public class AdopcionDataContext : DbContext
    {
        public DbSet<Refugio> Refugios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WONG;DataBase=Adopciones;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapMascotas());
            base.OnModelCreating(modelBuilder);
        }
    }
}
