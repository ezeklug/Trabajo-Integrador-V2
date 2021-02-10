using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Interface que especifica los metodos para poder obtener preguntas 
    /// </summary>
    public interface IEstrategiaObtenerPreguntas
    {
       ICollection<Pregunta> getPreguntas(int pCantidad, ConjuntoPreguntas pConjunto);
    }
}