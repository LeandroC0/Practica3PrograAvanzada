namespace ProyectoGrupo4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PracticaProgramada3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImagenProductoes", "ID_Estado", "dbo.Estadoes");
            DropForeignKey("dbo.Productoes", "ID_Estado", "dbo.Estadoes");
            DropForeignKey("dbo.Resennas", "ID_Estado", "dbo.Estadoes");
            DropForeignKey("dbo.Resennas", "ID_Producto", "dbo.Productoes");
            DropForeignKey("dbo.Resennas", "ID_Usuario", "dbo.AspNetUsers");
            DropForeignKey("dbo.ImagenProductoes", "ID_Producto", "dbo.Productoes");
            DropForeignKey("dbo.DetalleOrdens", "ID_Orden", "dbo.Ordens");
            DropForeignKey("dbo.Ordens", "ID_Estado", "dbo.Estadoes");
            DropForeignKey("dbo.Ordens", "ID_Usuario", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetalleOrdens", "ID_Estado", "dbo.Estadoes");
            DropForeignKey("dbo.DetalleOrdens", "ID_Producto", "dbo.Productoes");
            DropIndex("dbo.DetalleOrdens", new[] { "ID_Producto" });
            DropIndex("dbo.DetalleOrdens", new[] { "ID_Orden" });
            DropIndex("dbo.DetalleOrdens", new[] { "ID_Estado" });
            DropIndex("dbo.ImagenProductoes", new[] { "ID_Producto" });
            DropIndex("dbo.ImagenProductoes", new[] { "ID_Estado" });
            DropIndex("dbo.Productoes", new[] { "ID_Estado" });
            DropIndex("dbo.Resennas", new[] { "ID_Producto" });
            DropIndex("dbo.Resennas", new[] { "ID_Estado" });
            DropIndex("dbo.Resennas", new[] { "ID_Usuario" });
            DropIndex("dbo.Ordens", new[] { "ID_Usuario" });
            DropIndex("dbo.Ordens", new[] { "ID_Estado" });
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(nullable: false, maxLength: 500),
                        FechaCreacion = c.DateTime(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            DropTable("dbo.DetalleOrdens");
            DropTable("dbo.Estadoes");
            DropTable("dbo.ImagenProductoes");
            DropTable("dbo.Productoes");
            DropTable("dbo.Resennas");
            DropTable("dbo.Ordens");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ordens",
                c => new
                    {
                        ID_Orden = c.Int(nullable: false, identity: true),
                        Fecha_Orden = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ID_Usuario = c.String(nullable: false, maxLength: 128),
                        ID_Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Orden);
            
            CreateTable(
                "dbo.Resennas",
                c => new
                    {
                        ID_Reseña = c.Int(nullable: false, identity: true),
                        Comentario = c.String(nullable: false, maxLength: 500),
                        Calificación = c.Int(nullable: false),
                        Fecha_Reseña = c.DateTime(nullable: false),
                        ID_Producto = c.Int(nullable: false),
                        ID_Estado = c.Int(nullable: false),
                        ID_Usuario = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID_Reseña);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ID_Producto = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Inventario = c.Int(nullable: false),
                        ID_Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Producto);
            
            CreateTable(
                "dbo.ImagenProductoes",
                c => new
                    {
                        ImagenProductoId = c.Int(nullable: false, identity: true),
                        RutaImagen = c.Binary(),
                        ID_Producto = c.Int(nullable: false),
                        ID_Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImagenProductoId);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        ID_Estado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID_Estado);
            
            CreateTable(
                "dbo.DetalleOrdens",
                c => new
                    {
                        ID_DetalleOrden = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ID_Producto = c.Int(nullable: false),
                        ID_Orden = c.Int(nullable: false),
                        ID_Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_DetalleOrden);
            
            DropForeignKey("dbo.Comentarios", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Comentarios", new[] { "UserId" });
            DropTable("dbo.Comentarios");
            CreateIndex("dbo.Ordens", "ID_Estado");
            CreateIndex("dbo.Ordens", "ID_Usuario");
            CreateIndex("dbo.Resennas", "ID_Usuario");
            CreateIndex("dbo.Resennas", "ID_Estado");
            CreateIndex("dbo.Resennas", "ID_Producto");
            CreateIndex("dbo.Productoes", "ID_Estado");
            CreateIndex("dbo.ImagenProductoes", "ID_Estado");
            CreateIndex("dbo.ImagenProductoes", "ID_Producto");
            CreateIndex("dbo.DetalleOrdens", "ID_Estado");
            CreateIndex("dbo.DetalleOrdens", "ID_Orden");
            CreateIndex("dbo.DetalleOrdens", "ID_Producto");
            AddForeignKey("dbo.DetalleOrdens", "ID_Producto", "dbo.Productoes", "ID_Producto");
            AddForeignKey("dbo.DetalleOrdens", "ID_Estado", "dbo.Estadoes", "ID_Estado");
            AddForeignKey("dbo.Ordens", "ID_Usuario", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Ordens", "ID_Estado", "dbo.Estadoes", "ID_Estado");
            AddForeignKey("dbo.DetalleOrdens", "ID_Orden", "dbo.Ordens", "ID_Orden", cascadeDelete: true);
            AddForeignKey("dbo.ImagenProductoes", "ID_Producto", "dbo.Productoes", "ID_Producto");
            AddForeignKey("dbo.Resennas", "ID_Usuario", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Resennas", "ID_Producto", "dbo.Productoes", "ID_Producto");
            AddForeignKey("dbo.Resennas", "ID_Estado", "dbo.Estadoes", "ID_Estado");
            AddForeignKey("dbo.Productoes", "ID_Estado", "dbo.Estadoes", "ID_Estado");
            AddForeignKey("dbo.ImagenProductoes", "ID_Estado", "dbo.Estadoes", "ID_Estado");
        }
    }
}
