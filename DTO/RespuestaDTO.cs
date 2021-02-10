using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.DTO
{
    public class RespuestaDTO
    {

        public int Id { get; set; }
        public string Texto { get; set; }
        public Pregunta Pregunta { get; set; }

        public Boolean EsCorrecta { get; set; }

        public RespuestaDTO(string pTexto, Pregunta pPregunta, Boolean pCorrecta)
        {
            this.Texto = pTexto;
            this.Pregunta = pPregunta;
            this.EsCorrecta = pCorrecta;
        }
        public RespuestaDTO() { }

        public RespuestaDTO(Respuesta respuesta)
        {
            this.Id = respuesta.Id;
            this.Pregunta = respuesta.Pregunta; // deberia ir new PreguntaDTO(respuesta.Pregunta)
            this.Texto = respuesta.Texto;
            this.EsCorrecta = respuesta.EsCorrecta;
        }
    }
}
