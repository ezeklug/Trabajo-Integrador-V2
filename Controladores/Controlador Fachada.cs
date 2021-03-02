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
        /// Devuevlve el ranking de los examenes de un usuario.
        /// </summary>
        /// <param name="pUsuario">Id del usuario</param>
        /// <returns></returns>
        public static IEnumerable<ExamenDTO> GetRanking(String pUsuario)
        {
            var examenesDTO = new List<ExamenDTO>();
            foreach (Examen examen in ControladorAdministrativo.GetRanking(pUsuario))
            {
                examenesDTO.Add(new ExamenDTO(examen));
            }

            return examenesDTO;
        }

        /// <summary>
        /// Devuelve una lista con todos los logs
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Log> getLogs()
        {
            return ControladorAdministrativo.getLogs();
        }
        /// <summary>
        /// Metodo que devuelve una lista de todos los usuarios
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<UsuarioDTO> GetUsuarios()
        {
            var usuarios = new List<UsuarioDTO>();
            foreach (Usuario usuario in ControladorAdministrativo.GetUsuarios())
            {
                usuarios.Add(new UsuarioDTO(usuario));
            }
            return usuarios;
        }

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
        /// Devuelve los nombres de los conjuntos
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<String> GetNombreConjuntos()
        {
            return ControladorAdministrativo.GetNombresConjuntosPreguntas();
        }
        /// <summary>
        /// Guarda un nuevo usuario en la base de datos
        /// </summary>
        /// <exception cref="UsrYaExisteException">Si usuario ya existe</exception> 
        /// <param name="usuarioNombre"></param>
        /// <param name="contrasenia"></param>
        public static void GuardarUsuario(string usuarioNombre, string contrasenia)
        {
            var usr = Autenticador.ConstruirUsuario(usuarioNombre, contrasenia);
            ControladorAdministrativo.GuardarUsuario(usr);
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




        public static CategoriaPregunta DTOACategoriaPregunta(CategoriaPreguntaDTO categoriaPreguntaDTO)
        {
            return new CategoriaPregunta
            {
                Id = categoriaPreguntaDTO.Id,
                iCategoria = categoriaPreguntaDTO.iCategoria,
                ProviderId = categoriaPreguntaDTO.ProviderId,
            };
        }

        public static ConjuntoPreguntas DTOAConjunto(ConjuntoPreguntasDTO conjuntoPreguntasDTO)
        {
            ConjuntoPreguntas c;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    c = UoW.RepositorioConjuntoPregunta.Get(conjuntoPreguntasDTO.Id);
                }
            }
            return c;
        }




        public static Pregunta DTOAPregunta(PreguntaDTO pPreguntaDTO)
        {
            ConjuntoPreguntas conj;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    conj = UoW.RepositorioConjuntoPregunta.Get(pPreguntaDTO.ConjuntoId);
                }
            }

            return new Pregunta
            {
                Id = pPreguntaDTO.Id,
                Conjunto = conj,
            };
        }







        /// <summary>
        /// Devuelve todos los examenes
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ExamenDTO> GetExamenes()
        {
            List<ExamenDTO> examenesDTO = new List<ExamenDTO>();
            foreach (Examen examen in ControladorAdministrativo.GetExamenes())
            {
                examenesDTO.Add(new ExamenDTO(examen));
            }
            return examenesDTO;
        }


        /// <summary>
        /// Modifica el tiempo de un conjunto de preguntas
        /// </summary>
        /// <param name="pNombreConjunto">Conjunto a modificar</param>
        /// <param name="pTiempo">Tiempo por pregunta</param>
        public static void ModificarTiempo(string pNombreConjunto, float pTiempo)
        {
            ControladorAdministrativo.ModificarTiempo(pNombreConjunto, pTiempo);
        }



        /// <summary>
        /// Setea un usuario como  admin
        /// </summary>
        /// <param name="pUsuario">Id del usuario</param>
        public static void SetAdministrador(string pUsuario)
        {
            ControladorAdministrativo.SetAdministrador(pUsuario);
        }


        /// <summary>
        /// Setea un usuario como no admin
        /// </summary>
        /// <param name="pUsuario">Id del usuario</param>
        public static void SetNoAdministrador(string pUsuario)
        {
            ControladorAdministrativo.SetNoAdministrador(pUsuario);
        }

        /// <summary>
        /// Obtiene todas las preguntas de la base de datos
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<PreguntaDTO> GetPreguntas()
        {
            List<PreguntaDTO> preguntasDto = new List<PreguntaDTO>();
            foreach (Pregunta pregunta in ControladorAdministrativo.GetPreguntas())
            {
                preguntasDto.Add(new PreguntaDTO(pregunta));
            }
            return preguntasDto;
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
