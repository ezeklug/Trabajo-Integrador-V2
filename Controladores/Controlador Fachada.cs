using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using Trabajo_Integrador.DTO;
using Trabajo_Integrador.Dominio;
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
            foreach(Examen examen in controladorAdministrativo.GetRanking(pUsuario))
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
        public void InicarExamen(String pNombreUsuario, ExamenDTO pExamen)
        {
            controladorExamen.IniciarExamen(pNombreUsuario, pExamen);
        }


        /// <summary>
        /// Devuelve una lista con todos los logs
        /// </summary>
        /// <returns></returns>
        public List<Log> getLogs()
        {
            return controladorAdministrativo.getLogs();
        }



        /// <summary>
        /// Devuelve la cantidad de preguntas que pertecenientes a una categoria
        /// </summary>
        /// <param name="pIdCategoria">Id de la categoria</param>
        /// <returns>Cantidad</returns>
        public int CantidadDePreguntasParaCategoria(String pIdCategoria)
        {
            return controladorPreguntas.CantidadDePreguntasParaCategoria(pIdCategoria);
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
        public ExamenDTO InicializarExamen(int pCantidad, String pConjunto, string pCategoria, string pDificultad)
        {
            return (new ExamenDTO(controladorExamen.InicializarExamen(pCantidad.ToString(), pConjunto, pCategoria, pDificultad)));
        }


        /// <summary>
        /// Metodo que finaliza un examen y lo guarda en la base de datos
        /// </summary>
        /// <param name="pExamen"></param>
        public void FinalizarExamen(ExamenDTO pExamen)
        {
            controladorExamen.FinalizarExamen(pExamen);
        }

        /// <summary>
        /// Metodo que devuelve una lista de todos los usuarios
        /// </summary>
        /// <returns></returns>
        public List<UsuarioDTO> GetUsuarios()
        {
            List<UsuarioDTO> listaUsuariosDTO = new List<UsuarioDTO>();
            foreach (Usuario usuario in controladorAdministrativo.GetUsuarios())
            {
                listaUsuariosDTO.Add(new UsuarioDTO(usuario));
            }
            return listaUsuariosDTO;
        }

            /// <summary>
            /// Metodo que devuelve todas las categorias cargadas en base de datos
            /// </summary>
            /// <returns></returns>
            public List<CategoriaPreguntaDTO> GetCategorias()
            {
                List<CategoriaPreguntaDTO> listaCategoriaDTO = new List<CategoriaPreguntaDTO>();
                List<CategoriaPregunta> listaCategoriaPreguntas = controladorAdministrativo.GetCategorias();
                foreach (CategoriaPregunta categoria in listaCategoriaPreguntas)
                {
                    listaCategoriaDTO.Add(new CategoriaPreguntaDTO(categoria));
                }
                return listaCategoriaDTO;
            }



        /// <summary>
        /// Devuelve todas las categorias que tengan mas o igual a N preguntas
        /// </summary>
        /// <param name="n">Cantida de preguntas</param>
        /// <returns>Lista de Categorias</returns>
        public List<CategoriaPreguntaDTO> GetCategoriaPreguntasConNPreguntas(int n)
        {
            List<CategoriaPreguntaDTO> listaCategoriaDTO = new List<CategoriaPreguntaDTO>();
            foreach (CategoriaPregunta categoria in controladorPreguntas.GetCategoriasConMasDeNPreguntas(n))
            {
                listaCategoriaDTO.Add(new CategoriaPreguntaDTO(categoria));
            }
            return listaCategoriaDTO;
        }



        /// <summary>
        /// Metodo que devuelve todas los conjuntos de preguntas cargados en base de datos
        /// </summary>
        /// <returns></returns>
        /// 

        public List<ConjuntoPreguntasDTO> GetConjuntoPreguntas()
        {
            List<ConjuntoPreguntasDTO> listaConjuntoPreguntasDTO = new List<ConjuntoPreguntasDTO>();
            
            foreach (ConjuntoPreguntas conjuntoPregunta in controladorAdministrativo.GetConjuntoPreguntas())
            {
                listaConjuntoPreguntasDTO.Add(new ConjuntoPreguntasDTO(conjuntoPregunta));
            }
            return listaConjuntoPreguntasDTO;
        }
        /// <summary>
        /// Metodo que devuelve todas las dificultades cargadas en base de datos
        /// </summary>
        /// <returns></returns>
        public List<DificultadDTO> GetDificultades()
        {
            List<DificultadDTO> listaDificultadDTO = new List<DificultadDTO>();
         
            foreach (Dificultad dificultad in controladorAdministrativo.GetDificultades())
            {
                listaDificultadDTO.Add(new DificultadDTO(dificultad));
            }
            return listaDificultadDTO;
        }
        /// <summary>
        /// Metodo que guarda un usuario en la base de datos de usuarios
        /// </summary>
        /// <param name="usuarioNombre"></param>
        /// <param name="contrasenia"></param>
        public void GuardarUsuario(string usuarioNombre, string contrasenia)
        {
            controladorAdministrativo.GuardarUsuario(usuarioNombre, contrasenia);
        }



        /// <summary>
        /// Chequea si un usuario ya existe en la base de datos
        /// </summary>
        /// <param name="pUsuarioId"></param>
        /// <param name="pContrasenia"></param>
        /// <returns>Verdadero si usuario y contraseña existen </returns>
        public Boolean UsuarioValido(string pUsuarioId, string pContrasenia)
        {
            return controladorAdministrativo.UsuarioValido(pUsuarioId, pContrasenia);
        }

        /// <summary>
        /// Devuleve true si el nombre de usuario ya existe en BD.
        /// </summary>
        /// <param name="pNombreUsuario"></param>
        /// <returns></returns>
        public Boolean UsuarioExiste(string pNombreUsuario)
        {
            return controladorAdministrativo.UsuarioExiste(pNombreUsuario);

        }



        /// <summary>
        /// Chequea si un usuario es administrador
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        public Boolean EsAdministrador(string nombreUsuario)
        {
            return controladorAdministrativo.EsAdministrador(nombreUsuario);
        }

        public CategoriaPregunta DTOACategoriaPregunta(CategoriaPreguntaDTO categoriaPreguntaDTO)
        {
            return new CategoriaPregunta
            {
                Id = categoriaPreguntaDTO.Id,
                iCategoria = categoriaPreguntaDTO.iCategoria,
                OpentDbId = categoriaPreguntaDTO.OpentDbId
            };
        }

        public ConjuntoPreguntas DTOAConjunto(ConjuntoPreguntasDTO conjuntoPreguntasDTO)
        {
            return new ConjuntoPreguntas
            {
                Id = conjuntoPreguntasDTO.Id,
                TiempoEsperadoRespuesta = conjuntoPreguntasDTO.TiempoEsperadoRespuesta
            };
        }

        public Dificultad DTOADificultad(DificultadDTO dificultadDTO)
        {
            return new Dificultad
            {
                Id = dificultadDTO.Id,
                FactorDificultad = dificultadDTO.FactorDificultad
            };
        }
        public Pregunta DTOAPregunta(PreguntaDTO preguntaDTO)
        {
            return new Pregunta
            {

                Categoria = preguntaDTO.Categoria,
                Conjunto = preguntaDTO.Conjunto, //Deberia ser DTOAConjunto(preguntaDTO.Conjunto)
                Dificultad = preguntaDTO.Dificultad,
                Id = preguntaDTO.Id,


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
            public Boolean RespuestaCorrecta(ExamenDTO pExamen, PreguntaDTO pPregunta, int idRespuesta)
        {
            return controladorExamen.RespuestaCorrecta(pExamen, DTOAPregunta(pPregunta), idRespuesta);
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
        public void SetAdministrador(string pUsuario)
        {
            controladorAdministrativo.SetAdministrador(pUsuario);
        }


        /// <summary>
        /// Setea un usuario como no admin
        /// </summary>
        /// <param name="pUsuario">Id del usuario</param>
        public void SetNoAdministrador(string pUsuario)
        {
            controladorAdministrativo.SetNoAdministrador(pUsuario);
        }

        /// <summary>
        /// Obtiene todas las preguntas de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<PreguntaDTO> GetPreguntas()
        {
            List<PreguntaDTO> listaPreguntaDTO = new List<PreguntaDTO>();
            foreach (Pregunta pregunta in controladorAdministrativo.GetPreguntas())
            {
                listaPreguntaDTO.Add(new PreguntaDTO(pregunta));
            }
            return listaPreguntaDTO;
        }

        public List<PreguntaDTO> GetPreguntasRandom(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            List<PreguntaDTO> listaPreguntasRandomDTO = new List<PreguntaDTO>();
            foreach (Pregunta pregunta in controladorPreguntas.GetPreguntasRandom(pCantidad, pConjunto, pCategoria, pDificultad))
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
        public int GetPreguntasOnline(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
             return controladorPreguntas.GetPreguntasOnline(pCantidad, pConjunto, pCategoria, pDificultad);
        }
        /// <summary>
        /// Metodo que sirve para obtener todas las respuestas asociadas a una preguna
        /// </summary>
        /// <param name="pPregunta"></param>
        /// <returns>Una lista de respuestas</returns>
        public List<RespuestaDTO> RespuestasDePregunta(PreguntaDTO pPregunta)
        {
            List<RespuestaDTO> listaRespuestaDTO = new List<RespuestaDTO>();
            foreach(Respuesta respuesta in controladorPreguntas.RespuestasDePregunta(DTOAPregunta(pPregunta)))
            {
                listaRespuestaDTO.Add(new RespuestaDTO(respuesta));
            }
            return listaRespuestaDTO;
        }

    }
}
