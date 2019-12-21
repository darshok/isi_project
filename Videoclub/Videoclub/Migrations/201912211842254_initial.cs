namespace Videoclub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrador",
                c => new
                    {
                        AdministradorID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.AdministradorID);
            
            CreateTable(
                "dbo.Alquiler",
                c => new
                    {
                        AlquilerID = c.Int(nullable: false, identity: true),
                        FechaRecogida = c.DateTime(nullable: false),
                        FechaDevolucion = c.DateTime(nullable: false),
                        TotalAPagar = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.AlquilerID);
            
            CreateTable(
                "dbo.Pelicula",
                c => new
                    {
                        PeliculaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Director = c.String(),
                        FechaEstreno = c.DateTime(nullable: false),
                        PrecioAlquiler = c.Single(nullable: false),
                        Videoclub_VideoclubID = c.Int(),
                        Alquiler_AlquilerID = c.Int(),
                        Socio_SocioID = c.Int(),
                    })
                .PrimaryKey(t => t.PeliculaID)
                .ForeignKey("dbo.Videoclub", t => t.Videoclub_VideoclubID)
                .ForeignKey("dbo.Alquiler", t => t.Alquiler_AlquilerID)
                .ForeignKey("dbo.Socio", t => t.Socio_SocioID)
                .Index(t => t.Videoclub_VideoclubID)
                .Index(t => t.Alquiler_AlquilerID)
                .Index(t => t.Socio_SocioID);
            
            CreateTable(
                "dbo.Videoclub",
                c => new
                    {
                        VideoclubID = c.Int(nullable: false, identity: true),
                        NombreDelGerente = c.String(),
                        Ciudad = c.String(),
                        Calle = c.String(),
                        CodPostal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VideoclubID);
            
            CreateTable(
                "dbo.Socio",
                c => new
                    {
                        SocioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Edad = c.Int(nullable: false),
                        Videoclub_VideoclubID = c.Int(),
                        Alquiler_AlquilerID = c.Int(),
                    })
                .PrimaryKey(t => t.SocioID)
                .ForeignKey("dbo.Videoclub", t => t.Videoclub_VideoclubID)
                .ForeignKey("dbo.Alquiler", t => t.Alquiler_AlquilerID)
                .Index(t => t.Videoclub_VideoclubID)
                .Index(t => t.Alquiler_AlquilerID);
            
            CreateTable(
                "dbo.Estadistica",
                c => new
                    {
                        EstadisticaID = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                        TotalGastado = c.Single(nullable: false),
                        Socio_SocioID = c.Int(),
                        Videoclub_VideoclubID = c.Int(),
                    })
                .PrimaryKey(t => t.EstadisticaID)
                .ForeignKey("dbo.Socio", t => t.Socio_SocioID)
                .ForeignKey("dbo.Videoclub", t => t.Videoclub_VideoclubID)
                .Index(t => t.Socio_SocioID)
                .Index(t => t.Videoclub_VideoclubID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estadistica", "Videoclub_VideoclubID", "dbo.Videoclub");
            DropForeignKey("dbo.Estadistica", "Socio_SocioID", "dbo.Socio");
            DropForeignKey("dbo.Socio", "Alquiler_AlquilerID", "dbo.Alquiler");
            DropForeignKey("dbo.Socio", "Videoclub_VideoclubID", "dbo.Videoclub");
            DropForeignKey("dbo.Pelicula", "Socio_SocioID", "dbo.Socio");
            DropForeignKey("dbo.Pelicula", "Alquiler_AlquilerID", "dbo.Alquiler");
            DropForeignKey("dbo.Pelicula", "Videoclub_VideoclubID", "dbo.Videoclub");
            DropIndex("dbo.Estadistica", new[] { "Videoclub_VideoclubID" });
            DropIndex("dbo.Estadistica", new[] { "Socio_SocioID" });
            DropIndex("dbo.Socio", new[] { "Alquiler_AlquilerID" });
            DropIndex("dbo.Socio", new[] { "Videoclub_VideoclubID" });
            DropIndex("dbo.Pelicula", new[] { "Socio_SocioID" });
            DropIndex("dbo.Pelicula", new[] { "Alquiler_AlquilerID" });
            DropIndex("dbo.Pelicula", new[] { "Videoclub_VideoclubID" });
            DropTable("dbo.Estadistica");
            DropTable("dbo.Socio");
            DropTable("dbo.Videoclub");
            DropTable("dbo.Pelicula");
            DropTable("dbo.Alquiler");
            DropTable("dbo.Administrador");
        }
    }
}
