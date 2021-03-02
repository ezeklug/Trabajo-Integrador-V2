using System;
using System.Collections.Generic;
using System.Linq;
using Trabajo_Integrador.Controladores.Bitacora;
using Trabajo_Integrador.Controladores.Excepciones;
using Trabajo_Integrador.Controladores.Utils;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.DTO;
using Trabajo_Integrador.EntityFramework;

namespace Trabajo_Integrador.Controladores
{
    /// <summary>
    /// Clase utilizada por el administrador.
    /// </summary>
    public static class ControladorAdministrativo
    {
        public static IEnumerable<UsuarioDTO> GetUsuarios()
        {
            List<UsuarioDTO> listaUsuariosDTO = new List<UsuarioDTO>();
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    IEnumerable<Usuario> listaUsuarios = UoW.RepositorioUsuarios.GetAll();
                    foreach(Usuario usuario in listaUsuarios)
                    {
                        listaUsuariosDTO.Add(new UsuarioDTO (usuario));
                    }
                    return listaUsuariosDTO;
                }
            }
        }
        /// <summary>
        /// Obtiene todas las preguntas de la base de datos
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<PreguntaDTO> GetPreguntas()
        {
            List<PreguntaDTO> preguntasDTO = new List<PreguntaDTO>();
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                   IEnumerable<Pregunta> preguntas = UoW.RepositorioPreguntas.GetAll();
                    foreach (Pregunta pregunta in preguntas)
                    {
                        preguntasDTO.Add(new PreguntaDTO(pregunta));
                    }
                    return preguntasDTO;
                }
            }
        }
        public static List<ExamenDTO> GetExamenes()
        {
            List<ExamenDTO> listaExamenesDTO = new List<ExamenDTO>();
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    IEnumerable<Examen> listaExamenes = UoW.ExamenRepository.GetAll();
                    foreach(Examen examen in listaExamenes)
                    {
                        listaExamenesDTO.Add(new ExamenDTO(examen));
                    }
                    return listaExamenesDTO;
                }
            }
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
        /// <param name="pNombreConjunto"></param>
        /// <param name="pTiempo"></param>
        public static void ModificarTiempo(string pNombreConjunto, float pTiempo)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    UoW.RepositorioConjuntoPregunta.ModificarTiempoConjunto(pNombreConjunto, pTiempo);
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
        public static IEnumerable<ExamenDTO> GetRanking(String pUsuario)
        {
            List<ExamenDTO> listaExamenesDTO = new List<ExamenDTO>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                       IEnumerable<Examen> listaExamenes = UoW.ExamenRepository.GetRankingUser(pUsuario);
                       foreach(Examen examen in listaExamenes)
                        {
                            listaExamenesDTO.Add(new ExamenDTO(examen));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora.Bitacora();
                bitacora.GuardarLog("ControladorAdministrativo.GetRanking" + ex.Message);
            }
            return listaExamenesDTO;
        }
        /// <summary>
        /// Devuelve todos los logs
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Log> getLogs()
        {
            IBitacora bitacora = new Bitacora.Bitacora();
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
        public static void GuardarUsuario(string usuarioNombre, string contrasenia)
        {
            var usr = Autenticador.ConstruirUsuario(usuarioNombre, contrasenia);
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        UoW.RepositorioUsuarios.Add(usr);
                        UoW.Complete();
                    }
                }

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                throw new UsrYaExisteException(String.Format("{0} Ya existe en la bd", usr));
            }

        }
        /// <summary>
        /// Obtiene un usuario de la base de datos
        /// </summary>
        /// <exception cref="UsrNoEncontradoException"> Si el usuario no existe</exception>
        /// <param name="pUsuario"></param>
        /// <returns></returns>
        public static UsuarioDTO GetUsuario(String pUsuario)
        {
            return new UsuarioDTO(Autenticador.GetUsuario(pUsuario));
        }
        /// <summary>
        /// Devuelve un UsuarioDTO con los datos actualizados desde la BD
        /// </summary>
        /// <exception cref="UsrNoEncontradoException"> Si el usuario no existe</exception>
        /// <param name="pUsuario"></param>
        /// <param name="pContrasenia"></param>
        /// <returns></returns>
        public static UsuarioDTO AutenticarUsuario(String pUsuario, String pContrasenia)
        {
            var usr = Autenticador.ConstruirUsuario(pUsuario, pContrasenia);
            return new UsuarioDTO(Autenticador.AutenticarUsuario(usr));
        }
    }
}
