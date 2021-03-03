using System;
using System.Collections.Generic;
using Trabajo_Integrador.Controladores.ObtenerPreguntas;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.DTO;
using Trabajo_Integrador.EntityFramework;

namespace Trabajo_Integrador.Controladores
{
    public static class ControladorPreguntas
    {
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
                    return new OpentDbEstrategiaObtenerPreguntas();

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
            var preguntas = estrategia.DescargarPreguntas(int.Parse(pCantidad), conjunto);
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
        public static ICollection<CategoriaPreguntaDTO> GetCategoriasConMasDeNPreguntas(String pNombreConjunto, int n)
        {
            List<CategoriaPreguntaDTO> categoriasDTO = new List<CategoriaPreguntaDTO>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        var categorias = UoW.RepositorioPreguntas.CategoriasConMasDeNPreguntas(pNombreConjunto, n);
                        foreach (CategoriaPregunta categoria in categorias)
                        {
                            categoriasDTO.Add(new CategoriaPreguntaDTO(categoria));
                        }
                        return categoriasDTO;
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
        public static int CantidadDePreguntasParaCategoria(String pIdCategoria)
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
        /// Metodo que devuelve todas las dificultades cargadas en base de datos de un determinado conjunto
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DificultadDTO> GetDificultades(String pNombreConjunto)
        {
            List<DificultadDTO> dificultadesDTO = new List<DificultadDTO>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        ICollection<Dificultad> dificultades = UoW.RepositorioConjuntoPregunta.DificultadesDeUnConjunto(pNombreConjunto);
                        foreach (Dificultad dificultad in dificultades)
                        {
                            dificultadesDTO.Add(new DificultadDTO(dificultad));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora.Bitacora();
                bitacora.GuardarLog("ControladorPreguntas.GetDificultades" + ex.ToString());
            }
            return dificultadesDTO;

        }
        public static IEnumerable<RespuestaDTO> RespuestasDePregunta(PreguntaDTO pPregunta)
        {
            Pregunta pre;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    pre = UoW.RepositorioPreguntas.Get(pPregunta.Id);
                }
            }

            var respuestas = new List<RespuestaDTO>();
            foreach (var r in pre.Respuestas)
            {
                respuestas.Add(new RespuestaDTO(r));
            }

            return respuestas;
        }
    }
}
