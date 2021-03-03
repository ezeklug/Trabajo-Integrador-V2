using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.Controladores.ObtenerPreguntas
{
    internal class OpentDbParser
    {
        public OpentDbParser()
        {
        }

        /// <summary>
        /// Dada una web response y un conjunto, construye las preguntas
        /// </summary>
        /// <exception cref="FormatException">Si webResponse no tiene formato adecuado</exception>
        /// <param name="webResponse"></param>
        /// <param name="pConjunto"></param>
        /// <returns>Preguntas construidas</returns>
        public IEnumerable<Pregunta> ParseResponse(WebResponse webResponse, ConjuntoPreguntas pConjunto)
        {

            if (((HttpWebResponse)webResponse).StatusCode != HttpStatusCode.OK)
            {
                throw new ArgumentException(String.Format("Error en webResponse. Status code es: {0}", ((HttpWebResponse)webResponse).StatusCode));
            }

            var preguntas = new List<Pregunta>();


            using (Stream responseStream = webResponse.GetResponseStream())
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
                    string nombreDificultad = HttpUtility.HtmlDecode(bResponseItem.difficulty.ToString());
                    var respuestas = new List<Respuesta>();


                    if ((nombreCategoria != pConjunto.Categoria.Id) || (nombreDificultad != pConjunto.Dificultad.Id))
                    {
                        throw new FormatException(String.Format("Recibio otra cosa de la api {0} = {1}, {2} = {3}",
                            nombreCategoria, pConjunto.Categoria.Id, nombreDificultad, pConjunto.Dificultad.Id));
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
            return preguntas;

        }


    }
}
