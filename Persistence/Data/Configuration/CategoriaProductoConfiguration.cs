using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CategoriaProductoConfiguration : IEntityTypeConfiguration<CategoriaProducto>
    {
        public void Configure(EntityTypeBuilder<CategoriaProducto> builder)
        {
        builder.ToTable("CategoriaProducto");

        builder.Property(p => p.Id)
        
        .HasColumnName("IdCategoriaProducto")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.Nombre)
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired();
        
        builder.HasData(
            new {
                Id = 1,
                Nombre = "Jackets"
            },
            new {
                Id = 2,
                Nombre = "T-Shirts"
            },
            new {
                Id = 3,
                Nombre = "Pants"
            }
        );
        }
    }
}
