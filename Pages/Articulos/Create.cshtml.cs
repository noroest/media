using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyeArticulos.Data;
using ProyeArticulos.Models;

namespace ProyeArticulos.Pages.Articulos
{
    public class CreateModel : PageModel
    {
        private readonly ProyeArticulos.Data.ProyeArticulosContext _context;

        public CreateModel(ProyeArticulos.Data.ProyeArticulosContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Articulo Articulo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Articulo == null || Articulo == null)
            {
                return Page();
            }

            _context.Articulo.Add(Articulo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
