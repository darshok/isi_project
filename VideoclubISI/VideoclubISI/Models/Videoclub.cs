using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Videoclub.Models
{
    public class Videoclub
    {
       
        public int VideoclubId { get; set; }
        public string NombreDelGerente { get; set; }
        public string Ciudad { get; set; }
        [Display(Name = "Calle del Videoclub")]
        public string Calle { get; set; }
        public int CodPostal { get; set; }

        
    }
}