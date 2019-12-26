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
        [Display(Name = "Fecha Recogida")]
        public DateTime FechaRecogida { get; set; }
        [Display(Name = "Fecha Devolución")]
        public DateTime FechaDevolucion { get; set; }
        [Display(Name = "Precio de alquiler")]
        public float TotalAPagar { get; set; }
        [Display(Name = "Peliculas alquiladas")]
        public virtual List<PeliculaAlquiler> Peliculas { get; set; }
        [Display(Name = "Socio")]
        public virtual Socio Socio { get; set; }
    }
}