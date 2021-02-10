using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Trabajo_Integrador.Dominio
{


    /// <summary>
    /// Clase de asociacion que representa la relacion entre pregunta y examen
    /// </summary>
    public class ExamenPregunta
    {
        public int Id { get; set; }
        
        public string PreguntaId  { get; set; }
        
        public int RespuestaElegidaId { get; set; }


    }
}
