using System;
using System.Collections.Generic;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.DTO;
using Trabajo_Integrador.EntityFramework;

namespace Trabajo_Integrador.Controladores
{
    public class ControladorPreguntas
    {

        /// <summary>
        /// atributos
        /// </summary>
        private static ControladorPreguntas cinstancia = null;

        /// <summary>
        /// Obtiene la estrategia a utilizar teniendo como parametro el conjunto de preguntas
        /// Si no encuentra la estrategia devuelve la nula
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public static IEstrategiaObtenerPreguntas GetEstrategia(String nombre)
        {
            switch (nombre)
            {
                case "OpentDb":
                    return new OpentDB();

                default:
                    return new EstrategiaNula();
            }
        }


        /// <summary>
        /// Dada una lista de preguntas, las inserta en la base de datos
        /// Devuelve la cantidad de preguntas insertada con exito
        /// </summary>
        public static int CargarPreguntas(IEnumerable<Pregunta> pPreguntas)
        {
            /// Este metodo es horriblemente ineficiente
            /// Pero fue la unica forma que encontre de hacerlo andar
            int cantidad = 0;
            foreach (Pregunta pre in pPreguntas)
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {

                        // si la pregunta no existe
                        if (UoW.RepositorioPreguntas.Get(pre.Id) == null)
                        {
                            cantidad++;
                            ConjuntoPreguntas conjunto = UoW.RepositorioConjuntoPregunta.Get(pre.Conjunto.Id);
                            pre.Conjunto = conjunto;
                            UoW.RepositorioPreguntas.Add(pre);
                        }

                        UoW.Complete();
                    }

                }
            }

            return cantidad;
        }


        public static IEnumerable<Pregunta> ObtenerPreguntasDeInternet(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            ConjuntoPreguntas conjunto;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    conjunto = UoW.RepositorioConjuntoPregunta.ObtenerConjuntoPorDificultadYCategoria(pConjunto, pDificultad, pCategoria);
                }
            }
            IEstrategiaObtenerPreguntas estrategia = ControladorPreguntas.GetEstrategia(pConjunto);
            var preguntas = estrategia.getPreguntas(int.Parse(pCantidad), conjunto);
            return preguntas;

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
        public static int GetPreguntasOnline(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            int cargadas = 0;
            var preguntas = ControladorPreguntas.ObtenerPreguntasDeInternet(pCantidad, pConjunto, pCategoria, pDificultad);

            cargadas = ControladorPreguntas.CargarPreguntas(preguntas);
            return cargadas;



        }



        public static CategoriaPreguntaDTO CategoriaDePregunta(PreguntaDTO pPregunta)
        {
            CategoriaPregunta c;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    c = UoW.RepositorioPreguntas.Get(pPregunta.Id).Conjunto.Categoria;
                }
            }
            return new CategoriaPreguntaDTO(c);
        }

        /// <summary>
        /// Obtiene preguntas random de la base de datos
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// <returns></returns>
        public static IEnumerable<Pregunta> GetPreguntasRandom(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
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
        public static ICollection<CategoriaPregunta> GetCategorias(String pNombreConjunto)
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
        public static ICollection<CategoriaPregunta> GetCategoriasConMasDeNPreguntas(String pNombreConjunto, int n)
        {
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        return UoW.RepositorioPreguntas.CategoriasConMasDeNPreguntas(pNombreConjunto, n);
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
        public List<ConjuntoPreguntas> GetAllConjuntoPreguntas()
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
                bitacora.GuardarLog("ControladorPreguntas.GetNombresConjuntosPreguntas" + ex.ToString());
            }
            return listaConjuntos;
        }

        /// <summary>
        /// Metodo que devuelve todas las dificultades cargadas en base de datos de un determinado conjunto
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Dificultad> GetDificultades(String pNombreConjunto)
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

        internal ConjuntoPreguntas GetConjuntoPreguntas(string conjuntoId)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    return UoW.RepositorioConjuntoPregunta.Get(conjuntoId);
                }
            }
        }


        public static void GuardarConjunto(ConjuntoPreguntas pConjunto)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    UoW.RepositorioConjuntoPregunta.Add(pConjunto);
                }
            }

        }

        public static void GuardarConjuntos(IEnumerable<ConjuntoPreguntas> pConjuntos)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    foreach (var conjunto in pConjuntos)
                    {
                        var cat = UoW.RepositorioConjuntoPregunta.GetCategoria(conjunto);
                        var dif = UoW.RepositorioConjuntoPregunta.GetDificultad(conjunto);
                        if (cat != null)
                        {
                            conjunto.Categoria = cat;
                        }
                        if (dif != null)
                        {
                            conjunto.Dificultad = dif;
                        }
                        Console.WriteLine($"Va a agregar: {conjunto.Id}");
                        UoW.RepositorioConjuntoPregunta.Add(conjunto);

                    }


                    //UoW.RepositorioConjuntoPregunta.AgregarConjuntos(pConjuntos);
                    //db.SaveChanges();

                }

            }
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
        }
    }
}
