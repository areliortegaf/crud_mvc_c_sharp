using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ejemplomvc.Models;

namespace ejemplomvc.Data
{
    public class Conexion : DbContext
    {
        public Conexion (DbContextOptions<Conexion> options)
            : base(options)
        {
        }

        public DbSet<ejemplomvc.Models.Usuario> Usuarios { get; set; }
    }
}