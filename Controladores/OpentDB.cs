using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Globalization;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Clase que obtiene y procesa los datos obtenidos en OpentDb para transformarlos en preguntas
    /// </summary>
    public class OpentDB : EstrategiaObtenerPreguntas
    {


        public OpentDB():base ("OpentDB") {}

        /// <summary>
        /// Metodo para poder obtener preguntas de la pagina de OpentDB
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pDificultad"></param>
        /// <param name="pCategoria"></param>
        /// <returns></returns>
        public override List<Object> getPreguntas(string pCantidad, string pConjunto,string pDificultad, CategoriaPregunta pCategoria)
        {
            {
                //Lista usada para devolver
                //Primer elemento es una lista de preguntas
                //Segundo elemento es una lista de respuestas
                List<Object> aDevolver = new List<Object>();
                List<Pregunta> listaPreguntas = new List<Pregunta>();
                List<Respuesta> Respuestas = new List<Respuesta>();
                aDevolver[0] = listaPreguntas;
                aDevolver[1] = Respuestas;

                // Establecimiento del protocolo ssl de transporte
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                CultureInfo provider = new CultureInfo("en-us");
                // Creacion de URL
                var mUrl =CrearURL(pCantidad,pDificultad,pCategoria.OpentDbId.ToString(provider));

                
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
                            string pregunta = HttpUtility.HtmlDecode(bResponseItem.question.ToString());
                            CategoriaPregunta categoria = new CategoriaPregunta(bResponseItem.category.ToString());
                            Dificultad dificultad = new Dificultad(HttpUtility.HtmlDecode(bResponseItem.difficulty.ToString()));
                            
                            //Obtiene el texto de la respuesta correcta
                            string textorespuestaCorrecta = HttpUtility.HtmlDecode(bResponseItem.correct_answer.ToString());
                            //Obtiene el texto de las respuestas incorrectas
                            List<string> textoincorrectas = bResponseItem.incorrect_answers.ToObject<List<string>>();
                            
                            //Crea la pregunta
                            Pregunta preg = new Pregunta(pregunta, dificultad, categoria, new ConjuntoPreguntas(pConjunto));

                            //Crea la respuesta correcta
                            Respuesta respuestaCorrecta = new Respuesta(textorespuestaCorrecta, preg, true);
                            
                           //Añade respuesta correcta a la lista
                            Respuestas.Add(respuestaCorrecta);


                            //Por cada respuesta incorrecta, crea una respuesta y la añade a la lista
                            foreach (string tri in textoincorrectas)
                            {
                                Respuesta res = new Respuesta(HttpUtility.HtmlDecode(tri), preg, false);
                                Respuestas.Add(res);
                            }


                            
                            //se agrega cada una de las preguntas a la lista
                            listaPreguntas.Add(preg);
                        }           
                    }
                }
                catch (WebException ex)
                {
                    Bitacora.GuardarLog(ex.Message);

             /*       WebResponse mErrorResponse = ex.Response;
                    using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                    {
                        StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                        String mErrorText = mReader.ReadToEnd();
                    }*/
                }
                catch (Exception ex)
                {

                }
                return aDevolver;
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
