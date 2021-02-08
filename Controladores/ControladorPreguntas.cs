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
        /// Devuelve la cantidad de preguntas insertada con exito
        /// </summary>
        public int CargarPreguntas(List<Pregunta> pPreguntas)
        {
            int cantidad = 0;
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {

                        foreach (Pregunta pre in pPreguntas)
                        {
                            if (UoW.RepositorioPreguntas.Get(pre.Id)==null)
                            {
                                cantidad++;
                                CategoriaPregunta categoria = UoW.RepositorioCategorias.Get(pre.Categoria.Id); ;
                                Dificultad dificultad = UoW.RepositorioDificultades.Get(pre.Dificultad.Id);
                                ConjuntoPreguntas conjunto = UoW.RepositorioConjuntoPregunta.Get(pre.Conjunto.Id);

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
            return cantidad;
        }



        /// <summary>
        /// Obtiene las preguntas de internet y se cargan en la base de datos.
        /// Devuelve el numero de preguntas que se cargaron exitosamente
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// <returns></returns>
        public int GetPreguntasOnline(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            int cargadas = 0;
            try
            {
                CategoriaPregunta categoria;
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        categoria = UoW.RepositorioCategorias.Get(pCategoria);
                    }
                }
                (List<Pregunta>, List<Respuesta>) preguntas = this.GetEstrategia(pConjunto).getPreguntas(pCantidad, pConjunto, pDificultad, categoria);
                cargadas = CargarPreguntas(preguntas.Item1);
                CargarRespuestas(preguntas.Item2);
            }
            catch (NotImplementedException ex)
            {
                Bitacora.GuardarLog("ControladorPreguntas.GetPreguntasOnline: " + ex.Message);
            }
            return cargadas;

        }


        /// <summary>
        /// Dada una lista de respuestas, las carga en la base de datos
        /// </summary>
        /// <param name="pRespuestas"></param>
        public void CargarRespuestas(List<Respuesta> pRespuestas)
        {
          
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        foreach (Respuesta res in pRespuestas)
                        {
                            List<Respuesta> respuestas = (List<Respuesta>) UoW.RepositorioRespuesta.GetAll();
                            Respuesta rs =  respuestas.Find(r => (r.Texto == res.Texto) && (r.Pregunta.Id == res.Pregunta.Id));
                            if (rs == null)
                            {
                                Pregunta pre = UoW.RepositorioPreguntas.Get(res.Pregunta.Id);
                                res.Pregunta = pre;
                                UoW.RepositorioRespuesta.Add(res);
                            }
                        }
                        UoW.Complete();
                    }
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
        public List<Pregunta> GetPreguntasRandom(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
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
        /// Devuelve todas las categorias que tengan mas (o igual) de N preguntas
        /// </summary>
        /// <returns>Lista de categorias</returns>
        public List<CategoriaPregunta> GetCategoriasConMasDeNPreguntas(int n)
        {
            List<CategoriaPregunta> listaCategoria = new List<CategoriaPregunta>();
            List<CategoriaPregunta> ADevolver = new List<CategoriaPregunta>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        listaCategoria = (List<CategoriaPregunta>)UoW.RepositorioCategorias.GetAll();
                        foreach (CategoriaPregunta cat in listaCategoria)
                        {
                            List<Pregunta> preguntas = (List<Pregunta>)UoW.RepositorioPreguntas.GetAll();
                            preguntas=preguntas.FindAll(pre => (pre.Categoria.Id == cat.Id));
                            if (preguntas.Count >= n)
                            {
                                ADevolver.Add(cat);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog("ControladorPreguntas.GetCategoriasConMasDeNPreguntas" + ex.ToString());
            }
            return ADevolver;
        }
    


        /// <summary>
        /// Devuelve la cantidad de preguntas que tiene una categoria
        /// </summary>
        /// <param name="pIdCateoria">El id de la categoria</param>
        /// <returns></returns>
        public int CantidadDePreguntasParaCategoria(String pIdCategoria)
        {
            int aRetornar = 0;
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                       aRetornar = UoW.RepositorioPreguntas.GetAll().Where(pre => (pre.Categoria.Id == pIdCategoria)).Count(); ;
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog("ControladorPreguntas.CantidadDePreguntasParaCategoria" + ex.ToString());
            }
            return aRetornar;

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


        public List<Respuesta> RespuestasDePregunta(Pregunta pPregunta)
        {
            List<Respuesta> listaRespuesta = new List<Respuesta>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        listaRespuesta = (List<Respuesta>) UoW.RepositorioRespuesta.GetAll();
                        listaRespuesta = listaRespuesta.FindAll(r => r.Pregunta.Id == pPregunta.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog("ControladorPreguntas.RespuestasDePregunta" + ex.ToString());
            }
            return listaRespuesta;
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
