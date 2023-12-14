using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PagoConfiguration : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
        builder.ToTable("Pago");

        builder.Property(p => p.Id)
        
        .HasColumnName("IdPago")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.Nombre)
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
        

        
        builder.HasData(
            new {
                Id = 1,
                Nombre = "Tarjeta de Crédito"
            },
            new {
                Id = 2,
                Nombre = "Transferencia Bancaria"
            },
            new {
                Id = 3,
                Nombre = "PayPal"
            },
            new {
                Id = 4,
                Nombre = "Efectivo"
            },
            new {
                Id = 5,
                Nombre = "Cheque"
            },
            new {
                Id = 6,
                Nombre = "Tarjeta de Débito"
            }
        );

        }
    }
}
