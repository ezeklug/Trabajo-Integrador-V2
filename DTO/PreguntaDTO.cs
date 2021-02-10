using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.DTO
{
   public class PreguntaDTO
    {
        //Propiedades
        public string Id { get; set; }
        public virtual Dificultad Dificultad { get; set; }
        public virtual CategoriaPregunta Categoria { get; set; }

        public virtual ConjuntoPreguntas Conjunto { get; set; }



        /// <summary>
        /// Constructor de la pregunta
        /// </summary>
        /// <param name="pPregunta"></param>
        /// <param name="pDificultad"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pConjunto"></param>
        public PreguntaDTO(string pPregunta, Dificultad pDificultad, CategoriaPregunta pCategoria, ConjuntoPreguntas pConjunto)
        {
            Id = pPregunta;
            Dificultad = pDificultad;
            Categoria = pCategoria;
            Conjunto = pConjunto;
        }

        public PreguntaDTO(Pregunta pregunta)
        {
            this.Dificultad = pregunta.Dificultad;
            this.Conjunto = pregunta.Conjunto;
            this.Categoria = new CategoriaPregunta(pregunta.Categoria);
            this.Id = pregunta.Id;

        }

        /// <summary>
        /// Constructor
        /// </summary>
        public PreguntaDTO() { }

        
    }
}
    

