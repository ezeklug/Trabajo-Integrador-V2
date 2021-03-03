using System;
using System.Collections.Generic;
using System.Net;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.Controladores.ObtenerPreguntas
{
    public class OpentDbEstrategiaObtenerPreguntas : EstrategiaObtenerPreguntas
    {
        ///Clase compuesta por 

        private readonly OpentDbCreadorUrl iUrlCreador;
        private readonly OpentDBWebRequester iWebRequester;
        private readonly OpentDbParser iParser;


        /// <summary>
        /// </summary>
        /// <exception cref="WebException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <returns></returns>
        public override IEnumerable<Pregunta> DescargarPreguntas(int pCantidad, ConjuntoPreguntas pConjunto)
        {
            if ((pConjunto == null) ||
                (pConjunto.Categoria == null) ||
                (pConjunto.Dificultad == null) ||
                String.IsNullOrEmpty(pConjunto.Nombre))
            {
                throw new ArgumentNullException();
            }

            if (pCantidad == 0)
            {
                return new List<Pregunta>();
            }
            var url = iUrlCreador.CrearUrl(pCantidad, pConjunto);
            var response = iWebRequester.PeticionAUrl(url);
            return iParser.ParseResponse(response, pConjunto);
        }


        public OpentDbEstrategiaObtenerPreguntas() : base("OpentDb")
        {
            this.iUrlCreador = new OpentDbCreadorUrl();
            this.iWebRequester = new OpentDBWebRequester();
            this.iParser = new OpentDbParser();
        }
    }
}
