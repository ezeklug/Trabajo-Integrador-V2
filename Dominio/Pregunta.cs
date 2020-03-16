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

        public string RespuestaCorrecta { get; set; }
        public string RespuestaIncorrecta1 { get; set; }
        public string RespuestaIncorrecta2 { get; set; }
        public string RespuestaIncorrecta3 { get; set; }



        /// <summary>
        /// Constructor de la pregunta
        /// </summary>
        /// <param name="pPregunta"></param>
        /// <param name="pRespuestaCorrecta"></param>
        /// <param name="pRespuestasIncorrectas"></param>
        /// <param name="pDificultad"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pConjunto"></param>
        public Pregunta(string pPregunta,string pRespuestaCorrecta,List<string> pRespuestasIncorrectas,Dificultad pDificultad,CategoriaPregunta pCategoria, ConjuntoPreguntas pConjunto)
        {
            Id = pPregunta;
            RespuestaCorrecta = pRespuestaCorrecta;
            Dificultad = pDificultad;
            Categoria = pCategoria;
            Conjunto = pConjunto;
            RespuestaIncorrecta1 = pRespuestasIncorrectas[0];
            RespuestaIncorrecta2 = pRespuestasIncorrectas[1];
            RespuestaIncorrecta3 = pRespuestasIncorrectas[2];
        }

        /// <summary>
        /// Chequea si una respuesta es corretcta
        /// Devuelve verdado si las string coinciden
        /// </summary>
        /// <param name="respuesta"></param>
        /// <returns></returns>
        public Boolean RespuestaEsCorrecta(string respuesta)
        {
            if (respuesta == RespuestaCorrecta)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public Pregunta() { }
    }
}
