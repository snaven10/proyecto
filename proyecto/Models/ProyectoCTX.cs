using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
    public class ProyectoCTX:DbContext
    {
        public ProyectoCTX(DbContextOptions<ProyectoCTX> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UsuarioRol>().HasKey(x=>new { x.IdUsuario, x.IdRol });
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UsuarioRol> UsuarioRol { get; set; }
        public DbSet<Actividades> Actividades { get; set; }
    }
}
