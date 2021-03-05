using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Controladores.ObtenerPreguntas;

namespace UnitTests
{
    [TestClass]
    public class TestControladorPreguntas
    { 
        [TestMethod]
        public void ObtenerPreguntasDeInternet_AtributosValidos_DevuelveListaDePreguntas()
        {
            string cantidad = "20";
            string conjunto = "OpentDb";
            string categoria = "Sports";
            string dificultad = "easy";
            var count = ControladorPreguntas.ObtenerPreguntasDeInternet(cantidad, conjunto, categoria, dificultad).ToList().Count;
            Assert.IsTrue(count >= 1);
        }

        [TestMethod]
        public void GetCategoriasConMasDeNPreguntas_ConjuntoValido_DevuelveCategorias()
        {
            String nombreConjunto = "OpentDb";
            int cantidadDePreguntas = 35;
            var categorias = ControladorPreguntas.GetCategoriasConMasDeNPreguntas(nombreConjunto, cantidadDePreguntas);
            foreach (var categoria in categorias)
            {
                Assert.IsTrue(ControladorPreguntas.CantidadDePreguntasParaCategoria(categoria.Id) >= cantidadDePreguntas);
            }
        }
    }
}
