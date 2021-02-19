using System.Collections.Generic;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.Controladores.ObtenerPreguntas
{
    /// <summary>
    /// Clase abstracta que brinda metodo abstracto para cualquier implementacion de seleccion de preguntas.
    /// </summary>
    public abstract class EstrategiaObtenerPreguntas : IEstrategiaObtenerPreguntas
    {
        string iConjunto;


        public EstrategiaObtenerPreguntas(string pNombre)
        {
            iConjunto = pNombre;
        }
        public string Conjunto
        {
            get { return this.iConjunto; }
            set { this.iConjunto = value; }
        }

        public abstract IEnumerable<Pregunta> DescargarPreguntas(int pCantidad, ConjuntoPreguntas pConjunto);
    }
}
