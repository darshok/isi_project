namespace Videoclub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrador",
                c => new
                    {
                        AdministradorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.AdministradorId);
            
            CreateTable(
                "dbo.Alquiler",
                c => new
                    {
                        AlquilerId = c.Int(nullable: false, identity: true),
                        FechaRecogida = c.DateTime(nullable: false),
                        FechaDevolucion = c.DateTime(nullable: false),
                        TotalAPagar = c.Single(nullable: false),
                        Socio_SocioId = c.Int(),
                    })
                .PrimaryKey(t => t.AlquilerId)
                .ForeignKey("dbo.Socio", t => t.Socio_SocioId)
                .Index(t => t.Socio_SocioId);
            
            CreateTable(
                "dbo.Pelicula",
                c => new
                    {
                        PeliculaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Director = c.String(),
                        FechaEstreno = c.DateTime(nullable: false),
                        PrecioAlquiler = c.Single(nullable: false),
                        Videoclub_VideoclubId = c.Int(),
                    })
                .PrimaryKey(t => t.PeliculaId)
                .ForeignKey("dbo.Videoclub", t => t.Videoclub_VideoclubId)
                .Index(t => t.Videoclub_VideoclubId);
            
            CreateTable(
                "dbo.Videoclub",
                c => new
                    {
                        VideoclubId = c.Int(nullable: false, identity: true),
                        NombreDelGerente = c.String(),
                        Ciudad = c.String(),
                        Calle = c.String(),
                        CodPostal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VideoclubId);
            
            CreateTable(
                "dbo.Socio",
                c => new
                    {
                        SocioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Edad = c.Int(nullable: false),
                        Videoclub_VideoclubId = c.Int(),
                    })
                .PrimaryKey(t => t.SocioId)
                .ForeignKey("dbo.Videoclub", t => t.Videoclub_VideoclubId)
                .Index(t => t.Videoclub_VideoclubId);
            
            CreateTable(
                "dbo.Estadistica",
                c => new
                    {
                        EstadisticaId = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                        TotalGastado = c.Single(nullable: false),
                        Socio_SocioId = c.Int(),
                        Videoclub_VideoclubId = c.Int(),
                    })
                .PrimaryKey(t => t.EstadisticaId)
                .ForeignKey("dbo.Socio", t => t.Socio_SocioId)
                .ForeignKey("dbo.Videoclub", t => t.Videoclub_VideoclubId)
                .Index(t => t.Socio_SocioId)
                .Index(t => t.Videoclub_VideoclubId);
            
            CreateTable(
                "dbo.PeliculaAlquiler",
                c => new
                    {
                        Pelicula_PeliculaId = c.Int(nullable: false),
                        Alquiler_AlquilerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pelicula_PeliculaId, t.Alquiler_AlquilerId })
                .ForeignKey("dbo.Pelicula", t => t.Pelicula_PeliculaId, cascadeDelete: true)
                .ForeignKey("dbo.Alquiler", t => t.Alquiler_AlquilerId, cascadeDelete: true)
                .Index(t => t.Pelicula_PeliculaId)
                .Index(t => t.Alquiler_AlquilerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estadistica", "Videoclub_VideoclubId", "dbo.Videoclub");
            DropForeignKey("dbo.Estadistica", "Socio_SocioId", "dbo.Socio");
            DropForeignKey("dbo.Socio", "Videoclub_VideoclubId", "dbo.Videoclub");
            DropForeignKey("dbo.Alquiler", "Socio_SocioId", "dbo.Socio");
            DropForeignKey("dbo.Pelicula", "Videoclub_VideoclubId", "dbo.Videoclub");
            DropForeignKey("dbo.PeliculaAlquiler", "Alquiler_AlquilerId", "dbo.Alquiler");
            DropForeignKey("dbo.PeliculaAlquiler", "Pelicula_PeliculaId", "dbo.Pelicula");
            DropIndex("dbo.PeliculaAlquiler", new[] { "Alquiler_AlquilerId" });
            DropIndex("dbo.PeliculaAlquiler", new[] { "Pelicula_PeliculaId" });
            DropIndex("dbo.Estadistica", new[] { "Videoclub_VideoclubId" });
            DropIndex("dbo.Estadistica", new[] { "Socio_SocioId" });
            DropIndex("dbo.Socio", new[] { "Videoclub_VideoclubId" });
            DropIndex("dbo.Pelicula", new[] { "Videoclub_VideoclubId" });
            DropIndex("dbo.Alquiler", new[] { "Socio_SocioId" });
            DropTable("dbo.PeliculaAlquiler");
            DropTable("dbo.Estadistica");
            DropTable("dbo.Socio");
            DropTable("dbo.Videoclub");
            DropTable("dbo.Pelicula");
            DropTable("dbo.Alquiler");
            DropTable("dbo.Administrador");
        }
    }
}
