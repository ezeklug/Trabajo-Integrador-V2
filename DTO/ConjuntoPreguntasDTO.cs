using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.DTO
{
    public class ConjuntoPreguntasDTO
    {
        public float TiempoEsperadoRespuesta { get; set; }

        public string Id { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pDescripcion"></param>
        /// <param name="pTiempoEsperadoRespuesta"></param>
        public ConjuntoPreguntasDTO(string pDescripcion, float pTiempoEsperadoRespuesta)
        {
            Id = pDescripcion;
            TiempoEsperadoRespuesta = pTiempoEsperadoRespuesta;
        }
        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="pDescripcion"></param>
        public ConjuntoPreguntasDTO(string pDescripcion)
        {
            Id = pDescripcion;
            TiempoEsperadoRespuesta = 20;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public ConjuntoPreguntasDTO() { }

        public ConjuntoPreguntasDTO(ConjuntoPreguntas conjuntoPreguntas)
        {
            this.TiempoEsperadoRespuesta = conjuntoPreguntas.TiempoEsperadoRespuesta;
            this.Id = conjuntoPreguntas.Id;
        }
    }
}
