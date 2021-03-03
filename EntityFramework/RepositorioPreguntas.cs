using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Trabajo_Integrador.Dominio;
namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioPreguntas : Repository<Pregunta, TrabajoDbContext>
    {

        public RepositorioPreguntas(TrabajoDbContext pContext) : base(pContext)
        {

        }




        /// <summary>
        /// Devuelve una lista de preguntas de acuerdo a la cantidad, categoria y dificultad.
        /// Si la cantidad es de preguntas de una categoria y dificultad es menor a la especificada, 
        /// llena lo restante con preguntas aleatorias
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pCategoria">Si es "0" no lo tiene en cuenta</param>
        /// <param name="pDificultad">Si es "0" no lo tiene en cuenta</param>
        /// <returns>Una Lista de preguntas</returns>
        public List<Pregunta> GetRandom(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            List<Pregunta> preguntas;
            if ((pCategoria != "0") && (pDificultad == "0"))
            {
                preguntas = iDBSet.Include("Conjunto").Where(p => ((p.Conjunto.Categoria.Id == pCategoria) && (p.Conjunto.Nombre == pConjunto))).ToList<Pregunta>();
            }
            else
            {
                if ((pCategoria == "0") && (pDificultad != "0"))
                {
                    preguntas = iDBSet.Include("Conjunto").Where(p => ((p.Conjunto.Dificultad.Id == pDificultad) && (p.Conjunto.Nombre == pConjunto))).ToList<Pregunta>();
                }
                else
                {
                    if ((pCategoria == "0") && (pDificultad == "0"))
                    {
                        preguntas = iDBSet.Include("Conjunto").Where(p => ((p.Conjunto.Nombre == pConjunto))).ToList<Pregunta>();
                    }
                    else
                    {
                        preguntas = iDBSet.Include("Conjunto").Where(p => ((p.Conjunto.Dificultad.Id == pDificultad) && (p.Conjunto.Categoria.Id == pCategoria) && (p.Conjunto.Nombre == pConjunto))).ToList<Pregunta>();
                    }
                }
            }
            int cantidad = Convert.ToInt32(pCantidad);
            if (preguntas.Count <= cantidad)
            {
                List<Pregunta> preguntas2 = iDBSet.Include("Conjunto").Where(p => ((p.Conjunto.Categoria.Id == pCategoria) && (p.Conjunto.Nombre == pConjunto))).ToList<Pregunta>();
                foreach (Pregunta preg in preguntas2)
                {
                    if (!preguntas.Contains(preg) && preguntas.Count < cantidad)
                    {
                        preguntas.Add(preg);
                    }
                }
                return preguntas;
            }
            else
            {
                return preguntas.OrderBy(x => Guid.NewGuid()).Take(cantidad).ToList<Pregunta>();
            }



        }
        public override IEnumerable<Pregunta> GetAll()
        {
            return this.iDBSet.Include("Conjunto").Include("Respuestas").ToList();
        }

        public new Pregunta Get(string pId)
        {
            return this.iDBSet.Include("Conjunto").Include(p => p.Conjunto.Dificultad).Include(p => p.Conjunto.Categoria).Include("Respuestas").Where(p => p.Id == pId).FirstOrDefault<Pregunta>();
        }



        public ICollection<CategoriaPregunta> CategoriasConMasDeNPreguntas(String pNombreConjunto, int n)
        {
            var idCategoriaCantidad = new Dictionary<String, int>();
            HashSet<CategoriaPregunta> res = new HashSet<CategoriaPregunta>();

            foreach (var p in this.iDBSet.Include(p => p.Conjunto.Categoria).Where(p => p.Conjunto.Nombre == pNombreConjunto))
            {
                if (idCategoriaCantidad.ContainsKey(p.Conjunto.Categoria.Id))
                {
                    idCategoriaCantidad[p.Conjunto.Categoria.Id]++;
                }
                else
                {
                    idCategoriaCantidad.Add(p.Conjunto.Categoria.Id, 1);
                }


                if (idCategoriaCantidad[p.Conjunto.Categoria.Id] >= n)
                {
                    res.Add(p.Conjunto.Categoria);
                }
            }

            return res;
        }

        public int CantidadDePreguntasParaCategoria(String pIdCategoria)
        {
            return this.iDBSet.Where(p => p.Conjunto.Categoria.Id == pIdCategoria).Count();
        }


    }
}
