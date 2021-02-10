using System;
using System.Collections.Generic;

namespace Trabajo_Integrador.Dominio
{
    /// <summary>
    /// Clase que indica de donde se obtienen las preguntas.
    /// </summary>
    public class ConjuntoPreguntas
    {

        public string Id { get; set; }
        public String Nombre { get; set; }
        public float TiempoEsperadoRespuesta { get; set; }
        public Dificultad Dificultad { get; set; }
        public CategoriaPregunta Categoria { get; set; }
        public ICollection<Pregunta> Preguntas { get; set; }

        public ConjuntoPreguntas(string pNombre, float pTiempoEsperadoRespuesta, Dificultad pDificultad, CategoriaPregunta pCategoria)
        {
            this.Nombre = pNombre;
            this.Dificultad = pDificultad;
            this.Categoria = pCategoria;
            this.TiempoEsperadoRespuesta = pTiempoEsperadoRespuesta;
        }


        public ConjuntoPreguntas(string pNombre, Dificultad pDificultad, CategoriaPregunta pCategoria)
        {
            this.Nombre = pNombre;
            this.Dificultad = pDificultad;
            this.Categoria = pCategoria;
            this.TiempoEsperadoRespuesta = 20;
        }


        public ConjuntoPreguntas() { }

    }
}
