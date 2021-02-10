using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.DTO
{
    public class PreguntaDTO
    {
        //Propiedades
        public string Id { get; set; }

        public virtual int ConjuntoId { get; set; }



        /// <summary>
        /// Constructor de la pregunta
        /// </summary>
        /// <param name="pPregunta"></param>
        /// <param name="pDificultad"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pConjunto"></param>
        public PreguntaDTO(string pPregunta,  int pConjuntoId)
        {
            Id = pPregunta;
            ConjuntoId = pConjuntoId;
        }

        public PreguntaDTO(Pregunta pregunta)
        {
            this.ConjuntoId = pregunta.Conjunto.Id;
            this.Id = pregunta.Id;

        }

        /// <summary>
        /// Constructor
        /// </summary>
        public PreguntaDTO() { }

        
    }
}
    

