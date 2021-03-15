using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Trabajo_Integrador.Controladores.ObtenerPreguntas;
using Trabajo_Integrador.Dominio;

namespace UnitTests
{
    [TestClass]
    public class TestOpentDbEstrategiaObtenerPreguntas
    {
        [TestMethod]
        public void TestDescargarPreguntas_ParametrosInvalidos_DevuelveExcepcion()
        {
            var opentdb = new OpentDbEstrategiaObtenerPreguntas();
            Assert.ThrowsException<ArgumentNullException>(() => opentdb.DescargarPreguntas(0, null));
            Assert.ThrowsException<ArgumentNullException>(() => opentdb.DescargarPreguntas(100, null));

            var dificultad = new Dificultad("easy");
            var categoria = new CategoriaPregunta("Science: Computers", "18");
            var conjuntoExistente = new ConjuntoPreguntas("OpentDb", dificultad, categoria);
            conjuntoExistente.Categoria = null;

            Assert.ThrowsException<ArgumentNullException>(() => opentdb.DescargarPreguntas(0, conjuntoExistente));
            Assert.ThrowsException<ArgumentNullException>(() => opentdb.DescargarPreguntas(100, conjuntoExistente));
            conjuntoExistente.Categoria = categoria;
            conjuntoExistente.Dificultad = null;

            Assert.ThrowsException<ArgumentNullException>(() => opentdb.DescargarPreguntas(0, conjuntoExistente));
            Assert.ThrowsException<ArgumentNullException>(() => opentdb.DescargarPreguntas(100, conjuntoExistente));
        }

        [TestMethod]
        public void TestDescargarPreguntas_CantidadCero_DevuelveListaVacia()
        {
            var opentdb = new OpentDbEstrategiaObtenerPreguntas();
            var dificultad = new Dificultad("easy");
            var categoria = new CategoriaPregunta("Science: Computers", "18");
            var conjuntoExistente = new ConjuntoPreguntas("OpentDb", dificultad, categoria);


            var res = opentdb.DescargarPreguntas(0, conjuntoExistente);
            Assert.IsFalse(res.Any());
        }

        [TestMethod]
        public void TestDescargarPreguntas_ParametrosValidos_DevuelvePreguntas()
        {
            var dificultad = new Dificultad("easy");
            var categoria = new CategoriaPregunta("Science: Computers", "18");
            var conjuntoExistente = new ConjuntoPreguntas("OpentDb", dificultad, categoria);

            var opentdb = new OpentDbEstrategiaObtenerPreguntas();
            var res = opentdb.DescargarPreguntas(10, conjuntoExistente);

            Assert.IsTrue(res.Any());

        }
    }
}
