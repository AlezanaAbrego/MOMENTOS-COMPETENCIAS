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
    public class IndexModel : PageModel
    {
        private readonly ActividadesSugeridasRazorPages.Models.ApplicationDbContext _context;

        public IndexModel(ActividadesSugeridasRazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ActividadSugeridaEstatus> ActividadSugeridaEstatus { get; set; }
        public IList<TipoActividadSugerida> TipoActividadSugerida { get; set; }
        public IList<ActividadSugerida> ActividadSugerida { get; set; }


        public string message;
        public string description;
        public string tipo;
        public int Tipos;
        public int IdDescripcion;
        public int IdActividad;


        public async Task OnGetAsync(int id)
        {
            ActividadSugeridaEstatus = await _context.ActividadesSugeridasEstatus
                .Include(a => a.ActividadesSugeridas)
                .Include(a => a.TipoActividadesSugeridas)
                .Include(a => a.TiposEstatus).ToListAsync();

            ActividadSugerida = await _context.ActividadesSugeridas
                .Include(a => a.TipoActividadesSugeridas).ToListAsync();

            TipoActividadSugerida = await _context.TipoActividadesSugeridas.ToListAsync();


            IdActividad = id;
 

            foreach (var value in ActividadSugerida)
            {
                if(id == value.IdActividadSugerida)
                {
                    message = value.Tema.ToString();
                    description =  value.DesActividad.ToString();
                    IdDescripcion = value.IdTipoActividadSugerida;

                    foreach (var val in TipoActividadSugerida)
                    {
                        if (IdDescripcion == val.IdTipoActividadSugerida)
                        {
                            tipo = val.DesTipoActividadSugerida.ToString();
                            Tipos = val.IdTipoActividadSugerida;
                        }
                    }

                }


            }
        }

        
    }
}
