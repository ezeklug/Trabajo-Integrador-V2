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
        [TestMethod]
        public void DescargarPreguintas_ConjuntoValido_DevuelveListaDePreguntas()
        {
            IEstrategiaObtenerPreguntas opentDb = new OpentDbEstrategiaObtenerPreguntas();
            var dificultad = new Dificultad("easy");
            var categoria = new CategoriaPregunta("Science: Computers", "18");
            var conjuntoExistente = new ConjuntoPreguntas("OpentDb", dificultad, categoria);
            var preguntasVacio = opentDb.DescargarPreguntas(0, conjuntoExistente);
            var preguntas = opentDb.DescargarPreguntas(10, conjuntoExistente);
            Assert.IsFalse(preguntasVacio.Any());
            Assert.IsTrue(preguntas.ToList().Count > 1);
        }

        [TestMethod]
        public void DescargarPreguintas_ConjuntoInvalido_DevuelveListaDePreguntas()
        {
            IEstrategiaObtenerPreguntas opentDb = new OpentDbEstrategiaObtenerPreguntas();
            var conjuntoVacio = new ConjuntoPreguntas();
            Assert.ThrowsException<ArgumentNullException>(() => opentDb.DescargarPreguntas(0, conjuntoVacio));
            Assert.ThrowsException<ArgumentNullException>(() =>opentDb.DescargarPreguntas(10, conjuntoVacio));
        }

        [TestMethod]
        public void GetEstrategia_EstrategiaValida_DevuelveEstrategia()
        {
            string nombre = "OpentDb";
            var estrategia = ControladorPreguntas.GetEstrategia(nombre);
            Assert.IsInstanceOfType(estrategia, typeof(OpentDbEstrategiaObtenerPreguntas));
        }

        [TestMethod]
        public void GetEstrategia_EstrategiaInvalida_DevuelveEstrategiaNula()
        {
            string nombre = "Google";
            var estrategia = ControladorPreguntas.GetEstrategia(nombre);
            Assert.IsInstanceOfType(estrategia, typeof(EstrategiaNula));
        }
        [TestMethod]
        public void GetEstrategia_EstrategiaVacia_DevuelveEstrategiaNula()
        {
             var estrategia = ControladorPreguntas.GetEstrategia("");
            Assert.IsInstanceOfType(estrategia, typeof(EstrategiaNula));
        }

        [TestMethod]
        public void TestOpentDbParser()
        {
            var parser = new OpentDbParser();
            var httpRequestBueno = (WebRequest.CreateHttp("http://google.com")).GetResponse();
            Assert.ThrowsException<JsonReaderException>(() => parser.ParseResponse(httpRequestBueno, new ConjuntoPreguntas()));
        }
    }
}
