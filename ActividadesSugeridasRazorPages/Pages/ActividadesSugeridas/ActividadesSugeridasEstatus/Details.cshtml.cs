using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.ActividadesSugeridasEstatus
{
    public class DetailsModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;
        public int? idAct;
        public int idacti;
        public DetailsModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public ActividadSugeridaEstatus ActividadSugeridaEstatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            idAct = id;
            idacti = Convert.ToInt32(Request.Query["idacti"]);
            if (id == null)
            {
                return NotFound();
            }

            ActividadSugeridaEstatus = await _context.ActividadesSugeridasEstatus
                .Include(a => a.ActividadesSugeridas)
                .Include(a => a.TipoActividadesSugeridas)
                .Include(a => a.TiposEstatus).SingleOrDefaultAsync(m => m.IdEstatusDet == id);

            if (ActividadSugeridaEstatus == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
