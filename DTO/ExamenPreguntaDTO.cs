using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.DTO
{
    public class ExamenPreguntaDTO
    {
        public int Id { get; set; }

        public string PreguntaId { get; set; }

        public int RespuestaElegidaId { get; set; }
    }
}
