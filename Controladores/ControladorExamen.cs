using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.EntityFramework;
using Trabajo_Integrador.Dominio;
using System.Data.Entity.Migrations;
using Trabajo_Integrador.DTO;

namespace Trabajo_Integrador.Controladores
{
    public class ControladorExamen
    {

        ////Atributos
        ControladorPreguntas iControladorPreguntas;

        /// <summary>
        /// Asocia un examen con la clase de asociacion.
        /// </summary>
        /// <param name="pExamen"></param>
        /// <param name="pPregunta"></param>
        private void AsociarExamenPregunta(Examen pExamen, List<Pregunta> pPreguntas)
        {
            List<ExamenPreguntaDTO> examenPreguntasDTO = new List<ExamenPreguntaDTO>();
            foreach (var pregunta in pPreguntas)
            {
                ExamenPreguntaDTO examenPregunta = new ExamenPreguntaDTO();
                examenPregunta.PreguntaId = pregunta.Id;
                examenPreguntasDTO.Add(examenPregunta);

            }
            pExamen.ExamenPreguntas = examenPreguntasDTO;
        }

        /// <summary>
        /// Crea un nuevo examen no asociado a un usuario
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        public Examen InicializarExamen(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    List<Pregunta> preguntas = iControladorPreguntas.GetPreguntasRandom(pCantidad, pConjunto, pCategoria, pDificultad);
                    Examen examen = new Examen();
                    this.AsociarExamenPregunta(examen, preguntas);
                    examen.TiempoLimite = examen.CantidadPreguntas * UoW.RepositorioConjuntoPregunta.Get(UoW.RepositorioPreguntas.Get(examen.ExamenPreguntas.First().PreguntaId).ConjuntoId).TiempoEsperadoRespuesta;

                    return examen;
                }
            }
        }


        /// <summary>
        /// Dado un examen, una pregunta y una respuesta, devuelve verdadero si la respuesta es correcta.
        /// Almacena el resultado de la respuesta
        /// </summary>
        /// <param name="pExamen"></param>
        /// <param name="pPregunta"></param>
        /// <param name="pRespuesta"></param>
        /// <returns></returns>
        public Boolean RespuestaCorrecta(Examen pExamen, Pregunta pPregunta, int idRespuesta)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Respuesta respuesta = UoW.RepositorioRespuesta.Get(idRespuesta);
                    Pregunta pregunta = UoW.RepositorioPreguntas.Get(pPregunta.Id);
                    respuesta.Pregunta = pregunta;
                    ExamenPreguntaDTO examenPreguntaDTO= pExamen.ExamenPreguntas.Find(e => e.PreguntaId == pPregunta.Id);
                    ExamenPregunta examenPregunta = UoW.RepositorioPreguntasExamenes.Get(examenPreguntaDTO.Id);
                    examenPregunta.RespuestaElegidaId = respuesta.Id;
                    return respuesta.EsCorrecta;
                }
            }
        }

        public List<PreguntaDTO> GetPreguntasDeExamen(int examenId)
        {
            List<PreguntaDTO> preguntas = new List<PreguntaDTO>();
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    foreach(ExamenPreguntaDTO examenPregunta in UoW.ExamenRepository.Get(examenId).ExamenPreguntas)
                    {
                        Pregunta pregunta = UoW.RepositorioPreguntas.Get(examenPregunta.PreguntaId);
                        PreguntaDTO preguntaDTO = new PreguntaDTO(pregunta);
                        preguntas.Add(preguntaDTO);
                    }
                }
            }
            return preguntas;
        }
        /// <summary>
        /// Da fin a un examen y lo guarda en la DB
        /// </summary>
        /// <param name="pExamen"></param>
        public void FinalizarExamen(ExamenDTO pExamen)
        {
            Examen examen = new Examen(pExamen);
            examen.Finalizar();
            this.GuardarExamen(examen);
        }
        /// <summary>
        /// Da comienzo a un examen
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <param name="pExamen"></param>
        public void IniciarExamen(string pNombreUsuario, Examen pExamen)
        {
            Usuario usuario;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {

                    usuario = UoW.RepositorioUsuarios.Get(pNombreUsuario);
                }
            }

            pExamen.UsuarioId = usuario.Id;
            pExamen.Iniciar();
        }
        /// <summary>
        /// Guarda un examen la base de datos
        /// </summary>
        /// <param name="pExamen"></param>
        public void GuardarExamen(Examen pExamen) 
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {

                    /*          foreach (ExamenPreguntaDTO ep in pExamen.ExamenPreguntas)
                              {
                                  ep.Pregunta = UoW.RepositorioPreguntas.Get(ep.Pregunta.Id);
                                  ep.RespuestaElegida = UoW.RepositorioRespuesta.Get(ep.RespuestaElegida.Id);
                              }


                              Usuario usr = UoW.RepositorioUsuarios.Get(pExamen.Usuario.Id);
                              if (usr == null)
                              {
                                  UoW.ExamenRepository.Add(pExamen);
                              }
                              else
                              {
                                  pExamen.Usuario = usr;
                                  UoW.ExamenRepository.Add(pExamen);

                              }
                    */
                    UoW.ExamenRepository.Add(pExamen);
                    UoW.Complete();       
                }
            }
        }
        /// <summary>
        /// Metodo que devuelve el tiempo limite de un examen
        /// </summary>
        /// <param name="unExamen"></param>
        /// <returns></returns>
        public float GetTiempoLimite(ExamenDTO unExamen)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Examen ex =UoW.ExamenRepository.Get(unExamen.Id);
                    return ex.TiempoLimite;
                }
            }
        }
        public ControladorExamen() 
        {
            iControladorPreguntas = new ControladorPreguntas();
        }
    }
}
