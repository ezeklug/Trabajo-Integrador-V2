namespace Trabajo_Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.CategoriaPreguntas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OpentDbId = c.Int(nullable: false),
                        iCategoria = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.ConjuntoPreguntas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TiempoEsperadoRespuesta = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Dificultads",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FactorDificultad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Examen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TiempoLimite = c.Single(nullable: false),
                        Puntaje = c.Double(nullable: false),
                        TiempoUsado = c.Double(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        CantidadPreguntas = c.Int(nullable: false),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "public.Usuarios",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Contrasenia = c.String(),
                        Administrador = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Preguntas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RespuestaCorrecta = c.String(),
                        RespuestaIncorrecta1 = c.String(),
                        RespuestaIncorrecta2 = c.String(),
                        RespuestaIncorrecta3 = c.String(),
                        Categoria_Id = c.String(maxLength: 128),
                        Conjunto_Id = c.String(maxLength: 128),
                        Dificultad_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.CategoriaPreguntas", t => t.Categoria_Id)
                .ForeignKey("public.ConjuntoPreguntas", t => t.Conjunto_Id)
                .ForeignKey("public.Dificultads", t => t.Dificultad_Id)
                .Index(t => t.Categoria_Id)
                .Index(t => t.Conjunto_Id)
                .Index(t => t.Dificultad_Id);
            
            CreateTable(
                "public.ExamenPreguntas",
                c => new
                    {
                        ExamenId = c.Int(nullable: false),
                        PreguntaId = c.String(nullable: false, maxLength: 128),
                        OpcionElegida = c.String(),
                    })
                .PrimaryKey(t => new { t.ExamenId, t.PreguntaId });
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Preguntas", "Dificultad_Id", "public.Dificultads");
            DropForeignKey("public.Preguntas", "Conjunto_Id", "public.ConjuntoPreguntas");
            DropForeignKey("public.Preguntas", "Categoria_Id", "public.CategoriaPreguntas");
            DropForeignKey("public.Examen", "Usuario_Id", "public.Usuarios");
            DropIndex("public.Preguntas", new[] { "Dificultad_Id" });
            DropIndex("public.Preguntas", new[] { "Conjunto_Id" });
            DropIndex("public.Preguntas", new[] { "Categoria_Id" });
            DropIndex("public.Examen", new[] { "Usuario_Id" });
            DropTable("public.ExamenPreguntas");
            DropTable("public.Preguntas");
            DropTable("public.Logs");
            DropTable("public.Usuarios");
            DropTable("public.Examen");
            DropTable("public.Dificultads");
            DropTable("public.ConjuntoPreguntas");
            DropTable("public.CategoriaPreguntas");
        }
    }
}
