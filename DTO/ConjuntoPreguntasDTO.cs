using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.DTO
{
    public class ConjuntoPreguntasDTO
    {
        public float TiempoEsperadoRespuesta { get; set; }

        public string Id { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pTiempoEsperadoRespuesta"></param>
        public ConjuntoPreguntasDTO(string pId, float pTiempoEsperadoRespuesta)
        {
            Id = pId;
            TiempoEsperadoRespuesta = pTiempoEsperadoRespuesta;
        }
        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="pId"></param>
        public ConjuntoPreguntasDTO(string pId)
        {
            Id = pId;
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
