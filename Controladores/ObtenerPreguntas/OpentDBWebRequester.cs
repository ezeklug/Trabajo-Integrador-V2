using System.Globalization;
using System.Net;

namespace Trabajo_Integrador.Controladores.ObtenerPreguntas
{
    class OpentDBWebRequester
    {
        /// <summary>
        /// Crea una peticion a la url
        /// </summary>
        /// <exception cref="WebException"></exception>
        /// <param name="pUrl"></param>
        /// <returns></returns>
        public WebResponse PeticionAUrl(string pUrl)
        {

            // Establecimiento del protocolo ssl de transporte
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            CultureInfo provider = new CultureInfo("en-us");

            // Se crea el request http
            HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(pUrl);
            try
            {
                WebResponse mResponse = mRequest.GetResponse();
                return mResponse;
            }
            catch (WebException e)
            {
                throw;
            }
        }

    }
}
