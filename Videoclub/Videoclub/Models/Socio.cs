using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videoclub.Models
{
    public class Socio
    {
        public int SocioID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public virtual Videoclub Videoclub { get; set; }
        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}