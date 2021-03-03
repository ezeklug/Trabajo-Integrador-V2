using System.Collections.Generic;
using Trabajo_Integrador.Dominio;
namespace Trabajo_Integrador.DTO
{
    public class PreguntaDTO
    {
        //Propiedades
        public string Id { get; set; }
        public string ConjuntoId { get; set; }
        public string ConjuntoNombre { get; set; }

        public IEnumerable<RespuestaDTO> Respuestas { get; set; }


        public PreguntaDTO(string pPregunta, string pConjuntoId)
        {
            Id = pPregunta;
            ConjuntoId = pConjuntoId;
        }


        private void RespuestasADtos(IEnumerable<Respuesta> pRespuestas)
        {
            var respuestas = new List<RespuestaDTO>();
            foreach (var r in pRespuestas)
            {
                respuestas.Add(new RespuestaDTO(r));
            }
            this.Respuestas = respuestas;
        }


        public PreguntaDTO(Pregunta pregunta)
        {
            this.ConjuntoId = pregunta.Conjunto.Id;
            this.ConjuntoNombre = pregunta.Conjunto.Nombre;
            this.Id = pregunta.Id;
            this.RespuestasADtos(pregunta.Respuestas);
        }


        public PreguntaDTO() { }


    }
}
