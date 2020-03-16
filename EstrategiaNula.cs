using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Clase que representa la no implementacion de ninguna estrategia.
    /// </summary>
    public sealed class EstrategiaNula:EstrategiaObtenerPreguntas
    {
        public EstrategiaNula() : base("Null")
        {
        }

        public override List<Pregunta> getPreguntas(string pCantidad, string pConjunto,string pDificultad, CategoriaPregunta pCategoria)
        {
            throw new NotImplementedException();
        }
    }
}
