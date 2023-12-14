using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DetalleProductoConfiguration : IEntityTypeConfiguration<DetalleProducto>
    {
        public void Configure(EntityTypeBuilder<DetalleProducto> builder)
        {
        builder.ToTable("DetalleProducto");

        builder.Property(p => p.Id)
        
        .HasColumnName("IdDetalleProducto")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.IdProductoFk)
            .HasColumnName("IdProductoFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Productos)
            .WithMany(p => p.DetalleProductos)
            .HasForeignKey(p => p.IdProductoFk);

        builder.Property(p => p.DetallesAdicionalesProducto)
            .HasColumnName("DetallesAdicionalesProducto")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();
        

        builder.HasData(
            new {
                Id = 1,
                IdProductoFk = 1,
                DetallesAdicionalesProducto = "Detalles adicionales para Producto 1"
            },
            new {
                Id = 2,
                IdProductoFk = 2,
                DetallesAdicionalesProducto = "Detalles adicionales para Producto 2"
            },
            new {
                Id = 3,
                IdProductoFk = 3,
                DetallesAdicionalesProducto = "Detalles adicionales para Producto 3"
            }
        );

        }
    }
}
