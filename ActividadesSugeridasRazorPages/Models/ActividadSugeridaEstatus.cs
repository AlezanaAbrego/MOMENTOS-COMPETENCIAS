using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class ActividadSugeridaEstatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstatusDet { get; set; }

        [ForeignKey("IdTipoActividadSugerida")]
        public int IdTipoActividadSugerida { get; set; }
        //public String DesTipoActividadSugerida { get; set; }
        public virtual TipoActividadSugerida TipoActividadesSugeridas { get; set; }

        [ForeignKey("IdActividadSugerida")]
        public int IdActividadSugerida { get; set; }
        //public String Tema { get; set; }
        public virtual ActividadSugerida ActividadesSugeridas { get; set; }

        [ForeignKey("IdTipoEstatus")]
        public int IdTipoEstatus { get; set; }
        //public String Tema { get; set; }
        public virtual TipoEstatus TiposEstatus { get; set; }

        public DateTime FechaEstatus { get; set; }

        public bool Actual { get; set; }
        public String Observacion { get; set; }
       
    }
}
