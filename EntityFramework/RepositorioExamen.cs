using System.Collections.Generic;
using System.Linq;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioExamen : Repository<Examen, TrabajoDbContext>
    {
        public RepositorioExamen(TrabajoDbContext pContext) : base(pContext)
        { }
        public List<Examen> SelectAll(string pId)
        {
            return this.iDBSet.Where(c => c.UsuarioId == pId).ToList();
        }
        public override IEnumerable<Examen> GetAll()
        {
            return this.iDBSet.Include("ExamenPreguntas").ToList();
        }

        public override Examen Get(int pId)
        {
            return this.iDBSet.Include("ExamenPreguntas").FirstOrDefault(e => e.Id == pId);
        }
        public IEnumerable<Examen> GetRankingUser(string idUser)
        {
            return this.iDBSet.Where(u => u.UsuarioId == idUser).OrderBy(ex => ex.Puntaje);
        }
    }
}
