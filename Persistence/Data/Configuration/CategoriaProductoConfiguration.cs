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
                Nombre = "Electrónicos"
            },
            new {
                Id = 2,
                Nombre = "Ropa"
            },
            new {
                Id = 3,
                Nombre = "Hogar"
            },
            new {
                Id = 4,
                Nombre = "Deportes"
            },
            new {
                Id = 5,
                Nombre = "Juguetes"
            },
            new {
                Id = 6,
                Nombre = "Alimentos"
            },
            new {
                Id = 7,
                Nombre = "Libros"
            },
            new {
                Id = 8,
                Nombre = "Salud y Belleza"
            },
            new {
                Id = 9,
                Nombre = "Automotriz"
            },
            new {
                Id = 10,
                Nombre = "Muebles"
            }
        );

        }
    }
}
