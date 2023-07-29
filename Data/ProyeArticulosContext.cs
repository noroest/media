using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyeArticulos.Models;

namespace ProyeArticulos.Data
{
    public class ProyeArticulosContext : DbContext
    {
        public ProyeArticulosContext (DbContextOptions<ProyeArticulosContext> options)
            : base(options)
        {
        }

        public DbSet<ProyeArticulos.Models.Articulo> Articulo { get; set; } = default!;
    }
}
