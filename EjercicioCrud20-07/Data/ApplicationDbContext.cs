using EjercicioCrud20_07.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioCrud20_07.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Persona> Persona { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Persona>(va =>
            {
                va.HasKey(v => v.Codigo);

                va.Property(v => v.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                va.Property(v => v.Apellido)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                va.Property(v => v.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                va.Property(v => v.Estado)
                .IsRequired()
                //.HasMaxLength(250)
                .IsUnicode(false);


            });
        }

    }
}
