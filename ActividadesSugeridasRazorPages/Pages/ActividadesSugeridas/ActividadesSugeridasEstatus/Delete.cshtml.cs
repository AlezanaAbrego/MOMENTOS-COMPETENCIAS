﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasRazorPages.Models;

namespace ActividadesSugeridasRazorPages.Pages.ActividadesSugeridasEstatus
{
    public class DeleteModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;
        public int? idAct;

        public DeleteModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ActividadSugeridaEstatus ActividadSugeridaEstatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            idAct = id;
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActividadSugeridaEstatus = await _context.ActividadesSugeridasEstatus.FindAsync(id);

            if (ActividadSugeridaEstatus != null)
            {
                _context.ActividadesSugeridasEstatus.Remove(ActividadSugeridaEstatus);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index",  new {id = idAct});
        }
    }
}
