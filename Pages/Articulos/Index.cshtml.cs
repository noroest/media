using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyeArticulos.Data;
using ProyeArticulos.Models;

namespace ProyeArticulos.Pages.Articulos
{
    public class IndexModel : PageModel
    {
        private readonly ProyeArticulos.Data.ProyeArticulosContext _context;

        public IndexModel(ProyeArticulos.Data.ProyeArticulosContext context)
        {
            _context = context;
        }

        public IList<Articulo> Articulo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Articulo != null)
            {
                Articulo = await _context.Articulo.ToListAsync();
            }
        }
    }
}
