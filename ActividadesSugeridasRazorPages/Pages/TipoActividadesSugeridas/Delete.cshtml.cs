using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.TipoActividadesSugeridas
{
    public class DeleteModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public DeleteModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TipoActividadSugerida TipoActividadSugerida { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoActividadSugerida = await _context.TipoActividadesSugeridas.SingleOrDefaultAsync(m => m.IdTipoActividadSugerida == id);

            if (TipoActividadSugerida == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoActividadSugerida = await _context.TipoActividadesSugeridas.FindAsync(id);

            if (TipoActividadSugerida != null)
            {
                _context.TipoActividadesSugeridas.Remove(TipoActividadSugerida);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
