using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.EntityFramework
{
    public class UnitOfWork : IDisposable
    {

        ///////
        /// Atributes
        ///////
        private readonly TrabajoDbContext iDbContext;
        private bool iDisposedValue = false;





        ///////
        /// Properties
        ///////
        public  ExamenRepository ExamenRepository { get; private set; }
        public RepositorioPreguntas RepositorioPreguntas { get; private set; }
        public RepositorioUsuarios RepositorioUsuarios { get; private set; }
        public RepositorioConjuntoPregunta RepositorioConjuntoPregunta { get; private set; }

        public RepositorioDificultades RepositorioDificultades { get; private set; }

        public RepositorioCategorias RepositorioCategorias { get; private set; }

        public RepositorioPreguntaExamen RepositorioPreguntasExamenes { get; set; }
        public RepositorioLogs RepositorioLogs { get; private set; }




        protected virtual void Dispose(bool pDisposing)
        {
            if (!this.iDisposedValue)
            {
                if (pDisposing)
                {
                    this.iDbContext.Dispose();
                }

                this.iDisposedValue = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }


        public void Complete()
        {
            this.iDbContext.SaveChanges();
        }




        ///////
        /// Constructor
        ///////
        public UnitOfWork(TrabajoDbContext pDbContext)
        {
            if (pDbContext == null)
            {
                throw new NotImplementedException();
            }

            this.iDbContext = pDbContext;
            this.RepositorioConjuntoPregunta = new RepositorioConjuntoPregunta(pDbContext);
            this.RepositorioPreguntas = new RepositorioPreguntas(pDbContext);
            this.RepositorioUsuarios = new RepositorioUsuarios(pDbContext);
            this.ExamenRepository = new ExamenRepository(pDbContext);
            this.RepositorioCategorias = new RepositorioCategorias(pDbContext);
            this.RepositorioDificultades = new RepositorioDificultades(pDbContext);
            this.RepositorioPreguntasExamenes = new RepositorioPreguntaExamen(pDbContext);
            this.RepositorioLogs = new RepositorioLogs(pDbContext);
        }


    }
}
