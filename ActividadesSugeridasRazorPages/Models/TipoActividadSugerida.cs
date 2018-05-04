using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasRazorPages.Models
{
    public class TipoActividadSugerida
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoActividadSugerida { get; set; }
        [RegularExpression(@"^[a-zA-Z.\s]+$", ErrorMessage = "Solo Letras Porfavor")] [Required(ErrorMessage = "Escriba una Descripcion a la actividad")]
        public String DesTipoActividadSugerida { get; set; }
    }
}
