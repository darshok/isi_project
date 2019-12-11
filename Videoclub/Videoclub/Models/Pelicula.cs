using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videoclub.Models
{
    public class Pelicula
    {
        public int PeliculaID { get; set; }
        public string Nombre { get; set; }
        public string Director { get; set; }
        public DateTime FechaEstreno { get; set; }
        public float PrecioAlquiler { get; set; }
        public virtual Videoclub Videoclub { get; set; }
    }
}