using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class ActividadSugerida
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdActividadSugerida { get; set; }

        public String Tema { get; set; }
        [RegularExpression(@"^[a-zA-Z.\s]+$", ErrorMessage = "Solo Letras Porfavor")]
        [Required(ErrorMessage = "Escriba una Descripcion a la actividad")]
        public String DesActividad { get; set; }

        //[ForeignKey("IdTipoActividadSugerida")]
        //public int IdTipoActividadSugerida { get; set; }
        //public virtual TipoActividadSugerida TipoActividadSugerida { get; set; }

       // [Display(Name = "TipoActividadSugerida")]
        public int IdTipoActividadSugerida { get; set; }

        [ForeignKey("IdTipoActividadSugerida")]
        public virtual TipoActividadSugerida TipoActividadesSugeridas { get; set; }
    }
}
