namespace Trabajo_Integrador.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CambioConjuntoPregunta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.Preguntas", "Categoria_Id", "public.CategoriaPreguntas");
            DropForeignKey("public.Preguntas", "Dificultad_Id", "public.Dificultads");
            DropForeignKey("public.ExamenPreguntas", "Pregunta_Id", "public.Preguntas");
            DropForeignKey("public.ExamenPreguntas", "RespuestaElegida_Id", "public.Respuestas");
            DropForeignKey("public.Examen", "Usuario_Id", "public.Usuarios");
            DropIndex("public.Examen", new[] { "Usuario_Id" });
            DropIndex("public.ExamenPreguntas", new[] { "Pregunta_Id" });
            DropIndex("public.ExamenPreguntas", new[] { "RespuestaElegida_Id" });
            DropIndex("public.ExamenPreguntas", new[] { "Examen_Id" });
            DropIndex("public.Preguntas", new[] { "Categoria_Id" });
            DropIndex("public.Preguntas", new[] { "Dificultad_Id" });
            CreateTable(
                "public.ExamenPreguntaDTOes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    PreguntaId = c.String(),
                    RespuestaElegidaId = c.Int(defaultValue: 0, nullable: false),
                    Examen_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Examen_Id);

            AddColumn("public.CategoriaPreguntas", "ProviderId", c => c.String());
            AddColumn("public.ConjuntoPreguntas", "Nombre", c => c.String());
            AddColumn("public.ConjuntoPreguntas", "Categoria_Id", c => c.String(maxLength: 128));
            AddColumn("public.ConjuntoPreguntas", "Dificultad_Id", c => c.String(maxLength: 128));
            AddColumn("public.Examen", "UsuarioId", c => c.String());
            AddColumn("public.ExamenPreguntas", "PreguntaId", c => c.String());
            AddColumn("public.ExamenPreguntas", "RespuestaElegidaId", c => c.Int(nullable: false));
            CreateIndex("public.ConjuntoPreguntas", "Categoria_Id");
            CreateIndex("public.ConjuntoPreguntas", "Dificultad_Id");
            AddForeignKey("public.ConjuntoPreguntas", "Categoria_Id", "public.CategoriaPreguntas", "Id");
            AddForeignKey("public.ConjuntoPreguntas", "Dificultad_Id", "public.Dificultads", "Id");
            DropColumn("public.CategoriaPreguntas", "OpentDbId");
            DropColumn("public.Examen", "Usuario_Id");
            DropColumn("public.ExamenPreguntas", "Pregunta_Id");
            DropColumn("public.ExamenPreguntas", "RespuestaElegida_Id");
            DropColumn("public.ExamenPreguntas", "Examen_Id");
            DropColumn("public.Preguntas", "Categoria_Id");
            DropColumn("public.Preguntas", "Dificultad_Id");
        }

        public override void Down()
        {
            AddColumn("public.Preguntas", "Dificultad_Id", c => c.String(maxLength: 128));
            AddColumn("public.Preguntas", "Categoria_Id", c => c.String(maxLength: 128));
            AddColumn("public.ExamenPreguntas", "Examen_Id", c => c.Int());
            AddColumn("public.ExamenPreguntas", "RespuestaElegida_Id", c => c.Int());
            AddColumn("public.ExamenPreguntas", "Pregunta_Id", c => c.String(maxLength: 128));
            AddColumn("public.Examen", "Usuario_Id", c => c.String(maxLength: 128));
            AddColumn("public.CategoriaPreguntas", "OpentDbId", c => c.Int(nullable: false));
            DropForeignKey("public.ConjuntoPreguntas", "Dificultad_Id", "public.Dificultads");
            DropForeignKey("public.ConjuntoPreguntas", "Categoria_Id", "public.CategoriaPreguntas");
            DropIndex("public.ExamenPreguntaDTOes", new[] { "Examen_Id" });
            DropIndex("public.ConjuntoPreguntas", new[] { "Dificultad_Id" });
            DropIndex("public.ConjuntoPreguntas", new[] { "Categoria_Id" });
            DropColumn("public.ExamenPreguntas", "RespuestaElegidaId");
            DropColumn("public.ExamenPreguntas", "PreguntaId");
            DropColumn("public.Examen", "UsuarioId");
            DropColumn("public.ConjuntoPreguntas", "Dificultad_Id");
            DropColumn("public.ConjuntoPreguntas", "Categoria_Id");
            DropColumn("public.ConjuntoPreguntas", "Nombre");
            DropColumn("public.CategoriaPreguntas", "ProviderId");
            DropTable("public.ExamenPreguntaDTOes");
            CreateIndex("public.Preguntas", "Dificultad_Id");
            CreateIndex("public.Preguntas", "Categoria_Id");
            CreateIndex("public.ExamenPreguntas", "Examen_Id");
            CreateIndex("public.ExamenPreguntas", "RespuestaElegida_Id");
            CreateIndex("public.ExamenPreguntas", "Pregunta_Id");
            CreateIndex("public.Examen", "Usuario_Id");
            AddForeignKey("public.Examen", "Usuario_Id", "public.Usuarios", "Id");
            AddForeignKey("public.ExamenPreguntas", "RespuestaElegida_Id", "public.Respuestas", "Id");
            AddForeignKey("public.ExamenPreguntas", "Pregunta_Id", "public.Preguntas", "Id");
            AddForeignKey("public.Preguntas", "Dificultad_Id", "public.Dificultads", "Id");
            AddForeignKey("public.Preguntas", "Categoria_Id", "public.CategoriaPreguntas", "Id");
        }
    }
}
