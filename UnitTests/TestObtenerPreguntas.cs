using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Controladores.ObtenerPreguntas;
using Trabajo_Integrador.Dominio;

namespace UnitTests
{
    [TestClass]
    public class TestObtenerPreguntas
    {
        /// Deberiamos testear funcionalidades internas como la clase OpentDbCreadorUrl? En parte ya esta siendo 
        /// testeado por TestObtenerPreguntasOpentDb

        [TestMethod]
        public void TestObtenerPreguntasOpentDb()
        {
            IEstrategiaObtenerPreguntas opentDb = new OpentDbEstrategiaObtenerPreguntas();
            var conjuntoVacio = new ConjuntoPreguntas();

            Assert.ThrowsException<ArgumentNullException>(() =>
                        opentDb.DescargarPreguntas(0, conjuntoVacio));
            Assert.ThrowsException<ArgumentNullException>(() =>
                        opentDb.DescargarPreguntas(10, conjuntoVacio));


            var dificultad = new Dificultad("easy");
            var categoria = new CategoriaPregunta("Science: Computers", "18");
            var conjuntoExistente = new ConjuntoPreguntas("OpentDb", dificultad, categoria);

            var preguntas = opentDb.DescargarPreguntas(0, conjuntoExistente);
            Assert.IsFalse(preguntas.Any());

            preguntas = opentDb.DescargarPreguntas(10, conjuntoExistente);
            Assert.IsTrue(preguntas.ToList().Count > 1);
        }

        [TestMethod]
        public void TestObtenerEstrategia()
        {
            var estrategiaExistente = ControladorPreguntas.GetEstrategia("OpentDb");
            Assert.IsInstanceOfType(estrategiaExistente, typeof(OpentDbEstrategiaObtenerPreguntas));

            var estrategiaNula = ControladorPreguntas.GetEstrategia("EstrategiaQueNoExiste");
            Assert.IsInstanceOfType(estrategiaNula, typeof(EstrategiaNula));

            estrategiaNula = ControladorPreguntas.GetEstrategia("");
            Assert.IsInstanceOfType(estrategiaNula, typeof(EstrategiaNula));
        }


        [TestMethod]
        public void TestOpentDbParser()
        {
            // El "camino feliz" es testeado en TestObtenerPreguntasOpentDb
            var parser = new OpentDbParser();
            var httpRequestBueno = (WebRequest.CreateHttp("http://google.com")).GetResponse();
            Assert.ThrowsException<JsonReaderException>(() => parser.ParseResponse(httpRequestBueno, new ConjuntoPreguntas()));
        }


    }

}
