using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
        builder.ToTable("Producto");

        builder.Property(p => p.Id)
        
        .HasColumnName("IdProducto")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.Nombre)
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.Precio)
            .HasColumnName("Precio")
            .HasColumnType("double")
            .IsRequired();

        builder.Property(p => p.IdCategoriaFk)
            .HasColumnName("IdCategoriaFk")
            .HasColumnType("int")
            .IsRequired();
            
        builder.HasOne(p => p.CategoriaProductos)
            .WithMany(p => p.Productos)
            .HasForeignKey(p => p.IdCategoriaFk);

        builder.Property(p => p.Marca)
            .HasColumnName("Marca")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.UrlImagen)
            .HasColumnName("UrlImagen")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.StockDisponible)
            .HasColumnName("StockDisponible")
            .HasColumnType("int")
            .IsRequired();
        
        builder.HasData(
            new {
                Id = 1,
                Nombre = "Abrigo 01",
                Precio = 1000.0,
                IdCategoriaFk = 1,
                Marca = "Nike",
                UrlImagen = "aa",
                StockDisponible = 10
            },
            new {
                Id = 2,
                Nombre = "Camiseta 01",
                Precio = 500.0,
                IdCategoriaFk = 2,
                Marca = "Nike",
                UrlImagen = "aa",
                StockDisponible = 100
            },
            new {
                Id = 3,
                Nombre = "Pantalon 01",
                Precio = 1200.0,
                IdCategoriaFk = 3,
                Marca = "Nike",
                UrlImagen = "aa",
                StockDisponible = 30
            }
        );

        }
    }
}
