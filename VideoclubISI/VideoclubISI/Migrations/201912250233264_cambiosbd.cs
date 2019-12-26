namespace Videoclub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiosbd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PeliculaAlquiler", "Pelicula_PeliculaId", "dbo.Pelicula");
            DropForeignKey("dbo.PeliculaAlquiler", "Alquiler_AlquilerId", "dbo.Alquiler");
            DropIndex("dbo.PeliculaAlquiler", new[] { "Pelicula_PeliculaId" });
            DropIndex("dbo.PeliculaAlquiler", new[] { "Alquiler_AlquilerId" });
            DropPrimaryKey("dbo.PeliculaAlquiler");
            AddColumn("dbo.PeliculaAlquiler", "PeliculaAlquilerId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PeliculaAlquiler", "Pelicula_PeliculaId", c => c.Int());
            AlterColumn("dbo.PeliculaAlquiler", "Alquiler_AlquilerId", c => c.Int());
            AddPrimaryKey("dbo.PeliculaAlquiler", "PeliculaAlquilerId");
            CreateIndex("dbo.PeliculaAlquiler", "Alquiler_AlquilerId");
            CreateIndex("dbo.PeliculaAlquiler", "Pelicula_PeliculaId");
            AddForeignKey("dbo.PeliculaAlquiler", "Pelicula_PeliculaId", "dbo.Pelicula", "PeliculaId");
            AddForeignKey("dbo.PeliculaAlquiler", "Alquiler_AlquilerId", "dbo.Alquiler", "AlquilerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeliculaAlquiler", "Alquiler_AlquilerId", "dbo.Alquiler");
            DropForeignKey("dbo.PeliculaAlquiler", "Pelicula_PeliculaId", "dbo.Pelicula");
            DropIndex("dbo.PeliculaAlquiler", new[] { "Pelicula_PeliculaId" });
            DropIndex("dbo.PeliculaAlquiler", new[] { "Alquiler_AlquilerId" });
            DropPrimaryKey("dbo.PeliculaAlquiler");
            AlterColumn("dbo.PeliculaAlquiler", "Alquiler_AlquilerId", c => c.Int(nullable: false));
            AlterColumn("dbo.PeliculaAlquiler", "Pelicula_PeliculaId", c => c.Int(nullable: false));
            DropColumn("dbo.PeliculaAlquiler", "PeliculaAlquilerId");
            AddPrimaryKey("dbo.PeliculaAlquiler", new[] { "Pelicula_PeliculaId", "Alquiler_AlquilerId" });
            CreateIndex("dbo.PeliculaAlquiler", "Alquiler_AlquilerId");
            CreateIndex("dbo.PeliculaAlquiler", "Pelicula_PeliculaId");
            AddForeignKey("dbo.PeliculaAlquiler", "Alquiler_AlquilerId", "dbo.Alquiler", "AlquilerId", cascadeDelete: true);
            AddForeignKey("dbo.PeliculaAlquiler", "Pelicula_PeliculaId", "dbo.Pelicula", "PeliculaId", cascadeDelete: true);
        }
    }
}
