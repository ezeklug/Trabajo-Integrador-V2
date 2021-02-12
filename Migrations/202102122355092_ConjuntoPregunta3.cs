namespace Trabajo_Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConjuntoPregunta3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("public.ExamenPreguntaDTOes", new[] { "Examen_Id" });
            AddColumn("public.ExamenPreguntas", "Examen_Id", c => c.Int());
            CreateIndex("public.ExamenPreguntas", "Examen_Id");
            DropTable("public.ExamenPreguntaDTOes");
        }
        
        public override void Down()
        {
            CreateTable(
                "public.ExamenPreguntaDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PreguntaId = c.String(),
                        RespuestaElegidaId = c.Int(nullable: false),
                        Examen_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("public.ExamenPreguntas", new[] { "Examen_Id" });
            DropColumn("public.ExamenPreguntas", "Examen_Id");
            CreateIndex("public.ExamenPreguntaDTOes", "Examen_Id");
        }
    }
}
