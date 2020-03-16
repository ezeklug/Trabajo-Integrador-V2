using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.Migrations;

namespace Trabajo_Integrador.EntityFramework
{
    /// <summary>
    /// Representa una conexion con la base de datos para acceder a los examenes.
    /// </summary>
    public class TrabajoDbContext : DbContext
    {
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<ConjuntoPreguntas> ConjuntoPreguntas { get; set; }
        public DbSet<Dificultad> Dificultades { get; set; }
        public DbSet<CategoriaPregunta> Categorias { get; set; }

        public DbSet<ExamenPregunta> PreguntasExamenes { get; set; }

        public DbSet<Log> Logs { get; set; }

        public TrabajoDbContext() : base(nameOrConnectionString: "Default")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TrabajoDbContext, Configuration>());
            base.OnModelCreating(modelBuilder);

        }
    }
}
