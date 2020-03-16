using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.EntityFramework;
using Trabajo_Integrador.Dominio;
using System.Data.Entity.Migrations;

namespace Trabajo_Integrador.Controladores
{
    public class ControladorExamen
    {

        ////Atributos
        ///

        ControladorPreguntas iControladorPreguntas;







        /// <summary>
        /// Asocia un examen con la clase de asociacion.
        /// </summary>
        /// <param name="pExamen"></param>
        /// <param name="pPregunta"></param>
        private void AsociarExamenPregunta(Examen pExamen, List<Pregunta> pPreguntas)
        {
            List<ExamenPregunta> examenPreguntas = new List<ExamenPregunta>();
            foreach (var pregunta in pPreguntas)
            {
                ExamenPregunta examenPregunta = new ExamenPregunta();
                examenPregunta.Pregunta = pregunta;
                examenPreguntas.Add(examenPregunta);

            }
            pExamen.ExamenPreguntas = examenPreguntas;
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
            List<Pregunta> preguntas = iControladorPreguntas.GetPreguntasRandom(pCantidad, pConjunto, pCategoria, pDificultad);
            Examen examen = new Examen();
            this.AsociarExamenPregunta(examen, preguntas);

            return examen;
        }

                              
        /// <summary>
        /// Dado un examen, una pregunta y una respuesta, devuelve verdadero si la respuesta es correcta.
        /// Almacena el resultado de la respuesta
        /// </summary>
        /// <param name="pExamen"></param>
        /// <param name="pPregunta"></param>
        /// <param name="pRespuesta"></param>
        /// <returns></returns>
        public Boolean RespuestaCorrecta(Examen pExamen, Pregunta pPregunta, String pRespuesta)
        {
            return pExamen.RespuestaCorrecta(pPregunta, pRespuesta);
        }
        
        /// <summary>
        /// Da fin a un examen y lo guarda en la DB
        /// </summary>
        /// <param name="pExamen"></param>
        public void FinalizarExamen(Examen pExamen)
        {
            pExamen.Finalizar();
            GuardarExamen(pExamen);
        }




        /// <summary>
        /// Da comienzo a un examen
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <param name="pExamen"></param>
        public void IniciarExamen(Usuario pUsuario, Examen pExamen)
        {
            pExamen.Usuario = pUsuario;
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
                    foreach (var ep in pExamen.ExamenPreguntas)
                    {
                        ep.Pregunta = UoW.RepositorioPreguntas.Get(ep.Pregunta.Id);
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

                    UoW.Complete();       
                }
            }
        }
        /// <summary>
        /// Metodo que devuelve el tiempo limite de un examen
        /// </summary>
        /// <param name="unExamen"></param>
        /// <returns></returns>
        public float GetTiempoLimite(Examen unExamen)
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
