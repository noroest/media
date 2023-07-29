using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyeArticulos.Data;
using ProyeArticulos.Models;

namespace ProyeArticulos.Pages.Articulos
{
    public class EditModel : PageModel
    {
        private readonly ProyeArticulos.Data.ProyeArticulosContext _context;

        public EditModel(ProyeArticulos.Data.ProyeArticulosContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Articulo Articulo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Articulo == null)
            {
                return NotFound();
            }

            var articulo =  await _context.Articulo.FirstOrDefaultAsync(m => m.Id == id);
            if (articulo == null)
            {
                return NotFound();
            }
            Articulo = articulo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(Articulo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArticuloExists(int id)
        {
          return (_context.Articulo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
