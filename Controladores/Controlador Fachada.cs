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
    public class ControladorFachada
    {
        ///Atributos
        ControladorExamen controladorExamen;
        ControladorAdministrativo controladorAdministrativo;
        ControladorPreguntas controladorPreguntas;


        public ControladorFachada()
        {
            controladorAdministrativo = new ControladorAdministrativo();
            controladorExamen = new ControladorExamen();
            controladorPreguntas = new ControladorPreguntas();
        }


        /// <summary>
        /// Devuevlve el ranking de los examenes de un usuario.
        /// </summary>
        /// <param name="pUsuario">Id del usuario</param>
        /// <returns></returns>
        public List<ExamenDTO> GetRanking(String pUsuario)
        {
            List<ExamenDTO> listaExamenes = new List<ExamenDTO>();
            foreach (Examen examen in controladorAdministrativo.GetRanking(pUsuario))
            {
                listaExamenes.Add(new ExamenDTO(examen));
            }

            return listaExamenes;
        }


        /// <summary>
        /// Obtiene el tiempo limite que está asociado a un examen
        /// </summary>
        /// <param name="unExamen"></param>
        /// <returns></returns>
        public float GetTiempoLimite(ExamenDTO unExamen)
        {
            return controladorExamen.GetTiempoLimite(unExamen);
        }




        /// <summary>
        /// Da comienzo a un examen. Asocia el examen a un usuario
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <param name="pExamen"></param>
        public static ExamenDTO InicarExamen(String pNombreUsuario, ExamenDTO pExamen)
        {
            Examen examen = new Examen(pExamen);
            ExamenDTO dto = new ExamenDTO(ControladorExamen.IniciarExamen(pNombreUsuario, examen));
            return dto;
        }

        internal static IEnumerable<PreguntaDTO> GetPreguntasDeExamen(int examenId)
        {
            return ControladorExamen.GetPreguntasDeExamen(examenId);
        }


        /// <summary>
        /// Devuelve una lista con todos los logs
        /// </summary>
        /// <returns></returns>
        public List<Log> getLogs()
        {
            return (List<Log>)controladorAdministrativo.getLogs();
        }



        /// <summary>
        /// Devuelve la cantidad de preguntas que pertecenientes a una categoria
        /// </summary>
        /// <param name="pIdCategoria">Id de la categoria</param>
        /// <returns>Cantidad</returns>
        public static int CantidadDePreguntasParaCategoria(String pIdCategoria)
        {
            return ControladorPreguntas.CantidadDePreguntasParaCategoria(pIdCategoria);
        }

        /// <summary>
        /// Metodo que crea un examen sin asociarlo a un usuario
        /// </summary>
        /// <param name="pCantidad">Cantidad de preguntas</param>
        /// <param name="pConjunto">OpentDb</param>
        /// <param name="pCategoria">Id Categoria</param>
        /// <param name="pDificultad">Id Dificultad</param>
        /// <returns></returns>
        /// 
        public static ExamenDTO InicializarExamen(int pCantidad, String pConjunto, string pCategoria, string pDificultad)
        {
            return (new ExamenDTO(ControladorExamen.InicializarExamen(pCantidad.ToString(), pConjunto, pCategoria, pDificultad)));
        }


        /// <summary>
        /// Metodo que finaliza un examen y lo guarda en la base de datos
        /// </summary>
        /// <param name="pExamen"></param>
        public static void FinalizarExamen(ExamenDTO pExamen)
        {
            ControladorExamen.FinalizarExamen(pExamen);
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
        /// Devuelve todas las categorias que tengan mas o igual a N preguntas
        /// </summary>
        /// <param name="n">Cantida de preguntas</param>
        /// <returns>Lista de Categorias</returns>
        public static IEnumerable<CategoriaPreguntaDTO> GetCategoriaPreguntasConNPreguntas(String pNombreConjunto, int n)
        {
            var categoriasDTO = new List<CategoriaPreguntaDTO>();
            foreach (CategoriaPregunta categoria in ControladorPreguntas.GetCategoriasConMasDeNPreguntas(pNombreConjunto, n))
            {
                categoriasDTO.Add(new CategoriaPreguntaDTO(categoria));
            }
            return categoriasDTO;
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
        /// Devuelve todas las difulctades de un conjunto
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DificultadDTO> GetDificultades(String pNombreConjunto)
        {
            var dificultadesDTO = new List<DificultadDTO>();
            foreach (Dificultad dificultad in ControladorPreguntas.GetDificultades(pNombreConjunto))
            {
                dificultadesDTO.Add(new DificultadDTO(dificultad));
            }
            return dificultadesDTO;
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

        public Dificultad DTOADificultad(DificultadDTO dificultadDTO)
        {
            return new Dificultad
            {
                Id = dificultadDTO.Id,
                FactorDificultad = dificultadDTO.FactorDificultad
            };
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
        /// Metodo que determina si una respuesta es correcta o no 
        /// Almacena el resultado de la respuesta
        /// </summary>
        /// <param name="pExamen"></param>
        /// <param name="pPregunta"></param>
        /// <param name="pRespuesta"></param>
        /// <returns></returns>
        public static Boolean RespuestaCorrecta(ExamenDTO pExamen, PreguntaDTO pPregunta, int idRespuesta)
        {
            Examen examen = new Examen(pExamen);
            return ControladorExamen.RespuestaCorrecta(examen, ControladorFachada.DTOAPregunta(pPregunta), idRespuesta);
        }

        /// <summary>
        /// Metodo que permite cargar preguntas desde una pagina de preguntas hacia la base de datos.
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        public void CargarPreguntas(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            controladorAdministrativo.CargarPreguntas(pCantidad, pConjunto, pCategoria, pDificultad);
        }




        /// <summary>
        /// Devuelve todos los examenes
        /// </summary>
        /// <returns></returns>
        public List<ExamenDTO> GetExamenes()
        {
            List<ExamenDTO> listaExamenDTO = new List<ExamenDTO>();
            foreach (Examen examen in controladorAdministrativo.GetExamenes())
            {
                listaExamenDTO.Add(new ExamenDTO(examen));
            }
            return listaExamenDTO;
        }


        /// <summary>
        /// Modifica el tiempo de un conjunto de preguntas
        /// </summary>
        /// <param name="pConjuntoPreguntas">Conjunto a modificar</param>
        /// <param name="pTiempo">Tiempo por pregunta</param>
        public void ModificarTiempo(string pConjuntoPreguntas, float pTiempo)
        {
            controladorAdministrativo.ModificarTiempo(pConjuntoPreguntas, pTiempo);

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

        public List<PreguntaDTO> GetPreguntasRandom(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            List<PreguntaDTO> listaPreguntasRandomDTO = new List<PreguntaDTO>();
            foreach (Pregunta pregunta in ControladorPreguntas.GetPreguntasRandom(pCantidad, pConjunto, pCategoria, pDificultad))
            {
                listaPreguntasRandomDTO.Add(new PreguntaDTO(pregunta));
            }
            return listaPreguntasRandomDTO;
        }


        /// <summary>
        /// Carga preguntas desde un servicio  online a la base de datos
        /// Devuelve el numero de preguntas cargadas con exito
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        public static int GetPreguntasOnline(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            return ControladorPreguntas.GetPreguntasOnline(pCantidad, pConjunto, pCategoria, pDificultad);
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
