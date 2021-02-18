using System;
using System.Collections.Generic;
using System.Net;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.Controladores.ObtenerPreguntas
{
    class OpentDbEstrategiaObtenerPreguntas : EstrategiaObtenerPreguntas
    {
        ///Clase compuesta por 

        private readonly OpentDbCreadorUrl iUrlCreador;
        private readonly OpentDBWebRequester iWebRequester;
        private readonly OpentDbParser iParser;


        /// <summary>
        /// </summary>
        /// <exception cref="WebException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <returns></returns>
        public override IEnumerable<Pregunta> DescargarPreguntas(int pCantidad, ConjuntoPreguntas pConjunto)
        {
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
