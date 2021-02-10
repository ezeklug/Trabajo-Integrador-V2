using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Clase que indica de donde se obtienen las preguntas.
    /// </summary>
    public class ConjuntoPreguntas
    {

        public int Id { get; set; }
        public String Nombre { get; set; }
        public float TiempoEsperadoRespuesta { get; set; }
        public Dificultad Dificultad { get; set; }
        public CategoriaPregunta Categoria { get; set; }

        public ConjuntoPreguntas(string pNombre, float pTiempoEsperadoRespuesta)
        {
            this.Nombre = pNombre;
            TiempoEsperadoRespuesta = pTiempoEsperadoRespuesta;
        }


        public ConjuntoPreguntas(string pNombre)
        {
            this.Nombre = pNombre;
            TiempoEsperadoRespuesta = 20;
        }
        
        
        public ConjuntoPreguntas() { }

    }
}
