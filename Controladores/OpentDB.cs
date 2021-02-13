using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Trabajo_Integrador.Controladores.Bitacora;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador
{


    /// <summary>
    /// Clase que obtiene y procesa los datos obtenidos en OpentDb para transformarlos en preguntas
    /// </summary>
    public class OpentDB : EstrategiaObtenerPreguntas
    {


        public OpentDB() : base("OpentDB") { }

        /// <summary>
        /// Metodo para poder obtener preguntas de la pagina de OpentDB
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pDificultad"></param>
        /// <param name="pCategoria"></param>
        /// <returns></returns>
        public override ICollection<Pregunta> getPreguntas(int pCantidad, ConjuntoPreguntas pConjunto)
        {
            {
                List<Pregunta> preguntas = new List<Pregunta>();

                string nombreDificultad = pConjunto.Dificultad.Id;

                /// Es el nombre de la categoria en la fuente
                string providerCategoria = pConjunto.Categoria.ProviderId;

                // Establecimiento del protocolo ssl de transporte
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                CultureInfo provider = new CultureInfo("en-us");
                // Creacion de URL
                var mUrl = CrearURL(pCantidad.ToString(), nombreDificultad, providerCategoria);

                // Se crea el request http
                HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(mUrl);

                try
                {
                    // Se ejecuta la consulta
                    WebResponse mResponse = mRequest.GetResponse();

                    // Se obtiene los datos de respuesta
                    using (Stream responseStream = mResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                        // Se parsea la respuesta y se serializa a JSON a un objeto dynamic
                        dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());

                        // Se iteran cada uno de los resultados.
                        foreach (var bResponseItem in mResponseJSON.results)
                        {
                            // De esta manera se accede a los componentes de cada item
                            string textoPregunta = HttpUtility.HtmlDecode(bResponseItem.question.ToString());
                            string nombreCategoria = bResponseItem.category.ToString();
                            Dificultad dificultad = new Dificultad(HttpUtility.HtmlDecode(bResponseItem.difficulty.ToString()));
                            ICollection<Respuesta> respuestas = new List<Respuesta>();
                            if ((nombreCategoria != pConjunto.Categoria.Id) || (dificultad.Id != pConjunto.Dificultad.Id))
                            {
                                throw new FormatException(String.Format("Recibio otra cosa de la api {0} = {1}, {2} = {3}",
                                    nombreCategoria, pConjunto.Categoria.Id, dificultad.Id, pConjunto.Dificultad.Id));
                            }


                            //Obtiene el texto de la respuesta correcta
                            string textorespuestaCorrecta = HttpUtility.HtmlDecode(bResponseItem.correct_answer.ToString());
                            //Obtiene el texto de las respuestas incorrectas
                            List<string> textoincorrectas = bResponseItem.incorrect_answers.ToObject<List<string>>();

                            //Crea la pregunta
                            Pregunta preg = new Pregunta(textoPregunta, pConjunto);

                            //Crea la respuesta correcta
                            Respuesta respuestaCorrecta = new Respuesta(textorespuestaCorrecta, true);

                            //Añade respuesta correcta a la lista
                            respuestas.Add(respuestaCorrecta);


                            //Por cada respuesta incorrecta, crea una respuesta y la añade a la lista
                            foreach (string tri in textoincorrectas)
                            {
                                Respuesta res = new Respuesta(HttpUtility.HtmlDecode(tri), false);
                                respuestas.Add(res);
                            }

                            // Asocias las respuestas con la pregunta
                            preg.Respuestas = respuestas;

                            //se agrega cada una de las preguntas a la lista
                            preguntas.Add(preg);
                        }
                    }
                }
                catch (WebException ex)
                {
                    var bitacora = new Bitacora();
                    bitacora.GuardarLog(ex.Message);
                }
                return preguntas;
            }
        }
        /// <summary>
        /// Crea la url a partir de los parametros dados.
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pDificultad"></param>
        /// <param name="pCategoria"></param>
        /// <returns></returns>
        public string CrearURL(string pCantidad, string pDificultad, string pCategoria)
        {
            return ("https://opentdb.com/api.php?amount=" + pCantidad + "&category=" + pCategoria + "&difficulty=" + pDificultad + "&type=multiple");
        }
    }
}
