using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transplantar.Models;

namespace Transplantar.Persistencia
{
    public class TransplantarContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public TransplantarContext(DbContextOptions op) : base(op)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(t => t.TipoUsuario)
                  .HasConversion(typeof(string));

            modelBuilder.Entity<Usuario>()
              .Property(o => o.Orgao)
                .HasConversion(typeof(string));

            modelBuilder.Entity<Usuario>()
              .Property(s => s.GrupoSanguineo)
                .HasConversion(typeof(string));
        }
    }
}
