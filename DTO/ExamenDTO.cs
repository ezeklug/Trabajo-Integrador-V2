using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.DTO
{
   public class ExamenDTO
    {
        public List<ExamenPreguntaDTO> ExamenPreguntas { get; set; }
        public int Id { get; set; }
        public float TiempoLimite { get; set; }
        public double Puntaje { get; set; }
        public double TiempoUsado { get; set; }
        public DateTime Fecha { get; set; }
        public string UsuarioId { get; set; }
        public int CantidadPreguntas { get; set; }
        
        public ExamenDTO() { }
        public ExamenDTO(List<ExamenPreguntaDTO> pExamenPreguntas, int pId, 
            float pTiempoLimite, double pPuntaje, double pTiempoUsado, 
            DateTime pFecha, string pUsuarioId, int pCantidadPreguntas)
        {
            this.ExamenPreguntas = pExamenPreguntas;
            this.Id = pId;
            this.TiempoLimite = pTiempoLimite;
            this.Puntaje = pPuntaje;
            this.TiempoUsado = pTiempoUsado;
            this.Fecha = pFecha;
            this.UsuarioId = pUsuarioId;
            this.CantidadPreguntas = pCantidadPreguntas;
        }

        public ExamenDTO(Examen examen)
        {
            this.ExamenPreguntas = examen.ExamenPreguntas;
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
