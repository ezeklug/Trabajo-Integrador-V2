using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.DTO;


namespace Trabajo_Integrador.Dominio
{
    public class Examen
    {
        public List<ExamenPreguntaDTO> ExamenPreguntas { get; set; }
        public int Id { get; set; }

        /// <summary>
        /// Tiempo limite en segundos
        /// </summary>
        public float TiempoLimite { get; set; }
        /// <summary>
        /// Devuelve el factor tiempo para utilizar en el calculo del puntaje
        /// </summary>
        public double FactorTiempo { 
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
        public string UsuarioId {get;set;}
        public double CantidadPreguntas { get { return this.ExamenPreguntas.Count; } }

        /// <summary>
        /// Da inicio a un examen
        /// </summary>
        public void Iniciar() 
        {
            Fecha = DateTime.Now;
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

        public Examen(ExamenDTO examenDTO)
        {
            this.Id = examenDTO.Id;
            this.Puntaje = examenDTO.Puntaje;
            this.TiempoLimite = examenDTO.TiempoLimite;
            this.TiempoUsado = examenDTO.TiempoUsado;
            this.UsuarioId = examenDTO.UsuarioId;
        }
      
    }
}
