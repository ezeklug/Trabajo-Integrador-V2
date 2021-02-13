using Trabajo_Integrador.DTO;

namespace Trabajo_Integrador.Dominio
{


    /// <summary>
    /// Clase de asociacion que representa la relacion entre pregunta y examen
    /// </summary>
    public class ExamenPregunta
    {
        public int Id { get; set; }

        public string PreguntaId { get; set; }

        public int RespuestaElegidaId { get; set; }

        public ExamenPregunta(ExamenPreguntaDTO pExamenPreguntaDTO)
        {
            this.Id = pExamenPreguntaDTO.Id;
            this.PreguntaId = pExamenPreguntaDTO.PreguntaId;
            this.RespuestaElegidaId = pExamenPreguntaDTO.RespuestaElegidaId;
        }

        public ExamenPregunta() { }

    }
}
