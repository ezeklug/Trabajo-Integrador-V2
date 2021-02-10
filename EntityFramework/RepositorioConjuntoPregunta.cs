using System;
using System.Collections.Generic;
using System.Linq;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioConjuntoPregunta : Repository<ConjuntoPreguntas, TrabajoDbContext>
    {
        public RepositorioConjuntoPregunta(TrabajoDbContext pContext) : base(pContext) { }


        public ConjuntoPreguntas ObtenerConjuntoPorDificultadYCategoria(String pNombreConjunto, String pIdDificultad, String pIdCategoria)
        {
            return this.iDBSet.Include("Dificultad").Include("Categoria").FirstOrDefault(c =>
            (c.Nombre == pNombreConjunto) &&
            (c.Dificultad.Id == pIdDificultad) &&
            (c.Categoria.Id == pIdCategoria));
        }


        public ICollection<CategoriaPregunta> CategoriasDeUnConjunto(String pNombreConjunto)
        {
            var conjunto = this.iDBSet.Where(c => c.Nombre == pNombreConjunto);
            var categorias = new HashSet<CategoriaPregunta>();

            foreach (var c in conjunto)
            {
                categorias.Add(c.Categoria);
            }
            return categorias;
        }


        public ICollection<Dificultad> DificultadesDeUnConjunto(String pNombreConjunto)
        {
            var conjunto = this.iDBSet.Where(c => c.Nombre == pNombreConjunto);
            var dificultades = new HashSet<Dificultad>();

            foreach (var c in conjunto)
            {
                dificultades.Add(c.Dificultad);
            }

            return dificultades;
        }


        public IEnumerable<String> NombresDeConjuntos()
        {
            var resultado = this.iDBSet.GroupBy(c => c.Nombre);
            var nombres = new HashSet<String>();

            foreach (var r in resultado)
            {
                nombres.Add(r.Key);
            }
            return nombres;
        }
    }
}
