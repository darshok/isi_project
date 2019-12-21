using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Videoclub.Models;

namespace Videoclub.DAL
{
    public class VideoclubContext : DbContext
    {
        public VideoclubContext() : base("VideoclubContext") { }

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<Estadistica> Estadisticas { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Models.Videoclub> Videoclubs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
          
        }
    }
}