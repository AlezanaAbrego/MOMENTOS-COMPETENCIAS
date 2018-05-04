using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.TipoActividadesSugeridas
{
    public class EditModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;
        public int? idAct;
        public EditModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TipoActividadSugerida TipoActividadSugerida { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            idAct = id;
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TipoActividadSugerida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoActividadSugeridaExists(TipoActividadSugerida.IdTipoActividadSugerida))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { id = idAct});
        }

        private bool TipoActividadSugeridaExists(int id)
        {
            return _context.TipoActividadesSugeridas.Any(e => e.IdTipoActividadSugerida == id);
        }
    }
}
