using System.Collections.Generic;
using System.Net;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.Controladores.ObtenerPreguntas
{
    /// <summary>
    /// Clase abstracta que brinda metodo abstracto para cualquier implementacion de seleccion de preguntas.
    /// </summary>
    public abstract class EstrategiaObtenerPreguntas : IEstrategiaObtenerPreguntas
    {
        //atributos
        string iConjunto;

        public ICreadorUrl iCreadorUrl { get; set; }



        public EstrategiaObtenerPreguntas(string pNombre)
        {
            iConjunto = pNombre;
        }
        public string Conjunto
        {
            get { return this.iConjunto; }
            set { this.iConjunto = value; }
        }

        public string GetUrl(int pCantidad, ConjuntoPreguntas pConjunto)
        {
            return iCreadorUrl.CrearUrl(pCantidad, pConjunto);
        }

        public abstract WebResponse PeticionAUrl(string pUrl);

        public abstract IEnumerable<Pregunta> ParseResponse(WebResponse webResponse, ConjuntoPreguntas pConjunto);

        public IEnumerable<Pregunta> DescargarPreguntas(int pCantidad, ConjuntoPreguntas pConjunto)
        {
            var url = this.GetUrl(pCantidad, pConjunto);
            var response = this.PeticionAUrl(url);
            return this.ParseResponse(response, pConjunto);
        }

        public EstrategiaObtenerPreguntas(string pConjunto, ICreadorUrl pCreador)
        {
            iConjunto = pConjunto;
            iCreadorUrl = pCreador;
        }
    }
}
