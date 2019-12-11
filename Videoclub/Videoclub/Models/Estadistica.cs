using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videoclub.Models
{
    public class Estadistica
    {
        public int EstadisticaID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public float TotalGastado { get; set; }
        public virtual Socio Socio { get; set; }
        public virtual Videoclub Videoclub { get; set; }
    }
}