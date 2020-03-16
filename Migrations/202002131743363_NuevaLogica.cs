namespace Trabajo_Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevaLogica : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("public.ExamenPreguntas");
            AddColumn("public.ExamenPreguntas", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("public.ExamenPreguntas", "Pregunta_Id", c => c.String(maxLength: 128));
            AddColumn("public.ExamenPreguntas", "Examen_Id", c => c.Int());
            AddPrimaryKey("public.ExamenPreguntas", "Id");
            CreateIndex("public.ExamenPreguntas", "Pregunta_Id");
            CreateIndex("public.ExamenPreguntas", "Examen_Id");
            AddForeignKey("public.ExamenPreguntas", "Pregunta_Id", "public.Preguntas", "Id");
            AddForeignKey("public.ExamenPreguntas", "Examen_Id", "public.Examen", "Id");
            DropColumn("public.ExamenPreguntas", "ExamenId");
            DropColumn("public.ExamenPreguntas", "PreguntaId");
        }
        
        public override void Down()
        {
            AddColumn("public.ExamenPreguntas", "PreguntaId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("public.ExamenPreguntas", "ExamenId", c => c.Int(nullable: false));
            DropForeignKey("public.ExamenPreguntas", "Examen_Id", "public.Examen");
            DropForeignKey("public.ExamenPreguntas", "Pregunta_Id", "public.Preguntas");
            DropIndex("public.ExamenPreguntas", new[] { "Examen_Id" });
            DropIndex("public.ExamenPreguntas", new[] { "Pregunta_Id" });
            DropPrimaryKey("public.ExamenPreguntas");
            DropColumn("public.ExamenPreguntas", "Examen_Id");
            DropColumn("public.ExamenPreguntas", "Pregunta_Id");
            DropColumn("public.ExamenPreguntas", "Id");
            AddPrimaryKey("public.ExamenPreguntas", new[] { "ExamenId", "PreguntaId" });
        }
    }
}
