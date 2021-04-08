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

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
