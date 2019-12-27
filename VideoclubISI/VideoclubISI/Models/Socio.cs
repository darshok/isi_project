using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Videoclub.Models
{
    public class Socio
    {
     
        public int SocioId { get; set; }
        [Display(Name = "Nombre del socio")]
        public string Nombre { get; set; }
        [Display(Name = "Edad del socio")]
        public int Edad { get; set; }
        [Display(Name = "Videoclub del socio")]
        public virtual Videoclub Videoclub { get; set; }
        public virtual List<Alquiler> Alquileres { get; set; }
        public virtual List<Estadistica> Estadisticas { get; set; }
    }
}