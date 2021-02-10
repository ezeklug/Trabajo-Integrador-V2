using System;
using System.Collections.Generic;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.EntityFramework;

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
        public int CargarPreguntas(ICollection<Pregunta> pPreguntas)
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
                            // si la pregunta no existe
                            if (UoW.RepositorioPreguntas.Get(pre.Id) == null)
                            {
                                cantidad++;
                                ConjuntoPreguntas conjunto = UoW.RepositorioConjuntoPregunta.Get(pre.Conjunto.Id);
                                UoW.RepositorioPreguntas.Add(pre);
                            }
                        }
                        UoW.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora.Bitacora();
                bitacora.GuardarLog(ex.Message.ToString());
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

                ConjuntoPreguntas conjunto;
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        conjunto = UoW.RepositorioConjuntoPregunta.ObtenerConjuntoPorDificultadYCategoria(pConjunto, pDificultad, pCategoria);
                    }
                }
                IEstrategiaObtenerPreguntas estrategia = this.GetEstrategia(pConjunto);
                var preguntas = estrategia.getPreguntas(int.Parse(pCantidad), conjunto);
                cargadas = CargarPreguntas(preguntas);
                return cargadas;
            }


            catch (NotImplementedException ex)
            {
                var bitacora = new Bitacora.Bitacora();
                bitacora.GuardarLog("ControladorPreguntas.GetPreguntasOnline: " + ex.Message);
            }
            return cargadas;

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
        public ICollection<CategoriaPregunta> GetCategorias(String pNombreConjunto)
        {
            ICollection<CategoriaPregunta> categorias = null;
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        categorias = UoW.RepositorioConjuntoPregunta.CategoriasDeUnConjunto(pNombreConjunto);
                    }
                }
            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora.Bitacora();
                bitacora.GuardarLog("ControladorPreguntas.GetCategorias" + ex.ToString());
            }
            return categorias;
        }

        /// <summary>
        /// Devuelve todas las categorias que tengan mas (o igual) de N preguntas
        /// </summary>
        /// <returns>Lista de categorias</returns>
        public ICollection<CategoriaPregunta> GetCategoriasConMasDeNPreguntas(int n)
        {
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        return UoW.RepositorioPreguntas.CategoriasConMasDeNPreguntas(n);
                    }
                }
            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora.Bitacora();
                bitacora.GuardarLog("ControladorPreguntas.GetCategoriasConMasDeNPreguntas" + ex.ToString());
                return null;
            }
        }



        /// <summary>
        /// Devuelve la cantidad de preguntas que tiene una categoria
        /// </summary>
        /// <param name="pIdCateoria">El id de la categoria</param>
        /// <returns></returns>
        public int CantidadDePreguntasParaCategoria(String pIdCategoria)
        {
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        return UoW.RepositorioPreguntas.CantidadDePreguntasParaCategoria(pIdCategoria);
                    }
                }
            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora.Bitacora();
                bitacora.GuardarLog("ControladorPreguntas.CantidadDePreguntasParaCategoria" + ex.ToString());
                return 0;
            }

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
                var bitacora = new Bitacora.Bitacora();
                bitacora.GuardarLog("ControladorPreguntas.GetConjuntoPreguntas" + ex.ToString());
            }
            return listaConjuntos;
        }

        /// <summary>
        /// Metodo que devuelve todas las dificultades cargadas en base de datos de un determinado conjunto
        /// </summary>
        /// <returns></returns>
        public ICollection<Dificultad> GetDificultades(String pNombreConjunto)
        {
            ICollection<Dificultad> dificultades = null;
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        dificultades = UoW.RepositorioConjuntoPregunta.DificultadesDeUnConjunto(pNombreConjunto);
                    }
                }
            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora.Bitacora();
                bitacora.GuardarLog("ControladorPreguntas.GetDificultades" + ex.ToString());
            }
            return dificultades;
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
