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
        /// <param name="pCategoria">Si es "0" no lo tiene en cuenta</param>
        /// <param name="pDificultad">Si es "0" no lo tiene en cuenta</param>
        /// <returns>Una Lista de preguntas</returns>
        public List<Pregunta> GetRandom(string pCantidad,string pConjunto, string pCategoria, string pDificultad)
        {
            List<Pregunta> preguntas;
            if ((pCategoria != "0") && (pDificultad == "0"))
            {
                preguntas = iDBSet.Include("Conjunto").Include("Dificultad").Where(p => ((p.Categoria.Id == pCategoria) && (p.Conjunto.Id == pConjunto))).ToList<Pregunta>();
            }
            else 
            {
                if ((pCategoria == "0") && (pDificultad != "0"))
                {
                    preguntas = iDBSet.Include("Conjunto").Include("Dificultad").Where(p => ((p.Dificultad.Id == pDificultad) && (p.Conjunto.Id == pConjunto))).ToList<Pregunta>();
                }
                else
                {
                    if ((pCategoria == "0") && (pDificultad == "0"))
                    {
                        preguntas = iDBSet.Include("Conjunto").Include("Dificultad").Where(p => ((p.Conjunto.Id == pConjunto))).ToList<Pregunta>();
                    }
                    else
                    {
                        preguntas = iDBSet.Include("Conjunto").Include("Dificultad").Where(p => ((p.Dificultad.Id == pDificultad) && (p.Categoria.Id == pCategoria) && (p.Conjunto.Id == pConjunto))).ToList<Pregunta>();
                    }
                }
            }
            int cantidad = Convert.ToInt32(pCantidad);
            if (preguntas.Count <= cantidad)
            {
                List<Pregunta> preguntas2 =iDBSet.Include("Conjunto").Include("Dificultad").Where(p => ((p.Categoria.Id == pCategoria) && (p.Conjunto.Id == pConjunto))).ToList<Pregunta>();
                foreach(Pregunta preg in preguntas2)
                {
                    if (!preguntas.Contains(preg) && preguntas.Count<cantidad)
                    {
                        preguntas.Add(preg);
                    }
                }
                return preguntas;
            }
            else
            {
                return preguntas.OrderBy(x => Guid.NewGuid()).Take(cantidad+1).ToList<Pregunta>();
            }



        }



        
    }
}
