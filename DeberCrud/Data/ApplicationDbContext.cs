using DeberCrud.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeberCrud.Data
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
            builder.Entity<Persona>(en =>
            {
                en.HasKey(e => e.Codigo);
                en.Property(e => e.Nombre).HasMaxLength(100).IsUnicode(false);
                en.Property(e => e.Apellido).HasMaxLength(100).IsUnicode(false);
                en.Property(e => e.Direccion).HasMaxLength(250).IsUnicode(false);
            });

        }
    }
}
