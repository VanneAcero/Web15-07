using EjercicioCrud20_07.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioCrud20_07.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserRole, string>
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("Genero");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Persona__06370DAD99F7AEF7");

                entity.ToTable("Persona");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoGeneroNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.CodigoGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Genero");
            });
        }

    }
}
