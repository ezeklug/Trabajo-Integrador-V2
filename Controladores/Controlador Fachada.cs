using System;
using System.Collections.Generic;
using Trabajo_Integrador.Controladores.Bitacora;
using Trabajo_Integrador.Controladores.Excepciones;
using Trabajo_Integrador.Controladores.Utils;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.DTO;
using Trabajo_Integrador.EntityFramework;

namespace Trabajo_Integrador.Controladores
{
    public static class ControladorFachada
    {


        /// <summary>
        /// Devuelve todas las DTOcategorias relacionadas a un conjunto
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CategoriaPreguntaDTO> GetCategorias(String pNombre)
        {
            ICollection<CategoriaPregunta> categorias;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    categorias = UoW.RepositorioConjuntoPregunta.CategoriasDeUnConjunto(pNombre);
                }
            }

            var dtos = new CategoriaPreguntaDTO[categorias.Count];
            int i = 0;
            foreach (var cat in categorias)
            {
                dtos[i] = new CategoriaPreguntaDTO(cat);
            }
            return dtos;
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
