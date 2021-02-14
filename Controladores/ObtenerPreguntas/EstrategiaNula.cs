using System;
using System.Collections.Generic;
using System.Net;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.Controladores.ObtenerPreguntas
{
    /// <summary>
    /// Clase que representa la no implementacion de ninguna estrategia.
    /// </summary>
    public sealed class EstrategiaNula : EstrategiaObtenerPreguntas
    {

        public EstrategiaNula() : base("Null")
        {
        }

        public override IEnumerable<Pregunta> ParseResponse(WebResponse webResponse, ConjuntoPreguntas pConjunto)
        {
            throw new NotImplementedException();
        }

        public override WebResponse PeticionAUrl(string pUrl)
        {
            throw new NotImplementedException();
        }
    }
}
