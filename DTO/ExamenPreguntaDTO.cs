using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.DTO
{
    public class ExamenPreguntaDTO
    {
        public int Id { get; set; }

        public string PreguntaId { get; set; }

        public int RespuestaElegidaId { get; set; }

        public ExamenPreguntaDTO(ExamenPregunta pExamenPregunta)
        {
            this.Id = pExamenPregunta.Id;
            this.PreguntaId = pExamenPregunta.PreguntaId;
            this.RespuestaElegidaId = pExamenPregunta.RespuestaElegidaId;
        }
    }
}
