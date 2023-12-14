using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
                    builder.ToTable("Cliente");

        builder.Property(p => p.Id)
        
        .HasColumnName("IdCliente")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.Nombres)
            .HasColumnName("Nombres")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Apellidos)
            .HasColumnName("Apellidos")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Direccion)
            .HasColumnName("Direccion")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.NroContacto)
            .HasColumnName("NroContacto")
            .HasColumnType("double")
            .IsRequired();
        
        
        
        
        
        
        
        
        
        
        builder.HasData(
            new {
                Id = 1,
                Nombres = "Diego Fernando",
                Apellidos = "Castro Torres",
                Direccion = "Calle 15, Bucaramanga",
                NroContacto = 3115411220.0
            },
            new {
                Id = 2,
                Nombres = "Jennifer",
                Apellidos = "Aristizabal",
                Direccion = "Carrera 23, Piedecuesta",
                NroContacto = 3115422110.0
            },
            new {
                Id = 3,
                Nombres = "Alexandra",
                Apellidos = "Castro Torres",
                Direccion = "Calle 25, Giron",
                NroContacto = 3118473642.0
            }
        );

        }
    }
}
