using System;
using System.Collections.Generic;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Clase que representa la no implementacion de ninguna estrategia.
    /// </summary>
    public sealed class EstrategiaNula : EstrategiaObtenerPreguntas
    {

        public EstrategiaNula() : base("Null")
        {
        }

        public override ICollection<Pregunta> getPreguntas(int pCantidad, ConjuntoPreguntas pConjunto)
        {
            throw new NotImplementedException();
        }
    }
}
