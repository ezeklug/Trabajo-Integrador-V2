using System.Collections.Generic;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Interface que especifica los metodos para poder obtener preguntas 
    /// </summary>
    public interface IEstrategiaObtenerPreguntas
    {
        IEnumerable<Pregunta> DescargarPreguntas(int pCantidad, ConjuntoPreguntas pConjunto);
    }
}
