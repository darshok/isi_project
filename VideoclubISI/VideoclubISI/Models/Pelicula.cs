using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Videoclub.Models
{
    public class Pelicula
    {
       
        public int PeliculaId { get; set; }
        public string Nombre { get; set; }
        public string Director { get; set; }
        public DateTime FechaEstreno { get; set; }
        public float PrecioAlquiler { get; set; }
        public virtual Videoclub Videoclub { get; set; }
        public virtual List<Alquiler> Alquileres { get; set; }
    }
}