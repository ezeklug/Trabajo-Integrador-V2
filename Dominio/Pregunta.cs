using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador
{
    public class Pregunta
    {

        public string Id { get; set; }
        public ConjuntoPreguntas Conjunto { get; set; }

        public ICollection<Respuesta> Respuestas { get; set; }

    
        public Pregunta(string pPregunta, ConjuntoPreguntas pConjunto)
        {
            Id = pPregunta;
            Conjunto = pConjunto;
        }


        public Pregunta() { }
    }
}
