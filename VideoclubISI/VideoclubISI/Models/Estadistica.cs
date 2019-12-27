using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Videoclub.Models
{
    public class Estadistica
    {
        
        public int EstadisticaId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Creación")]
        public DateTime FechaCreacion { get; set; }
        public float TotalGastado { get; set; }
        public virtual Socio Socio { get; set; }
        public virtual Videoclub Videoclub { get; set; }
    }
}