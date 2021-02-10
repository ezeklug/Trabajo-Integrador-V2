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
        private double FactorTiempo { 
            get 
            {
                double factor = TiempoUsado / getPreguntas().Count;

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
        public double Puntaje { get; private set; }
        /// <summary>
        /// Tiempo usado en segundos
        /// </summary>
        public double TiempoUsado { set; get; }
        public DateTime Fecha { get; set; }
        public string UsuarioId {get;set;}
        public int CantidadPreguntas { get { return getPreguntas().Count; } }



        

/*
        public List<Pregunta> getPreguntas() 
        {
            List<Pregunta> ADevoler = new List<Pregunta>();
            foreach (var ep in ExamenPreguntas)
            {
                ADevoler.Add(ep.Pregunta);
            }

            return ADevoler;
        }

*/


        /// <summary>
        /// Devuelve la cantidad de respuestas correctas
        /// </summary>
        /// <returns></returns>
   /*     private int CantidadRespuestasCorrectas() 
        {
            int cont = 0;

            foreach (var ep in ExamenPreguntas)
            {
                if (ep.RespuestaElegida.EsCorrecta)
                {
                    cont++;
                }
            }

            return cont;

        }

        */
        /// <summary>
        /// Calcula el puntaje de un examen
        /// </summary>
        /// <returns></returns>
        private double CalcularPuntaje() 
        {
            int cantidadRespuestasCorrectas = CantidadRespuestasCorrectas();
            return ((double)cantidadRespuestasCorrectas / (double)getPreguntas().Count) * (double)getPreguntas().First().Dificultad.FactorDificultad * (double)FactorTiempo;
        }



        /// <summary>
        /// Da fin a un examen
        /// </summary>
        public void Finalizar()
        {
            TiempoUsado = (DateTime.Now - Fecha).TotalSeconds;
            Puntaje = CalcularPuntaje();
        }


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
