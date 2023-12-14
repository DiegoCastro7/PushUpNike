using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ClienteCompraConfiguration : IEntityTypeConfiguration<ClienteCompra>
    {
        public void Configure(EntityTypeBuilder<ClienteCompra> builder)
        {
        builder.ToTable("ClienteCompra");

        builder.Property(p => p.Id)
        
        .HasColumnName("IdClienteCompra")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.IdClienteFk)
            .HasColumnName("IdClienteFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Clientes)
            .WithMany(p => p.ClienteCompras)
            .HasForeignKey(p => p.IdClienteFk);

        builder.Property(p => p.IdCompraFk)
            .HasColumnName("IdCompraFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Compras)
            .WithMany(p => p.ClienteCompras)
            .HasForeignKey(p => p.IdCompraFk);

        builder.Property(p => p.FechaTransaccion)
            .HasColumnName("FechaTransaccion")
            .HasColumnType("DateTime")
            .IsRequired();

        builder.Property(p => p.ValorTotalTransaccion)
            .HasColumnName("ValorTotalTransaccion")
            .HasColumnType("double")
            .IsRequired();

        builder.Property(p => p.IdMetodoPagoFk)
            .HasColumnName("IdMetodoPagoFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Pagos)
            .WithMany(p => p.ClienteCompras)
            .HasForeignKey(p => p.IdMetodoPagoFk);

        builder.Property(p => p.DireccionCliente)
            .HasColumnName("DireccionCliente")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();
        
        builder.HasData(
            new {
                Id = 1,
                IdClienteFk = 1,
                IdCompraFk = 1,
                FechaTransaccion = DateTime.Now,
                ValorTotalTransaccion = 50.0,
                IdMetodoPagoFk = 1,
                DireccionCliente = "Calle A, Ciudad"
            },
            new {
                Id = 2,
                IdClienteFk = 2,
                IdCompraFk = 2,
                FechaTransaccion = DateTime.Now,
                ValorTotalTransaccion = 75.0,
                IdMetodoPagoFk = 2,
                DireccionCliente = "Calle B, Ciudad"
            },
            new {
                Id = 3,
                IdClienteFk = 3,
                IdCompraFk = 3,
                FechaTransaccion = DateTime.Now,
                ValorTotalTransaccion = 100.0,
                IdMetodoPagoFk = 1,
                DireccionCliente = "Calle C, Ciudad"
            }
        );

        }
    }
}
