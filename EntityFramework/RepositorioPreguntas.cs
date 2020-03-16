using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioPreguntas : Repository<Pregunta, TrabajoDbContext>
    {

        public RepositorioPreguntas(TrabajoDbContext pContext) : base(pContext) {
    
        }




        /// <summary>
        /// Devuelve una lista de preguntas de acuerdo a la cantidad, categoria y dificultad.
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// <returns>Una Lista de preguntas</returns>
        public List<Pregunta> GetRandom(string pCantidad,string pConjunto, string pCategoria, string pDificultad)
        {
            
            List<Pregunta> preguntas = iDBSet.Include("Conjunto").Include("Dificultad").Where(p => ((p.Dificultad.Id == pDificultad) && (p.Categoria.Id == pCategoria) && (p.Conjunto.Id == pConjunto))).ToList<Pregunta>();
            int cantidad = Convert.ToInt32(pCantidad);
            if (preguntas.Count <= cantidad)
            {
                return preguntas;
            }
            else
            {
                return preguntas.OrderBy(x => Guid.NewGuid()).Take(cantidad).ToList<Pregunta>();
            }



        }
    }
}
