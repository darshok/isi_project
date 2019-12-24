using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videoclub.Models
{
    public class PeliculaAlquiler
    {
        public int PeliculaAlquilerId { get; set; }
        public Pelicula Pelicula { get; set; }
        public Alquiler Alquiler { get; set; }
    }
}