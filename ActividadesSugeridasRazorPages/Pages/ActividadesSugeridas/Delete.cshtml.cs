using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.ActividadesSugeridas
{
    public class DeleteModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public DeleteModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ActividadSugerida ActividadSugerida { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActividadSugerida = await _context.ActividadesSugeridas
                .Include(a => a.TipoActividadesSugeridas).SingleOrDefaultAsync(m => m.IdActividadSugerida == id);

            if (ActividadSugerida == null)
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

            ActividadSugerida = await _context.ActividadesSugeridas.FindAsync(id);

            if (ActividadSugerida != null)
            {
                _context.ActividadesSugeridas.Remove(ActividadSugerida);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
