using System;
using System.Collections.Generic;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.DTO
{
    public class ExamenDTO
    {
        public IEnumerable<ExamenPreguntaDTO> ExamenPreguntas { get; set; }
        public int Id { get; set; }
        public float TiempoLimite { get; set; }
        public double Puntaje { get; set; }
        public double TiempoUsado { get; set; }
        public DateTime Fecha { get; set; }
        public string UsuarioId { get; set; }
        public double CantidadPreguntas { get; set; }

        private static IEnumerable<ExamenPreguntaDTO> ExamenPreguntaADto(IEnumerable<ExamenPregunta> pEp)
        {
            var epDto = new List<ExamenPreguntaDTO>();

            foreach (var ep in pEp)
            {
                epDto.Add(new ExamenPreguntaDTO(ep));
            }
            return epDto;
        }

        public ExamenDTO(Examen examen)
        {
            this.ExamenPreguntas = ExamenDTO.ExamenPreguntaADto(examen.ExamenPreguntas);
            this.Id = examen.Id;
            this.TiempoLimite = examen.TiempoLimite;
            this.Puntaje = examen.Puntaje;
            this.TiempoUsado = examen.TiempoUsado;
            this.Fecha = examen.Fecha;
            this.UsuarioId = examen.UsuarioId;
            this.CantidadPreguntas = examen.CantidadPreguntas;
        }
    }
}
