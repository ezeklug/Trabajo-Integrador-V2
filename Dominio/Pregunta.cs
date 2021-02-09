using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador
{
    public class Pregunta
    {
        //Propiedades
        public string Id { get; set; }
        public virtual Dificultad Dificultad { get; set; }
        public virtual CategoriaPregunta Categoria { get; set; }
        public virtual ConjuntoPreguntas Conjunto { get; set; }

        public ICollection<Respuesta> Respuestas { get; set; }

        /// <summary>
        /// Constructor de la pregunta
        /// </summary>
        /// <param name="pPregunta"></param>
        /// <param name="pRespuestaCorrecta"></param>
        /// <param name="pRespuestasIncorrectas"></param>
        /// <param name="pDificultad"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pConjunto"></param>
        public Pregunta(string pPregunta,Dificultad pDificultad,CategoriaPregunta pCategoria, ConjuntoPreguntas pConjunto)
        {
            Id = pPregunta;
            Dificultad = pDificultad;
            Categoria = pCategoria;
            Conjunto = pConjunto;
        }

        
        /// <summary>
        /// Constructor
        /// </summary>
        public Pregunta() { }
    }
}
