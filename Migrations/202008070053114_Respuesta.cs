namespace Trabajo_Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Respuesta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Respuestas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(),
                        EsCorrecta = c.Boolean(nullable: false),
                        Pregunta_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Preguntas", t => t.Pregunta_Id)
                .Index(t => t.Pregunta_Id);
            
            AddColumn("public.ExamenPreguntas", "RespuestaElegida_Id", c => c.Int());
            CreateIndex("public.ExamenPreguntas", "RespuestaElegida_Id");
            AddForeignKey("public.ExamenPreguntas", "RespuestaElegida_Id", "public.Respuestas", "Id");
            DropColumn("public.ExamenPreguntas", "OpcionElegida");
            DropColumn("public.Preguntas", "RespuestaCorrecta");
            DropColumn("public.Preguntas", "RespuestaIncorrecta1");
            DropColumn("public.Preguntas", "RespuestaIncorrecta2");
            DropColumn("public.Preguntas", "RespuestaIncorrecta3");
        }
        
        public override void Down()
        {
            AddColumn("public.Preguntas", "RespuestaIncorrecta3", c => c.String());
            AddColumn("public.Preguntas", "RespuestaIncorrecta2", c => c.String());
            AddColumn("public.Preguntas", "RespuestaIncorrecta1", c => c.String());
            AddColumn("public.Preguntas", "RespuestaCorrecta", c => c.String());
            AddColumn("public.ExamenPreguntas", "OpcionElegida", c => c.String());
            DropForeignKey("public.ExamenPreguntas", "RespuestaElegida_Id", "public.Respuestas");
            DropForeignKey("public.Respuestas", "Pregunta_Id", "public.Preguntas");
            DropIndex("public.Respuestas", new[] { "Pregunta_Id" });
            DropIndex("public.ExamenPreguntas", new[] { "RespuestaElegida_Id" });
            DropColumn("public.ExamenPreguntas", "RespuestaElegida_Id");
            DropTable("public.Respuestas");
        }
    }
}
