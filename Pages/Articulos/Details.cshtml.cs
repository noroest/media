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
    public class DetailsModel : PageModel
    {
        private readonly ProyeArticulos.Data.ProyeArticulosContext _context;

        public DetailsModel(ProyeArticulos.Data.ProyeArticulosContext context)
        {
            _context = context;
        }

      public Articulo Articulo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Articulo == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulo.FirstOrDefaultAsync(m => m.Id == id);
            if (articulo == null)
            {
                return NotFound();
            }
            else 
            {
                Articulo = articulo;
            }
            return Page();
        }
    }
}
