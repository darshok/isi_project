using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Videoclub.Models
{
    public class Alquiler
    {
       
        public int AlquilerId { get; set; }
        public DateTime FechaRecogida { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public float TotalAPagar { get; set; }
        public virtual ICollection<PeliculaAlquiler> Peliculas { get; set; }
        public virtual Socio Socio { get; set; }
    }
}