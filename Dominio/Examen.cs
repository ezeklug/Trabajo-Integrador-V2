using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Trabajo_Integrador.DTO;


namespace Trabajo_Integrador.Dominio
{
    public class Examen
    {
        public ICollection<ExamenPregunta> ExamenPreguntas { get; set; }
        public int Id { get; set; }

        /// <summary>
        /// Tiempo limite en segundos
        /// </summary>
        [NotMapped]
        public float TiempoLimite { get; set; }
        /// <summary>
        /// Devuelve el factor tiempo para utilizar en el calculo del puntaje
        /// </summary>
        public double FactorTiempo
        {
            get
            {
                double factor = TiempoUsado / CantidadPreguntas;

                if (factor < 5)
                {
                    return 5;
                }
                else if (factor < 20)
                {
                    return 3;
                }
                else return 1;
            }
        }
        /// <summary>
        /// Devuelve el puntaje de un examen
        /// </summary>
        public double Puntaje { get; set; }
        /// <summary>
        /// Tiempo usado en segundos
        /// </summary>
        public double TiempoUsado { set; get; }
        public DateTime Fecha { get; set; }
        public string UsuarioId { get; set; }
        public double CantidadPreguntas { get { return this.ExamenPreguntas.Count; } }

        /// <summary>
        /// Da inicio a un examen
        /// </summary>
        public void Iniciar()
        {
            Fecha = DateTime.Now;
        }


        private void CalcularPuntaje(int pCantidadRespuestasCorrectas, double pFactorDificultad)
        {
            this.Puntaje = pCantidadRespuestasCorrectas / this.CantidadPreguntas * pFactorDificultad * this.FactorTiempo;
        }


        public void Finalizar(int pCantidadRespuestasCorrectas, double pFactorDificultad)
        {
            this.TiempoUsado = (DateTime.Now - this.Fecha).TotalSeconds;
            this.CalcularPuntaje(pCantidadRespuestasCorrectas, pFactorDificultad);
        }




        /// <summary>
        /// Constructor de examen
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// 
        public Examen()
        {

        }

        private static ICollection<ExamenPregunta> DTOaExamenPregunta(IEnumerable<ExamenPreguntaDTO> pExamenPreguntas)
        {
            var dtos = new List<ExamenPregunta>();
            foreach (var ep in pExamenPreguntas)
            {
                dtos.Add(new ExamenPregunta(ep));
            }
            return dtos;
        }


        public Examen(ExamenDTO examenDTO)
        {
            this.Id = examenDTO.Id;
            this.Puntaje = examenDTO.Puntaje;
            this.TiempoLimite = examenDTO.TiempoLimite;
            this.TiempoUsado = examenDTO.TiempoUsado;
            this.UsuarioId = examenDTO.UsuarioId;
            this.ExamenPreguntas = Examen.DTOaExamenPregunta(examenDTO.ExamenPreguntas);
        }

    }
}
