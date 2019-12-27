using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Videoclub.Restricciones;

namespace Videoclub.Models
{
    public class Alquiler
    {
       
        public int AlquilerId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Recogida")]
        [RestrictedDate(ErrorMessage = "La fecha debe ser igual o posterior a la actual.")]
        public DateTime FechaRecogida { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Devolución")]
        [RestrictedDate(ErrorMessage = "La fecha debe ser igual o posterior a la actual.")]
        public DateTime FechaDevolucion { get; set; }
        [Display(Name = "Precio de alquiler")]
        public float TotalAPagar { get; set; }
        [Display(Name = "Peliculas alquiladas")]
        public virtual List<PeliculaAlquiler> Peliculas { get; set; }
        [Display(Name = "Socio")]
        public virtual Socio Socio { get; set; }
    }
}