﻿using System;
using System.Collections.Generic;
using Trabajo_Integrador.Controladores.Bitacora;
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
        public void InicarExamen(String pNombreUsuario, ExamenDTO pExamen)
        {
            Examen examen = new Examen(pExamen);
            controladorExamen.IniciarExamen(pNombreUsuario, examen);
        }

        internal List<PreguntaDTO> GetPreguntasDeExamen(int examenId)
        {
            return controladorExamen.GetPreguntasDeExamen(examenId);
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
        public Pregunta DTOAPregunta(PreguntaDTO pPreguntaDTO)
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
        public Boolean RespuestaCorrecta(ExamenDTO pExamen, PreguntaDTO pPregunta, int idRespuesta)
        {
            Examen examen = new Examen(pExamen);
            return controladorExamen.RespuestaCorrecta(examen, DTOAPregunta(pPregunta), idRespuesta);
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
