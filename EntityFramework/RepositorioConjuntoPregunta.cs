using System;
using System.Linq;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioConjuntoPregunta : Repository<ConjuntoPreguntas, TrabajoDbContext>
    {
        public RepositorioConjuntoPregunta(TrabajoDbContext pContext) : base(pContext) { }


        public ConjuntoPreguntas ObtenerConjuntoConDificultadYCategoria(String pNombreConjunto, String pIdDificultad, String pIdCategoria)
        {
            return this.iDBSet.Include("Dificultad").Include("Categoria").FirstOrDefault(c =>
            (c.Nombre == pNombreConjunto) &&
            (c.Dificultad.Id == pIdDificultad) &&
            (c.Categoria.Id == pIdCategoria));
        }

    }
}
