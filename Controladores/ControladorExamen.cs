using System.Collections.Generic;
using System.Linq;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.DTO;
using Trabajo_Integrador.EntityFramework;

namespace Trabajo_Integrador.Controladores
{
    public static class ControladorExamen
    {


        /// <summary>
        /// Asocia un examen con la clase de asociacion.
        /// </summary>
        /// <param name="pExamen"></param>
        /// <param name="pPregunta"></param>
        private static Examen AsociarExamenPregunta(Examen pExamen, IEnumerable<Pregunta> pPreguntas)
        {
            pExamen.ExamenPreguntas = new List<ExamenPregunta>();
            foreach (var pregunta in pPreguntas)
            {
                var examenPregunta = new ExamenPregunta();
                examenPregunta.PreguntaId = pregunta.Id;
                pExamen.ExamenPreguntas.Add(examenPregunta);
            }
            return pExamen;
        }

        /// <summary>
        /// Crea un nuevo examen no asociado a un usuario
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        public static Examen InicializarExamen(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            var preguntas = ControladorPreguntas.GetPreguntasRandom(pCantidad, pConjunto, pCategoria, pDificultad);
            Examen examen = new Examen();
            examen = ControladorExamen.AsociarExamenPregunta(examen, preguntas);
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    var conjunto = UoW.RepositorioConjuntoPregunta.ObtenerConjuntoPorDificultadYCategoria(pConjunto, pDificultad, pCategoria);
                    examen.TiempoLimite = (float)examen.CantidadPreguntas * conjunto.TiempoEsperadoRespuesta;

                }
            }
            return examen;
        }


        /// <summary>
        /// Guarda el resultado de un examen para una pregunta y su respuesta
        /// Almacena el resultado de la respuesta
        /// </summary>
        /// <param name="pExamen"></param>
        /// <param name="pPregunta"></param>
        /// <param name="pRespuesta"></param>
        /// <returns>Examen actualizado</returns>
        public static Examen GuardarRespuesta(Examen pExamen, Pregunta pPregunta, int idRespuesta)
        {
            Examen examen;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    examen = UoW.ExamenRepository.Get(pExamen.Id);
                    examen.ExamenPreguntas.First(e => e.PreguntaId == pPregunta.Id).RespuestaElegidaId = idRespuesta;
                    UoW.Complete();
                }
            }
            return examen;
        }

        public static IEnumerable<PreguntaDTO> GetPreguntasDeExamen(int examenId)
        {
            List<PreguntaDTO> preguntas = new List<PreguntaDTO>();
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    foreach (var examenPregunta in UoW.ExamenRepository.Get(examenId).ExamenPreguntas)
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
        public static Examen FinalizarExamen(ExamenDTO pExamen)
        {
            Examen examen = new Examen(pExamen);
            int n = ControladorExamen.CantidadRespuestasCorrectas(examen);
            double factorDificultad = ControladorExamen.GetFactorDificultad(examen);
            examen.Finalizar(n, factorDificultad);

            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    var ex = UoW.ExamenRepository.Get(examen.Id);
                    ex.Puntaje = examen.Puntaje;
                    ex.TiempoUsado = examen.TiempoUsado;
                    UoW.Complete();
                }
            }
            return examen;

        }

        private static double GetFactorDificultad(Examen examen)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    return UoW.RepositorioPreguntas.Get(examen.ExamenPreguntas.First().PreguntaId).Conjunto.Dificultad.FactorDificultad;
                }
            }
        }

        private static int CantidadRespuestasCorrectas(Examen examen)
        {
            int cantidadRespuestasCorrectas = 0;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    foreach (var examenPregunta in examen.ExamenPreguntas)
                    {
                        if ((examenPregunta.RespuestaElegidaId != 0) &&
                            (UoW.RepositorioPreguntas
                            .Get(examenPregunta.PreguntaId)
                            .Respuestas
                            .First(r => r.Id == examenPregunta.RespuestaElegidaId)
                            .EsCorrecta))
                        {
                            cantidadRespuestasCorrectas += 1;
                        }
                    }
                }
            }
            return cantidadRespuestasCorrectas;
        }

        /// <summary>
        /// Da comienzo a un examen
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <param name="pExamen"></param>
        public static Examen IniciarExamen(string pNombreUsuario, Examen pExamen)
        {
            Examen ex = pExamen;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Usuario usuario = UoW.RepositorioUsuarios.Get(pNombreUsuario);
                    pExamen.UsuarioId = usuario.Id;
                    pExamen.Iniciar();
                    UoW.ExamenRepository.Add(ex);
                }
            }
            return ex;

        }



        /// <summary>
        /// Guarda un examen la base de datos
        /// </summary>
        /// <param name="pExamen"></param>
        public static void GuardarExamen(Examen pExamen)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    UoW.ExamenRepository.Add(pExamen);
                    UoW.Complete();
                }
            }
        }



        public static float GetTiempoLimite(ExamenDTO pExamen)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Examen ex = UoW.ExamenRepository.Get(pExamen.Id);
                    return ex.TiempoLimite;
                }
            }
        }
    }
}
