using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Adopciones.Models;

namespace Adopciones.DataContext
{
    public class MapMascotas : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.ToTable("Mascotas", "dbo");
            builder.HasKey(q => q.id);
            builder.Property(e => e.id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.nombre).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.descripcion).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.imagenURL).HasColumnType("nvarchar(max)").IsRequired();

            builder.HasOne(e => e.Refugio)
                .WithMany(e => e.Mascotas)
                .HasForeignKey(e => e.refugioId);
        }
    }
}
