using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoclub.Models;
using System.Data.Entity;

namespace Videoclub.DAL
{
    public class VideoclubInitializer : DropCreateDatabaseIfModelChanges<VideoclubContext>
    {
        protected override void Seed(VideoclubContext context)
        {
            var videoclubs = new List<Models.Videoclub>
            {
                new Models.Videoclub{NombreDelGerente="Alberto Santiago",Ciudad="Valencia",CodPostal=46022},
                new Models.Videoclub{NombreDelGerente="Paco Perez",Ciudad="Madrid",CodPostal=15843}
            };

            videoclubs.ForEach(v => context.Videoclubs.Add(v));
            context.SaveChanges();

            var peliculas = new List<Pelicula>
            {
                new Pelicula{Nombre="Pulp Fiction",Director="Quentin Tarantino",FechaEstreno=DateTime.Parse("21/05/1994"), PrecioAlquiler=3, Videoclub=videoclubs[0] },
                new Pelicula{Nombre="Titanic",Director="James Cameron",FechaEstreno=DateTime.Parse("01/11/1997"), PrecioAlquiler=4,Videoclub=videoclubs[0] },
                new Pelicula{Nombre="Jurassic Park",Director="Steven Spielberg",FechaEstreno=DateTime.Parse("11/06/1993"), PrecioAlquiler=2,Videoclub=videoclubs[1] }
            };

            peliculas.ForEach(p => context.Peliculas.Add(p));
            context.SaveChanges();

            var socios = new List<Socio>
            {
                new Socio{Nombre="Alejandro Marco",Edad=24,Videoclub=videoclubs[0]},
                new Socio{Nombre="Daniel Fenollar",Edad=24,Videoclub=videoclubs[0]},
                new Socio{Nombre="Alejandro Muñoz",Edad=24,Videoclub=videoclubs[1]},
                new Socio{Nombre="Juan Manuel Félix",Edad=24,Videoclub=videoclubs[1]}
            };

            socios.ForEach(s => context.Socios.Add(s));
            context.SaveChanges();

            var administradores = new List<Administrador>
            {
                new Administrador{Nombre="Admin"}
            };

            context.Administradores.Add(administradores.First());
            context.SaveChanges();

            var estadisticas = new List<Estadistica>
            {
                new Estadistica{FechaCreacion=DateTime.Parse("01/01/2019"),TotalGastado=0,Socio=socios[0],Videoclub=videoclubs[0]},
                new Estadistica{FechaCreacion=DateTime.Parse("01/01/2019"),TotalGastado=5,Socio=socios[2],Videoclub=videoclubs[1]}
            };

            estadisticas.ForEach(e => context.Estadisticas.Add(e));
            context.SaveChanges();
        }
    }
}