using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Videoclub.Models
{
    public class Administrador
    {
        
        public int AdministradorId { get; set; }
        public string Nombre { get; set; }
        
    }
}