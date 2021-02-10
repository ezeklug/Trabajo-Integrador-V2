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
        public virtual string DificultadId { get; set; }
        public virtual string CategoriaId { get; set; }

        public virtual string ConjuntoId { get; set; }



        /// <summary>
        /// Constructor de la pregunta
        /// </summary>
        /// <param name="pPregunta"></param>
        /// <param name="pRespuestaCorrecta"></param>
        /// <param name="pRespuestasIncorrectas"></param>
        /// <param name="pDificultad"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pConjunto"></param>
        public Pregunta(string pPreguntaId, string pDificultadId, string pCategoriaId, string pConjuntoId)
        {
            Id = pPreguntaId;
            DificultadId = pDificultadId;
            CategoriaId = pCategoriaId;
            ConjuntoId = pConjuntoId;
        }

        
        /// <summary>
        /// Constructor
        /// </summary>
        public Pregunta() { }
    }
}
