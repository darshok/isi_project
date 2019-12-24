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
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public virtual Videoclub Videoclub { get; set; }
        public virtual List<Alquiler> Alquileres { get; set; }
    }
}