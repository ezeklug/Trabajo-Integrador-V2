﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Trabajo_Integrador.DTO
{
    public class ConjuntoPreguntasDTO
    {
        public float TiempoEsperadoRespuesta { get; set; }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ConjuntoPreguntasDTO(string pNombre, float pTiempoEsperadoRespuesta)
        {
            Nombre = pNombre;
            TiempoEsperadoRespuesta = pTiempoEsperadoRespuesta;
        }
        public ConjuntoPreguntasDTO(string pNombre)
        {
            Nombre = pNombre;
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
            this.Nombre = conjuntoPreguntas.Nombre;
        }
    }
}