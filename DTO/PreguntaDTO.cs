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
        public virtual string DificultadId { get; set; }
        public virtual string CategoriaId { get; set; }

        public virtual string ConjuntoId { get; set; }



        /// <summary>
        /// Constructor de la pregunta
        /// </summary>
        /// <param name="pPregunta"></param>
        /// <param name="pDificultad"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pConjunto"></param>
        public PreguntaDTO(string pPregunta, string pDificultadId, string pCategoriaId, string pConjuntoId)
        {
            Id = pPregunta;
            DificultadId = pDificultadId;
            CategoriaId = pCategoriaId;
            ConjuntoId = pConjuntoId;
        }

        public PreguntaDTO(Pregunta pregunta)
        {
            this.DificultadId = pregunta.DificultadId;
            this.ConjuntoId = pregunta.ConjuntoId;
            this.CategoriaId = pregunta.CategoriaId;
            this.Id = pregunta.Id;

        }

        /// <summary>
        /// Constructor
        /// </summary>
        public PreguntaDTO() { }

        
    }
}
    

