using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(p => p.Id)
                .HasColumnName("Id_Usuario")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Username)
                .HasColumnName("Username")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(p => p.Username)
            .IsUnique();

            builder.HasIndex(p => p.Email)
            .IsUnique();

            builder.Property(p => p.Password)
                .HasColumnName("Password")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasMany(p => p.RefreshTokens)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.UsuarioId);

            //se define la configuracion de la entidad UsuariosRoles
            builder
            .HasMany(p => p.Roles)
            .WithMany(p => p.Usuarios)
            .UsingEntity<UsuarioRoles> (
                j => j
                    .HasOne(p => p.Roles)
                    .WithMany(p => p.UsuarioRoles)
                    .HasForeignKey(p => p.RolId),

                j => j
                    .HasOne(p => p.Usuarios)
                    .WithMany(p => p.UsuarioRoles)
                    .HasForeignKey(p => p.UsuarioId),

                j => 
                    {
                        j.HasKey(p => new { p.UsuarioId, p.RolId});
                    }
            );

            builder.HasData(
                new {
                    Id = 1,
                    Username = "Diego Castro",
                    Email = "fercho11422@gmail.com",
                    Password = "123456"
                },
                new {
                    Id = 2,
                    Username = "Jennifer Aristizabal",
                    Email = "jennifer@gmail.com",
                    Password = "1234567"
                },
                new {
                    Id = 3,
                    Username = "Alexandra Castro",
                    Email = "alexandra@gmail.com",
                    Password = "1234568"
                }
            );

        }
    }
}
