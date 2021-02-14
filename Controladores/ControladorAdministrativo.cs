using System;
using System.Collections.Generic;
using System.Linq;
using Trabajo_Integrador.Controladores.Bitacora;
using Trabajo_Integrador.Controladores.Excepciones;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.EntityFramework;

namespace Trabajo_Integrador.Controladores
{
    /// <summary>
    /// Clase utilizada por el administrador.
    /// </summary>
    public class ControladorAdministrativo
    {
        ControladorPreguntas iControladorPreguntas = new ControladorPreguntas();

        public void CargarPreguntas(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            ControladorPreguntas.GetPreguntasOnline(pCantidad, pConjunto, pCategoria, pDificultad);
        }
        public static IEnumerable<Usuario> GetUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    listaUsuarios = UoW.RepositorioUsuarios.GetAll().ToList();
                }
            }

            return listaUsuarios;
        }


        /// <summary>
        /// Obtiene todas las preguntas de la base de datos
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Pregunta> GetPreguntas()
        {
            IEnumerable<Pregunta> preguntas;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    preguntas = UoW.RepositorioPreguntas.GetAll();
                }
            }

            return preguntas;
        }
        public List<Examen> GetExamenes()
        {
            List<Examen> listaExamenes = new List<Examen>();
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    listaExamenes = (List<Examen>)UoW.ExamenRepository.GetAll();
                }
            }

            return listaExamenes;

        }
        /// <summary>
        /// Devuelve todas las categorias cargadas en la base de datos para un conjunto
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CategoriaPregunta> GetCategorias(String pNombre)
        {
            return ControladorPreguntas.GetCategorias(pNombre);
        }

        /// <summary>
        /// Devuelve todos los nombres de los conjuntos
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<String> GetNombresConjuntosPreguntas()
        {
            IEnumerable<String> nombres;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    nombres = UoW.RepositorioConjuntoPregunta.NombresDeConjuntos();
                }
            }

            return nombres;
        }
        /// <summary>
        /// Metodo que modifica el tiempo esperado por respuesta de un conjunto pasado como parametro.
        /// </summary>
        /// <param name="pConjuntoPreguntas"></param>
        /// <param name="pTiempo"></param>
        public void ModificarTiempo(string pConjuntoPreguntas, float pTiempo)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    ConjuntoPreguntas conjunto = UoW.RepositorioConjuntoPregunta.Get(pConjuntoPreguntas);
                    conjunto.TiempoEsperadoRespuesta = pTiempo;
                    UoW.Complete();
                }
            }



        }
        /// <summary>
        /// Metodo que establece como admin a un usuario pasado como parametro
        /// </summary>
        /// <param name="pUsuario"></param>
        public static void SetAdministrador(string pUsuario)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Usuario dBUsuario = UoW.RepositorioUsuarios.Get(pUsuario);
                    dBUsuario.Administrador = true;
                    UoW.Complete();
                }
            }

        }

        /// <summary>
        /// Metodo que devuelve una lista de examenes de un usuario ordenados por puntaje
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <returns></returns>
        public List<Examen> GetRanking(String pUsuario)
        {
            List<Examen> listaExamenes = new List<Examen>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        listaExamenes = (List<Examen>)UoW.ExamenRepository.GetAll().ToList().FindAll(ex => ex.UsuarioId == pUsuario).OrderBy(ex => ex.Puntaje).ToList<Examen>();
                    }
                }
            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora.Bitacora();
                bitacora.GuardarLog("ControladorAdministrativo.GetRanking" + ex.Message);
            }
            return listaExamenes;
        }

        /// <summary>
        /// Devuelve todos los logs
        /// </summary>
        /// <returns></returns>
        public ICollection<Log> getLogs()
        {
            IBitacora bitacora = new Controladores.Bitacora.Bitacora();
            return bitacora.ObtenerTodos();
        }

        /// <summary>
        /// Setea un usuario como no administrador
        /// </summary>
        /// <param name="pUsuario">Id del usuario</param>
        public static void SetNoAdministrador(string pUsuario)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Usuario dBUsuario = UoW.RepositorioUsuarios.Get(pUsuario);
                    dBUsuario.Administrador = false;
                    UoW.Complete();
                }
            }
        }


        /// <summary>
        /// Guarda un usuario en la base de datos
        /// </summary>
        /// <exception cref="UsrYaExisteException">Si usuario ya existe</exception> 
        /// <param name="pUsuario"></param>
        public static void GuardarUsuario(Usuario pUsuario)
        {
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        UoW.RepositorioUsuarios.Add(pUsuario);
                        UoW.Complete();
                    }
                }

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                throw new UsrYaExisteException(String.Format("{0} Ya existe en la bd", pUsuario));
            }

        }




    }
}
