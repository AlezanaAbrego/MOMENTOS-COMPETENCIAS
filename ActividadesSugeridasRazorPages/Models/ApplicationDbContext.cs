using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TipoActividadSugerida> TipoActividadesSugeridas { get; set; }

        public DbSet<ActividadSugerida> ActividadesSugeridas { get; set; }

        public DbSet<ActividadSugeridaEstatus> ActividadesSugeridasEstatus { get; set; }

        public DbSet<TipoEstatus> TiposEstatus { get; set; }

    }
}
