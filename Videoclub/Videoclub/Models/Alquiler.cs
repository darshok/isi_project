using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videoclub.Models
{
    public class Alquiler
    {
        public int AlquilerID { get; set; }
        public DateTime FechaRecogida { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public float TotalAPagar { get; set; }
        public virtual ICollection<Pelicula> Peliculas { get; set; }
        public virtual ICollection<Socio> Socios { get; set; }
    }
}