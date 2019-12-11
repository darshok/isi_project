using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videoclub.Models
{
    public class Videoclub
    {
        public int VideoclubID { get; set; }
        public string NombreDelGerente { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int CodPostal { get; set; }

    }
}