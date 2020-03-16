using System;
using System.Collections.Generic;
using Trabajo_Integrador.EntityFramework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.Controladores
{
    public class ControladorPreguntas
    {

        /// <summary>
        /// atributos
        /// </summary>
        private static ControladorPreguntas cinstancia = null;
        private IEstrategiaObtenerPreguntas iEstrategiaObtenerPreguntas;
        private List<IEstrategiaObtenerPreguntas> iEstrategias;

        /// <summary>
        /// Obtiene la estrategia a utilizar teniendo como parametro el conjunto de preguntas
        /// Si no encuentra la estrategia devuelve la nula
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public IEstrategiaObtenerPreguntas GetEstrategia(String nombre)
        {
            IEstrategiaObtenerPreguntas estrategiaRetorno = new EstrategiaNula();
            foreach (EstrategiaObtenerPreguntas est in iEstrategias)
            {
                if (est.Conjunto == nombre)
                {
                    estrategiaRetorno = est;
                }
            }
            return estrategiaRetorno;
        }


        /// <summary>
        /// Dada una lista de preguntas, las inserta en la base de datos
        /// </summary>
        public void CargarPreguntas(List<Pregunta> pPreguntas)
        {
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {

                        foreach (Pregunta pre in pPreguntas)
                        {
                            if (db.Preguntas.Find(pre.Id) == null)
                            {
                                CategoriaPregunta categoria = db.Categorias.Find(pre.Categoria.Id);
                                Dificultad dificultad = db.Dificultades.Find(pre.Dificultad.Id);
                                ConjuntoPreguntas conjunto = db.ConjuntoPreguntas.Find(pre.Conjunto.Id);

                                ///Si la categoria esta en la base de datos la referencia,
                                ///sino crea una nueva y la inserta en la db
                                if (categoria == null)
                                {
                                    CategoriaPregunta categoriaNueva = new CategoriaPregunta(pre.Categoria.Id);
                                }
                                else
                                {
                                    pre.Categoria = categoria;
                                }


                                ///Si la dificultad esta en la base de datos la referencia,
                                ///sino crea una nueva y la inserta en la db
                                if (dificultad == null)
                                {
                                    Dificultad dificultadNueva = new Dificultad(pre.Dificultad.Id);
                                }
                                else
                                {
                                    pre.Dificultad = dificultad;
                                }

                                ///Si el conjunto esta en la base de datos la referencia,
                                ///sino crea uno nuevo y la inserta en la db
                                if (conjunto == null)
                                {
                                    ConjuntoPreguntas conjuntoNuevo = new ConjuntoPreguntas(pre.Conjunto.Id);
                                }
                                else
                                {
                                    pre.Conjunto = conjunto;
                                }


                                UoW.RepositorioPreguntas.Add(pre);
                            }
                        }
                        UoW.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog(ex.Message.ToString());
            }
        }
     


        /// <summary>
        /// Obtiene las preguntas de internet y se cargan en la base de datos.
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// <returns></returns>
        public void GetPreguntasOnline(string pCantidad,string pConjunto, string pCategoria, string pDificultad)
        {
            try
            {
                CategoriaPregunta categoria;
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        categoria = db.Categorias.Find(pCategoria);
                    }
                }
                IEstrategiaObtenerPreguntas estrategia = this.GetEstrategia(pConjunto);
                List<Pregunta> preguntas = estrategia.getPreguntas(pCantidad, pConjunto, pDificultad, categoria);
                CargarPreguntas(preguntas);
            }
            catch (NotImplementedException ex)
            {
                Bitacora.GuardarLog("ControladorPreguntas.GetPreguntasOnline: "+ex.Message);
            }

        }










       



        

        



        /// <summary>
        /// Obtiene preguntas random de la base de datos
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// <returns></returns>
        public List<Pregunta> GetPreguntasRandom(string pCantidad,string pConjunto, string pCategoria, string pDificultad)
        {
            List<Pregunta> preguntas = new List<Pregunta>();
           
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        preguntas = (List<Pregunta>)UoW.RepositorioPreguntas.GetRandom(pCantidad, pConjunto, pCategoria, pDificultad);
                    }
                }
            
            
               
            
            return preguntas;
        }

        /// <summary>
        /// Metodo que devuelve todas las categorias cargadas en base de datos
        /// </summary>
        /// <returns></returns>
        public List<CategoriaPregunta> GetCategorias()
        {
            List<CategoriaPregunta> listaCategoria = new List<CategoriaPregunta>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        listaCategoria = (List<CategoriaPregunta>)UoW.RepositorioCategorias.GetAll();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog("ControladorPreguntas.GetCategorias" + ex.ToString());
            }
            return listaCategoria;
        }
        /// <summary>
        /// Metodo que devuelve todas los conjuntos de preguntas cargados en base de datos
        /// </summary>
        /// <returns></returns>
        public List<ConjuntoPreguntas> GetConjuntoPreguntas()
        {
            List<ConjuntoPreguntas> listaConjuntos = new List<ConjuntoPreguntas>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        listaConjuntos = (List<ConjuntoPreguntas>)UoW.RepositorioConjuntoPregunta.GetAll();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog("ControladorPreguntas.GetConjuntoPreguntas" + ex.ToString());
            }
            return listaConjuntos;
        }

        /// <summary>
        /// Metodo que devuelve todas las dificultades cargadas en base de datos
        /// </summary>
        /// <returns></returns>
        public List<Dificultad> GetDificultades()
        {
            List<Dificultad> listaDificultades = new List<Dificultad>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        listaDificultades = (List<Dificultad>)UoW.RepositorioDificultades.GetAll();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog("ControladorPreguntas.GetDificultades" + ex.ToString());
            }
            return listaDificultades;
        }




        /// <summary>
        /// Implementacion del patron singleton
        /// </summary>
        public static ControladorPreguntas Instance
        {
            get
            {
                if (cinstancia == null)
                {
                    cinstancia = new ControladorPreguntas();
                }
                return cinstancia;
            }
        }




        /// <summary>
        /// Constructor
        /// </summary>
        public ControladorPreguntas()
        {
            iEstrategias = new List<IEstrategiaObtenerPreguntas>();
            iEstrategias.Add(new OpentDB());
            iEstrategiaObtenerPreguntas = this.GetEstrategia("OpentDB");
        }
    }
}
